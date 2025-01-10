using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class PetOwnerNamePageSteps
    {
        private readonly IWebDriver _driver;
        private readonly IPetOwnerNamePage _petOwnerNamePage;
        public PetOwnerNamePageSteps(IWebDriver driver, IPetOwnerNamePage petOwnerNamePage)
        {
            _driver = driver;
            _petOwnerNamePage = petOwnerNamePage;
        }

        [Then(@"I should navigate to Pets Owner full name page")]
        public void ThenIShouldNavigateToPetsOwnerFullNamePage()
        {
            var pageTitle = $"What is your full name?";
            Assert.IsTrue(_petOwnerNamePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I provided '([^']*)' and continue")]
        public void WhenIProvidedAndContinue(string userName)
        {
            _petOwnerNamePage?.EnterPetOwnerName(userName);
            _petOwnerNamePage?.ClickContinueButton();
        }
    }
}