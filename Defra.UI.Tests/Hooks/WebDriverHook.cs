using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin;
using Capgemini.PowerApps.SpecFlowBindings.Hooks;
using Defra.UI.Framework.Object;
using Defra.UI.Tests.Capabilities;
using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Data.Users;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Reqnroll;
using Reqnroll.BoDi;
using System.Net.Http.Headers;
using System.Reflection;

namespace Defra.UI.Tests.Hooks
{
    [Binding]
    public class WebDriverHook
    {
        public IWebDriver Driver { get; set; }

        private ScenarioContext _scenarioContext;
        private IObjectContainer _objectContainer;
        private IReqnrollOutputHelper _reqnrollOutputHelper;
        private ISignInPage? Signin => _objectContainer.IsRegistered<ISignInPage>() ? _objectContainer.Resolve<ISignInPage>() : null;
        private IEmailSignUpPage? EmailSignUpPage => _objectContainer.IsRegistered<IEmailSignUpPage>() ? _objectContainer.Resolve<IEmailSignUpPage>() : null;
        private IHomePage? HomePage => _objectContainer.IsRegistered<IHomePage>() ? _objectContainer.Resolve<IHomePage>() : null;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;
        private ILandingPage? landingPage => _objectContainer.IsRegistered<ILandingPage>() ? _objectContainer.Resolve<ILandingPage>() : null;
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;
        private string domainName = "team707045.testinator.com";


        private static ExtentReports _extent;
        [ThreadStatic]
        private static ExtentTest _feature;
        [ThreadStatic]
        private static ExtentTest _scenario;

        public WebDriverHook(ScenarioContext context, ObjectContainer objectContainer,
            IReqnrollOutputHelper reqnrollOutputHelper)
        {
            _scenarioContext = context;
            _objectContainer = objectContainer;
            _reqnrollOutputHelper = reqnrollOutputHelper;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _extent = ExtentReportManager.GetInstance();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _feature = _extent.CreateTest<AventStack.ExtentReports.Gherkin.Model.Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario(Order = (int)HookRunOrder.WebDriver)]
        public void BeforeTestScenario()
        {
            Logger.Debug("Starting set Capability");

            var site = new Site();
            site.With(GetDriverOptions());
            Driver = site.WebDriver.Driver;

            if (ConfigSetup.BaseConfiguration.UiFrameworkConfiguration.IsDebug)
            {
                PrintNodeInfo("http://localhost:4444/status");
            }

            _objectContainer.RegisterInstanceAs(Driver);

            if (ConfigSetup.BaseConfiguration.TestConfiguration.IsAccessibilityEnabled)
            {
                var reportPath = Path.Combine($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}", "Accessibility");
                Console.WriteLine(reportPath);
                Cognizant.WCAG.Compliance.Checker.Start.Init(Driver, reportPath, false);
            }

            _scenario = _feature.CreateNode<AventStack.ExtentReports.Gherkin.Model.Scenario>(_scenarioContext.ScenarioInfo.Title);

            if (string.IsNullOrEmpty(AuthData.GGID)|| string.IsNullOrEmpty(AuthData.Secret))
            {
                GGIDCreation();
            }

        }


        [AfterScenario]
        public void AfterScenario()
        {
            bool takeScreenShot = false;
            try
            {
                if (_scenarioContext.TestError != null)
                {
                    takeScreenShot = true;
                    var error = _scenarioContext.TestError;
                    Logger.LogMessage("An error ocurred:" + error.Message);
                    Logger.Debug("It was of type:" + error.GetType().Name);
                }
            }
            catch (Exception ex)
            {
                Logger.Debug("Not able to take screenshot" + ex.Message);
            }
            finally
            {
                if (takeScreenShot)
                {
                    AttachScreenShotToXmlReport();
                }

                CloseBrowsers();

                if (ConfigSetup.BaseConfiguration.TestConfiguration.IsAccessibilityEnabled)
                {
                    Cognizant.WCAG.Compliance.Checker.Reporter.HtmlReport.GenerateByCategory();
                    Cognizant.WCAG.Compliance.Checker.Reporter.HtmlReport.GenerateByGuideline();
                }

                _extent.Flush();
            }
        }

        private void AttachScreenShotToXmlReport()
        {
            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            filePath = Path.Combine(filePath, "TestResults");

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
                Logger.Debug($"{filePath} directory created....");
            }

            var fileTitle = _scenarioContext.ScenarioInfo.Title;
            var fileName = Path.Combine(filePath, $"{fileTitle}_TestFailures_{DateTime.Now:yyyyMMdd_hhss}" + ".png");

            ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile(fileName);

            _reqnrollOutputHelper.AddAttachment(fileName);
            Logger.Debug($"SCREENSHOT {fileName} ");
        }

        private DriverOptions GetDriverOptions()
        {
            return _objectContainer.Resolve<IDriverOptions>().GetDriverOptions();
        }

        public void PrintNodeInfo(string gridIpAddress)
        {
            string endpoint = string.Empty;
            try
            {
                var remoteWebDriver = (RemoteWebDriver)Driver;
                var sessionId = remoteWebDriver.SessionId.ToString();
                gridIpAddress = gridIpAddress.Replace("/wd/hub", "");
                endpoint = $"{gridIpAddress}status";

                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
                var resp = client.GetAsync(new Uri(endpoint)).Result.Content.ReadAsStringAsync().Result;

                Logger.Debug($"Appium node details: {resp}");
            }
            catch (Exception)
            {
                Logger.LogMessage($"Not able to print Node information for {endpoint}, most likely running against manually started appium server.");
            }
        }

        [AfterStep]
        public void AfterStep()
        {
            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            var stepInfo = _scenarioContext.StepContext.StepInfo.Text;
            var screenshotPath = CaptureScreenshot();

            if (_scenarioContext.TestError == null)
            {
                _scenario.CreateNode(new GherkinKeyword(stepType), stepInfo)
                    .Pass("Step passed")
                    .AddScreenCaptureFromPath(screenshotPath);
            }
            else
            {
                _scenario.CreateNode(new GherkinKeyword(stepType), stepInfo)
                         .Fail(_scenarioContext.TestError.Message)
                         .AddScreenCaptureFromPath(screenshotPath);
            }
        }

        private string CaptureScreenshot()
        {
            var screenshotsDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Reports", "Screenshots");

            if (!Directory.Exists(screenshotsDir))
            {
                Directory.CreateDirectory(screenshotsDir);
            }

            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            var filePath = Path.Combine(screenshotsDir, $"{Guid.NewGuid()}.png");
            screenshot.SaveAsFile(filePath);
            return filePath;
        }

        private void CloseBrowsers()
        {
            try
            {
                Driver.Quit();
                Driver.Dispose();
                AfterScenarioHooks.TestCleanup();
            }
            catch { }
        }


        private async Task GGIDCreation()
        {
            Task.Run(async () => await new FetchCodeFromEmail(_scenarioContext)?.DeleteAllMessagesFromInbox(domainName));
            string url = UrlBuilder?.Default().BuildApp();
            _driver?.Navigate().GoToUrl(url);

            landingPage?.EnterPassword();
            
            var emailRef = "petsautomation";

            Signin?.ClickCreateSignInDetailsLink();
            //var date = new Random().Next(0, 100000);
            var date = DateTime.Now.ToString("ddMMyyHHmmss");
            var randomText = date.ToString();

            var emailText = emailRef + randomText;
            var emailAddress = emailText + "@team707045.testinator.com";

            EmailSignUpPage?.EnterEmailAddress(emailAddress);
            Thread.Sleep(3000);
            EmailSignUpPage?.ClickContinueButton();
            
            var code = Task.Run(async() => await new FetchCodeFromEmail(_scenarioContext)?.GetCodeFromEmail(emailText)).Result;
            _scenarioContext.Add("emailText", emailText);
            _scenarioContext.Add("emailAddress", emailAddress);
            _scenarioContext.Add("confirmationCode", code);

            EmailSignUpPage?.EnterConfirmationCode(_scenarioContext.Get<string>("confirmationCode"));
            EmailSignUpPage?.ClickContinueButton();
            EmailSignUpPage?.ClickContinueButton();

            EmailSignUpPage?.EnterFullName("Pets Automation");
            EmailSignUpPage?.ClickContinueButton();

            AuthData.Secret = "G0vernmen+";
            EmailSignUpPage?.EnterThePassword(AuthData.Secret);
            _scenarioContext.Add("Credential", AuthData.Secret);
            EmailSignUpPage?.ClickContinueButton();

            var ggid = EmailSignUpPage?.GetGGID();
            Assert.IsNotEmpty(ggid);
            AuthData.GGID = ggid;
            _scenarioContext.Add("GGID", ggid);            
                       
            EmailSignUpPage?.ClickContinueButton();

            EmailSignUpPage?.ClickContinueButton();
            EmailSignUpPage?.ClickContinueButton();
            EmailSignUpPage?.ClickContinueButton();

            EmailSignUpPage?.SelectIndividualUser();
            EmailSignUpPage?.ClickContinueButton();

            EmailSignUpPage?.EnterFirstAndLastName("Pets", "Automation");
            EmailSignUpPage?.ClickContinueButton();

            EmailSignUpPage?.EnterTelephoneNumber("07639928765");
            EmailSignUpPage?.ClickContinueButton();

            EmailSignUpPage?.EnterPostCode("OX1 1AF");
            EmailSignUpPage?.ClickContinueButton();

            EmailSignUpPage?.SelectAddress();
            EmailSignUpPage?.ClickContinueButton();

            EmailSignUpPage?.EnterMemorableWordAndHint("OpsPetsTesting", "OpsPetsTesting");
            EmailSignUpPage?.ClickContinueButton();
            EmailSignUpPage?.ClickContinueButton();

            Assert.True(HomePage?.IsPageLoaded(), "Apply for a pet travel document not loaded");
            Signin?.IsSignedOut();

        }
    }
}