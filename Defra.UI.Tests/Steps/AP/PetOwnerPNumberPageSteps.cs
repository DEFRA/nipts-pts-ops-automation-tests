using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class PetOwnerPNumberPageSteps
    {
        private readonly IWebDriver _driver;
        private readonly IPetOwnerPhoneNumberPage _petOwnerPNumberPage;
        public PetOwnerPNumberPageSteps(IWebDriver driver, IPetOwnerPhoneNumberPage petOwnerPNumberPage)
        {
            _driver = driver;
            _petOwnerPNumberPage = petOwnerPNumberPage;
        }

        [Then(@"I should navigate to Pets Owner phone number page")]
        public void ThenIShouldNavigateToPetsOwnerPhoneNumberPage()
        {
            var pageTitle = $"What is your phone number?";
            Assert.IsTrue(_petOwnerPNumberPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I provide Pets Owner '([^']*)' and continue")]
        public void WhenIProvidePetsOwnerAndContinue(string phoneNumber)
        {
            _petOwnerPNumberPage?.EnterPetOwnerPNumber(phoneNumber);
            _petOwnerPNumberPage?.ClickContinueButton();
        }

    }
}