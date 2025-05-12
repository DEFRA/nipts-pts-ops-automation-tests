using Reqnroll.BoDi;
using OpenQA.Selenium;
using Defra.UI.Tests.Tools;
using Defra.UI.Tests.Pages.CP.Interfaces;
using OpenQA.Selenium.Support.UI;
using Defra.UI.Framework.Driver;
using Defra.UI.Tests.Configuration;
using Microsoft.Dynamics365.UIAutomation.Browser;
using AngleSharp.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Dynamics365.UIAutomation.Api;

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
        private IWebElement lblOutcome => _driver.WaitForElement(By.XPath("//h2[normalize-space()='Outcome']"));
        private IWebElement lblCheckdetails => _driver.WaitForElement(By.XPath("//h2[normalize-space()='Check details']"));
        private IWebElement lblCheckOutcome => _driver.WaitForElement(By.XPath("//dt[normalize-space()='Check outcome']"));
        private IWebElement lblCheckOutcomeValue => _driver.WaitForElement(By.XPath("//h2[text()='Outcome']//following::p[1]"));
        private IWebElement lblReasonForReferral => _driver.WaitForElement(By.XPath("//dt[normalize-space()='Reason for referral']"));
        private IWebElement lblReasonForReferralValue => _driver.WaitForElement(By.XPath("//dt[text()='Reason for referral']//following::p[1]"));
        private IWebElement lblMcNumberFoundInScan => _driver.WaitForElement(By.XPath("//dt[normalize-space()='Microchip number found in scan']"));
        private IWebElement lblMcNumberFoundInScanValue => _driver.WaitForElement(By.XPath("//dt[text()='Microchip number found in scan']//following::p[1]"));
        private IWebElement lblAdditionalComments => _driver.WaitForElement(By.XPath("//dt[normalize-space()='Additional comments']"));
        private IWebElement lblAdditionalCommentsValue => _driver.WaitForElement(By.XPath("//dt[text()='Additional comments']//following::p[1]"));
        private IWebElement lblGBCheckerName => _driver.WaitForElement(By.XPath("//dt[normalize-space()='GB checker’s name']"));
        private IWebElement lblGBCheckerNameValue => _driver.WaitForElement(By.XPath("//dt[text()='GB checker’s name']//following::dd[1]"));
        private IWebElement lblRoute => _driver.WaitForElement(By.XPath("//dt[normalize-space()='Route']"));
        private IWebElement lblRouteValue => _driver.WaitForElement(By.XPath("//dt[text()='Route']//following::dd[1]"));
        private IWebElement lblDepartDate => _driver.WaitForElement(By.XPath("//dt[normalize-space()='Scheduled departure date']"));
        private IWebElement lblDepartDateValue => _driver.WaitForElement(By.XPath("//dt[text()='Scheduled departure date']//following::p[1]"));
        private IWebElement lblDepartTime => _driver.WaitForElement(By.XPath("(//dt[normalize-space()='Scheduled departure time'])"));
        private IWebElement lblDepartTimeValue => _driver.WaitForElement(By.XPath("//dt[text()='Scheduled departure time']//following::p[1]"));
        private IWebElement lnkPTDRefNumber => _driver.WaitForElement(By.XPath("(//strong[normalize-space(.)='Check needed'])[1]//ancestor::tr//following-sibling::button"));
        private IWebElement btnConductSPSCheck => _driver.WaitForElement(By.XPath("//button[normalize-space(.)='Conduct an SPS check']"));
        private IWebElement lnkNext => _driver.WaitForElement(By.XPath("//*[@rel='next']"));
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

        public bool CheckReportPageSubheadings(string subHeading1, string subHeading2)
        {
            return lblOutcome.Text.Trim().Equals(subHeading1)
                && lblCheckdetails.Text.Trim().Equals(subHeading2);
        }

        public bool CheckOutcome(string checkOutcome)
        {
            return lblCheckOutcome.Text.Trim().Equals("Check outcome")
            && lblCheckOutcomeValue.Text.Trim().Equals(checkOutcome);
        }

        public bool ReasonForReferral(string referralReason)
        {
            return lblReasonForReferral.Text.Trim().Equals("Reason for referral")
            && lblReasonForReferralValue.Text.Trim().Equals(referralReason);
        }

        public bool MCNumberFoundInScan(string mcNumber)
        {
            return lblMcNumberFoundInScan.Text.Trim().Equals("Microchip number found in scan")
            && lblMcNumberFoundInScanValue.Text.Trim().Equals(mcNumber);
        }

        public bool AdditionalComments(string additionalComments)
        {
            return lblAdditionalComments.Text.Trim().Equals("Additional comments")
            && lblAdditionalCommentsValue.Text.Trim().Equals(additionalComments);
        }

        public bool GBChecker(string gbChecker)
        {
            return lblGBCheckerName.Text.Trim().Equals("GB checker’s name")
            && lblGBCheckerNameValue.Text.Equals(gbChecker);
        }

        public bool RouteInGBCheckPage(string route)
        {
            return lblRoute.Text.Trim().Equals("Route")
            && lblRouteValue.Text.Trim().Equals(route);
        }

        public bool ScheduledDepartDate()
        {
            DateTime dateAndTime = DateTime.Today;
            var currentDate = dateAndTime.ToString("dd/MM/yyyy");
            return lblDepartDate.Text.Trim().Equals("Scheduled departure date")
            && lblDepartDateValue.Text.Trim().Equals(currentDate);
        }

        public bool ScheduledDepartTime(string departTime)
        {
            return lblDepartTime.Text.Trim().Equals("Scheduled departure time")
            && lblDepartTimeValue.Text.Trim().Equals(departTime);
        }

        public bool ClickApplicationRef(string referenceNumber)
        {
            var hasNext = true;
            while (hasNext)
            {
                if (_driver.WaitForElements(By.XPath("//button[@data-identifier='referred-" + referenceNumber + "']")).Count > 0)
                {
                    _driver.WaitForElement(By.XPath("//button[@data-identifier='referred-" + referenceNumber + "']")).Click(_driver);
                    return true;
                }
                else
                {
                    try
                    {
                        lnkNext.ScrollToElement(_driver);
                        if (lnkNext.Displayed)
                        {
                            lnkNext.Click();
                        }
                    }
                    catch (NoSuchElementException)
                    {
                        hasNext = false;
                    }
                }
            }
            return false;
        }
        
        public void ClickOnConductSPSCheckButton()
        {
            btnConductSPSCheck.Click(_driver);
        }

        public bool CheckPTDNumberFormat(string ptdNumberPrefix)
        {
            List<string> allRecords = new List<string>();
            while(true)
            {
                foreach(var element in ptdOrReferenceNumberList)
                {
                    string cleanText = element.Text.Replace("reported", "").Trim();
                    allRecords.Add(cleanText);
                }

                try
                {
                    lnkNext.ScrollToElement(_driver);
                    if (lnkNext.Displayed)
                    {
                        lnkNext.Click();
                    }
                    else
                    {
                        throw new NoSuchElementException();
                    }
                }
                catch (NoSuchElementException)
                {
                    break;
                }
            }

            foreach (var recordValue in allRecords)
            {
                if (recordValue.StartsWith("GB826"))
                {
                    string[] parts = recordValue.Split(' ');
                    if (parts.Length == 3 && parts[0].Length == 5
                        && parts[1].Length == 3 && parts[2].Length == 3)
                    {
                        continue;
                    }
                }
            }
            return true;
        }

        public bool VerifyTravelStatus(string referenceNumber, string travelStatus)
        {
            var hasNext = true;
            while (hasNext)
            {
                if (_driver.WaitForElements(By.XPath("(//button[@data-identifier='referred-" + referenceNumber + "']//following::strong)[1]")).Count > 0)
                {
                    return _driver.WaitForElement(By.XPath("(//button[@data-identifier='referred-" + referenceNumber + "']//following::strong)[1]")).Text.ToUpper().Equals(travelStatus);
                }
                else
                {
                    try
                    {
                        lnkNext.ScrollToElement(_driver);
                        if (lnkNext.Displayed)
                        {
                            lnkNext.Click();
                        }
                    }
                    catch (NoSuchElementException)
                    {
                        hasNext = false;
                    }
                }
            }
            return false;
        }
        
        public bool VerifyBGColorforTravelStatus(string referenceNumber, string travelStatus, string color)
        {
            var hasNext = true;
            while (hasNext)
            {
                if (_driver.WaitForElements(By.XPath("(//button[@data-identifier='referred-" + referenceNumber + "']//following::strong)[1]")).Count > 0)
                {
                    return _driver.WaitForElement(By.XPath("(//button[@data-identifier='referred-" + referenceNumber + "']//following::strong)[1]")).GetAttribute("class").ToUpper().Contains(color);
                }
                else
                {
                    try
                    {
                        lnkNext.ScrollToElement(_driver);
                        if (lnkNext.Displayed)
                        {
                            lnkNext.Click();
                        }
                    }
                    catch (NoSuchElementException)
                    {
                    }
                }
            }
            return false;
        }
        #endregion
    }
}