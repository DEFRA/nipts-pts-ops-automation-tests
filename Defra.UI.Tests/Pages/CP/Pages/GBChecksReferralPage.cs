using Reqnroll.BoDi;
using OpenQA.Selenium;
using Defra.UI.Tests.Tools;
using Defra.UI.Tests.Pages.CP.Interfaces;
using OpenQA.Selenium.Support.UI;
using Defra.UI.Framework.Driver;
using Defra.UI.Tests.Configuration;
using Microsoft.Dynamics365.UIAutomation.Browser;
using AngleSharp.Text;

namespace Defra.UI.Tests.Pages.CP.Pages
{
    public class GBChecksReferralPage : IGBChecksReferralPage
    {
        private readonly IObjectContainer _objectContainer;

        public GBChecksReferralPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement pageHeading => _driver.WaitForElement(By.XPath("//h1[normalize-space()='Referred to SPS']"));
        private IWebElement gbCheckReportPageHeading => _driver.WaitForElement(By.XPath("//h1[normalize-space()='GB check report']"));
        private IWebElement viewLink => _driver.WaitForElement(By.XPath("//*[contains(text(),'View')]"));
        private IReadOnlyCollection<IWebElement> viewLinkList => _driver.WaitForElements(By.XPath("//*[contains(text(),'View')]"));
        private IWebElement ptdOrReferenceNumber => _driver.WaitForElement(By.XPath("//*[@class='referred-form']/button"));
        private IReadOnlyCollection<IWebElement> ptdOrReferenceNumberList => _driver.WaitForElements(By.XPath("//*[@class='referred-form']/button"));
        #endregion

        #region Methods
        public bool IsPageLoaded()
        {
            if (ConfigSetup.BaseConfiguration.TestConfiguration.IsAccessibilityEnabled)
            {
                Cognizant.WCAG.Compliance.Checker.Analyzer.Execute(_driver);
            }
            return pageHeading.Text.Contains("Referred to SPS");
        }

        public bool IsGBCheckReportPageLoaded()
        {
            if (ConfigSetup.BaseConfiguration.TestConfiguration.IsAccessibilityEnabled)
            {
                Cognizant.WCAG.Compliance.Checker.Analyzer.Execute(_driver);
            }
            return gbCheckReportPageHeading.Text.Contains("GB check report");
        }

        public void ClickViewLink()
        { 
            if (viewLinkList.Count > 0)
            {
                viewLink.ScrollToElement(_driver);
                viewLinkList.ElementAt(0).Click();
            }
            else
                Console.WriteLine("No elements found");
        }

        public void ClickPTDOrReferenceNumber()
        {
            if (ptdOrReferenceNumberList.Count > 0)
            {
                ptdOrReferenceNumber.ScrollToElement(_driver);
                ptdOrReferenceNumberList.ElementAt(0).Click();
            }
        }
        #endregion
    }
}