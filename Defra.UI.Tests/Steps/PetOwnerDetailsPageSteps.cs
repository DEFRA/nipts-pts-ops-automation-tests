using BoDi;
using Defra.UI.Tests.Pages.AP.PetOwnerDetailsPage;
using Defra.UI.Tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps
{
    [Binding]
    public class PetOwnerDetailsPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetOwnerDetailsPage? PetOwnerDetailsPage => _objectContainer.IsRegistered<IPetOwnerDetailsPage>() ? _objectContainer.Resolve<IPetOwnerDetailsPage>() : null;
        public PetOwnerDetailsPageSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I should navigate to the Pets Owner details correct page")]
        public void ThenIShouldNavigateToThePetsOwnerDetailsCorrectPage()
        {
            var pageTitle = "Are your details correct?";
            Assert.IsTrue(PetOwnerDetailsPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I selected the radio button '([^']*)' option and continue")]
        public void WhenISelectedTheRadioButtonOptionAndContinue(string petsOwnerDetails)
        {
            PetOwnerDetailsPage?.SelectIsOwnerDetailsCorrect(petsOwnerDetails);
            PetOwnerDetailsPage?.ClickContinueButton();
        }

        [Then(@"I should see an error message '([^']*)' in pet owner details page")]
        public void ThenIShouldSeeAnErrorMessageInPetOwnerDetailsPage(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                Assert.True(PetOwnerDetailsPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
            }
        }

        [Then(@"I verify the updated Phone number")]
        public void ThenIVerifyTheUpdatedPhoneNumber()
        {
            Assert.IsTrue(PetOwnerDetailsPage?.VerifyUpdatedPhoneNumber(_scenarioContext.Get<string>("PhoneNumber")));
        }

        [Then(@"I verify the updated Pet Owner Name")]
        public void ThenIVerifyTheUpdatedPetOwnerName()
        {
            String petOwnerName = _scenarioContext.Get<string>("FirstName") + " " + _scenarioContext.Get<string>("LastName");
            Assert.IsTrue(PetOwnerDetailsPage?.VerifyUpdatedName(petOwnerName));
        }

        [Then(@"I verify the updated Pet Owner Address")]
        public void ThenIVerifyTheUpdatedPetOwnerAddress()
        {            
            _driver?.Wait(15);
            _driver?.Navigate().Refresh();

            Assert.IsTrue(PetOwnerDetailsPage?.VerifyUpdatedPetOwnerAddress(_scenarioContext.Get<string>("SelectedAddress")));
        }
    }
}