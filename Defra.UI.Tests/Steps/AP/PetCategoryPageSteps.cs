using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class PetCategoryPageSteps
    {

        private readonly IWebDriver _driver;
        private readonly IPetSpeciesPage _petSpeciesPage;
      
        public PetCategoryPageSteps(IWebDriver driver, IPetSpeciesPage petSpeciesPage)
        {
            _driver = driver;
            _petSpeciesPage = petSpeciesPage;
        }

        [Then(@"I should navigate to the Is your pet a cat, dog or ferret page")]
        public void ThenIShouldNavigateToTheIsYourPetACatDogOrFerretPage()
        {
            var pageTitle = "Is your pet a dog, cat or ferret?";
            Assert.IsTrue(_petSpeciesPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have selected radio button as '([^']*)' and continue")]
        public void ThenIHaveSelectedRadioButtonAsAndContinue(string petsType)
        {
            _petSpeciesPage?.SelectSpecies(petsType);
            _petSpeciesPage?.ClickContinueButton();
        }
    }
}