using Reqnroll.BoDi;
using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Tools;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.CP.Pages
{
    public class WelcomePage : IWelcomePage
    {

        private readonly IObjectContainer _objectContainer;

        public WelcomePage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement pageHeading => _driver.WaitForElement(By.XPath("//h1[contains(text(),'Checks')]"), true);
        private IWebElement iconSearch => _driver.WaitForElement(By.XPath("//a[@href='/checker/document-search']//*[name()='svg']"));
        private IWebElement iconHome => _driver.WaitForElement(By.XPath("//span[normalize-space()='Home']"));
        private IWebElement iconScan => _driver.WaitForElement(By.XPath("//span[normalize-space()='Scan']"));
        private IWebElement lnkHeadersChange => _driver.WaitForElement(By.XPath("//a[normalize-space()='Change']"));
        private IWebElement btnBack => _driver.WaitForElement(By.XPath("//a[text()='Back']"));
        private IReadOnlyCollection<IWebElement> pageHeader => _driver.FindElements(By.XPath("//header[@class='pts-location-bar']"));
        private IWebElement lblConfirmationBox => _driver.WaitForElement(By.XPath("//div[normalize-space(.) = 'Information has been successfully submitted']"));
        private IWebElement txtFlightHomePageContent => _driver.WaitForElement(By.XPath("//*[@id='main-content']//p"));
        private IWebElement txtFlightHomePageContentList1 => _driver.WaitForElement(By.XPath("//*[@id='main-content']//li[1]"));
        private IWebElement txtFlightHomePageContentList2 => _driver.WaitForElement(By.XPath("//*[@id='main-content']//li[2]"));
        private IWebElement txtFlightHomePageContentList3 => _driver.WaitForElement(By.XPath("//*[@id='main-content']//li[3]"));
        private IReadOnlyCollection<IWebElement> txtRouteChecksPageTables => _driver.FindElements(By.XPath("//h2[@class='govuk-summary-card__title']/p[1]"));
        private IReadOnlyCollection<IWebElement> txtDepartureChecksPageTables => _driver.FindElements(By.XPath("//h2[@class='govuk-summary-card__title']/p[2]"));
        private IReadOnlyCollection<IWebElement> ChecksPageTables => _driver.FindElements(By.XPath("//*[@class='govuk-summary-card']"));
        #endregion

        #region Methods
        public bool IsPageLoaded()
        {
            if (ConfigSetup.BaseConfiguration.TestConfiguration.IsAccessibilityEnabled)
            {
                Cognizant.WCAG.Compliance.Checker.Analyzer.Execute(_driver);
            }

            return pageHeading.Text.Contains("Checks");
        }

        public void FooterSearchButton()
        {
            iconSearch.Click();
        }

        public void HeadersChangeLink()
        {
            lnkHeadersChange.Click();
        }

        public bool IsHeaderChangeLinkDisplayed()
        {
            return lnkHeadersChange.Displayed;
        }

        public void FooterHomeIcon()
        {
            iconHome.Click();
        }
        public bool CheckFooter()
        {
            try
            {
                if (iconHome.Displayed && iconSearch.Displayed && iconScan.Displayed)
                {
                    return true;
                }
                else
                {
                    throw new NoSuchElementException();
                }
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool CheckHeader()
        {
            if (pageHeader.Count > 0)
                return true;
            else
                return false;
        }
        public bool IsBackButtonDisplayed()
        {
            return btnBack.IsVisible();
        }

        public void ClickBackButton()
        {
            btnBack.Click();
        }

        public bool IsConfirmationBoxDisplayed()
        {
            return lblConfirmationBox.IsVisible();
        }

        public bool CheckFlightHomePageContent(string content, string contentList1, string contentList2, string contentList3)
        {
            return txtFlightHomePageContent.Text.Contains(content) && txtFlightHomePageContentList1.Text.Contains(contentList1)
                && txtFlightHomePageContentList2.Text.Contains(contentList2) && txtFlightHomePageContentList3.Text.Contains(contentList3);
        }

        public bool ChecksPageRouteFilter(string selectedRoute)
        {
            if (txtRouteChecksPageTables.Count == 0)
            {
                return true;
            }

            foreach (var element in txtRouteChecksPageTables)
            {
                if (!element.Text.Contains(selectedRoute))
                {
                    return false;
                }
            }
            return true;
        }

        public bool SailingDetailsInChecksPageTables()
        {
            if (txtDepartureChecksPageTables.Count == 0)
            {
                return true;
            }

            DateTime dateAndTime = DateTime.Today;
            var currentDate = dateAndTime.ToString("dd/MM/yyyy");
            var currentDateMinus2Days = dateAndTime.AddDays(-2).ToString("dd/MM/yyyy");
            var currentDateMinus1Day = dateAndTime.AddDays(-1).ToString("dd/MM/yyyy");
            var currentDatePlus1Day = dateAndTime.AddDays(1).ToString("dd/MM/yyyy");

            if (ChecksPageTables.Count.Equals(txtDepartureChecksPageTables.Count))
            {
                foreach (var element in txtDepartureChecksPageTables)
                {
                    string fullDepartureLine = element.Text;
                    var departureTime = fullDepartureLine.Substring(fullDepartureLine.Length - 5);

                    if (!element.Text.Contains("Departure:")
                    && (!element.Text.Contains(currentDate) || !element.Text.Contains(currentDatePlus1Day)
                    || !element.Text.Contains(currentDateMinus2Days) || !element.Text.Contains(currentDateMinus1Day))
                    && !element.Text.Contains(departureTime))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void OpenNewTab()
        {
            _driver.SwitchTo().NewWindow(WindowType.Tab);
        }
        #endregion
    }
}