using BoDi;
using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
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
        private IWebElement btnSignIn => _driver.WaitForElement(By.XPath("//a[contains(text(),'Sign in')]"));
        private By signInConfirmBy => By.XPath("//h1[contains(@class,'govuk-heading-xl')]");
        private IWebElement UserId => _driver.FindElement(By.CssSelector("#user_id"));
        private IWebElement Password => _driver.FindElement(By.CssSelector("#password"));
        private IWebElement SignIn => _driver.WaitForElement(By.Id("continue"));
        private IWebElement txtLoging => _driver.WaitForElement(By.XPath("//input[@id='password']"));
        private IWebElement btnContinue => _driver.WaitForElement(By.XPath("//button[normalize-space()='Continue']"));
        private IWebElement lblTitle => _driver.WaitForElement(By.XPath("//h1"));
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading']"), true);
        #endregion

        #region Methods
        public bool VerifyHeadings(string heading, string subHeading)
        {
            var applicationTitle = lblTitle.Text;
            var headings = applicationTitle.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            var mainHeading = $"{headings[1]} {headings[2]}";

            return headings[0].Equals(subHeading) && mainHeading.Equals(heading);
        }

        public bool IsPageLoaded()
        {
            return PageHeading.Text.Contains("Sign in using Government Gateway");
        }

        public void ClickSignInButton()
        {
            btnSignIn.Click();
        }

        public bool IsSignedIn(string userName, string password)
        {
            UserId.SendKeys(userName);
            Password.SendKeys(password);
            _driver.WaitForElementCondition(ExpectedConditions.ElementToBeClickable(SignIn)).Click();
            return _driver.WaitForElement(signInConfirmBy).Enabled;
        }

        public void EnterPassword()
        {
            Thread.Sleep(1000);
            txtLoging.SendKeys(ConfigSetup.BaseConfiguration.TestConfiguration.EnvCPLogin);
            btnContinue.Click();
        }
        #endregion
    }
}