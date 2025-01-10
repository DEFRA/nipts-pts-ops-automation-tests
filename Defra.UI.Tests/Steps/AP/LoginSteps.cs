using Defra.UI.Tests.Data.Users;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class LoginSteps
    {
        private readonly IWebDriver _driver;
        private readonly IUrlBuilder _urlBuilder;
        private readonly ILandingPage _landingPage;
        private readonly ISignInPage _signInPage;
        private readonly IUserObject _userObject;
        private readonly ScenarioContext _scenarioContext;

        public LoginSteps(ScenarioContext context, IWebDriver driver, IUrlBuilder urlBuilder, ILandingPage landingPage, ISignInPage signInPage, IUserObject userObject)
        {
            _scenarioContext = context;
            _driver = driver;
            _urlBuilder = urlBuilder;
            _landingPage = landingPage;
            _signInPage = signInPage;
            _userObject = userObject;
        }

        [Given(@"I navigate to PETS a travel document URL")]
        public void GivenINavigateToPETSATravelDocumentURL()
        {
            var url = _urlBuilder.Default().BuildApp();
            _driver?.Navigate().GoToUrl(url);
            Assert.True(_landingPage?.IsPageLoaded("This is for testing use only"), "Application page not loaded");
        }

        [Given(@"I have provided the password for Landing page")]
        [Then(@"I have provided the password for Landing page")]
        public void GivenIHaveProvidedThePasswordForLandingPage()
        {
            _landingPage?.EnterPassword();
        }

        [When(@"I click Continue button from Landing page")]
        public void WhenIClickContinueButtonFromLandingPage()
        {
            _landingPage?.ClickContinueButton();
        }

        [Then(@"I should redirected to the Sign in using Government Gateway page")]
        public void ThenIShouldRedirectedToTheSignInUsingGovernmentGatewayPage()
        {
            Assert.True(_signInPage?.IsPageLoaded(), "Application page not loaded");
        }

        [When(@"I have provided the credentials and signin")]
        public void WhenIHaveProvidedTheCredentialsAndSignin()
        {

            var jsonData = _userObject?.GetUser("AP");
            var userObject = new User
            {
                UserName = jsonData.UserName,
                Credential = jsonData.Credential
            };

            _signInPage?.IsSignedIn(userObject.UserName, userObject.Credential);
        }
    }
}
