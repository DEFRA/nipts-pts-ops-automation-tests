using Defra.UI.Tests.Pages.WELSH.Classes;
using Defra.UI.Tests.Pages.WELSH.Interfaces;
using Defra.UI.Tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Steps.WELSH
{
    [Binding]
    public class PetOwnerDetailsPageWelshSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetOwnerDetailsPageWelsh? PetOwnerDetailsPageWelsh => _objectContainer.IsRegistered<IPetOwnerDetailsPageWelsh>() ? _objectContainer.Resolve<IPetOwnerDetailsPageWelsh>() : null;
        public PetOwnerDetailsPageWelshSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I should navigate to the Pets Owner details correct page in Welsh")]
        public void ThenIShouldNavigateToThePetsOwnerDetailsCorrectPage()
        {
            var pageTitle = "Ydy’ch manylion chi’n gywir?";
            Assert.IsTrue(PetOwnerDetailsPageWelsh?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I selected the radio button '([^']*)' option and continue in Welsh")]
        public void WhenISelectedTheRadioButtonOptionAndContinue(string petsOwnerDetails)
        {
            PetOwnerDetailsPageWelsh?.SelectIsOwnerDetailsCorrect(petsOwnerDetails);
            PetOwnerDetailsPageWelsh?.ClickContinueButton();
        }

        [Then(@"I should see an error message '([^']*)' in pet owner details page in Welsh")]
        public void ThenIShouldSeeAnErrorMessageInPetOwnerDetailsPage(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                Assert.True(PetOwnerDetailsPageWelsh?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
            }
        }

        [Then(@"I verify the updated Phone number in Welsh")]
        public void ThenIVerifyTheUpdatedPhoneNumber()
        {
            Assert.IsTrue(PetOwnerDetailsPageWelsh?.VerifyUpdatedPhoneNumber(_scenarioContext.Get<string>("PhoneNumber")));
        }

        [Then(@"I verify the updated Pet Owner Name in Welsh")]
        public void ThenIVerifyTheUpdatedPetOwnerName()
        {
            string petOwnerName = _scenarioContext.Get<string>("FirstName") + " " + _scenarioContext.Get<string>("LastName");
            Assert.IsTrue(PetOwnerDetailsPageWelsh?.VerifyUpdatedName(petOwnerName));
        }

        [Then(@"I verify the updated Pet Owner Address in Welsh")]
        public void ThenIVerifyTheUpdatedPetOwnerAddress()
        {
            _driver?.Wait(15);
            _driver?.Navigate().Refresh();
            Assert.IsTrue(PetOwnerDetailsPageWelsh?.VerifyUpdatedPetOwnerAddress(_scenarioContext.Get<string>("SelectedAddress")));
        }
    }
}
