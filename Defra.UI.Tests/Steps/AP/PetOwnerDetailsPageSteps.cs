using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class PetOwnerDetailsPageSteps
    {
        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly IPetOwnerDetailsPage _petOwnerDetailsPage;

        public PetOwnerDetailsPageSteps(ScenarioContext context, IWebDriver driver, IPetOwnerDetailsPage petOwnerDetailsPage)
        {
            _scenarioContext = context;
            _driver = driver;
            _petOwnerDetailsPage = petOwnerDetailsPage;
        }

        [Then(@"I should navigate to the Pets Owner details correct page")]
        public void ThenIShouldNavigateToThePetsOwnerDetailsCorrectPage()
        {
            var pageTitle = "Are your details correct?";
            Assert.IsTrue(_petOwnerDetailsPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I selected the radio button '([^']*)' option and continue")]
        public void WhenISelectedTheRadioButtonOptionAndContinue(string petsOwnerDetails)
        {
            _petOwnerDetailsPage?.SelectIsOwnerDetailsCorrect(petsOwnerDetails);
            _petOwnerDetailsPage?.ClickContinueButton();
        }

        [Then(@"I should see an error message '([^']*)' in pet owner details page")]
        public void ThenIShouldSeeAnErrorMessageInPetOwnerDetailsPage(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                Assert.True(_petOwnerDetailsPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
            }
        }

        [Then(@"I verify the updated Phone number")]
        public void ThenIVerifyTheUpdatedPhoneNumber()
        {
            Assert.IsTrue(_petOwnerDetailsPage?.VerifyUpdatedPhoneNumber(_scenarioContext.Get<string>("PhoneNumber")));
        }

        [Then(@"I verify the updated Pet Owner Name")]
        public void ThenIVerifyTheUpdatedPetOwnerName()
        {
            string petOwnerName = _scenarioContext.Get<string>("FirstName") + " " + _scenarioContext.Get<string>("LastName");
            Assert.IsTrue(_petOwnerDetailsPage?.VerifyUpdatedName(petOwnerName));
        }

        [Then(@"I verify the updated Pet Owner Address")]
        public void ThenIVerifyTheUpdatedPetOwnerAddress()
        {
            _driver?.Wait(15);
            _driver?.Navigate().Refresh();

            Assert.IsTrue(_petOwnerDetailsPage?.VerifyUpdatedPetOwnerAddress(_scenarioContext.Get<string>("SelectedAddress")));
        }
    }
}