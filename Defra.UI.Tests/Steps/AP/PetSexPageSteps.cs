using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class PetSexPageSteps
    {
        private readonly IWebDriver _driver;
        private readonly IPetSexPage _petSexPage;
        public PetSexPageSteps(IWebDriver driver, IPetSexPage petSexPage)
        {
            _driver = driver;
            _petSexPage = petSexPage;
        }

        [Then(@"I should navigate to the What sex is your pet page")]
        public void ThenIShouldNavigateToTheWhatSexIsYourPetPage()
        {
            var pageTitle = "What sex is your pet?";
            Assert.IsTrue(_petSexPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I have selected the radio button as '([^']*)' for sex option and continue")]
        public void WhenIHaveSelectedTheRadioButtonAsForSexOptionAndContinue(string sexType)
        {
            _petSexPage?.SelectPetsSexOption(sexType);
            _petSexPage?.ClickContinueButton();
        }
    }
}