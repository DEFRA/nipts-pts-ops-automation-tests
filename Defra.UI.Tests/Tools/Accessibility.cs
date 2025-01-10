using Reqnroll.BoDi;
using Defra.UI.Tests.Configuration;
using OpenQA.Selenium;
using Selenium.Axe;
using System.Reflection;

namespace Defra.UI.Tests.Tools
{
    public interface IAccessibility
    {
        public void CreateAccessibilityReport(string pageName);

    }
    public class Accessibility : IAccessibility 
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        public Accessibility(IObjectContainer container)
        {
            _objectContainer = container;
        }

        public void CreateAccessibilityReport(string pageName)
        {
            if (ConfigSetup.BaseConfiguration.TestConfiguration.IsAccessibilityTesting)
            {
                string reportLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string reportFileName = reportLocation + $"\\Accessibiliy_{pageName}.html";
                AxeResult results = _driver.Analyze();
                _driver.CreateAxeHtmlReport(results, reportFileName);
            }
        }
    }
}