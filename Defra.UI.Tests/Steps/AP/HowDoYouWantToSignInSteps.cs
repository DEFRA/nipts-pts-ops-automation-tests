using Defra.UI.Tests.Pages.AP.Classes;
using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class HowDoYouWantToSignInSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IGovernmentGatewayTypePage? governmentGatewayTypePage => _objectContainer.IsRegistered<IGovernmentGatewayTypePage>() ? _objectContainer.Resolve<IGovernmentGatewayTypePage>() : null;
        public HowDoYouWantToSignInSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then("I should see type of Gateway login page")]
        public void ThenIShouldSeeTypeOfGatewayLoginPage()
        {
            Assert.True(governmentGatewayTypePage?.IsPageLoaded("How do you want to sign in?"), "How do you want to sign in? page not loaded");
        }

        [Then("I have selected {string} as login type")]
        public void ThenIHaveSelectedAsLoginType(string loginType)
        {
            governmentGatewayTypePage?.SelectLoginType(loginType);
        }

        [When("I click Continue button from How do you want to sign in page")]
        public void WhenIClickContinueButtonFromHowDoYouWantToSignInPage()
        {
            governmentGatewayTypePage?.ClickContinueButton();
        }

    }
}
