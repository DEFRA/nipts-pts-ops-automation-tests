using BoDi;
using Defra.UI.Tests.Pages.AP.PetMicrochipDatePage;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class PetMicrochipDatePageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetMicrochipDatePage? PetMicrochipDatePage => _objectContainer.IsRegistered<IPetMicrochipDatePage>() ? _objectContainer.Resolve<IPetMicrochipDatePage>() : null;
        public PetMicrochipDatePageSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should navigate to When was your pet microchipped page")]
        public void ThenIShouldNavigateToWhenWasYourPetMicrochippedPage()
        {
            var pageTitle = "When was your pet microchipped or last scanned?";
            Assert.IsTrue(PetMicrochipDatePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I have provided the date of PETS microchipped and continue")]
        public void WhenIHaveProvidedTheDateOfPETSMicrochippedAndContinue()
        {
            PetMicrochipDatePage?.EnterDateMonthYear(DateTime.Now.AddYears(-1));
            PetMicrochipDatePage?.ClickContinueButton();
        }
    }
}