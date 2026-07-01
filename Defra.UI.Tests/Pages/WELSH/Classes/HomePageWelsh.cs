using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Pages.WELSH.Interfaces;
using Defra.UI.Tests.Tools;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Pages.WELSH.Classes
{
    public class HomePageWelsh : IHomePageWelsh
    {
        private readonly IObjectContainer _objectContainer;

        public HomePageWelsh(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public IWebElement lnkFeedback => _driver.WaitForElement(By.XPath("//a[contains(text() ,'adborth (yn agor mewn tab newydd)')]"));
        public IWebElement lnkPrivacyNotice => _driver.WaitForElement(By.XPath("//a[contains(text() ,'Hysbysiad preifatrwydd (yn agor mewn tab newydd)')]"));
        public IWebElement lnkAccessibilityStatement => _driver.WaitForElement(By.XPath("//a[contains(text() ,'Datganiad hygyrchedd')]"));
        public IWebElement lnkCookies => _driver.WaitForElement(By.XPath("//a[contains(text() ,'Cwcis')]"));
        public IWebElement lnkTermsAndConditions => _driver.WaitForElement(By.LinkText("Telerau ac amodau"));
        public IWebElement lnkEnglish => _driver.WaitForElement(By.XPath("//span[normalize-space(text()) ='English']"));
        public IWebElement lnkWelsh => _driver.WaitForElement(By.XPath("//span[normalize-space(text()) ='Cymraeg']"));
        public IWebElement lnkDashboardHeadingWelsh => _driver.WaitForElement(By.XPath("//*[@id='documents']"));
        private IWebElement GethelpHeader => _driver.WaitForElement(By.XPath("//*[@class='govuk-heading-xl']"));
        public IWebElement btnBackWelsh => _driver.WaitForElement(By.XPath("//a[normalize-space(text())='Yn ôl']"));
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')]"), true);
        public IWebElement btnApplyForDocumentWelsh => _driver.WaitForElement(By.XPath("//*[@id='main-content']//form/button"));
        public IWebElement CookiesLink => _driver.WaitForElement(By.XPath("/html/body/footer/div/div/div[1]/ul/li[2]/a"));
        public IWebElement PrivacyNoticeLink => _driver.WaitForElement(By.XPath("//a[contains(text() ,'Privacy notice (opens in new tab)')]"));
        public IWebElement AccessibilityStatementLink => _driver.WaitForElement(By.XPath("/html/body/footer/div/div/div[1]/ul/li[1]/a"));
        public IWebElement TermsAndConditionsLink => _driver.WaitForElement(By.LinkText("Terms and conditions"));
        public IWebElement CrownCopyrightLink => _driver.WaitForElement(By.XPath("/html/body/footer/div/div/div[2]/a"));
        private IWebElement btnApplyForDocument => _driver.WaitForElement(By.XPath("//button[normalize-space(text())='Apply for a document']"), true);
        private IReadOnlyCollection<IWebElement> tableRows => _driver.WaitForElements(By.XPath("//table/tbody/descendant::tr"), true);
        private IReadOnlyCollection<IWebElement> tableHeaderRows => _driver.WaitForElements(By.XPath("//table/tbody/descendant::tr/th"), true);
        private IReadOnlyCollection<IWebElement> tableActionRows => _driver.WaitForElements(By.XPath("//table/tbody/descendant::tr/td[2]//a"), true);
        private IWebElement lnkManageAccount => _driver.WaitForElement(By.XPath("//a[normalize-space(text()) ='Rheoli’r cyfrif']"));
        private IWebElement lnkSignOut => _driver.WaitForElement(By.XPath("//a[contains(text() ,'Sign out')]"));
        private IWebElement lnkInvalidDocuments => _driver.WaitForElement(By.XPath("//a[contains(text() ,'Gweld dogfennau annilys')]"));
        private IWebElement InvalidDocHeader => _driver.WaitForElement(By.XPath("//*[@class='govuk-heading-xl govuk-!-margin-bottom-4']"));
        private IWebElement lblPetName => _driver.WaitForElement(By.XPath("//th[text() = \"Enw’r anifail anwes\"]"));
        private IWebElement lblStatus => _driver.WaitForElement(By.XPath("//th[text() = 'Statws']"));
        private IReadOnlyCollection<IWebElement> txtStausValues => _driver.WaitForElements(By.XPath("//*[@class = 'govuk-table__row']/td[1]"));
        private IReadOnlyCollection<IWebElement> txtViewLinks => _driver.WaitForElements(By.XPath("//*[@class = 'govuk-table__row']/td[2]"));
        private IReadOnlyCollection<IWebElement> lnksManageAccAndSingOut => _driver.FindElements(By.XPath("//div[@class = 'login-nav govuk-!-display-none-print']"));
        private IWebElement lblSusWarning => _driver.WaitForElement(By.XPath("//div[@class = 'govuk-warning-text']/strong"));
        private IReadOnlyCollection<IWebElement> btnApplyForDocumentCheck => _driver.FindElements(By.XPath("//button[normalize-space(text())='Gwneud cais am ddogfen']"));
        private IReadOnlyCollection<IWebElement> lblSusStatusInDashboard => _driver.FindElements(By.XPath("//*[@class='govuk-table__cell status-column']/strong"));
        private IWebElement lblCookiesBanner => _driver.WaitForElement(By.XPath("//h2[@class = 'govuk-cookie-banner__heading govuk-heading-m']"));
        private IWebElement btnAcceptAdditionalCookies => _driver.WaitForElement(By.XPath("//button[normalize-space(text())='Derbyn cwcis ychwanegol']"));
        private IWebElement btnRejectAdditionalCookies => _driver.WaitForElement(By.XPath("//button[normalize-space(text())='Gwrthod cwcis ychwanegol']"));
        private IWebElement lnkViewCookies => _driver.WaitForElement(By.XPath("//a[normalize-space(text())='Gweld cwcis']"));
        private IWebElement lblAcceptedCookies => _driver.WaitForElement(By.XPath("//*[@id='govuk-cookie-banner-accepted']//p"));
        private IWebElement lblRejectedCookies => _driver.WaitForElement(By.XPath("//*[@id='govuk-cookie-banner-rejected']//p"));
        private IWebElement lnkChangeCookieSettingsAccepted => _driver.WaitForElement(By.XPath("//*[@id='govuk-cookie-banner-accepted']//a"));
        private IWebElement lnkChangeCookieSettingsRejected => _driver.WaitForElement(By.XPath("//*[@id='govuk-cookie-banner-rejected']//a"));
        private IWebElement btnHideCookieAcceptedMsg => _driver.WaitForElement(By.XPath("//*[@id='govuk-cookie-banner-accepted']//div[2]/button"));
        private IWebElement btnHideCookieRejectedMsg => _driver.WaitForElement(By.XPath("//*[@id='govuk-cookie-banner-rejected']//div[2]/button"));
        private IReadOnlyCollection<IWebElement> txtEntireCookieBanner => _driver.FindElements(By.XPath("//*[@class='govuk-cookie-banner']"));
        private IWebElement btnCookiesOptionYes => _driver.WaitForElementExists(By.XPath("//*[@id='yes']/following-sibling::label"));
        private IWebElement btnCookiesOptionNo => _driver.WaitForElementExists(By.XPath("//*[@id='no']/following-sibling::label"));
        private IWebElement btnRadioNo => _driver.WaitForElementExists(By.XPath("//*[@id='no']"));
        private IWebElement btnSaveCookiesSettings => _driver.WaitForElementExists(By.XPath("//button[normalize-space(text())='Save cookies settings']"));
        private IWebElement txtSuccessMsgHeader => _driver.WaitForElementExists(By.XPath("//*[@class='govuk-notification-banner__title']"));
        private IWebElement txtSuccessMsg => _driver.WaitForElementExists(By.XPath("//*[@class='govuk-notification-banner__content']/p"));
        private IWebElement lnkPetsTravelPortal => _driver.WaitForElement(By.XPath("//a[normalize-space(text())='Taking a pet from Great Britain to Northern Ireland']"));
        private IWebElement lnkGovUk => _driver.WaitForElement(By.XPath("//*[@class='govuk-header__logo']/a"));
        #endregion

        #region Methods

        public bool IsPageLoaded()
        {
            if (ConfigSetup.BaseConfiguration.TestConfiguration.IsAccessibilityEnabled)
            {
                Cognizant.WCAG.Compliance.Checker.Analyzer.Execute(_driver);
            }

            return PageHeading.Text.Contains("Dogfennau teithio gydol oes i anifeiliaid anwes");
        }

        public void ClickLanguageLnk(string language)
        {
            if (language.Equals("English"))
                lnkEnglish.Click();
            else if (language.Equals("Cymraeg"))
                lnkWelsh.Click();
        }

        public bool VerifyDashboardHeadingInWelsh()
        {
            return lnkDashboardHeadingWelsh.Text.Contains("Dogfennau teithio gydol oes i anifeiliaid anwes");
        }

        public void ClickWelshFeedbackLink()
        {
            lnkFeedback.Click();
        }

        public void ClickWelshPrivacyNoticeLink()
        {
            lnkPrivacyNotice.Click();
        }

        public void ClickWelshCookiesLink()
        {
            lnkCookies.Click();
        }

        public bool IsNextPageLoaded(string pageTitle)
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.LastOrDefault());
            Thread.Sleep(1000);
            return GethelpHeader.Text.Contains(pageTitle);
        }

        public bool VerifyTheLinkOpensInSameTab()
        {
            if (_driver.WindowHandles.Count == 1)
            {
                return true;
            }
            return false;
        }

        public void ClickWelshBackButton()
        {
            btnBackWelsh.Click();
        }

        public void ClickApplyForADocumentInWelsh()
        {
            btnApplyForDocumentWelsh.Click();
        }

        public void ClickAccessibilityStatementLink()
        {
            lnkAccessibilityStatement.Click();
        }

        public void ClickCookiesLink()
        {
            CookiesLink.Click();
        }

        public void ClickPrivacyNoticeLink()
        {
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,5000)", "");
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", PrivacyNoticeLink);
            //PrivacyNoticeLink.Click();
        }
        public void ClickTermsAndConditionsLink()
        {
            lnkTermsAndConditions.Click();
        }

        public void ClickCrownCopyrightLink()
        {
            CrownCopyrightLink.Click();
        }

        public void ClickApplyForPetTravelDocument()
        {
            btnApplyForDocument.Click();
        }

        public bool VerifyTheExpectedStatus(string petName, string status)
        {

            _driver.Navigate().Refresh();
            _driver.WaitForPageToLoad();

            Thread.Sleep(TimeSpan.FromSeconds(5));

            var reversedTrCollection = tableRows.Reverse();

            foreach (var element in reversedTrCollection)
            {
                var tableHeader = element.FindElement(By.TagName("th"));

                if (tableHeader.Text.Replace("\r\n", string.Empty).Trim().ToUpper().Equals(petName.ToUpper()))
                {
                    var tdCollection = element.FindElements(By.TagName("td"));

                    return tdCollection[0].Text.Replace("\r\n", string.Empty).Trim().ToUpper().Equals(status.ToUpper());
                }
            }

            return false;
        }

        public bool VerifyTheApplicationIsNotAvailable(string petName)
        {
            _driver.Navigate().Refresh();
            _driver.WaitForPageToLoad();
            Thread.Sleep(5000);
            _driver.Navigate().Refresh();
            _driver.WaitForPageToLoad();

            var t = _driver.FindElements(By.XPath("//th[text() = '" + petName + "']")).Count;
            if (_driver.FindElements(By.XPath("//th[text() = '" + petName + "']")).Count.Equals(0))
            {
                return true;
            }
            return false;
        }

        public void ClickViewLink(string petName)
        {
            IWebElement? lnkview = null;

            var rowCount = tableRows.Count - 1;

            for (var elementIndex = rowCount; elementIndex >= 0; elementIndex--)
            {
                var tableHeader = tableHeaderRows.ElementAt(elementIndex).Text.Replace("\r\n", string.Empty).Trim().ToUpper();

                if (tableHeader.Equals(petName.ToUpper()))
                {
                    lnkview = tableActionRows.ElementAt(elementIndex);

                    break;
                }
            }

            lnkview?.Click();
        }

        public void ClickOnManageAccountLink()
        {
            lnkManageAccount.Click();
        }

        public void ClickSignOutLink()
        {
            lnkSignOut.Click();
        }

        public bool VerifyInvalidDocumentsLink()
        {
            return lnkInvalidDocuments.Text.Equals("Gweld dogfennau annilys");
        }

        public void ClickInvalidDocumentsLink()
        {
            lnkInvalidDocuments.Click();
        }

        public bool InvalidDocsTableHeadings(string petName, string status)
        {
            return lblPetName.Text.Contains(petName) && lblStatus.Text.Contains(status);
        }

        public bool InvalidDocsTablePTDStatus()
        {
            foreach (var element in txtStausValues)
            {
                if (element.Text.Contains("Yn aflwyddiannus") || element.Text.Contains("Wedi’u canslo"))
                    return true;
                else if (element.Text.Contains("Yn aros") || element.Text.Contains("Wedi’u cymeradwyo"))
                    return false;
            }
            return false;
        }

        public bool InvalidDocsTableViewLink()
        {
            foreach (var element in txtViewLinks)
            {
                if (!element.Text.Contains("Gweld"))
                    return false;
            }
            return true;
        }

        public void CloseCurrentTabAndSwitchBack()
        {
            var allWindows = _driver.WindowHandles;
            _driver.Close();
            _driver.SwitchTo().Window(allWindows[0]);
        }

        public bool IsInvalidDocumentsPageLoaded(string pageTitle)
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.LastOrDefault());
            Thread.Sleep(1000);
            return InvalidDocHeader.Text.Contains(pageTitle);
        }

        public bool VerifyManageAccAndSignOutNotVisible()
        {
            return lnksManageAccAndSingOut.Count == 0;
        }

        public bool VerifySuspensionWarningInWelsh()
        {
            Thread.Sleep(2000);
            var element = lblSusWarning;
            var text = element.Text.Trim(); // Gets all text content from the <strong> element
            return text.Contains("Rydych chi wedi cael eich atal o'r cynllun yma a chewch chi ddim defnyddio’ch dogfennau teithio anifeiliaid anwes na gwneud cais am rai newydd nes bod eich ataliad wedi’i godi. Gwiriwch eich ebost am ragor o wybodaeth, gan gynnwys sut i apelio.");           
        }

        public bool VerifyWelshApplyButtonNotVisible()
        {
            return btnApplyForDocumentCheck.Count == 0;
        }

        public bool VerifySuspensionStatusInDashboardInWelsh(string susStatus)
        {
            foreach (var element in lblSusStatusInDashboard)
            {
                if (element.Text.Contains("Wedi’i atal"))
                    return true;
            }
            return false;
        }

        public bool VerifyCookiesBanner()
        {
            return lblCookiesBanner.Text.Trim().Contains("Cwcis ar fynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon");
        }

        public bool VerifyCookiesBannerButtons()
        {
            return btnAcceptAdditionalCookies.Text.Trim().Contains("Derbyn cwcis ychwanegol")
                && btnRejectAdditionalCookies.Text.Trim().Contains("Gwrthod cwcis ychwanegol")
                && lnkViewCookies.Text.Trim().Contains("Gweld cwcis");
        }

        public void ClickAcceptAdditionalCookies()
        {
            btnAcceptAdditionalCookies.Click();
        }

        public bool VerifyAcceptedCookiesConfirmation()
        {
            return lblAcceptedCookies.Text.Trim().Contains("Rydych chi wedi derbyn cwcis ychwanegol. Gallwch chi newid eich gosodiadau cwcis unrhyw bryd.");
        }

        public void ClickRejectAdditionalCookies()
        {
            btnRejectAdditionalCookies.Click();
        }

        public bool VerifyRejectedCookiesConfirmation()
        {
            return lblRejectedCookies.Text.Trim().Contains("Rydych chi wedi gwrthod cwcis ychwanegol. Gallwch chi newid eich gosodiadau cwcis unrhyw bryd.");
        }

        public void ClickHideCookiesButton(string option)
        {
            if (option.Equals("Accepted"))
                btnHideCookieAcceptedMsg.Click();
            else if (option.Equals("Rejected"))
                btnHideCookieRejectedMsg.Click();
        }

        public bool VerifyCookiesRadioButtons()
        {
            return btnCookiesOptionYes.Text.Trim().Contains("Oes")
                && btnCookiesOptionNo.Text.Trim().Contains("Nac oes");
        }

        public bool VerifyCookiesDefaultSelection()
        {
            btnRadioNo.ScrollToElement(_driver);

            string checkedRadioBtn = btnRadioNo.GetAttribute("checked");
            bool isNoSelected = !string.IsNullOrEmpty(checkedRadioBtn);
            return isNoSelected;
        }

        public void ClickCookiesYesRadioButton()
        {
            btnCookiesOptionYes.Click();
        }

        public void ClickSaveCookiesSettings()
        {
            btnSaveCookiesSettings.Click();
        }

        public bool VerifyCookiesSuccessMessage()
        {
            return txtSuccessMsgHeader.Text.Trim().Contains("Llwyddiant")
                && txtSuccessMsg.Text.Trim().Contains("Rydych chi wedi gosod eich dewisiadau cwci");
        }

        public void ClickChangeYourCookieSettings(string option)
        {
            if (option == "Accepted")
                lnkChangeCookieSettingsAccepted.Click();
            else if (option == "Rejected")
                lnkChangeCookieSettingsRejected.Click();
        }

        public bool VerifyCookiesBannerNotDisplayed()
        {
            foreach (var element in txtEntireCookieBanner)
            {
                string display = element.GetCssValue("display");
                if (!display.Equals("none", StringComparison.OrdinalIgnoreCase))
                    return false;
            }
            return true;
        }

        public bool VerifyCommonHeaderLinks(string govukLink, string takingAPetLink)
        {
            return lnkGovUk.Text.Trim().Contains("GOV.UK")
                && lnkPetsTravelPortal.Text.Trim().Contains("Taking a pet from Great Britain to Northern Ireland");
        }
        #endregion
    }
}