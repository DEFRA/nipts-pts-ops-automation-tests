using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin;
using BoDi;
using Capgemini.PowerApps.SpecFlowBindings.Hooks;
using Defra.UI.Framework.Driver;
using Defra.UI.Framework.Object;
using Defra.UI.Tests.Capabilities;
using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Net.Http.Headers;
using System.Reflection;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace Defra.UI.Tests.Hooks
{
    [Binding]
    public class WebDriverHook
    {
        public IWebDriver Driver { get; set; }
        private static string Target => ConfigSetup.BaseConfiguration.UiFrameworkConfiguration.Target;
        private static string SeleniumGrid => ConfigSetup.BaseConfiguration.UiFrameworkConfiguration.SeleniumGrid;

        private ScenarioContext _scenarioContext;
        private readonly object _lock = new object();

        private readonly IObjectContainer _objectContainer;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
        private IFetchCodeFromEmail FetchCodeFromEmail => _objectContainer.IsRegistered<IFetchCodeFromEmail>() ? _objectContainer.Resolve<IFetchCodeFromEmail>() : null;

        private static ExtentReports _extent;
        [ThreadStatic]
        private static ExtentTest _feature;
        [ThreadStatic]
        private static ExtentTest _scenario;

        public WebDriverHook(ScenarioContext context, ObjectContainer container,
            ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _scenarioContext = context;
            _objectContainer = container;
            _specFlowOutputHelper = specFlowOutputHelper;
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

            _scenario = _feature.CreateNode<AventStack.ExtentReports.Gherkin.Model.Scenario>(_scenarioContext.ScenarioInfo.Title);
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

            _specFlowOutputHelper.AddAttachment(fileName);
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
                _scenario
                    .CreateNode(new GherkinKeyword(stepType), stepInfo)
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
    }
}