using Reqnroll.BoDi;
using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using AventStack.ExtentReports.Gherkin.Model;
using Defra.UI.Tests.Pages.AP.Classes;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class HomePageWelshSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IHomePageWelsh? HomePageWelsh => _objectContainer.IsRegistered<IHomePageWelsh>() ? _objectContainer.Resolve<IHomePageWelsh>() : null;

        public HomePageWelshSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"I click '([^']*)' link to change the language")]
        public void WhenIClickLinkToChangeTheLanguage(string language)
        {
            HomePageWelsh.ClickLanguageLnk(language);
        }

        [Then(@"I should see the heading of dashboard page changed to Welsh")]
        public void ThenIShouldSeeTheHeadingOfDashboardPageChangedToWelsh()
        {
            Assert.IsTrue(HomePageWelsh?.VerifyDashboardHeadingInWelsh());
        }

        [Then(@"I click the welsh feedback link")]
        public void ThenIClickTheWelshFeedbackLink()
        {
            HomePageWelsh?.ClickWelshFeedbackLink();
        }

        [Then(@"I click the welsh PrivacyNotice link")]
        public void ThenIClickTheWelshPrivacyNoticeLink()
        {
            HomePageWelsh?.ClickWelshPrivacyNoticeLink();
        }

        [Then(@"I click the welsh cookies link")]
        public void ThenIClickTheWelshCookiesLink()
        {
            HomePageWelsh?.ClickWelshCookiesLink();
        }

        [Then(@"I should navigate to the welsh cookies details correct page opens in same tab")]
        public void ThenIShouldNavigateToTheWelshCookiesDetailsCorrectPageOpensInSameTab()
        {
            var pageTitle = "Cwcis";
            Assert.IsTrue(HomePageWelsh?.VerifyTheLinkOpensInSameTab());
            Assert.IsTrue(HomePageWelsh?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I click on welsh Back button")]
        public void ThenIClickOnWelshBackButton()
        {
            HomePageWelsh?.ClickWelshBackButton();
        }

        [Then(@"I should navigate to Lifelong pet travel documents page in Welsh")]
        public void ThenIShouldNavigateToLifelongPetTravelDocumentsPageInWelsh()
        {
            Assert.True(HomePageWelsh?.IsPageLoaded(), "Dashboard page in welsh not loaded");
        }


        /*[When(@"I click Apply for a document button")]
         public void WhenIClickApplyForADocumentButton()
         {
             HomePage?.ClickApplyForPetTravelDocument();
         }*/


         [Then(@"I click the welsh AccessibilityStatement Link")]
         public void ThenIClickTheWelshAccessibilityStatementLink()
         {
            HomePageWelsh?.ClickAccessibilityStatementLink();
         }

         [Then(@"I should navigate to the welsh AccessibilityStatement details correct page opens in same tab")]
         public void ThenIShouldNavigateToTheWelshAccessibilityStatementDetailsCorrectPageOpensInSameTab()
         {
             var pageTitle = "Datganiad hygyrchedd ar gyfer 'Mynd â chi, cath neu ffured o Brydain Fawr i Ogledd Iwerddon'";
             Assert.IsTrue(HomePageWelsh?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
             Assert.IsTrue(HomePageWelsh?.VerifyTheLinkOpensInSameTab());
         }

       /*  [Then(@"I click the Cookies Link")]
         public void ThenIClickTheCookiesLink()
         {
             HomePage?.ClickCookiesLink();
         }


         [Then(@"I click the PrivacyNotice Link")]
         public void ThenIClickThePrivacyNoticeLink()
         {
             HomePage?.ClickPrivacyNoticeLink();
         }

         [Then(@"I should navigate to the PrivacyNotice details correct page")]
         public void ThenIShouldNavigateToThePrivacyNoticeDetailsCorrectPage()
         {
             var pageTitle = "Pet travel scheme privacy notice";
             Assert.IsTrue(HomePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
         } */

         [Then(@"I click the welsh TermsAndConditions Link")]
         public void ThenIClickTheWelshTermsAndConditionsLink()
         {
            HomePageWelsh?.ClickTermsAndConditionsLink();
         }

         [Then(@"I should navigate to the welsh TermsAndConditions details correct page opens in same tab")]
         public void ThenIShouldNavigateToTheWelshTermsAndConditionsDetailsCorrectPageOpensInSameTab()
         {
             var pageTitle = "Telerau ac amodau Cynllun Teithio Anifeiliaid Anwes Gogledd Iwerddon";
             Assert.IsTrue(HomePageWelsh?.VerifyTheLinkOpensInSameTab());
             Assert.IsTrue(HomePageWelsh?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
         }

        /* [Then(@"I click the CrownCopyright Link")]
         public void ThenIClickTheCrownCopyrightLink()
         {
             HomePage?.ClickCrownCopyrightLink();
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
             HomePage?.ClickOnManageAccountLink();
         }

         [When(@"I have clicked the View hyperlink from home page")]
         public void WhenIHaveClickedTheViewHyperlinkFromHomePage()
         {
             var petName = _scenarioContext.Get<string>("PetName");
             HomePage?.ClickViewLink(petName);
         }

         [Then(@"I should see the application in '([^']*)' status")]
         public void ThenIShouldSeeTheApplicationInStatus(string applicationStatus)
         {
             var petName = _scenarioContext.Get<string>("PetName");

             Assert.IsTrue(HomePage?.VerifyTheExpectedStatus(petName, applicationStatus), $"The submitted application is not in expected status of '{applicationStatus}'");
         }

         [When("signed out from PETS portal")]
         public void WhenSignedOutFromPETSPortal()
         {
             HomePage?.ClickSignOutLink();
         }

         [Then(@"I should see invalid documents link")]
         public void ThenIShouldSeeInvalidDocumentsLink()
         {
             Assert.IsTrue(HomePage?.VerifyInvalidDocumentsLink(), "View invalid documents link is not visible");
         }

         [When(@"I click invalid documents link")]
         public void WhenIClickInvalidDocumentsLink()
         {
             HomePage?.ClickInvalidDocumentsLink();
         }

         [Then(@"I should be navigated to invalid documents page")]
         public void ThenIShouldBeNavigatedToInvalidDocumentsPage()
         {
             var pageTitle = "Invalid documents";
             Assert.IsTrue(HomePage?.IsInvalidDocumentsPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
         }

         [Then(@"invalid documents table column names should be '([^']*)' '([^']*)'")]
         public void ThenInvalidDocumentsTableColumnNamesShouldBe(string petName, string status)
         {
             Assert.IsTrue(HomePage?.InvalidDocsTableHeadings(petName, status));
         }

         [Then(@"the status column should display only unsuccessful and cancelled records")]
         public void ThenTheStatusColumnShouldDisplayOnlyUnsuccessfulAndCancelledRecords()
         {
             Assert.IsTrue(HomePage?.InvalidDocsTablePTDStatus());
         }

         [Then(@"I can see the view link in all records of the table")]
         public void ThenICanSeeTheViewLinkInAllRecordsOfTheTable()
         {
             Assert.IsTrue(HomePage?.InvalidDocsTableViewLink());
         }

         [Then(@"I should navigate to the TermsAndConditions details page")]
         public void ThenIShouldNavigateToTheTermsAndConditionsDetailsPage()
         {
             var pageTitle = "Terms and conditions";
             Assert.IsTrue(HomePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
         }

         [Then(@"I should navigate to the AccessibilityStatement details page")]
         public void ThenIShouldNavigateToTheAccessibilityStatementDetailsPage()
         {
             var pageTitle = "Accessibility statement for Government Gateway";
             Assert.IsTrue(HomePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
         }

         [Then(@"I should navigate to the Cookies details page")]
         public void ThenIShouldNavigateToTheCookiesDetailsPage()
         {
             var pageTitle = "Cookies";
             Assert.IsTrue(HomePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
         }

         [Then(@"I close the current tab and switch back to government gateway page")]
         public void ThenICloseTheCurrentTabAndSwitchBackToGovernmentGatewayPage()
         {
             HomePage?.CloseCurrentTabAndSwitchBack();
         }

         [Then(@"I should not see manage account and sign out links")]
         public void ThenIShouldNotSeeManageAccountAndSignOutLinks()
         {
             Assert.IsTrue(HomePage?.VerifyManageAccAndSignOutNotVisible());
         }*/

         [Then(@"I should see a suspension warning message in Welsh")]
         public void ThenIShouldSeeASuspensionWarningMessageInWelsh()
         {
             Assert.IsTrue(HomePageWelsh?.VerifySuspensionWarningInWelsh());
         }

        [Then(@"I should not see apply for a document green button in Welsh")]
        public void ThenIShouldNotSeeApplyForADocumentGreenButtonInWelsh()
        {
            Assert.IsTrue(HomePageWelsh?.VerifyWelshApplyButtonNotVisible());
        }

        [Then(@"I should verify the status of all records in the dashboard as '(.*)' in Welsh")]
         public void ThenIShouldVerifyTheStatusOfAllRecordsInTheDashboardAsInWelsh(string susStatus)
         {
             Assert.IsTrue(HomePageWelsh?.VerifySuspensionStatusInDashboardInWelsh(susStatus));
         }

       /*  [Then(@"I should see cookies banner at the top of the page")]
         public void ThenIShouldSeeCookiesBannerAtTheTopOfThePage()
         {
             Assert.True(HomePage?.VerifyCookiesBanner());
         }

         [Then(@"I should not see cookies banner at the top of the page")]
         public void ThenIShouldNotSeeCookiesBannerAtTheTopOfThePage()
         {
             Assert.True(HomePage?.VerifyCookiesBannerNotDisplayed());
         }

         [Then(@"I should see accept and reject additional cookies button in the cookies banner")]
         public void ThenIShouldSeeAcceptAndRejectAdditionalCookiesButtonInTheCookiesBanner()
         {
             Assert.True(HomePage?.VerifyCookiesBannerButtons());
         }

         [When(@"I click Accept additional cookies button in the cookies banner")]
         public void WhenIClickAcceptAdditionalCookiesButtonInTheCookiesBanner()
         {
             HomePage?.ClickAcceptAdditionalCookies();
         }

         [Then(@"I should see additional cookies accepted confirmation message")]
         public void ThenIShouldSeeAdditionalCookiesAcceptedConfirmationMessage()
         {
             Assert.True(HomePage?.VerifyAcceptedCookiesConfirmation());
         }

         [When(@"I click Reject additional cookies button in the cookies banner")]
         public void WhenIClickRejectAdditionalCookiesButtonInTheCookiesBanner()
         {
             HomePage?.ClickRejectAdditionalCookies();
         }

         [Then(@"I should see additional cookies rejected confirmation message")]
         public void ThenIShouldSeeAdditionalCookiesRejectedConfirmationMessage()
         {
             Assert.True(HomePage?.VerifyRejectedCookiesConfirmation());
         }

         [Then(@"I click Hide cookie message should hide the '(.*)' cookie banner")]
         public void ThenIClickHideCookieMessageShouldHideTheCookieBanner(string option)
         {
             HomePage?.ClickHideCookiesButton(option);
             Assert.True(HomePage?.VerifyCookiesBannerNotDisplayed());
         }

         [When(@"I see two radio buttons are visible at the end of the page")]
         public void WhenISeeTwoRadioButtonAreVisibleAtTheEndOfThePage()
         {
             Assert.True(HomePage?.VerifyCookiesRadioButtons());
         }

         [Then(@"I should see the No option is selected as default option")]
         public void ThenIShouldSeeTheNoOptionIsSelectedAsDefaultOption()
         {
             Assert.True(HomePage?.VerifyCookiesDefaultSelection());
         }

         [Then(@"I select the Yes option")]
         public void ThenISelectTheYesOption()
         {
             HomePage?.ClickCookiesYesRadioButton();
         }

         [When(@"I click the save cookies settings button")]
         public void WhenIClickTheSaveCookiesSettingsButton()
         {
             HomePage?.ClickSaveCookiesSettings();
         }

         [Then(@"I should see success message at the top of the page")]
         public void ThenIShouldSeeSuccessMessageAtTheTopOfThePage()
         {
             Assert.True(HomePage?.VerifyCookiesSuccessMessage());
         }

         [When(@"I click change your cookie settings link in the '(.*)' confirmation message")]
         public void WhenIChangeYourCookieSettingsLinkInTheConfirmationMessage(string option)
         {
             HomePage?.ClickChangeYourCookieSettings(option);
         }

         [Then("I should see '(.*)' '(.*)' links in the header")]
         public void ThenIShouldSeeLinksInTheHeader(string govukLink, string takingAPetLink)
         {
             HomePage?.VerifyCommonHeaderLinks(govukLink, takingAPetLink);
         }*/
    }
}