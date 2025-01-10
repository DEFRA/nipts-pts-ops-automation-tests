using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class PetDOBPageSteps
    {
        private readonly IWebDriver _driver;
        private readonly IPetDOBPage _petDOBPage;

        public PetDOBPageSteps(IWebDriver driver, IPetDOBPage petDOBPage)
        {
            _driver = driver;
            _petDOBPage = petDOBPage;
        }

        [Then(@"I should navigate to the Do you know your pet's date of birth page")]
        public void ThenIShouldNavigateToTheDoYouKnowYourPetsDateOfBirthPage()
        {
            var pageTitle = "What is your pet's date of birth?";
            Assert.IsTrue(_petDOBPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I have provided date of birth for pet and continue")]
        public void WhenIHaveProvidedDateOfBirthForPetAndContinue()
        {
            _petDOBPage?.EnterDateMonthYear(DateTime.Now.AddYears(-8));
            _petDOBPage?.ClickContinueButton();
        }
    }
}