using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class PetColourPageSteps
    {
        private readonly IWebDriver _driver;
        private readonly IPetColourPage _petColourPage;

        public PetColourPageSteps(IWebDriver driver, IPetColourPage petColourPage)
        {
            _driver = driver;
            _petColourPage = petColourPage;
        }

        [Then(@"I should navigate to the What is the main colour of your '([^']*)' page")]
        public void ThenIShouldNavigateToTheWhatIsTheMainColourOfYourPage(string petType)
        {
            var pageTitle = $"What is the main colour of your {petType.ToLower()}?";
            Assert.IsTrue(_petColourPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I have selected the radio button as '([^']*)' for pet's")]
        public void WhenIHaveSelectedTheRadioButtonAsForPets(string colourOption)
        {
            _petColourPage?.SelectColorOption(colourOption);
        }

        [When(@"I have selected the radio button as '(.*)' for pet's and continue")]
        public void WhenIHaveSelectedTheRadioButtonAsForPetsAndContinue(string colourOption)
        {
            _petColourPage?.SelectColorOption(colourOption);
            _petColourPage?.ClickContinueButton();
        }
    }
}