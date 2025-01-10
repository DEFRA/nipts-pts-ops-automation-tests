using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class _homePageSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IHomePage _homePage;

        public _homePageSteps(ScenarioContext context, IHomePage homePage)
        {
            _scenarioContext = context;
            _homePage = homePage;
        }

        [Then(@"I should navigate to Lifelong pet travel documents page")]
        public void ThenIShouldNavigateToLifelongPetTravelDocumentsPage()
        {
            Assert.True(_homePage?.IsPageLoaded(), "Apply for a pet travel document not loaded");
        }

        [When(@"I click Apply for a document button")]
        public void WhenIClickApplyForADocumentButton()
        {
            _homePage?.ClickApplyForPetTravelDocument();
        }

        [Then(@"I click the Feedback Link")]
        public void ThenIClickTheFeedbackLink()
        {
            _homePage?.ClickFeedbackLink();
        }

        [Then(@"I should navigate to the Feedback details correct page")]
        public void ThenIShouldNavigateToTheFeedbackDetailsCorrectPage()
        {
            string currentURL = DriverCommand.GetCurrentUrl;
            currentURL.Contains("defragroup.eu.qualtrics.com/");
        }

        [Then(@"I click the Gethelp Link")]
        public void ThenIClickTheGethelpLink()
        {
            _homePage?.ClickGethelpLink();
        }

        [Then(@"I should navigate to the Gethelp details correct page")]
        public void ThenIShouldNavigateToTheGethelpDetailsCorrectPage()
        {
            var pageTitle = "Get help applying";
            Assert.IsTrue(_homePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I click the AccessibilityStatement Link")]
        public void ThenIClickTheAccessibilityStatementLink()
        {
            _homePage?.ClickAccessibilityStatementLink();
        }

        [Then(@"I should navigate to the AccessibilityStatement details correct page")]
        public void ThenIShouldNavigateToTheAccessibilityStatementDetailsCorrectPage()
        {
            var pageTitle = "Accessibility statement for taking a dog, cat or ferret from Great Britain to Northern Ireland";
            Assert.IsTrue(_homePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I click the Cookies Link")]
        public void ThenIClickTheCookiesLink()
        {
            _homePage?.ClickCookiesLink();
        }

        [Then(@"I should navigate to the Cookies details correct page")]
        public void ThenIShouldNavigateToTheCookiesDetailsCorrectPage()
        {
            var pageTitle = "Cookies";
            Assert.IsTrue(_homePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I click the PrivacyNotice Link")]
        public void ThenIClickThePrivacyNoticeLink()
        {
            _homePage?.ClickPrivacyNoticeLink();
        }

        [Then(@"I should navigate to the PrivacyNotice details correct page")]
        public void ThenIShouldNavigateToThePrivacyNoticeDetailsCorrectPage()
        {
            var pageTitle = "Pet travel scheme privacy notice";
            Assert.IsTrue(_homePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I click the TermsAndConditions Link")]
        public void ThenIClickTheTermsAndConditionsLink()
        {
            _homePage?.ClickTermsAndConditionsLink();
        }

        [Then(@"I should navigate to the TermsAndConditions details correct page")]
        public void ThenIShouldNavigateToTheTermsAndConditionsDetailsCorrectPage()
        {
            var pageTitle = "Terms and conditions for taking a dog, cat or ferret from Great Britain to Northern Ireland";
            Assert.IsTrue(_homePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I click the CrownCopyright Link")]
        public void ThenIClickTheCrownCopyrightLink()
        {
            _homePage?.ClickCrownCopyrightLink();
        }

        [Then(@"I should navigate to the CrownCopyright details correct page")]
        public void ThenIShouldNavigateToTheCrownCopyrightDetailsCorrectPage()
        {
            string currentURL = DriverCommand.GetCurrentUrl;
            currentURL.Contains("https://www.nationalarchives.gov.uk/information-management/re-using-public-sector-information/uk-government-licensing-framework/crown-copyright/");
        }

        [Then(@"I should navigate to Manage account")]
        public void ThenIShouldNavigateToManageAccount()
        {
            _homePage?.ClickOnManageAccountLink();
        }

        [When(@"I have clicked the View hyperlink from home page")]
        public void WhenIHaveClickedTheViewHyperlinkFrom_homePage()
        {
            var petName = _scenarioContext.Get<string>("PetName");
            _homePage?.ClickViewLink(petName);
        }

        [Then(@"I should see the application in '([^']*)' status")]
        public void ThenIShouldSeeTheApplicationInStatus(string applicationStatus)
        {
            var petName = _scenarioContext.Get<string>("PetName");

            Assert.IsTrue(_homePage?.VerifyTheExpectedStatus(petName, applicationStatus), $"The submitted application is not in expected status of '{applicationStatus}'");
        }
    }
}