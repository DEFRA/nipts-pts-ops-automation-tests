using BoDi;
using Capgemini.PowerApps.SpecFlowBindings;
using Defra.UI.Tests.Data.Users;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Pages.AP.SignInPage;
using Defra.UI.Tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps
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
            var user = UserObject?.GetUser("AP");
            _objectContainer.RegisterInstanceAs(user);
            Assert.True(Signin?.IsSignedIn(user?.UserName, user?.Credential), "Not able to sign in");
        }

        [When(@"click on signout button and verify the signout message")]
        [Then(@"click on signout button and verify the signout message")]
        public void ThenClickOnSignoutButtonAndVerifyTheSignoutMessage()
        {
            Assert.True(Signin?.IsSignedOut(), "Not able to sign out");
        }

        [When(@"I Login to Dynamics application")]
        public void GivenThatINavigateToTheDynamicspplication()
        {
            var user = PowerAppsStepDefiner.TestConfig.Users.FirstOrDefault();
            
            Trade.Plants.SpecFlowBindings.Steps.LoginSteps.GivenIAmLoggedInToTheAppAs1("Defra Trade - NIPTS", user?.Alias);
        }
    }
}