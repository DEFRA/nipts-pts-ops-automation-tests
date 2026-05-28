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

        [When(@"I click {string} link to change the language")]
        public void WhenIClickLinkToChangeTheLanguage(string language)
        {
            HomePageWelsh?.ClickLanguageLnk(language);
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
        [Then(@"I click on Back button in Welsh")]
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
        */
         [Then(@"I should navigate to Manage account in Welsh")]
         public void ThenIShouldNavigateToManageAccount()
         {
             HomePageWelsh?.ClickOnManageAccountLink();
         }

        [When(@"I have clicked the View hyperlink from home page in Welsh")]
         public void WhenIHaveClickedTheViewHyperlinkFromHomePage()
         {
             var petName = _scenarioContext.Get<string>("Enw");
             HomePageWelsh?.ClickViewLink(petName);
         }

        [Then(@"I should see the application in '([^']*)' status in Welsh")]
        public void ThenIShouldSeeTheApplicationInStatus(string applicationStatus)
        {
            var petName = _scenarioContext.Get<string>("Enw");

            Assert.IsTrue(HomePageWelsh?.VerifyTheExpectedStatus(petName, applicationStatus), $"The submitted application is not in expected status of '{applicationStatus}'");
        }

        /*

         [When("signed out from PETS portal")]
         public void WhenSignedOutFromPETSPortal()
         {
             HomePage?.ClickSignOutLink();
         }
        */
         [Then(@"I should see invalid documents link in Welsh")]
         public void ThenIShouldSeeInvalidDocumentsLink()
         {
             Assert.IsTrue(HomePageWelsh?.VerifyInvalidDocumentsLink(), "View invalid documents link is not visible in Welsh");
         }
        
         [When(@"I click invalid documents link in Welsh")]
         public void WhenIClickInvalidDocumentsLink()
         {
             HomePageWelsh?.ClickInvalidDocumentsLink();
         }
        
         [Then(@"I should be navigated to invalid documents page in Welsh")]
         public void ThenIShouldBeNavigatedToInvalidDocumentsPage()
         {
             var pageTitle = "Dogfennau annilys";
             Assert.IsTrue(HomePageWelsh?.IsInvalidDocumentsPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
         }
        
         [Then(@"invalid documents table column names should be '([^']*)' '([^']*)' in Welsh")]
         public void ThenInvalidDocumentsTableColumnNamesShouldBe(string petName, string status)
         {
             Assert.IsTrue(HomePageWelsh?.InvalidDocsTableHeadings(petName, status));
         }
        
         [Then(@"the status column should display only unsuccessful and cancelled records in Welsh")]
         public void ThenTheStatusColumnShouldDisplayOnlyUnsuccessfulAndCancelledRecords()
         {
             Assert.IsTrue(HomePageWelsh?.InvalidDocsTablePTDStatus());
         }
        
         [Then(@"I can see the view link in all records of the table in Welsh")]
         public void ThenICanSeeTheViewLinkInAllRecordsOfTheTable()
         {
             Assert.IsTrue(HomePageWelsh?.InvalidDocsTableViewLink());
         }
        /*
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

         [Then(@"I should see cookies banner at the top of the page in Welsh")]
         public void ThenIShouldSeeCookiesBannerAtTheTopOfThePage()
         {
             Assert.True(HomePageWelsh?.VerifyCookiesBanner());
         }
        /*
         [Then(@"I should not see cookies banner at the top of the page")]
         public void ThenIShouldNotSeeCookiesBannerAtTheTopOfThePage()
         {
             Assert.True(HomePage?.VerifyCookiesBannerNotDisplayed());
         }
        */
         [Then(@"I should see accept and reject additional cookies button in the cookies banner in Welsh")]
         public void ThenIShouldSeeAcceptAndRejectAdditionalCookiesButtonInTheCookiesBanner()
         {
             Assert.True(HomePageWelsh?.VerifyCookiesBannerButtons());
         }
        
         [When(@"I click Accept additional cookies button in the cookies banner in Welsh")]
         public void WhenIClickAcceptAdditionalCookiesButtonInTheCookiesBanner()
         {
             HomePageWelsh?.ClickAcceptAdditionalCookies();
         }
       
         [Then(@"I should see additional cookies accepted confirmation message in Welsh")]
         public void ThenIShouldSeeAdditionalCookiesAcceptedConfirmationMessage()
         {
             Assert.True(HomePageWelsh?.VerifyAcceptedCookiesConfirmation());
         }
        
         [When(@"I click Reject additional cookies button in the cookies banner in Welsh")]
         public void WhenIClickRejectAdditionalCookiesButtonInTheCookiesBanner()
         {
             HomePageWelsh?.ClickRejectAdditionalCookies();
         }

        [Then(@"I should navigate to the Cookies details correct page opens in same tab in Welsh")]
        public void ThenIShouldNavigateToTheCookiesDetailsCorrectPageOpensInSameTab()
        {
            var pageTitle = "Cwcis";
            Assert.IsTrue(HomePageWelsh?.VerifyTheLinkOpensInSameTab());
            Assert.IsTrue(HomePageWelsh?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I should see additional cookies rejected confirmation message in Welsh")]
         public void ThenIShouldSeeAdditionalCookiesRejectedConfirmationMessage()
         {
             Assert.True(HomePageWelsh?.VerifyRejectedCookiesConfirmation());
         }
        
         [Then(@"I click Hide cookie message should hide the '(.*)' cookie banner in Welsh")]
         public void ThenIClickHideCookieMessageShouldHideTheCookieBanner(string option)
         {
             HomePageWelsh?.ClickHideCookiesButton(option);
             Assert.True(HomePageWelsh?.VerifyCookiesBannerNotDisplayed());
         }
        
         [When(@"I see two radio buttons are visible at the end of the page in Welsh")]
         public void WhenISeeTwoRadioButtonAreVisibleAtTheEndOfThePage()
         {
             Assert.True(HomePageWelsh?.VerifyCookiesRadioButtons());
         }
        /*
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
             HomePageWelsh?.ClickSaveCookiesSettings();
         }
        */
         [Then(@"I should see success message at the top of the page in Welsh")]
         public void ThenIShouldSeeSuccessMessageAtTheTopOfThePage()
         {
             Assert.True(HomePageWelsh?.VerifyCookiesSuccessMessage());
         }
        /*
         [When(@"I click change your cookie settings link in the '(.*)' confirmation message")]
         public void WhenIChangeYourCookieSettingsLinkInTheConfirmationMessage(string option)
         {
             HomePageWelsh?.ClickChangeYourCookieSettings(option);
         }
        
         [Then("I should see '(.*)' '(.*)' links in the header")]
         public void ThenIShouldSeeLinksInTheHeader(string govukLink, string takingAPetLink)
         {
             HomePage?.VerifyCommonHeaderLinks(govukLink, takingAPetLink);
         }*/
    }
}