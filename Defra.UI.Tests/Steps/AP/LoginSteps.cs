using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Data.Users;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class LoginSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IUrlBuilder? urlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;
        private ILandingPage? landingPage => _objectContainer.IsRegistered<ILandingPage>() ? _objectContainer.Resolve<ILandingPage>() : null;
        private ISignInPage? signin => _objectContainer.IsRegistered<ISignInPage>() ? _objectContainer.Resolve<ISignInPage>() : null;
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;

        public LoginSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Given(@"I navigate to PETS a travel document URL")]
        public void GivenINavigateToPETSATravelDocumentURL()
        {
            var url = urlBuilder.Default().BuildApp();
            _driver?.Navigate().GoToUrl(url);

            var environment = ConfigSetup.BaseConfiguration.TestConfiguration.Environment;
            var title = environment.ToUpper().Equals("PRE") ? "Private beta testing login" : "Private beta testing login";

            //Assert.True(landingPage?.IsPageLoaded(title), "Application page not loaded");
        }

        [Given(@"I have provided the password for Landing page")]
        [Then(@"I have provided the password for Landing page")]
        [When(@"I have provided the password for Landing page")]
        public void GivenIHaveProvidedThePasswordForLandingPage()
        {
            landingPage?.EnterPasswordAndClick();
        }

        [When(@"I click Continue button from Landing page")]
        public void WhenIClickContinueButtonFromLandingPage()
        {
            landingPage?.ClickContinueButton();
        }

        [Then(@"I should redirected to the AP Sign in using Government Gateway page")]
        public void ThenIShouldRedirectedToTheAPSignInUsingGovernmentGatewayPage()
        {
            Assert.True(signin?.IsPageLoaded(), "Application page not loaded");
        }

        [When(@"I have provided the credentials and signin")]
        public void WhenIHaveProvidedTheCredentialsAndSignin()
        {
            var userDetails = ConfigSetup.BaseConfiguration.TestConfiguration.IsLiveUserAccount ?
                GovernmentGateway.Instance.GetUserDetails() :
                GovernmentGateway.Instance.GetUserDetailsFromFile();

            signin?.IsSignedIn(userDetails.GovernmentGatewayID, userDetails.Secret);
        }

        [When(@"I have provided the suspension credentials and signin")]
        public void WhenIHaveProvidedTheSuspensionCredentialsAndSignin()
        {
            var userDetails = GovernmentGateway.Instance.GetUserDetailsFromFile("SUS");

            signin?.IsSignedIn(userDetails.GovernmentGatewayID, userDetails.Secret);
        }

        [When(@"I have provided invalid CP credentials and signin")]
        public void WhenIHaveProvidedInvalidCPCredentialsAndSignin()
        {
            var jsonData = UserObject?.GetUser("AP");
            signin?.CPSignIn(jsonData.UserName, jsonData.Credential);
        }
    }
}
