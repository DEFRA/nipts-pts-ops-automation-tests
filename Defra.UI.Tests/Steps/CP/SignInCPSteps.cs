using Defra.UI.Tests.Data.Users;
using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.CP
{
    [Binding]
    public class SignInCPSteps
    {
        private readonly IWebDriver _driver;

        private IUrlBuilder? _urlBuilder;
        private ISignInCPPage? _signInCPPage;
        private IUserObject? _userObject;

        public SignInCPSteps(IWebDriver driver, IUrlBuilder urlBuilder, ISignInCPPage signInCPPage, IUserObject userObject)
        {
            _driver = driver;
            _urlBuilder = urlBuilder;
            _signInCPPage = signInCPPage;
            _userObject = userObject;
        }

        [When(@"I navigate to the port checker application")]
        [Given(@"that I navigate to the port checker application")]
        public void GivenThatINavigateToThePortCheckerApplication()
        {
            var url = _urlBuilder.Default().BuildCom();
            _driver?.Navigate().GoToUrl(url);
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
            var jsonData = _userObject?.GetUser("CP");
            var userObject = new User
            {
                UserName = jsonData.UserName,
                Credential = jsonData.Credential
            };

            _signInCPPage?.IsSignedIn(userObject.UserName, userObject.Credential);
        }
    }
}