using BoDi;
using OpenQA.Selenium;
using Defra.UI.Tests.Tools;
using Defra.UI.Tests.Pages.CP.Interfaces;
using SeleniumExtras.WaitHelpers;
using Defra.UI.Tests.Configuration;
using Defra.UI.Framework.Driver;

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
        #endregion

        #region Methods
        public bool VerifyHeadings(string heading, string subHeading)
        {
            String applicationTitle = lblTitle.Text;
            //String[] headings = applicationTitle.Replace("\r\n", "*").Split('*');
            String[] headings = applicationTitle.Replace("\r\n", "*").Split('*',2);
            //String.Join(headings[1], " ");
            String MainHeading = headings[1].Replace("*", " ");
            if (headings[0].Equals(subHeading) && MainHeading.Equals(heading))
            {
                return true;
            }
            return false;
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