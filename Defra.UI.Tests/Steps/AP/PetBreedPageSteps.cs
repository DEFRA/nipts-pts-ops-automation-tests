using Defra.UI.Tests.Pages.AP.Classes;
using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;

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
        [Then(@"I Verify the footer links changes to English")]
        public void ThenIVerifyTheFooterLinksChangesToEnglish()
        {
            Assert.IsTrue(PetBreedPage?.VerifyFooterLinksinEnglish(), "Footer links are not displayed correctly in english page.");

        }
    }
    
    }