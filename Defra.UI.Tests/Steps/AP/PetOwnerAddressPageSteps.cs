using Reqnroll.BoDi;
using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class PetOwnerAddressPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetOwnerAddressPage? PetOwnerAddressPage => _objectContainer.IsRegistered<IPetOwnerAddressPage>() ? _objectContainer.Resolve<IPetOwnerAddressPage>() : null;
        public PetOwnerAddressPageSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [When(@"I select Pets Owner Address from dropdown and continue")]
        public void WhenISelectPetsOwnerAddressFromDropdownAndContinue()
        {
            PetOwnerAddressPage?.SelectAnAddress(3);
            PetOwnerAddressPage?.ClickContinueButton();
        }

        [Then(@"I should navigate to Pets Owner address page '(.*)'")]
        public void ThenIShouldNavigateToPetOwnerAddressPage(string title)
        {
            Assert.IsTrue(PetOwnerAddressPage?.IsAddressPageHeaderDisplayed(title), $"The page {title} not loaded!");
        }
    }
}