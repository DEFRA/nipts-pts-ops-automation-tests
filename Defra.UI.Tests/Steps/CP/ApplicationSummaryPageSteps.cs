using Defra.UI.Tests.Pages.CP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Steps.CP
{
    [Binding]
    public class ApplicationSummaryPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IApplicationSummaryPage? _applicationSummaryPage => _objectContainer.IsRegistered<IApplicationSummaryPage>() ? _objectContainer.Resolve<IApplicationSummaryPage>() : null;

        public ApplicationSummaryPageSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"I should see the application status in '([^']*)'")]
        public void ThenIShouldSeeTheApplicationStatusIn(string applicationStatus)
        {
            Assert.IsTrue(_applicationSummaryPage?.VerifyTheExpectedStatus(applicationStatus), "The submitted application is not in expected status");
        }

        [When(@"I select Pass radio button")]
        public void WhenISelectPassRadioButton()
        {
            _applicationSummaryPage?.SelectPassRadioButton();
        }

        [When(@"I select Fail radio button")]
        public void WhenISelectFailRadioButton()
        {
            _applicationSummaryPage?.SelectFailRadioButton();
        }

        [When(@"I click save and continue button from application status page")]
        [When(@"I continue button from application status page")]
        public void WhenIClickSaveAndContinueButtonFromApplicationStatusPage()
        {
            _applicationSummaryPage?.SelectSaveAndContinue();
        }

        [Then(@"I should see an error message ""([^""]*)"" in application status page")]
        public void ThenIShouldSeeAnErrorMessageInApplicationStatusPage(string errorMessage)
        {
            Assert.True(_applicationSummaryPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
        }

        [Then(@"I see the '(.*)' color banner")]
        public void ThenISeeTheColorBanner(string Color)
        {
            Assert.True(_applicationSummaryPage?.VerifyTheBannerColor(Color), $"The Banner {Color} is not as expected");
        }

        [Then(@"I verify the Reference number table for '([^']*)' application")]
        public void ThenIVerifyTheReferenceNumberTableForApplication(string status)
        {
            Assert.True(_applicationSummaryPage?.VerifyReferenceNumberTable(status));
        }

        [Then(@"I verify the Microchip Information table in Search result page")]
        public void ThenIVerifyTheMCInfoTable()
        {
            Assert.True(_applicationSummaryPage?.VerifyMicrochipInformationTable());
        }

        [Then(@"I verify the Pet Details table for '(.*)' in Search result page")]
        public void ThenIVerifyThePetDetailsTable(string Species)
        {
            Assert.True(_applicationSummaryPage?.VerifyPetDetailsTable(Species));
        }

        [Then(@"I verify the Pet Owner Details table in Search result page")]
        public void ThenIVerifyThePetOwnerDetailsTable()
        {
            Assert.True(_applicationSummaryPage?.VerifyPetOwnerDetailsTable());
        }

        [Then("I verify the Reference number table values {string} for {string} application")]
        public void ThenIVerifyTheReferenceNumberTableValuesForApplication(string values, string status)
        {
            Assert.True(_applicationSummaryPage?.VerifyRefNumTableValues(values, status),$"The Reference number table values are not matching");
        }

        [Then("I verify the Microchip table values {string} for {string} application")]
        public void ThenIVerifyTheMicrochipTableValuesForApplication(string values, string status)
        {
            Assert.True(_applicationSummaryPage?.VerifyMCTableValues(values, status), $"The Microchip table values are not matching");
        }

        [Then("I verify the Pet Details table values {string} for the species {string}")]
        public void ThenIVerifyThePetDetailsTableValuesForTheSpecies(string values, string species)
        {
            Assert.True(_applicationSummaryPage?.VerifyPetDetailsValues(values, species),$"The Pet Details table values are not matching");
        }

        [Then(@"I verify the Pet Owner Details table values '([^']*)' for the application")]
        public void ThenIVerifyPetOwnerDetailsTableValues(string Values)
        {
            Assert.True(_applicationSummaryPage?.VerifyPetOwnerDetailsValues(Values),
                        $"The Pet Owner Details table values are not matching");
        }

        [Then(@"I verify '([^']*)' section with '([^']*)' subheading and '([^']*)' check points")]
        public void ThenIverifySectionWithSubHeadingAndCheckPoints(string heading, string subHeading, string checkpoints)
        {
            Assert.True(_applicationSummaryPage?.VerifyChecksSection(heading, subHeading, checkpoints));
        }

        [Then(@"I should not see any radio button options in Checks section")]
        public void ThenIShouldNotSeeAnyRadioButtonOptionsInChecksSection()
        {
            Assert.True(_applicationSummaryPage?.VerifyChecksSectionRadioButtonsNotPresent());
        }

        [Then(@"The Application Summary is displayed for '(.*)' Application")]
        public void ThenTheApplicationSummaryIsDisplayed(String Status)
        {
            var pageTitle = "Your application summary";
            Assert.IsTrue(_applicationSummaryPage?.IsApplicationSummayPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I verify Checks section with radio buttons '([^']*)' and hint '([^']*)'")]
        public void ThenIverifyChecksSectionWithRadioButtonsAndHint(string radiobuttons, string hint)
        {
            Assert.True(_applicationSummaryPage?.VerifyChecksSectionRadioButtonsWithHints(radiobuttons, hint));
        }
    }
}