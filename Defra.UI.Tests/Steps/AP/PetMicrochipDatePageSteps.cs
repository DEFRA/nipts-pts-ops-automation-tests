using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class PetMicrochipDatePageSteps
    {
        private readonly IWebDriver _driver;
        private readonly IPetMicrochipDatePage _petMicrochipDatePage;

        public PetMicrochipDatePageSteps(IWebDriver driver, IPetMicrochipDatePage petMicrochipDatePage)
        {
            _driver = driver;
            _petMicrochipDatePage = petMicrochipDatePage;
        }

        [Then(@"I should navigate to When was your pet microchipped page")]
        public void ThenIShouldNavigateToWhenWasYourPetMicrochippedPage()
        {
            var pageTitle = "When was your pet microchipped or last scanned?";
            Assert.IsTrue(_petMicrochipDatePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I have provided the date of PETS microchipped and continue")]
        public void WhenIHaveProvidedTheDateOfPETSMicrochippedAndContinue()
        {
            _petMicrochipDatePage?.EnterDateMonthYear(DateTime.Now.AddYears(-1));
            _petMicrochipDatePage?.ClickContinueButton();
        }
    }
}