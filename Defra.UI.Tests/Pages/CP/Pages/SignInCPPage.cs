using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Tools;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using Reqnroll.BoDi;
using SeleniumExtras.WaitHelpers;

namespace Defra.UI.Tests.Pages.CP.Pages
{
    public class SignInCPPage : ISignInCPPage
    {
        private readonly IObjectContainer _objectContainer;

        public SignInCPPage(IObjectContainer container)
        {
            _objectContainer = container;
        }


        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement lnkSignIn => _driver.WaitForElement(By.XPath("//a[contains(text(),'Sign in')]"));
        private IWebElement btnSignIn => _driver.WaitForElement(By.Id("continue"), true);
        private By signInConfirmBy => By.XPath("//h1[contains(@class,'govuk-heading-xl')]");
        private IWebElement UserId => _driver.FindElement(By.CssSelector("#user_id"));
        private IWebElement Password => _driver.FindElement(By.CssSelector("#password"));
        private IWebElement txtLoging => _driver.WaitForElement(By.XPath("//input[@id='password']"));
        private IWebElement btnContinue => _driver.WaitForElement(By.XPath("//button[normalize-space()='Continue']"));
        private IWebElement lblTitle => _driver.WaitForElement(By.XPath("//h1"));
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading']"), true);
        #endregion

        #region Methods
        public bool VerifyHeadings(string heading, string subHeading)
        {
            var applicationTitle = lblTitle.Text.Replace("\r\n", " ").ToUpper();
            return applicationTitle.Contains(subHeading.ToUpper()) && applicationTitle.Contains(heading.ToUpper());
        }

        public bool IsPageLoaded()
        {
            return PageHeading.Text.Contains("Sign in using Government Gateway");
        }

        public void ClickSignInButton()
        {
            lnkSignIn.Click();
        }

        public void SignIn(string userName, string password)
        {
            UserId.SendKeys(userName);
            Password.SendKeys(password);
            _driver.WaitForElementCondition(ExpectedConditions.ElementToBeClickable(btnSignIn)).Click();
            _driver.WaitForElement(signInConfirmBy);
        }

        public void EnterPassword()
        {
            if(_driver.IsVisible(By.Id("continue")))
            {
                btnSignIn.Click();
            }

            _driver.Wait(2);
            txtLoging.SendKeys(ConfigSetup.BaseConfiguration.TestConfiguration.EnvCPLogin);
            btnContinue.Click();
        }

        #endregion
    }
}