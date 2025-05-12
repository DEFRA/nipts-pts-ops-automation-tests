using Reqnroll.BoDi;
using Defra.UI.Tests.Data.Users;
using Defra.UI.Tests.Pages.CP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Defra.UI.Tests.Pages.CP.Pages;
using System.Drawing;

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

        public GBChecksReferralPageSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"I click View link in Fail Referred to SPS row with count more than {int}")]
        public void WhenIClickViewLinkInFailReferredToSPSRowWithCountMoreThanNumber(int number)
        {
            _gbChecksReferralPage?.ClickViewLink();
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

        [Then(@"I should see '([^']*)' and '([^']*)' subheadings")]
        public void ThenIShouldSeeAndSubheadings(string subHeading1, string subHeading2)
        {
            Assert.IsTrue(_gbChecksReferralPage?.CheckReportPageSubheadings(subHeading1, subHeading2), "GB check report page subheadings are not correct");
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

        [Then(@"I should see '([^']*)' as Additional comments")]
        public void ThenIShouldSeeAsAdditionalComments(string additionalComments)
        {
            Assert.IsTrue(_gbChecksReferralPage?.AdditionalComments(additionalComments), "Additional comments in GB check report page is not correct");
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
        
        [When(@"I click Conduct a SPS check button")]
        public void WhenIClickOnConductSPSCheclButton()
        {
            _gbChecksReferralPage?.ClickOnConductSPSCheckButton();
        }

        [Then(@"I should see all the PTD numbers should be in correct format and starts with '([^']*)'")]
        public void ThenIShouldSeeAllThePTDNumbersShouldBeInCorrectFormatAndStartsWith(string ptdNumberPrefix)
        {
            Assert.IsTrue(_gbChecksReferralPage?.CheckPTDNumberFormat(ptdNumberPrefix), "PTD Number format in Referred to SPS page is not correct");
        }
    }
}