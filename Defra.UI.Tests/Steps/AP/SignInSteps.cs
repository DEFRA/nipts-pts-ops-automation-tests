using Capgemini.PowerApps.SpecFlowBindings;
using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Data.Users;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class SigninSteps
    {
        private readonly object _lock = new object();
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        private ISignInPage? Signin => _objectContainer.IsRegistered<ISignInPage>() ? _objectContainer.Resolve<ISignInPage>() : null;
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;
        private IFetchKeyVault? FetchKeyVault => _objectContainer.IsRegistered<IFetchKeyVault>() ? _objectContainer.Resolve<IFetchKeyVault>() : null;
        private IDataHelperConnections? dataHelperConnections => _objectContainer.IsRegistered<IDataHelperConnections>() ? _objectContainer.Resolve<IDataHelperConnections>() : null;

        public SigninSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Given(@"that I navigate to the DEFRA application")]
        public void GivenThatINavigateToTheDEFRAApplication()
        {
            string url = UrlBuilder.Default().BuildApp();
            _driver?.Navigate().GoToUrl(url);
        }

        [Then(@"sign in with valid credentials with logininfo")]
        public void ThenSignInWithValidCredentialsWithLogininfo()
        {
            var userDetails = ConfigSetup.BaseConfiguration.TestConfiguration.IsLiveUserAccount ?
                                GovernmentGateway.Instance.GetUserDetails() :
                                GovernmentGateway.Instance.GetUserDetailsFromFile();

            Assert.True(Signin?.IsSignedIn(userDetails.GovernmentGatewayID, userDetails.Secret), "Not able to sign in");
        }

        [When(@"click on signout button and verify the signout message")]
        [Then(@"click on signout button and verify the signout message")]
        public void ThenClickOnSignoutButtonAndVerifyTheSignoutMessage()
        {
            Assert.True(Signin?.IsSignedOut(), "Not able to sign out");
        }

        [Then(@"I click on signout button from your defra account page and verify the signout message")]
        public void ThenIClickOnSignoutButtonFromYourDefraAccountPageAndVerifyTheSignoutMessage()
        {
            Assert.True(Signin?.IsSignedOutFromYourDefraAccountPage(), "Not able to sign out");
        }

        [When(@"I Login to Dynamics application")]
        public void GivenThatINavigateToTheDynamicspplication()
        {
            var user = PowerAppsStepDefiner.TestConfig.Users.FirstOrDefault();

            Trade.Plants.SpecFlowBindings.Steps.LoginSteps.GivenIAmLoggedInToTheAppAs1("Defra Trade - NIPTS", user?.Alias);
        }

        [Then("I click on Taking a pet from Great Britain to Northern Ireland link")]
        public void ThenIClickOnTakingAPetFromGreatBritainToNorthernIrelandLink()
        {
            Signin?.ClickPetsTravelApplicationPortalLink();
        }

        [Then("I click sign in button")]
        public void ThenIClickSignInButton()
        {
            Signin?.ClickSignInButton();
        }

        [Then(@"I should see an error message ""(.*)"" in Government Gateway page")]
        public void ThenIShouldSeeAnErrorMessageInGovernmentGatewayPage(string errorMessage)
        {
            Assert.True(Signin?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
        }
    }
}