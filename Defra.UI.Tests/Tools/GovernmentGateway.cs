using Defra.UI.Tests.Contracts;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Tools
{
    public sealed class GovernmentGateway
    {
        private static readonly Lazy<GovernmentGateway> _instance = new Lazy<GovernmentGateway>(() => new GovernmentGateway());

        private LoginDetails _cachedValue;
        private bool _isMethodCalled = false;
        private readonly object _lock = new object();

        private ScenarioContext? _scenarioContext;
        private IObjectContainer _objectContainer;
        private ISignInPage? signin => _objectContainer.IsRegistered<ISignInPage>() ? _objectContainer.Resolve<ISignInPage>() : null;
        private IEmailSignUpPage? emailSignUpPage => _objectContainer.IsRegistered<IEmailSignUpPage>() ? _objectContainer.Resolve<IEmailSignUpPage>() : null;
        private IHomePage? homePage => _objectContainer.IsRegistered<IHomePage>() ? _objectContainer.Resolve<IHomePage>() : null;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IUrlBuilder? urlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;
        private ILandingPage? landingPage => _objectContainer.IsRegistered<ILandingPage>() ? _objectContainer.Resolve<ILandingPage>() : null;
        private IFetchCodeFromEmail? fetchCodeFromEmail => _objectContainer.IsRegistered<IFetchCodeFromEmail>() ? _objectContainer.Resolve<IFetchCodeFromEmail>() : null;

        private GovernmentGateway() { }

        public static GovernmentGateway Instance => _instance.Value;

        public LoginDetails GetID()
        {
            if (!_isMethodCalled)
            {
                lock (_lock)
                {
                    if (!_isMethodCalled)
                    {
                        _cachedValue = GenerateID();
                        _isMethodCalled = true;
                    }
                }
            }
            return _cachedValue;
        }

        private LoginDetails GenerateID()
        {
            var url = urlBuilder?.Default().BuildApp();
            _driver?.Navigate().GoToUrl(url);

            landingPage?.EnterPassword();

            signin?.ClickCreateSignInDetailsLink();

            var emailText = $"PetsAutomation{DateTime.Now.ToString("yyyyMMddHHmmss")}";
            var emailAddress = $"{emailText}@{fetchCodeFromEmail?.DomainName}";
            var secret = "G0vernmen+";

            emailSignUpPage?.EnterEmailAddress(emailAddress);
            Thread.Sleep(3000);
            emailSignUpPage?.ClickContinueButton();

            var code = Task.Run(async () => await fetchCodeFromEmail?.GetCodeFromEmail(emailText)).Result;

            emailSignUpPage?.EnterConfirmationCode(code);
            emailSignUpPage?.ClickContinueButton();
            emailSignUpPage?.ClickContinueButton();

            emailSignUpPage?.EnterFullName("Pets Automation");
            emailSignUpPage?.ClickContinueButton();

            emailSignUpPage?.EnterThePassword(secret);
            emailSignUpPage?.ClickContinueButton();

            var ggid = emailSignUpPage?.GetGGID();
            Assert.IsNotEmpty(ggid);

            emailSignUpPage?.ClickContinueButton();

            emailSignUpPage?.ClickContinueButton();
            emailSignUpPage?.ClickContinueButton();
            emailSignUpPage?.ClickContinueButton();

            emailSignUpPage?.SelectIndividualUser();
            emailSignUpPage?.ClickContinueButton();

            emailSignUpPage?.EnterFirstAndLastName("Pets", "Automation");
            emailSignUpPage?.ClickContinueButton();

            emailSignUpPage?.EnterTelephoneNumber("07639928765");
            emailSignUpPage?.ClickContinueButton();

            emailSignUpPage?.EnterPostCode("OX1 1AF");
            emailSignUpPage?.ClickContinueButton();

            emailSignUpPage?.SelectAddress();
            emailSignUpPage?.ClickContinueButton();

            emailSignUpPage?.EnterMemorableWordAndHint("OpsPetsTesting", "OpsPetsTesting");
            emailSignUpPage?.ClickContinueButton();
            emailSignUpPage?.ClickContinueButton();

            Assert.True(homePage?.IsPageLoaded(), "Apply for a pet travel document not loaded");

            return new LoginDetails
            {
                EmailText = emailText,
                EmailAddress = emailAddress,
                ConfirmationCode = code,
                GovernmentGatewayID = ggid,
                Secret = secret
            };
        }
    }
}
