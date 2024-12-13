using BoDi;
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
        public IWebElement FeedbackLink => _driver.WaitForElement(By.ClassName("govuk-link"));
        public IWebElement GetHelpLink => _driver.WaitForElement(By.ClassName("govuk-link--inverse"));
        public IWebElement GethelpHeader => _driver.WaitForElement(By.ClassName("govuk-heading-xl"));
        public IWebElement AccessibilityStatementLink => _driver.WaitForElement(By.XPath("/html/body/footer/div/div/div[1]/ul/li[1]/a"));
        public IWebElement CookiesLink => _driver.WaitForElement(By.XPath("/html/body/footer/div/div/div[1]/ul/li[2]/a"));
        public IWebElement PrivacyNoticeLink => _driver.WaitForElement(By.XPath("/html/body/footer/div/div/div[1]/ul/li[4]/a"));
        public IWebElement TermsAndConditionsLink => _driver.WaitForElement(By.XPath("/html/body/footer/div/div/div[1]/ul/li[5]/a"));
        public IWebElement CrownCopyrightLink => _driver.WaitForElement(By.XPath("/html/body/footer/div/div/div[2]/a"));
        private IWebElement btnApplyForDocument => _driver.WaitForElement(By.XPath("//button[normalize-space(text())='Apply for a document']"), true);
        private IReadOnlyCollection<IWebElement> tableRows => _driver.WaitForElements(By.XPath("//table/tbody/descendant::tr"), true);
        private IReadOnlyCollection<IWebElement> tableHeaderRows => _driver.WaitForElements(By.XPath("//table/tbody/descendant::tr/th"), true);
        private IReadOnlyCollection<IWebElement> tableActionRows => _driver.WaitForElements(By.XPath("//table/tbody/descendant::tr/td[4]//a"), true);
        public IWebElement lnkManageAccount => _driver.WaitForElement(By.XPath("//a[normalize-space(text()) ='Manage account']"));
        private IWebElement btnAddtionalCoockies => _driver.WaitForElement(By.XPath("//button[normalize-space(text()) ='Accept additional cookies']"));
        private IWebElement btnHideCoockies => _driver.WaitForElement(By.XPath("//button[normalize-space(text()) ='Hide cookie message']"));

        #endregion

        #region Methods

        public bool IsPageLoaded()
        {
            return PageHeading.Text.Contains("Lifelong pet travel documents");
        }

        public void ClickFeedbackLink()
        {
            FeedbackLink.Click();
        }

        public void ClickHideCoockies()
        {
            btnAddtionalCoockies.Click();
            btnHideCoockies.Click();
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

                    return tdCollection[2].Text.Replace("\r\n", string.Empty).Trim().ToUpper().Equals(status.ToUpper());
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

            for (var elementIndex = rowCount; elementIndex > 0; elementIndex--)
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

        #endregion
    }
}