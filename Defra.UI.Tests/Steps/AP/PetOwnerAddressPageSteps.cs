using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class PetOwnerAddressPageSteps
    {
        private readonly IWebDriver _driver;
        private readonly IPetOwnerAddressPage _petOwnerAddressPage;
        public PetOwnerAddressPageSteps(IWebDriver driver, IPetOwnerAddressPage petOwnerAddressPage)
        {
            _driver = driver;
            _petOwnerAddressPage = petOwnerAddressPage;
        }

        [Then(@"I should navigate to Pets Owner address dropdown page")]
        public void ThenIShouldNavigateToPetsOwnerAddressDropdownPage()
        {
            var pageTitle = $"What is your address?";
            Assert.IsTrue(_petOwnerAddressPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I select Pets Owner Address from dropdown and continue")]
        public void WhenISelectPetsOwnerAddressFromDropdownAndContinue()
        {
            _petOwnerAddressPage?.SelectAnAddress(3);
            _petOwnerAddressPage?.ClickContinueButton();
        }
    }
}