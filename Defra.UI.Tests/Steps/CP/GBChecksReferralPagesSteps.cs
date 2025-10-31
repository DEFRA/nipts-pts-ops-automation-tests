using AventStack.ExtentReports.Gherkin.Model;
using Defra.UI.Tests.Data.Users;
using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Pages.CP.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Steps.CP
{
    [Binding]
    public class GBChecksReferralPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IWelcomePage? _welcomePage => _objectContainer.IsRegistered<IWelcomePage>() ? _objectContainer.Resolve<IWelcomePage>() : null;
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;
        private IGBChecksReferralPage? _gbChecksReferralPage => _objectContainer.IsRegistered<IGBChecksReferralPage>() ? _objectContainer.Resolve<IGBChecksReferralPage>() : null;
        private IRouteCheckingPage? _routeCheckingPage => _objectContainer.IsRegistered<IRouteCheckingPage>() ? _objectContainer.Resolve<IRouteCheckingPage>() : null;
        private ISearchDocumentPage? _searchDocumentPage => _objectContainer.IsRegistered<ISearchDocumentPage>() ? _objectContainer.Resolve<ISearchDocumentPage>() : null;
        private IApplicationSummaryPage? _applicationSummaryPage => _objectContainer.IsRegistered<IApplicationSummaryPage>() ? _objectContainer.Resolve<IApplicationSummaryPage>() : null;
        private IReportNonCompliancePage? _reportNonCompliancePage => _objectContainer.IsRegistered<IReportNonCompliancePage>() ? _objectContainer.Resolve<IReportNonCompliancePage>() : null;

        public GBChecksReferralPageSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I should navigate to Referred to SPS page")]
        public void ThenIShouldNavigateToReferredToSPSPage()
        {
            Assert.IsTrue(_gbChecksReferralPage?.IsPageLoaded(), "Referred to SPS page not loaded ");
        }

        [When(@"I click first link in PTD or Reference number")]
        public void WhenIClickFirstLinkInPTDOrReferenceNumber()
        {
            _gbChecksReferralPage?.ClickPTDOrReferenceNumber();
        }

        [Then(@"I should navigate to GB check report page")]
        public void ThenIShouldNavigateToGBCheckReportPage()
        {
            Assert.IsTrue(_gbChecksReferralPage?.IsGBCheckReportPageLoaded(), "GB check report page not loaded");
        }

        [Then(@"I should navigate to Update referral outcome page")]
        public void ThenIShouldNavigateToUpdateReferralOutcomePage()
        {
            Assert.IsTrue(_gbChecksReferralPage?.IsGBUpdateReferralOutcomePageLoaded(), "GB check report page not loaded");
        }

        [Then(@"I should see '([^']*)' and '([^']*)' subheadings")]
        public void ThenIShouldSeeAndSubheadings(string subHeading1, string subHeading2)
        {
            Assert.IsTrue(_gbChecksReferralPage?.CheckReportPageSubheadings(subHeading1, subHeading2), "GB check report page subheadings are not correct");
        }

        [When("I click the View button from Checks page")]
        public void WhenIClickTheViewButtonFromChecksPage()
        {
            _gbChecksReferralPage?.ClickViewLink();
        }

        [Then(@"I should see '([^']*)' as Check outcome")]
        public void ThenIShouldSeeAsCheckOutcome(string checkOutcome)
        {
            Assert.IsTrue(_gbChecksReferralPage?.CheckOutcome(checkOutcome), "Check outcome in GB check report page is not correct");
        }

        [Then(@"I should see '([^']*)' as Reason for referral")]
        public void ThenIShouldSeeAsReasonForReferral(string referralReason)
        {
            Assert.IsTrue(_gbChecksReferralPage?.ReasonForReferral(referralReason), "Reason for referral in GB check report page is not correct");
        }

        [Then(@"I should see '([^']*)' as Microchip number found in scan")]
        public void ThenIShouldSeeAsMicrochipNumberFoundInScan(string mcNumber)
        {
            Assert.IsTrue(_gbChecksReferralPage?.MCNumberFoundInScan(mcNumber), "Microchip number found in scan in GB check report page is not correct");
        }

        [Then(@"I should see '([^']*)' as Details of outcome")]
        public void ThenIShouldSeeAsDetailsOfOutcome(string outcomeDetails)
        {
            Assert.IsTrue(_gbChecksReferralPage?.VerifyDetailsOfOutcome(outcomeDetails), "Details of outcome in GB check report page is not correct");
        }

        [Then(@"I should see '([^']*)' as Additional comments")]
        public void ThenIShouldSeeAsAdditionalComments(string additionalComments)
        {
            Assert.IsTrue(_gbChecksReferralPage?.AdditionalComments(additionalComments), "Additional comments in GB check report page is not correct");
        }

        [Then(@"I should not see Additional Comments")]
        public void ThenIShouldNotSeeAdditionalComments()
        {
            Assert.IsTrue(_gbChecksReferralPage?.VerifyAdditionalCommentsNotPresent(), "Additional comments in GB check report page is Present");
        }

        [Then(@"I should see '([^']*)' as GB checker name")]
        public void ThenIShouldSeeAsGBCheckerName(string gbChecker)
        {
            Assert.IsTrue(_gbChecksReferralPage?.GBChecker(gbChecker), "GB Checker's name in GB check report page is not correct");
        }

        [Then(@"I should see '([^']*)' as Route")]
        public void ThenIShouldSeeAsRoute(string route)
        {
            Assert.IsTrue(_gbChecksReferralPage?.RouteInGBCheckPage(route), "Route in GB check report page is not correct");
        }

        [Then(@"I should see current date as Scheduled departure date")]
        public void ThenIShouldSeeCurrentDateAsScheduledDepartureDate()
        {
            Assert.IsTrue(_gbChecksReferralPage?.ScheduledDepartDate(), "Scheduled departure date in GB check report page is not correct");
        }

        [Then(@"I should see '([^']*)' as Scheduled departure time")]
        public void ThenIShouldSeeAsScheduledDepartureTime(string departTime)
        {
            Assert.IsTrue(_gbChecksReferralPage?.ScheduledDepartTime(departTime), "Scheduled departure time in GB check report page is not correct");
        }

        [When(@"I click on the '(.*)' application that is in checks Needed SPS Outcome")]
        public void WhenIClickOnChecksNeededLink(string ApplicationStatus)
        {
            if (ApplicationStatus.ToUpper().Equals("APPROVED") || ApplicationStatus.ToUpper().Equals("CANCELLED"))
            {
                var PTDreferenceNumber = _scenarioContext.Get<string>("PTDReferenceNumber");
                Assert.IsTrue(_gbChecksReferralPage?.ClickApplicationRef(PTDreferenceNumber), "The reference number is not present or Not able to click on " + PTDreferenceNumber);
            }
            else
            {
                var referenceNumber = _scenarioContext.Get<string>("ReferenceNumber");
                Assert.IsTrue(_gbChecksReferralPage?.ClickApplicationRef(referenceNumber), "The reference number is not present or Not able to click on " + referenceNumber);
            }
        }

        [Then(@"The Background colour of '(.*)' in '(.*)' application is '(.*)'")]
        public void ThenIVerifyBGColorOfTheStaus(string travelStatus, string ApplicationStatus, string color)
        {
            if (ApplicationStatus.ToUpper().Equals("APPROVED") || ApplicationStatus.ToUpper().Equals("CANCELLED"))
            {
                var PTDreferenceNumber = _scenarioContext.Get<string>("PTDReferenceNumber");
                Assert.IsTrue(_gbChecksReferralPage?.VerifyBGColorforTravelStatus(PTDreferenceNumber, travelStatus, color.ToUpper()), "The Background color of the SPS Status is not matching");
            }
            else
            {
                var referenceNumber = _scenarioContext.Get<string>("ReferenceNumber");
                Assert.IsTrue(_gbChecksReferralPage?.VerifyBGColorforTravelStatus(referenceNumber, travelStatus, color.ToUpper()), "The Background color of the SPS Status is not matching");
            }
        }

        [Then(@"I verify the travel status for the '(.*)' application is '(.*)'")]
        public void WhenIVerifyTheTravelStatus(String ApplicationStatus, string travelStatus)
        {
            if (ApplicationStatus.ToUpper().Equals("APPROVED") || ApplicationStatus.ToUpper().Equals("CANCELLED"))
            {
                var PTDreferenceNumber = _scenarioContext.Get<string>("PTDReferenceNumber");
                Assert.IsTrue(_gbChecksReferralPage?.VerifyTravelStatus(PTDreferenceNumber, travelStatus.ToUpper()), "Travel Status is not set to " + travelStatus);
            }
            else
            {
                var referenceNumber = _scenarioContext.Get<string>("ReferenceNumber");
                Assert.IsTrue(_gbChecksReferralPage?.VerifyTravelStatus(referenceNumber, travelStatus.ToUpper()), "Travel Status is not set to " + travelStatus);
            }
        }

        [When(@"I click Update referral outcome button")]
        public void WhenIClickUpdateReferralOutcomeButton()
        {
            _gbChecksReferralPage?.ClickOnUpdateReferralOutcomeButton();
        }

        [Then(@"I should see all the PTD numbers should be in correct format and starts with '([^']*)'")]
        public void ThenIShouldSeeAllThePTDNumbersShouldBeInCorrectFormatAndStartsWith(string ptdNumberPrefix)
        {
            Assert.IsTrue(_gbChecksReferralPage?.CheckPTDNumberFormat(ptdNumberPrefix), "PTD Number format in Referred to SPS page is not correct");
        }

        [Then("I should see route details '([^']*)' date and time '([^']*)' below the title of the page")]
        public void ThenIShouldSeeRouteDetailsDateAndTimeBelowTheTitleOfThePage(string route, string departureTime)
        {
            Assert.True(_gbChecksReferralPage?.CheckRouteDetailOnReferredToSPSPage(route, departureTime), "Given route displayed is not displayed properly");
        }

        [When(@"I click the reference number '(.*)' link")]
        public void WhenIClickTheReferenceNumberLink(string referenceNumber)
        {
            Assert.IsTrue(_gbChecksReferralPage?.ClickApplicationRef(referenceNumber), "The reference number is not present or Not able to click on " + referenceNumber);
        }

        [When(@"I click View link in Fail Referred to SPS row with departure time '([^']*)'")]
        public void WhenIClickViewLinkInFailReferredToSPSRowWithDepartureTime(string departureTime)
        {
            _gbChecksReferralPage?.ClickViewLink(departureTime);
        }

        [Then(@"I verify the Referred to SPS page table column names as '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public void ThenIVerifyTheReferredToSPSPageTableColumnNamesAs(string ptdOrRefNumber, string pet, string microchip, string travelBy, string spsOutcome)
        {
            Assert.IsTrue(_gbChecksReferralPage?.CheckReferredToSPSTableLabels(ptdOrRefNumber, pet, microchip, travelBy, spsOutcome), "Referred to SPS page table column names are not displayed as expected");
        }

        [Then(@"I verify the Referred to SPS page table column values as '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public void ThenIVerifyTheReferredToSPSPageTableColumnValuesAs(string ptdOrRefNumber, string pet, string microchip, string travelBy, string spsOutcome)
        {
            Assert.IsTrue(_gbChecksReferralPage?.CheckReferredToSPSTableValues(ptdOrRefNumber, pet, microchip, travelBy, spsOutcome), "Referred to SPS page table column values are not displayed as expected");
        }

        [Then(@"I verify the PTDOrRefNum '([^']*)' is not repeated in the table")]
        public void ThenIVerifyThePTDOrRefNumIsNotRepeatedInTheTable(string ptdOrRefNumber)
        {
            Assert.IsTrue(_gbChecksReferralPage?.CheckPTDOrRefNumDuplicates(ptdOrRefNumber), "PTD or Reference number is duplicated in the Referred to SPS page table");
        }

        [Then(@"I should see the count next to Pass as '([^']*)' in the table contains departure time '([^']*)'")]
        public void ThenIShouldSeeTheCountNextToPassAsInTheTableContainsDepartureTime(string count, string departureTime)
        {
            Assert.IsTrue(_gbChecksReferralPage?.CheckPassCount(count, departureTime), "Pass count is not correct");
        }

        [Then(@"I should see the count next to Fail Referred to SPS as '([^']*)' in the table contains departure time '([^']*)'")]
        public void ThenIShouldSeeTheCountNextToFailReferredToSPSAsInTheTableContainsDepartureTime(string count, string departureTime)
        {
            Assert.IsTrue(_gbChecksReferralPage?.CheckFailCount(count, departureTime), "Fail count is not correct");
        }

        [Then(@"I should see current date and current time as Date and time checked")]
        public void ThenIShouldSeeCurrentDateAndCurrentTimeAsDateAndTimeChecked()
        {
            Assert.IsTrue(_gbChecksReferralPage?.DateAndTimeChecked(), "Date and time checked is incorrect");
        }

        [Then(@"I click View link in Fail row with departure time '([^']*)' and check for pagination")]
        public void ThenIClickViewLinkInFailRowWithDepartureTimeAndCheckForPagination(string departureTime)
        {
            _gbChecksReferralPage?.ClickViewLink(departureTime);
            Assert.IsTrue(_gbChecksReferralPage?.CheckPagination(), "Pagination is not correct");
            Assert.IsTrue(_gbChecksReferralPage?.CheckDirectPageNavigation(), "Direct page navigation is not correct");
        }

        [Then(@"I add records in referrals list in Referred to SPS page '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public void ThenIAddRecordsInReferralsListInReferredToSPSPage(string transportType, string routeOption, string departTime, string MCCheckbox, string GBOutcome, string passengerType, string submittedMessage)
        {
            var referenceNumber = new[] { "VSP7XJCA", "ZQNIKXQD", "7RTYVEJC", "SEEQP2Q9", "BPBXU589", "LQSDFZ57", "Q5PPR5R8", "7O8OZZ57", "Q7BN4KI6", "4COBZ8B8", "O99TAXJE" };
            var radioButton = "Search by application number";

            foreach (var reference in referenceNumber)
            {
                _routeCheckingPage?.SelectTransportationOption(transportType);
                _routeCheckingPage?.SelectFerryRouteOption(routeOption);
                _routeCheckingPage?.SetScheduledDepartureTime(departTime);
                _routeCheckingPage?.SelectSaveAndContinue();
                _welcomePage?.FooterSearchButton();
                _searchDocumentPage?.SelectSearchRadioOption(radioButton);
                _searchDocumentPage?.EnterApplicationNumber(reference);
                _searchDocumentPage?.SearchButton();
                _applicationSummaryPage?.SelectReferToSPSRadioButton();
                _applicationSummaryPage?.SelectSaveAndContinue();
                _reportNonCompliancePage?.ClickOnMCCheckbox(MCCheckbox);
                _reportNonCompliancePage?.ClickGBOutcomeCheckbox(GBOutcome);
                _reportNonCompliancePage?.SelectTypeOfPassenger(passengerType);
                _reportNonCompliancePage?.ClickSaveOutComeButton();
                Assert.True(_reportNonCompliancePage?.VerifyInfoSubmittedMessage(submittedMessage));
                _welcomePage?.HeadersChangeLink();
            }
        }

        [Then(@"I Should not see the View link in the table contains departure time '([^']*)'")]
        public void ThenIShouldNotSeeViewLink(string departureTime)
        {
            Assert.IsTrue(_gbChecksReferralPage?.IsViewLinkPresent(departureTime), "View Link is Present");
        }
    }
}