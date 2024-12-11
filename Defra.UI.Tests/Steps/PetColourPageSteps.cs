using BoDi;
using Defra.UI.Tests.Pages.AP.PetColourPage;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps
{
    [Binding]
    public class PetColourPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetColourPage? PetColourPage => _objectContainer.IsRegistered<IPetColourPage>() ? _objectContainer.Resolve<IPetColourPage>() : null;
        public PetColourPageSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should navigate to the What is the main colour of your '([^']*)' page")]
        public void ThenIShouldNavigateToTheWhatIsTheMainColourOfYourPage(string petType)
        {
            var pageTitle = $"What is the main colour of your {petType.ToLower()}?";
            Assert.IsTrue(PetColourPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I have selected the radio button as '([^']*)' for pet's")]
        public void WhenIHaveSelectedTheRadioButtonAsForPets(string colourOption)
        {
            PetColourPage?.SelectColorOption(colourOption);            
        }         

        [When(@"I have selected the radio button as '(.*)' for pet's and continue")]
        public void WhenIHaveSelectedTheRadioButtonAsForPetsAndContinue(string colourOption)
        {
            PetColourPage?.SelectColorOption(colourOption);
            PetColourPage?.ClickContinueButton();
        }
    }
}