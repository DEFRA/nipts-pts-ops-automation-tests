using Capgemini.PowerApps.SpecFlowBindings;
using Defra.UI.Tests.Data.Users;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class SigninSteps
    {
        private readonly IWebDriver _driver;

        private readonly ISignInPage? _signin;
        private readonly IUserObject? _userObject;
        private readonly IUrlBuilder? _urlBuilder;
    

        public SigninSteps(IWebDriver driver, ISignInPage signInPage, IUserObject userObject, IUrlBuilder urlBuilder)
        {
            _driver = driver;
            _signin = signInPage;
            _userObject = userObject;
            _urlBuilder = urlBuilder;
        }

        [Given(@"that I navigate to the DEFRA application")]
        public void GivenThatINavigateToTheDEFRAApplication()
        {
            string url = _urlBuilder.Default().BuildApp();
            _driver?.Navigate().GoToUrl(url);
        }

        [Then(@"sign in with valid credentials with logininfo")]
        public void ThenSignInWithValidCredentialsWithLogininfo()
        {
            var user = _userObject?.GetUser("AP");
            Assert.True(_signin?.IsSignedIn(user?.UserName, user?.Credential), "Not able to sign in");
        }

        [When(@"click on signout button and verify the signout message")]
        [Then(@"click on signout button and verify the signout message")]
        public void ThenClickOnSignoutButtonAndVerifyTheSignoutMessage()
        {
            Assert.True(_signin?.IsSignedOut(), "Not able to sign out");
        }

        [When(@"I Login to Dynamics application")]
        public void GivenThatINavigateToTheDynamicspplication()
        {
            var user = PowerAppsStepDefiner.TestConfig.Users.FirstOrDefault();

            Trade.Plants.SpecFlowBindings.Steps.LoginSteps.GivenIAmLoggedInToTheAppAs1("Defra Trade - NIPTS", user?.Alias);
        }
    }
}