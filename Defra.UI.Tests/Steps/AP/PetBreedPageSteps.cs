using BoDi;
using Defra.UI.Tests.Pages.AP.PetBreedPage;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class PetBreedPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetBreedPage? PetBreedPage => _objectContainer.IsRegistered<IPetBreedPage>() ? _objectContainer.Resolve<IPetBreedPage>() : null;
        public PetBreedPageSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should navigate to What breed is your '([^']*)' page")]
        public void ThenIShouldNavigateToWhatBreedIsYourPage(string petType)
        {
            var pageTitle = $"What breed is your {petType.ToLower()}?";
            Assert.IsTrue(PetBreedPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have selected from the dropdown as '([^']*)' for pet's and continue")]
        public void ThenIHaveSelectedFromTheDropdownAsForPetsAndContinue(string petBreed)
        {
            PetBreedPage?.EnterFreeTextBreed(petBreed);
            PetBreedPage?.ClickContinueButton();
        }
    }
}