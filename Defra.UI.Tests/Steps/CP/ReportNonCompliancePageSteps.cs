using BoDi;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Pages.CP.Pages;
using Dynamitey.DynamicObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Runtime.Intrinsics.X86;
using TechTalk.SpecFlow;
using static Microsoft.Dynamics365.UIAutomation.Api.Pages.ActivityFeed;
using static System.Net.Mime.MediaTypeNames;

namespace Defra.UI.Tests.Steps.CP
{

    [Binding]
    public class ReportNonCompliancePageSteps
    {

        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private ISummaryPage? summaryPage => _objectContainer.IsRegistered<ISummaryPage>() ? _objectContainer.Resolve<ISummaryPage>() : null;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IReportNonCompliancePage? _reportNonCompliancePage => _objectContainer.IsRegistered<IReportNonCompliancePage>() ? _objectContainer.Resolve<IReportNonCompliancePage>() : null;

        public ReportNonCompliancePageSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I should navigate to Report non-compliance page")]
        public void ThenIShouldNavigateToReportNon_CompliancePage()
        {
            Assert.IsTrue(_reportNonCompliancePage?.IsPageLoaded(), "Report non-compliance page not loaded ");
        }

        [When(@"I click Report non-compliance button from Report non-compliance page")]
        public void WhenIClickReportNon_ComplianceButtonFromReportNon_CompliancePage()
        {
            _reportNonCompliancePage?.SelectReportNonComplianceButton();
        }

        [Then(@"I click Pet Travel Document details link dropdown")]
        public void ThenIClickPetTravelDocumentDetailsLinkDropdown()
        {
            _reportNonCompliancePage?.ClickPetTravelDocumentDetailsLnk();
        }

        [Then(@"I should see a table name as '([^']*)'")]
        public void ThenIShouldSeeATableNameAs(string tableName)
        {
            Assert.IsTrue(_reportNonCompliancePage?.VerifyTheTableNameInPTDLink(tableName), "Pet Travel Document (PTD)");
        }

        [Then(@"I should see a table name for approved and revoked status as '([^']*)'")]
        public void ThenIShouldSeeATableNameForApprovedAndRevokedStatusAs(string tableName)
        {
            Assert.IsTrue(_reportNonCompliancePage?.VerifyTableNameForApprovedAndRevokedInPTDLink(tableName), "Application Details");
        }

        [Then(@"I Verify the PTD number '([^']*)'")]
        public void ThenIVerifyThePTDNumber(string ptdNumber)
        {
            Assert.IsTrue(_reportNonCompliancePage?.VerifyThePTDNumber(ptdNumber), "The PTD number is not displayed");
        }

        [Then(@"I verify the date of issuance '([^']*)'")]
        public void ThenIVerifyTheDateOfIssuance(string dateOfIssuance)
        {
            Assert.IsTrue(_reportNonCompliancePage?.VerifyTheDateOfIssuance(dateOfIssuance), "The date of issuance is not displayed");
        }

        [Then(@"I Verify the reference number '([^']*)'")]
        public void ThenIVerifyTheReferenceNumber(string refereneNumber)
        {
            Assert.IsTrue(_reportNonCompliancePage?.VerifyTheReferenceNumber(refereneNumber), "The reference number is not displayed");
        }

        [Then(@"I Verify status '([^']*)' on Report non-compliance page")]
        public void ThenIVerifyStatusOnReportNon_CompliancePage(string applicationStatus)
        {
            Assert.IsTrue(_reportNonCompliancePage?.VerifyTheExpectedStatus(applicationStatus), "The submitted application is not in expected status");
        }

        [Then(@"I click '([^']*)' in Passenger details")]
        public void ThenIClickInPassengerDetails(string passengerType)
        {
            _reportNonCompliancePage?.SelectTypeOfPassenger(passengerType);
        }

        [Then(@"I should see an error message ""([^""]*)"" in Report non-compliance page")]
        public void ThenIShouldSeeAnErrorMessageInReportNon_CompliancePage(string errorMessage)
        {
            Assert.True(_reportNonCompliancePage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
        }

        [Then(@"I should not see the Pet Travel Document section for '([^']*)' status")]
        public void ThenIShouldNotSeeThePetTravelDocumentSectionForStatus(string status)
        {
            Assert.False(_reportNonCompliancePage?.CheckPetTravelDocumentDetailsSection(status), "Pet Travel Document Section does not exists as expected");
        }

        [Then(@"I should see the Pet Travel Document section with status '([^']*)'")]
        public void ThenIShouldSeeThePetTravelDocumentSectionWithStatus(string status)
        {
            Assert.True(_reportNonCompliancePage?.CheckPetTravelDocumentDetailsSection(status), "Pet Travel Document Section does not exists as expected");
        }

        [Then(@"I should see the '([^']*)' heading with hint '([^']*)'")]
        public void ThenIShouldSeeTheHeadingWithHint(string reasons,string hint)
        {
            Assert.True(_reportNonCompliancePage?.VerifyReasonsHeadingWithHint(reasons,hint), "Reasons Heading and Hint does not exists as expected");
        }

        [Then(@"I verify the GB Outcome '(.*)' checkboxes")]
        public void ThenIVerifyTheGBOutcomeCheckboxes(string checkboxValues)
        {
            Assert.True(_reportNonCompliancePage?.VerifyGBOutcomeCheckboxes(checkboxValues),"The GB Outcome checkbox values are not correct");
        }

        [Then(@"I Verify the GB and SPS Outcomes are not selected")]
        public void ThenIVerifyGBAndSPSOutcomesAreNotSelected()
        {
            Assert.False(_reportNonCompliancePage?.VerifyGBCheckboxesAreNotChecked());
            Assert.False(_reportNonCompliancePage?.VerifySPSCheckboxesAreNotChecked());
        }
        
        [Then(@"I verify the SPS Outcome '(.*)' options")]
        public void ThenIVerifyTheSPSOutcomeOptions(string checkboxValues)
        {
            Assert.True(_reportNonCompliancePage?.VerifySPSOutcomeCheckboxes(checkboxValues),"The SPS Outcome checkbox values are not correct");
        }
        
        [Then(@"I verify the Details of Outcome label")]
        public void ThenIVerifyTheDetailsOfOutcome()
        {
            Assert.True(_reportNonCompliancePage?.VerifyDetailsOfOutcome(),"The Details of Outcome label is incorrect");
        }

        [Then(@"I verify the Details of Outcome textarea maximum length is '(.*)'")]
        public void ThenIVerifyTheDetailsOfOutcomeTextareaMaxLength(string maxLength)
        {
            Assert.True(_reportNonCompliancePage?.VerifyMaxLengthOfDetailsOfOutcomeTextarea(maxLength), "The Details of Outcome textarea maxlength is not "+ maxLength);
        }

        [Then(@"I verify any relavant comments section")]
        public void ThenIVerifyAnyRelavantCommentsSection()
        {
            Assert.True(_reportNonCompliancePage?.VerifyAnyRelavantCommentsTextarea("Any relevant comments", "This could be more information about the checks or any risks you've identified. Do not include personal or sensitive information.", "500"));
        }

        [Then(@"I should see '([^']*)' subheading under '([^']*)' section")]
        public void ThenIShouldSeeSubheadingUnderSection(string subHeading, string sectionName)
        {
            Assert.True(_reportNonCompliancePage?.VerifyTypeOfPassengerSubheading(subHeading, sectionName), "Type of passenger subheading under Passenger details section is not displayed properly");
        }

        [Then(@"I should see the '([^']*)' subheading")]
        public void ThenIShouldSeeTheSubheading(string subHeading)
        {
            Assert.True(_reportNonCompliancePage?.VerifyVisualCheckSubheading(subHeading), "Visual check subheading is not displayed");
        }
        [Then(@"I should click '([^']*)' link next to the subheading")]
        public void ThenIShouldClickLinkNextToTheSubheading(string linkName)
        {
            Assert.True(_reportNonCompliancePage?.VerifyPetDetailsFromPTDLink(linkName), "Pet details from PTD link is not displayed");
        }
        [Then(@"I should see a checkbox '([^']*)' is not selected")]
        public void ThenIShouldSeeACheckboxIsNotSelected(string checkBoxValue)
        {
            Assert.True(_reportNonCompliancePage?.VerifyPetDoesNotMatchThePTDCheckBox(checkBoxValue), "Pet does not match the PTD check box is not displayed or selected by default");
        }
        [Then(@"I should see a table '([^']*)'")]
        public void ThenIShouldSeeATable(string tableName)
        {
            Assert.True(_reportNonCompliancePage?.VerifyVisualCheckTableName(tableName), "Visual check table name is not displayed properly");
        }
        [Then(@"I should see Species '([^']*)' Breed '([^']*)' Sex '([^']*)' Date of birth '([^']*)' Colour '([^']*)' and Significant features '([^']*)' in the table")]
        public void ThenIShouldSeeSpeciesBreedSexDateOfBirthColourSignificantFeaturesInTheTable(string species, string breed, string sex, string dob, string colour, string significantFeature)
        {
            Assert.True(_reportNonCompliancePage?.VerifyVisualCheckTableFields(species, breed, sex, dob, colour, significantFeature), "Field values in Visual check table are not displayed properly");
        }
        [Then(@"I should see the '([^']*)' subheading in visual check section")]
        public void ThenIShouldSeeTheSubheadingInVisualCheckSection(string subHeading)
        {
            Assert.True(_reportNonCompliancePage?.VerifyOtherIssuesSubheading(subHeading), "Other issues subheading in Visual check section is not displayed");
        }
        [Then(@"I verify the other issues '(.*)' checkboxes")]
        public void ThenIVerifyTheOtherIssuesCheckboxes(string checkboxOptions)
        {
            Assert.True(_reportNonCompliancePage?.VerifyOtherIssuesCheckboxes(checkboxOptions), "The other issues in Visual check section checkbox values are not correct");
        }
        [Then(@"I should see a hint '([^']*)' next to Other reason option")]
        public void ThenIShouldSeeAHintNextToOtherReasonOption(string hint)
        {
            Assert.True(_reportNonCompliancePage?.VerifyOtherReasonOptionHint(hint), "Other reason checkbox hint is not displayed");
        }
        [Then(@"I should see no checkboxes are selected in other issues section")]
        public void ThenIShouldSeeNoCheckBoxesAreSelectedInOtherIssuesSection()
        {
            Assert.False(_reportNonCompliancePage?.VerifyOtherIssuesCheckboxesAreNotChecked());
        }

        [Then(@"I Verify the Microchip section")]
        public void ThenISeeMicrochipSection()
        {
            Assert.True(_reportNonCompliancePage?.VerifyMicrochipSection(), $"The Microchip section is not as expected");
        }

        [Then(@"I expand and verify Microchip details '(.*)' from PTD table")]
        public void ThenIExpandAndVerifyMicrochipDetailsFromPTDTable(string MCDetails)
        {
            Assert.True(_reportNonCompliancePage?.VerifyMCDetailsPTDTableWithValues(MCDetails),
                        $"The Microchip details from PTD table is not as expected");
        }

        [When(@"I enter the Microchip number in '(.*)' in Report non-compliance page")]
        public void WhenIEnterMCNumber(string MCNumber)
        {
            _reportNonCompliancePage?.EnterMCNumber(MCNumber);
        }

        [When(@"I Select the '(.*)' Microchip Checkbox")]
        public void WhenISelectTheMCCheckbox(string MCCheckbox)
        {
            _reportNonCompliancePage?.ClickOnMCCheckbox(MCCheckbox);
        } 
        
        [When(@"When I click '(.*)' GB Outcome")]
        public void WhenISelectGBOutcome(string GBOutcome)
        {
            _reportNonCompliancePage?.ClickGBOutcomeCheckbox(GBOutcome);
        }
    }
}