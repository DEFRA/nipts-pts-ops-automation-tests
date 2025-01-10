using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class PetBreedPageSteps
    {
        private readonly IWebDriver _driver;
        private readonly IPetBreedPage _petBreedPage;
        public PetBreedPageSteps(IPetBreedPage petBreedPage)
        {
            _petBreedPage = petBreedPage;
        }

        [Then(@"I should navigate to What breed is your '([^']*)' page")]
        public void ThenIShouldNavigateToWhatBreedIsYourPage(string petType)
        {
            var pageTitle = $"What breed is your {petType.ToLower()}?";
            Assert.IsTrue(_petBreedPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have selected from the dropdown as '([^']*)' for pet's and continue")]
        public void ThenIHaveSelectedFromTheDropdownAsForPetsAndContinue(string petBreed)
        {
            _petBreedPage?.EnterFreeTextBreed(petBreed);
            _petBreedPage?.ClickContinueButton();
        }
    }
}