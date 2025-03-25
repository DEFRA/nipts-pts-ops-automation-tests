using Reqnroll.BoDi;
using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Tools;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.CP.Pages
{
    public class WelcomePage : IWelcomePage
    {

        private readonly IObjectContainer _objectContainer;

        public WelcomePage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement pageHeading => _driver.WaitForElement(By.XPath("//h1[contains(text(),'Checks')]"),true);
        private IWebElement iconSearch => _driver.WaitForElement(By.XPath("//a[@href='/checker/document-search']//*[name()='svg']"));
        private IWebElement iconHome => _driver.WaitForElement(By.XPath("//span[normalize-space()='Home']"));
        private IWebElement lnkHeadersChange => _driver.WaitForElement(By.XPath("//a[normalize-space()='Change']"));
        private IWebElement btnBack => _driver.WaitForElement(By.XPath("//a[text()='Back']"));
        private IWebElement pageFooter => _driver.WaitForElement(By.XPath("//div[@class='govuk-width-container']/ul"));
        #endregion

        #region Methods
        public bool IsPageLoaded()
        {
            if (ConfigSetup.BaseConfiguration.TestConfiguration.IsAccessibilityEnabled)
            {
                Cognizant.WCAG.Compliance.Checker.Analyzer.Execute(_driver);
            }

            return pageHeading.Text.Contains("Checks");
        }

        public void FooterSearchButton()
        {
            iconSearch.Click();
        }

        public void HeadersChangeLink()
        {
            lnkHeadersChange.Click();
        }

        public bool IsHeaderChangeLinkDisplayed()
        {
            return lnkHeadersChange.Displayed;
        }

        public void FooterHomeIcon()
        {
            iconHome.Click();
        }
        public bool CheckFooter()
        {
            return pageFooter.Displayed && iconHome.Displayed && iconSearch.Displayed;
        }
        public bool IsBackButtonDisplayed()
        {
            return btnBack.IsVisible();
        }

        public void ClickBackButton()
        {
            btnBack.Click();
        }
        #endregion
    }
}