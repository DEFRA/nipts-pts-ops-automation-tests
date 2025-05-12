using Reqnroll.BoDi;
using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.AP.Classes
{
    public class LandingPage : ILandingPage
    {
        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')]"), true);

        private IWebElement txtLoging => _driver.WaitForElement(By.Id("EnteredPassword"));

        private IWebElement btnContinue => _driver.WaitForElement(By.XPath("//button[@type='submit']"));

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public LandingPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public bool IsPageLoaded(string pageName)
        {
            return PageHeading.Text.Contains(pageName);
        }

        public void EnterPassword()
        {
            txtLoging.SendKeys(ConfigSetup.BaseConfiguration.TestConfiguration.EnvAPLogin);
            btnContinue?.Click();
        }

        public void ClickContinueButton()
        {
            btnContinue.Click();
        }

        #endregion Page Methods
    }
}