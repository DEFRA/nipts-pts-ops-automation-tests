using Defra.UI.Tests.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using System.Globalization;
using Reqnroll;

namespace Defra.UI.Tests.Capabilities
{
    public class BrowserStackCapability : IDriverOptions
    {
        private BaseConfiguration _configuration => ConfigSetup.BaseConfiguration;
        private readonly ScenarioContext _scenarioContext;
        private readonly Dictionary<string, object> _capDictionary = [];
        private readonly Dictionary<string, object> _browserstackOptions = [];
        private static readonly string[] _osList = ["WINDOWS", "OS X"];

        private readonly string _target;
        private readonly string _deviceName;
        private readonly string _bs_os_version;
        private readonly string _bs_browser_version;

        public BrowserStackCapability(BaseConfiguration baseConfiguration, ScenarioContext context)
        {
            _scenarioContext = context;
            _target = _configuration.UiFrameworkConfiguration.Target;
            _deviceName = _configuration.TestConfiguration.DeviceName;
            _bs_os_version = _configuration.TestConfiguration.BSOSVersion;
            _bs_browser_version = _configuration.TestConfiguration.BSBrowserVersion;
        }

        public DriverOptions GetDriverOptions(Dictionary<string, string> capDictionary = null)
        {
            // populate common BrowserStack options
            GetBrowserStackConfig();
            GetProjectDriverOptions();
            GetTestNameDriverOptions();

            _browserstackOptions["acceptInsecureCerts"] = true;
            _capDictionary["autoGrantPermission"] = true;

            var deviceUpper = _deviceName?.ToUpperInvariant() ?? string.Empty;
            var browserName = string.IsNullOrWhiteSpace(_target)
                ? "Chrome"
                : CultureInfo.InvariantCulture.TextInfo.ToTitleCase(_target.ToLowerInvariant());

            // Mobile device configuration
            if (deviceUpper.Contains("IPAD") || deviceUpper.Contains("IPHONE"))
            {
                // BrowserStack expects device info in bstack:options but top-level W3C keys should also be set
                _browserstackOptions["deviceName"] = _deviceName;
                if (!string.IsNullOrEmpty(_bs_os_version)) _browserstackOptions["osVersion"] = _bs_os_version;
                _browserstackOptions["realMobile"] = true;

                // Use SafariOptions for iOS runs and set top-level W3C capabilities
                var opts = new SafariOptions();
                AddDictionaryValuesInDriverOptions(opts, _capDictionary);
                opts.AddAdditionalOption("browserName", "Safari");
                opts.AddAdditionalOption("platformName", "iOS");
                // also keep browserstack-specific options nested
                opts.AddAdditionalOption("bstack:options", _browserstackOptions);
                return opts;
            }

            _browserstackOptions.Add("local", "false");

            // choose options based on mobile/desktop target
            DriverOptions driverOptions;
            if (_deviceName.ToUpper().Contains("IPAD") || _deviceName.ToUpper().Contains("IPHONE"))
            {
                driverOptions = new OpenQA.Selenium.Safari.SafariOptions();
            }
            else
            {
                driverOptions = new OpenQA.Selenium.Chrome.ChromeOptions();
            }
            AddDictionaryValuesInDriverOptions(driverOptions, _capDictionary);
            driverOptions.AddAdditionalOption("bstack:options", _browserstackOptions);

            var chromeOpts = new ChromeOptions();
            AddDictionaryValuesInDriverOptions(chromeOpts, _capDictionary);
            chromeOpts.AddAdditionalOption("browserName", browserName);
            chromeOpts.AddAdditionalOption("bstack:options", _browserstackOptions);
            return chromeOpts;
        }

        private void GetBrowserStackConfig()
        {
            if (!_browserstackOptions.ContainsKey("debug"))
            {
                _browserstackOptions.Add("debug", true);
                _browserstackOptions.Add("userName", _configuration.BrowserStackConfiguration.CloudDeviceUserName);
                _browserstackOptions.Add("accessKey", _configuration.BrowserStackConfiguration.CloudDeviceUserKey);
                _browserstackOptions.Add("idleTimeout", 300);
            }

            _capDictionary.Add("acceptSslCerts", "true");
        }

        private void GetProjectDriverOptions()
        {
            if (!_browserstackOptions.ContainsKey("projectName"))
            {
                _browserstackOptions.Add("projectName", ConfigSetup.BaseConfiguration.TestConfiguration.Project);
                _browserstackOptions.Add("buildName", ConfigSetup.BaseConfiguration.TestConfiguration.Build);
            }
        }

        protected virtual void GetTestNameDriverOptions()
        {
            if (!_browserstackOptions.ContainsKey("sessionName"))
            {
                _browserstackOptions.Add("sessionName", TestContext.CurrentContext.Test.ClassName);
            }
        }

        private void AddDictionaryValuesInDriverOptions(DriverOptions driverOptions, Dictionary<string, object> capDictionary)
        {
            if (capDictionary != null)
            {
                foreach (var androidDictionary in capDictionary)
                {
                    driverOptions.AddAdditionalOption(androidDictionary.Key.ToString(), androidDictionary.Value);
                }
            }
        }
    }
}
