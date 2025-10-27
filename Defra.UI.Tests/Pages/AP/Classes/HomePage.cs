using Reqnroll.BoDi;
using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.AP.Classes
{
    public class HomePage : IHomePage
    {
        private readonly IObjectContainer _objectContainer;

        public HomePage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')]"), true);
        public IWebElement btnApplyForDocumentButton => _driver.WaitForElement(By.XPath("//*[@id='main-content']//form/button"));
        public IWebElement FeedbackLink => _driver.WaitForElement(By.XPath("//a[contains(text() ,'give your feedback (opens in a new tab).')]"));
        public IWebElement GetHelpLink => _driver.WaitForElement(By.ClassName("govuk-link--inverse"));
        private IWebElement GethelpHeader => _driver.WaitForElement(By.XPath("//*[@class='govuk-heading-xl' or @class='gem-c-heading__text govuk-heading-xl']"));
        public IWebElement AccessibilityStatementLink => _driver.WaitForElement(By.XPath("/html/body/footer/div/div/div[1]/ul/li[1]/a"));
        public IWebElement CookiesLink => _driver.WaitForElement(By.XPath("/html/body/footer/div/div/div[1]/ul/li[2]/a"));
        public IWebElement PrivacyNoticeLink => _driver.WaitForElement(By.XPath("//a[contains(text() ,'Privacy notice (opens in new tab)')]"));
        public IWebElement TermsAndConditionsLink => _driver.WaitForElement(By.LinkText("Terms and conditions"));
        public IWebElement CrownCopyrightLink => _driver.WaitForElement(By.XPath("/html/body/footer/div/div/div[2]/a"));
        private IWebElement btnApplyForDocument => _driver.WaitForElement(By.XPath("//button[normalize-space(text())='Apply for a document']"), true);
        private IReadOnlyCollection<IWebElement> tableRows => _driver.WaitForElements(By.XPath("//table/tbody/descendant::tr"), true);
        private IReadOnlyCollection<IWebElement> tableHeaderRows => _driver.WaitForElements(By.XPath("//table/tbody/descendant::tr/th"), true);
        private IReadOnlyCollection<IWebElement> tableActionRows => _driver.WaitForElements(By.XPath("//table/tbody/descendant::tr/td[2]//a"), true);
        private IWebElement lnkManageAccount => _driver.WaitForElement(By.XPath("//a[normalize-space(text()) ='Manage account']"));
        private IWebElement lnkSignOut => _driver.WaitForElement(By.XPath("//a[contains(text() ,'Sign out')]"));
        private IWebElement lnkInvalidDocuments => _driver.WaitForElement(By.XPath("//a[contains(text() ,'View invalid documents')]"));
        private IWebElement InvalidDocHeader => _driver.WaitForElement(By.XPath("//*[@class='govuk-heading-xl govuk-!-margin-bottom-4']"));
        private IWebElement lblPetName => _driver.WaitForElement(By.XPath("//th[text() = 'Pet name']"));
        private IWebElement lblStatus => _driver.WaitForElement(By.XPath("//th[text() = 'Status']"));
        private IReadOnlyCollection<IWebElement> txtStausValues => _driver.WaitForElements(By.XPath("//*[@class = 'govuk-table__row']/td[1]"));
        private IReadOnlyCollection<IWebElement> txtViewLinks => _driver.WaitForElements(By.XPath("//*[@class = 'govuk-table__row']/td[2]"));
        private IReadOnlyCollection<IWebElement> lnksManageAccAndSingOut => _driver.FindElements(By.XPath("//div[@class = 'login-nav govuk-!-display-none-print']"));
        private IWebElement lblSusWarning => _driver.WaitForElement(By.XPath("//div[@class = 'govuk-warning-text']/strong"));
        private IReadOnlyCollection<IWebElement> btnApplyForDocumentCheck => _driver.FindElements(By.XPath("//button[normalize-space(text())='Apply for a document']"));
        #endregion

        #region Methods

        public bool IsPageLoaded()
        {
            if(ConfigSetup.BaseConfiguration.TestConfiguration.IsAccessibilityEnabled)
            {
                Cognizant.WCAG.Compliance.Checker.Analyzer.Execute(_driver);
            }

            return PageHeading.Text.Contains("Lifelong pet travel documents");
        }

        public void ClickFeedbackLink()
        {
            FeedbackLink.Click();
        }

        public void ClickGethelpLink()
        {
            GetHelpLink.Click();
        }

        public bool IsNextPageLoaded(string pageTitle)
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.LastOrDefault());
            Thread.Sleep(1000);
            return GethelpHeader.Text.Contains(pageTitle);
        }

        public void ClickAccessibilityStatementLink()
        {
            AccessibilityStatementLink.Click();
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
            TermsAndConditionsLink.Click();
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

            var rowCount = tableRows.Count-1;

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

        public bool VerifyTheLinkOpensInSameTab()
        {
            if (_driver.WindowHandles.Count == 1)
            {
                return true;
            }
            return false;
        }

        public bool VerifyInvalidDocumentsLink()
        {
            return lnkInvalidDocuments.Text.Equals("View invalid documents");
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
                if (element.Text.Contains("Unsuccessful") || element.Text.Contains("Cancelled"))
                    return true;
                else if (element.Text.Contains("Pending") || element.Text.Contains("Approved"))
                    return false;
            }
            return false;
        }

        public bool InvalidDocsTableViewLink()
        {
            foreach (var element in txtViewLinks)
            {
                if (element.Text.Contains("View"))
                    return true;
            }
            return false;
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

        public bool VerifySuspensionWarning()
        {
            return lblSusWarning.Text.Trim().Contains("You have been suspended from this scheme and cannot use your pet travel documents or apply for new ones until your suspension is lifted. Check your email for more information, including how to appeal.");
        }

        public bool VerifyApplyButtonNotVisible()
        {
            return btnApplyForDocumentCheck.Count == 0;
        }
        #endregion
    }
}