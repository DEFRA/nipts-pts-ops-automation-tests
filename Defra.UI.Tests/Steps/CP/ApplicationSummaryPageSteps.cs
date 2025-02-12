using BoDi;
using Defra.UI.Tests.Pages.CP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using static System.Collections.Specialized.BitVector32;

namespace Defra.UI.Tests.Steps.CP
{
    [Binding]
    public class ApplicationSummaryPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IApplicationSummaryPage? _applicationSummaryPage => _objectContainer.IsRegistered<IApplicationSummaryPage>() ? _objectContainer.Resolve<IApplicationSummaryPage>() : null;

        public ApplicationSummaryPageSteps (ScenarioContext context, IObjectContainer container)
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
        public void ThenISeeTheColorBanner(String Color)
        {
            Assert.True(_applicationSummaryPage?.VerifyTheBannerColor(Color), $"The Banner {Color} is not as expected");
        }

        [Then(@"I verify the Reference number table for '([^']*)' application")]
        public void ThenIVerifyTheReferenceNumberTableForApplication(String Status)
        {
            Assert.True(_applicationSummaryPage?.VerifyReferenceNumberTable(Status));
        }
        
        [Then(@"I verify the Issuing Authority table for '([^']*)' application")]
        public void ThenIVerifyTheIssuingAuthorityTable(String Status)
        {
            Assert.True(_applicationSummaryPage?.VerifyIssuingAuthorityTable(Status));
        }

        [Then(@"I verify the Microchip Information table in Search result page")]
        public void ThenIVerifyTheMCInfoTable()
        {
            Assert.True(_applicationSummaryPage?.VerifyMicrochipInformationTable());
        }

        [Then(@"I verify the Pet Details table for '(.*)' in Search result page")]
        public void ThenIVerifyThePetDetailsTable(String Species)
        {
            Assert.True(_applicationSummaryPage?.VerifyPetDetailsTable(Species));
        }

        [Then(@"I verify the Pet Owner Details table in Search result page")]
        public void ThenIVerifyThePetOwnerDetailsTable()
        {
            Assert.True(_applicationSummaryPage?.VerifyPetOwnerDetailsTable());
        }

        [Then(@"I verify the Reference number table values '([^']*)' for '([^']*)' application")]
        public void ThenIVerifyRefNumTableValues(string values, string status)
        {
            Assert.True(_applicationSummaryPage?.VerifyRefNumTableValues(values, status),
                        $"The Reference number table values are not matching");
        }
        
        [Then(@"I verify the Microchip table values '([^']*)' for '([^']*)' application")]
        public void ThenIVerifyMCTableValues(string values, string status)
        {
            Assert.True(_applicationSummaryPage?.VerifyMCTableValues(values, status),
                        $"The Microchip table values are not matching");
        } 
        
        [Then(@"I verify the Pet Details table values '([^']*)' for the species '(.*)'")]
        public void ThenIVerifyPetDetailsTableValues(string Values, string Species)
        {
            Assert.True(_applicationSummaryPage?.VerifyPetDetailsValues(Values, Species),
                        $"The Pet Details table values are not matching");
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
            Assert.True(_applicationSummaryPage?.VerifyChecksSectionRadioButtons());
        }
    }
}