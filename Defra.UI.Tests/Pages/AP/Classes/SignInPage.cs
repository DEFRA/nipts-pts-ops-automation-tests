﻿using Reqnroll.BoDi;
using OpenQA.Selenium;
using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Defra.UI.Tests.Pages.AP.Classes
{
    public class SignInPage : ISignInPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading']"), true);
        private IWebElement UserId => _driver.FindElement(By.Id("user_id"));
        private IWebElement Password => _driver.FindElement(By.Id("password"));
        private IWebElement SignIn => _driver.WaitForElement(By.Id("continue"));
        private By SignInConfirmBy => By.CssSelector("[href='/User/OSignOut']");
        private IWebElement CreateSignInDetails => _driver.WaitForElement(By.XPath("//a[contains(text(),'Create sign in')]"));
        private IWebElement SignOutGCConfirmMessage => _driver.WaitForElement(By.CssSelector("h1.govuk-heading-xl"));
        private IWebElement DynamicsUserId => _driver.WaitForElement(By.XPath("//*[normalize-space(text())='Sign in']/following::input[1]"));
        private IWebElement BtnNext => _driver.WaitForElement(By.XPath("//*[@value='Next']"));
        private IWebElement DynamicsPassword => _driver.WaitForElement(By.XPath("//*[normalize-space(text())='Enter password']/following::input[1]"));
        private IWebElement BtnSignin => _driver.WaitForElement(By.XPath("//*[@value='Sign in']"));
        private IWebElement Signin => _driver.WaitForElement(By.XPath("//*[normalize-space(text()) ='Sign In']"));
        #endregion

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public SignInPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        public bool IsPageLoaded()
        {
            return PageHeading.Text.Contains("Sign in using Government Gateway");
        }

        public bool IsSignedIn(string userName, string password)
        {
            UserId.SendKeys(userName);
            Password.SendKeys(password);
            _driver.WaitForElementCondition(ExpectedConditions.ElementToBeClickable(SignIn)).Click();
            return _driver.WaitForElement(SignInConfirmBy).Enabled;
        }

        public void ClickCreateSignInDetailsLink() => CreateSignInDetails.Click();

        public void ClickSignedOut()
        {
            _driver.WaitForElement(SignInConfirmBy).Click();
        }

        public bool IsSignedOut()
        {
            ClickSignedOut();
            return PageHeading.Text.Contains("You have signed out") || PageHeading.Text.Contains("Your Defra account");
        }

        public bool IsSuccessfullySignedOut()
        {
            ClickSignedOut();
            return SignOutGCConfirmMessage.Text.Contains("You need to sign in again");
        }

        public void SignInToDynamics(string username, string password)
        {
            DynamicsUserId.SendKeys(username);
            BtnNext.Click();
            DynamicsPassword.SendKeys(password);
            BtnSignin.Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(50));
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[text() = 'Please sign in again']")));
                Signin.Click();
            }
            catch (NoSuchElementException e)
            {

            }

        }

    }
}