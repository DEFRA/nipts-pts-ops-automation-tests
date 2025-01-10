using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class PetOwnerPostCodePageSteps
    {
        private readonly IWebDriver _driver;
        private IPetOwnerPostCodePage _petOwnerPostCodePage;
        public PetOwnerPostCodePageSteps(IWebDriver driver, IPetOwnerPostCodePage petOwnerPostCodePage)
        {
            _driver = driver;
            _petOwnerPostCodePage = petOwnerPostCodePage;
        }

        [Then(@"I should navigate to Pets Owner address postcode page")]
        public void ThenIShouldNavigateToPetsOwnerAddressPostcodePage()
        {
            var pageTitle = $"What is your postcode?";
            Assert.IsTrue(_petOwnerPostCodePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I provide Pets Owner '([^']*)' and click find address")]
        public void WhenIProvidePetsOwnerAndClickFindAddress(string postCode)
        {
            _petOwnerPostCodePage?.EnterPetOwnerPostCode(postCode);
            _petOwnerPostCodePage?.ClickFindAddressButton();
        }

        [When(@"I I click on Enter the address manually link from postcode page")]
        public void WhenIIClickOnEnterTheAddressManuallyLinkFromPostcodePage()
        {
            _petOwnerPostCodePage?.ClickManuallyAddressLink();
        }
    }
}