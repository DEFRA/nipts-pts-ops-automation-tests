using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin;
using Capgemini.PowerApps.SpecFlowBindings;
using Capgemini.PowerApps.SpecFlowBindings.Hooks;
using Defra.UI.Framework.Object;
using Defra.UI.Tests.Capabilities;
using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Reqnroll;
using Reqnroll.BoDi;
using System.Diagnostics;
using System.Drawing;
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

        /// <summary>
        /// Tracks which browser is currently being driven by the scenario. Scenarios can move between
        /// the AP/CP browser (<see cref="Driver"/>) and the separate Dynamics 365/EasyRepro browser
        /// (<see cref="DynamicsBrowserAccessor"/>) multiple times (e.g. Idcoms steps followed by a
        /// switch back to the Compliance Portal). Once the Dynamics browser has been launched it
        /// stays initiated for the rest of the scenario, so we can't rely on
        /// <see cref="DynamicsBrowserAccessor.IsBrowserInitiated"/> alone to know which browser is
        /// actually in focus for the current step - we also track step text that indicates a switch.
        /// </summary>
        private bool _isDynamicsActive;

        private IFetchCodeFromEmail fetchCodeFromEmail => _objectContainer.IsRegistered<IFetchCodeFromEmail>() ? _objectContainer.Resolve<IFetchCodeFromEmail>() : null;

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
            _isDynamicsActive = false;

            // Marks the very start of this scenario's execution in the log, before any step
            // (including login/email account creation) runs, so the CSV generator can reliably
            // tell this run's data apart from any earlier run of the same scenario in the log file.
            Utils.AppendToLoginLog(("ScenarioStart", DateTime.UtcNow.ToString("O")));

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
                Cognizant.WCAG.Compliance.Checker.Start.Init(Driver, reportPath);
            }

            _scenario = _feature.CreateNode<AventStack.ExtentReports.Gherkin.Model.Scenario>(_scenarioContext.ScenarioInfo.Title);

            GovernmentGateway.Initialize(_objectContainer);

            if (ConfigSetup.BaseConfiguration.TestConfiguration.IsLiveUserAccount)
            {
                GovernmentGateway.Instance.GetUserDetails();
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

                var testResult = _scenarioContext.TestError == null ? "PASSED" : "FAILED";
                Utils.AppendToLoginLog(("*********************TestResult*********************", testResult));
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

                // Regenerate the CSV after every scenario so the file is always up to date even if
                // the run is stopped/cancelled, or individual tests are run/isolated from Test Explorer.
                try
                {
                    Utils.GenerateCsvFromTodayLog();
                }
                catch (Exception ex)
                {
                    Logger.Debug("Not able to generate CSV from the test log " + ex.Message);
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

            var fileTitle = string.Concat(_scenarioContext.ScenarioInfo.Title.Split(Path.GetInvalidFileNameChars()));
            var fileName = Path.Combine(filePath, $"{fileTitle}_TestFailures_{DateTime.Now:yyyyMMdd_hhss}" + ".png");

            CaptureFullPageScreenshot(fileName);

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
            UpdateActiveApplication(stepInfo);
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

        /// <summary>
        /// Captures a full page screenshot of the currently active browser (<see cref="GetActiveDriver"/>)
        /// into a new file in the Reports/Screenshots directory, for attaching to the Extent report.
        /// </summary>
        private string CaptureScreenshot()
        {
            var screenshotsDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Reports", "Screenshots");

            if (!Directory.Exists(screenshotsDir))
            {
                Directory.CreateDirectory(screenshotsDir);
            }

            var filePath = Path.Combine(screenshotsDir, $"{Guid.NewGuid()}.png");
            CaptureFullPageScreenshot(filePath);
            return filePath;
        }

        /// <summary>
        /// Scenarios tagged with @Idcoms (or any scenario that drives Dynamics 365) run against a
        /// separate EasyRepro/Dynamics browser instance (<see cref="DynamicsBrowserAccessor"/>),
        /// distinct from the AP/CP browser created in <see cref="BeforeTestScenario"/>. Screenshots
        /// must be taken from whichever browser is actually active for the current step, otherwise
        /// they capture the wrong application (e.g. still the Dynamics browser after control has
        /// switched back to AP/CP, since the Dynamics browser isn't disposed until the end of the
        /// scenario).
        /// </summary>
        private IWebDriver GetActiveDriver()
        {
            return _isDynamicsActive && DynamicsBrowserAccessor.IsBrowserInitiated ? DynamicsBrowserAccessor.DynamicsDriver : Driver;
        }

        /// <summary>
        /// Inspects the just-executed step's text for recognizable phrases that indicate the scenario
        /// has navigated into (or logged in to) a particular application, and updates
        /// <see cref="_isDynamicsActive"/> accordingly so screenshots are captured from the correct browser.
        /// </summary>
        private void UpdateActiveApplication(string stepInfo)
        {
            if (string.IsNullOrEmpty(stepInfo))
            {
                return;
            }

            var normalizedStep = stepInfo.ToLowerInvariant();

            if (normalizedStep.Contains("dynamics application"))
            {
                _isDynamicsActive = true;
            }
            else if (normalizedStep.Contains("port checker application") ||
                     normalizedStep.Contains("defra application") ||
                     normalizedStep.Contains("pets a travel document url") ||
                     normalizedStep.Contains("back button in pets application") ||
                     normalizedStep.Contains("go back to pets application"))
            {
                _isDynamicsActive = false;
            }
        }

        /// <summary>
        /// JavaScript used to measure the current page and viewport dimensions (in CSS pixels),
        /// used to determine whether a full page screenshot requires scrolling/stitching.
        /// </summary>
        private const string PageDimensionsScript = @"
            return {
                pageWidth: Math.max(
                    document.body.scrollWidth, document.documentElement.scrollWidth,
                    document.body.offsetWidth, document.documentElement.offsetWidth),
                pageHeight: Math.max(
                    document.body.scrollHeight, document.documentElement.scrollHeight,
                    document.body.offsetHeight, document.documentElement.offsetHeight),
                viewportWidth: window.innerWidth,
                viewportHeight: window.innerHeight
            };";

        /// <summary>
        /// Maximum time to wait after scrolling for the page to settle (e.g. lazy-loaded images, sticky
        /// headers repositioning) before taking a screenshot of the new scroll position. In practice
        /// scrolling settles almost immediately, so <see cref="WaitForScrollSettle"/> usually returns
        /// long before this timeout is reached - this is only a safety ceiling for slow pages.
        /// </summary>
        private static readonly TimeSpan ScrollSettleTimeout = TimeSpan.FromMilliseconds(200);

        /// <summary>
        /// How often to poll the current scroll position while waiting for it to settle.
        /// </summary>
        private static readonly TimeSpan ScrollSettlePollInterval = TimeSpan.FromMilliseconds(15);

        /// <summary>
        /// Holds the page and viewport dimensions (in CSS pixels) reported by <see cref="PageDimensionsScript"/>.
        /// </summary>
        private readonly record struct PageDimensions(int PageWidth, int PageHeight, int ViewportWidth, int ViewportHeight)
        {
            public bool PageFitsInViewport => PageHeight <= ViewportHeight && PageWidth <= ViewportWidth;
        }

        /// <summary>
        /// Captures a screenshot of the full page (not just the visible viewport) of the currently
        /// active browser (<see cref="GetActiveDriver"/>) and saves it to <paramref name="filePath"/>.
        /// </summary>
        private void CaptureFullPageScreenshot(string filePath)
        {
            var activeDriver = UnwrapDriver(GetActiveDriver());

            try
            {
                if (activeDriver is not IJavaScriptExecutor jsExecutor)
                {
                    CaptureViewportScreenshot(activeDriver, filePath);
                    return;
                }

                var dimensions = GetPageDimensions(jsExecutor);

                if (dimensions.PageFitsInViewport)
                {
                    // The whole page already fits in the viewport, no need to scroll/stitch.
                    CaptureViewportScreenshot(activeDriver, filePath);
                    return;
                }

                CaptureStitchedFullPageScreenshot(activeDriver, jsExecutor, dimensions, filePath);
            }
            catch (Exception ex)
            {
                Logger.Debug($"Full page screenshot failed, falling back to standard screenshot: {ex.Message}");
                CaptureViewportScreenshot(activeDriver, filePath);
            }
        }

        /// <summary>
        /// Takes a single viewport-sized screenshot of <paramref name="driver"/> and saves it to <paramref name="filePath"/>.
        /// </summary>
        private static void CaptureViewportScreenshot(IWebDriver driver, string filePath)
        {
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(filePath);
        }

        /// <summary>
        /// Reads the current page and viewport dimensions (in CSS pixels) from the browser via <see cref="PageDimensionsScript"/>.
        /// </summary>
        private static PageDimensions GetPageDimensions(IJavaScriptExecutor jsExecutor)
        {
            var dimensions = (Dictionary<string, object>)jsExecutor.ExecuteScript(PageDimensionsScript);

            return new PageDimensions(
                PageWidth: Convert.ToInt32(Convert.ToInt64(dimensions["pageWidth"])),
                PageHeight: Convert.ToInt32(Convert.ToInt64(dimensions["pageHeight"])),
                ViewportWidth: Convert.ToInt32(Convert.ToInt64(dimensions["viewportWidth"])),
                ViewportHeight: Convert.ToInt32(Convert.ToInt64(dimensions["viewportHeight"])));
        }

        /// <summary>
        /// Scrolls through the page in viewport-sized increments, screenshotting each segment and
        /// stitching them together into a single full page image, which is saved to <paramref name="filePath"/>.
        /// </summary>
        private static void CaptureStitchedFullPageScreenshot(IWebDriver driver, IJavaScriptExecutor jsExecutor, PageDimensions dimensions, string filePath)
        {
            jsExecutor.ExecuteScript("window.scrollTo(0, 0);");
            WaitForScrollSettle(jsExecutor);

            // Take an initial screenshot to determine the actual device pixel size of a
            // viewport-sized screenshot. The page dimensions above are reported in CSS pixels by
            // JavaScript, but the screenshot image is captured in physical/device pixels, which
            // differ whenever the OS display scaling (DPI) is not 100% - a very common setup on
            // Windows laptops (e.g. 125%/150% scaling). Deriving the scale factor from the actual
            // screenshot avoids misaligned/clipped stitching on such machines.
            using var firstSegmentBitmap = TakeScreenshotBitmap(driver);
            var scaleX = (double)firstSegmentBitmap.Width / dimensions.ViewportWidth;
            var scaleY = (double)firstSegmentBitmap.Height / dimensions.ViewportHeight;

            var fullBitmapWidth = (int)Math.Ceiling(dimensions.PageWidth * scaleX);
            var fullBitmapHeight = (int)Math.Ceiling(dimensions.PageHeight * scaleY);

            using var fullBitmap = new Bitmap(fullBitmapWidth, fullBitmapHeight);
            using var graphics = Graphics.FromImage(fullBitmap);

            graphics.DrawImage(firstSegmentBitmap, 0, 0);

            var scrollPositionY = dimensions.ViewportHeight;
            while (scrollPositionY < dimensions.PageHeight)
            {
                jsExecutor.ExecuteScript($"window.scrollTo(0, {scrollPositionY});");
                var actualScrollY = WaitForScrollSettle(jsExecutor);

                using var segmentBitmap = TakeScreenshotBitmap(driver);
                graphics.DrawImage(segmentBitmap, 0, (int)Math.Round(actualScrollY * scaleY));

                scrollPositionY += dimensions.ViewportHeight;
            }

            fullBitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
        }

        /// <summary>
        /// Takes a screenshot of <paramref name="driver"/> and returns it as a <see cref="Bitmap"/>.
        /// </summary>
        private static Bitmap TakeScreenshotBitmap(IWebDriver driver)
        {
            var screenshotBytes = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
            return new Bitmap(new MemoryStream(screenshotBytes));
        }

        /// <summary>
        /// Polls the current vertical scroll position until it stops changing between consecutive
        /// reads (i.e. the scroll/any resulting layout shift has settled), or <see cref="ScrollSettleTimeout"/>
        /// is reached, whichever comes first. This is significantly faster than a fixed delay in the
        /// common case where scrolling settles almost immediately, while still tolerating slower pages.
        /// </summary>
        /// <returns>The last observed scroll position.</returns>
        private static int WaitForScrollSettle(IJavaScriptExecutor jsExecutor)
        {
            const string readScrollYScript = "return window.pageYOffset || document.documentElement.scrollTop;";

            var stopwatch = Stopwatch.StartNew();
            var previousScrollY = Convert.ToInt32((long)jsExecutor.ExecuteScript(readScrollYScript));

            while (stopwatch.Elapsed < ScrollSettleTimeout)
            {
                Thread.Sleep(ScrollSettlePollInterval);

                var currentScrollY = Convert.ToInt32((long)jsExecutor.ExecuteScript(readScrollYScript));

                if (currentScrollY == previousScrollY)
                {
                    return currentScrollY;
                }

                previousScrollY = currentScrollY;
            }

            return previousScrollY;
        }

        /// <summary>
        /// Unwraps a driver that implements <see cref="IWrapsDriver"/> (e.g. <see cref="EventFiringWebDriver"/>)
        /// to find the real underlying <see cref="IWebDriver"/> implementation.
        /// </summary>
        private static IWebDriver UnwrapDriver(IWebDriver driver)
        {
            while (driver is IWrapsDriver wrapsDriver && wrapsDriver.WrappedDriver != null && !ReferenceEquals(wrapsDriver.WrappedDriver, driver))
            {
                driver = wrapsDriver.WrappedDriver;
            }

            return driver;
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
