using Reqnroll.BoDi;
using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class PetColourPageWelshSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetColourPageWelsh? PetColourPageWelsh => _objectContainer.IsRegistered<IPetColourPageWelsh>() ? _objectContainer.Resolve<IPetColourPageWelsh>() : null;
        public PetColourPageWelshSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should navigate to the What is the main colour of your '([^']*)' page in Welsh")]
        public void ThenIShouldNavigateToTheWhatIsTheMainColourOfYourPageInWelsh(string petType)
        {
            var pageTitle = $"Beth yw prif liw eich {petType.ToLower()}?";
            Assert.IsTrue(PetColourPageWelsh?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        /*        [When(@"I have selected the radio button as '([^']*)' for pet's")]
                public void WhenIHaveSelectedTheRadioButtonAsForPets(string colourOption)
                {
                    PetColourPage?.SelectColorOption(colourOption);
                }*/

        [When(@"I have selected the radio button as '(.*)' for pet's and continue in Welsh")]
        public void WhenIHaveSelectedTheRadioButtonAsForPetsAndContinueInWelsh(string colourOption)
        {
            PetColourPageWelsh?.SelectColorOption(colourOption);
            PetColourPageWelsh?.ClickParhauButton();
        }
    }
}