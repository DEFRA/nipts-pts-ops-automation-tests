using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class PetOwnerAddressManuallyPageSteps
    {
        private readonly IWebDriver _driver;
        private readonly IPetOwnerAddressManuallyPage _petOwnerAddressManuallyPage;

        public PetOwnerAddressManuallyPageSteps(IWebDriver driver, IPetOwnerAddressManuallyPage petOwnerAddressManuallyPage)
        {
            _driver = driver;
            _petOwnerAddressManuallyPage = petOwnerAddressManuallyPage;
        }

        [Then(@"I should navigate to Pets Owner manually address page")]
        public void ThenIShouldNavigateToPetsOwnerManuallyAddressPage()
        {
            var pageTitle = $"What is your address?";
            Assert.IsTrue(_petOwnerAddressManuallyPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I fill in '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)'and continue")]
        public void WhenIFillInAndContinue(string firstLine, string secondLine, string city, string county, string postCode)
        {
            _petOwnerAddressManuallyPage?.EnterAddressManually(firstLine, secondLine, city, county, postCode);
            _petOwnerAddressManuallyPage?.ClickContinueButton();
        }
    }
}