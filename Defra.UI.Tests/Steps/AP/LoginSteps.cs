using BoDi;
using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Data.Users;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class LoginSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IUrlBuilder? urlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;
        private ILandingPage? landingPage => _objectContainer.IsRegistered<ILandingPage>() ? _objectContainer.Resolve<ILandingPage>() : null;
        private ISignInPage? signin => _objectContainer.IsRegistered<ISignInPage>() ? _objectContainer.Resolve<ISignInPage>() : null;
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;

        public LoginSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Given(@"I navigate to PETS a travel document URL")]
        public void GivenINavigateToPETSATravelDocumentURL()
        {
            var url = urlBuilder.Default().BuildApp();
            _driver?.Navigate().GoToUrl(url);
            Assert.True(landingPage?.IsPageLoaded("This is for testing use only"), "Application page not loaded");
        }

        [Given(@"I have provided the password for Landing page")]
        [Then(@"I have provided the password for Landing page")]
        public void GivenIHaveProvidedThePasswordForLandingPage()
        {
            landingPage?.EnterPassword();
        }

        [When(@"I click Continue button from Landing page")]
        public void WhenIClickContinueButtonFromLandingPage()
        {
            landingPage?.ClickContinueButton();
        }

        [Then(@"I should redirected to the Sign in using Government Gateway page")]
        public void ThenIShouldRedirectedToTheSignInUsingGovernmentGatewayPage()
        {
            Assert.True(signin?.IsPageLoaded(), "Application page not loaded");
        }

        [When(@"I have provided the credentials and signin")]
        public void WhenIHaveProvidedTheCredentialsAndSignin()
        {

            var jsonData = UserObject?.GetUser("AP");
            var userObject = new User
            {
                UserName = jsonData.UserName,
                Credential = jsonData.Credential
            };

            signin?.IsSignedIn(userObject.UserName, userObject.Credential);
        }
    }
}
