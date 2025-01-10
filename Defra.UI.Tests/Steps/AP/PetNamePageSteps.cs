using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class PetNamePageSteps
    {
        private readonly IWebDriver _driver;
        private readonly IPetNamePage _petNamePage;
        public PetNamePageSteps(IWebDriver driver, IPetNamePage petNamePage)
        {
            _driver = driver;
            _petNamePage = petNamePage;
        }

        [Then(@"I should navigate to the What is your pet's name page")]
        public void ThenIShouldNavigateToTheWhatIsYourPetsNamePage()
        {
            var pageTitle = "What is your pet's name?";
            Assert.IsTrue(_petNamePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have provided the Pets name as '([^']*)' and continue")]
        public void ThenIHaveProvidedThePetsNameAsAndContinue(string petName)
        {
            _petNamePage?.EnterPetsName(petName);
            _petNamePage?.ClickContinueButton();
        }
    }
}