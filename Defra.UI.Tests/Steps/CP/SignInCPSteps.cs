﻿using Reqnroll.BoDi;
using Defra.UI.Tests.Data.Users;
using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.CP
{
    [Binding]
    public class SignInCPSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IUrlBuilder? urlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;
        private ISignInCPPage? _signInCPPage => _objectContainer.IsRegistered<ISignInCPPage>() ? _objectContainer.Resolve<ISignInCPPage>() : null;
        private IRouteCheckingPage? _routeCheckingPage => _objectContainer.IsRegistered<IRouteCheckingPage>() ? _objectContainer.Resolve<IRouteCheckingPage>() : null;
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;

        public SignInCPSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I should redirected to the CP Sign in using Government Gateway page")]
        public void ThenIShouldRedirectedToTheCPSignInUsingGovernmentGatewayPage()
        {
            Assert.True(_signInCPPage?.IsPageLoaded(), "Application page not loaded");
        }

        [When(@"I navigate to the port checker application")]
        [Given(@"that I navigate to the port checker application")]
        public void GivenThatINavigateToThePortCheckerApplication()
        {
            var url = urlBuilder.Default().BuildCom();
            _driver?.Navigate().GoToUrl(url);
        }

        [Then(@"I Verify the Access Start Page Content")]
        public void ThenIVerifyTheAccessStartPageContent()
        {
            Assert.True(_signInCPPage?.VerifyHeadings("Check a pet travelling from Great Britain to Northern Ireland", "Pet Travel Scheme"), "Incorrect Heading is displayed in the Access Page");
        }

        [When(@"I click signin button on port checker application")]
        [Given(@"I click signin button on port checker application")]
        public void GivenIClickSigninButtonOnPortCheckerApplication()
        {
            _signInCPPage?.ClickSignInButton();
        }

        [When(@"I have provided the password for prototype research page")]
        public void WhenIHaveProvidedThePasswordForPrototypeResearchPage()
        {
            _signInCPPage?.EnterPassword();
        }

        [When(@"I have provided the CP credentials and signin")]
        public void WhenIHaveProvidedTheCPCredentialsAndSignin()
        {
            var jsonData = UserObject?.GetUser("CP","GB");
            var userObject = new User
            {
                UserName = jsonData.UserName,
                Credential = jsonData.Credential
            };

            _signInCPPage?.SignIn(userObject.UserName, userObject.Credential);
        }

        [When(@"I have provided the CP SPS credentials and signin")]
        public void WhenIHaveProvidedTheCPSPSCredentialsAndSignin()
        {
            var jsonData = UserObject?.GetUser("CP","SPS");
            var userObject = new User
            {
                UserName = jsonData.UserName,
                Credential = jsonData.Credential
            };

            _signInCPPage?.SignIn(userObject.UserName, userObject.Credential);
        }
    }
}