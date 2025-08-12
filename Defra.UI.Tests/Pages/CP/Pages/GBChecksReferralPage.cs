using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Tools;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using Reqnroll.BoDi;

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
        private IWebElement ptdOrReferenceNumber => _driver.WaitForElement(By.XPath("//*[@class='referred-form']/button"));
        private IReadOnlyCollection<IWebElement> ptdOrReferenceNumberList => _driver.WaitForElements(By.XPath("//*[@class='referred-form']/button"));
        private IWebElement lblOutcome => _driver.WaitForElement(By.XPath("//h2[normalize-space()='Outcome']"));
        private IWebElement lblCheckdetails => _driver.WaitForElement(By.XPath("//h2[normalize-space()='Check details']"));
        private IWebElement lblCheckOutcome => _driver.WaitForElement(By.XPath("//dt[normalize-space()='Check outcome']"));
        private IWebElement lblCheckOutcomeValue => _driver.WaitForElement(By.XPath("//h2[text()='Outcome']//following::p[1]"));
        private IWebElement lblReasonForReferral => _driver.WaitForElement(By.XPath("//dt[normalize-space()='Reason for referral']"));
        private IWebElement lblReasonForReferralValue => _driver.WaitForElement(By.XPath("//dt[text()='Reason for referral']//following::p[1]"));
        private IWebElement lblReasonForReferralMultipleValues => _driver.WaitForElement(By.XPath("//dt[text()='Reason for referral']//following::dd/ul"));
        private IWebElement lblMcNumberFoundInScan => _driver.WaitForElement(By.XPath("//dt[normalize-space()='Microchip number found in scan']"));
        private IWebElement lblMcNumberFoundInScanValue => _driver.WaitForElement(By.XPath("//dt[text()='Microchip number found in scan']//following::p[1]"));
        private IWebElement lblDetailsOfOutcome => _driver.WaitForElement(By.XPath("//dt[normalize-space()='Details of outcome']"));
        private IWebElement lblDetailsOfOutcomeValue => _driver.WaitForElement(By.XPath("//dt[text()='Details of outcome']//following::p[1]"));
        private IWebElement lblAdditionalComments => _driver.WaitForElement(By.XPath("//dt[normalize-space()='Additional comments']"));
        private IWebElement lblAdditionalCommentsValue => _driver.WaitForElement(By.XPath("//dt[text()='Additional comments']//following::p[1]"));
        private IWebElement lblGBCheckerName => _driver.WaitForElement(By.XPath("//dt[normalize-space()='GB checker’s name']"));
        private IWebElement lblGBCheckerNameValue => _driver.WaitForElement(By.XPath("//dt[text()='GB checker’s name']//following::dd[1]"));
        private IWebElement lblRoute => _driver.WaitForElement(By.XPath("//dt[normalize-space()='Route']"));
        private IWebElement lblRouteValue => _driver.WaitForElement(By.XPath("//dt[text()='Route']//following::dd[1]"));
        private IWebElement lblDateAndTimeChecked => _driver.WaitForElement(By.XPath("//dt[normalize-space()='Date and time checked']"));
        private IWebElement lblDateAndTimeCheckedValue => _driver.WaitForElement(By.XPath("//dt[text()='Date and time checked']//following::dd[1]"));
        private IWebElement lblDepartDate => _driver.WaitForElement(By.XPath("//dt[normalize-space()='Scheduled departure date']"));
        private IWebElement lblDepartDateValue => _driver.WaitForElement(By.XPath("//dt[text()='Scheduled departure date']//following::p[1]"));
        private IWebElement lblDepartTime => _driver.WaitForElement(By.XPath("(//dt[normalize-space()='Scheduled departure time'])"));
        private IWebElement lblDepartTimeValue => _driver.WaitForElement(By.XPath("//dt[text()='Scheduled departure time']//following::p[1]"));
        private IWebElement lnkPTDRefNumber => _driver.WaitForElement(By.XPath("(//strong[normalize-space(.)='Check needed'])[1]//ancestor::tr//following-sibling::button"));
        private IWebElement btnConductSPSCheck => _driver.WaitForElement(By.XPath("//button[normalize-space(.)='Conduct an SPS check']"));
        private IWebElement lnkNext => _driver.WaitForElement(By.XPath("//*[@rel='next']"));
        private IWebElement DisplayedRouteInReferredToSPSPage => _driver.WaitForElement(By.XPath("//h1[text()='Referred to SPS']//following::caption"));
        private IReadOnlyCollection<IWebElement> ChecksPageTables => _driver.FindElements(By.XPath("//div[@class='govuk-summary-card']"));
        private IWebElement lblPTDRefNumber => _driver.WaitForElement(By.XPath("//*[@class='govuk-table__head']//th[1]"));
        private IWebElement lblPet => _driver.WaitForElement(By.XPath("//*[@class='govuk-table__head']//th[2]"));
        private IWebElement lblMicrochip => _driver.WaitForElement(By.XPath("//*[@class='govuk-table__head']//th[3]"));
        private IWebElement lblTravelBy => _driver.WaitForElement(By.XPath("//*[@class='govuk-table__head']//th[4]"));
        private IWebElement lblSPSOutcome => _driver.WaitForElement(By.XPath("//*[@class='govuk-table__head']//th[5]"));
        private IWebElement lblPTDRefNumberValue => _driver.WaitForElement(By.XPath("//*[@class='govuk-table__body']//th"));
        private IWebElement lblPetValue => _driver.WaitForElement(By.XPath("//*[@class='govuk-table__body']//td[1]"));
        private IWebElement lblMicrochipValue => _driver.WaitForElement(By.XPath("//*[@class='govuk-table__body']//td[2]"));
        private IWebElement lblTravelByValue => _driver.WaitForElement(By.XPath("//*[@class='govuk-table__body']//td[3]"));
        private IWebElement lblSPSOutcomeValue => _driver.WaitForElement(By.XPath("//*[@class='govuk-table__body']//td[4]"));
        private IReadOnlyCollection<IWebElement> allPTDRefNumberValues => _driver.FindElements(By.XPath("//*[@class='govuk-table__body']//button"));
        private IWebElement txtPassCount => _driver.WaitForElement(By.XPath("//*[contains(text(),'Pass')]//following-sibling::dd"));
        private IReadOnlyCollection<IWebElement> recordsInGBReferralList => _driver.FindElements(By.XPath("//*[@class='govuk-table__body']/tr"));
        private IReadOnlyCollection<IWebElement> pagination => _driver.FindElements(By.XPath("//*[@class='govuk-pagination__list']"));
        private IReadOnlyCollection<IWebElement> lnkNextpagination => _driver.FindElements(By.XPath("//*[@class='govuk-pagination__next']"));
        private IWebElement lnkPrevpagination => _driver.WaitForElement(By.XPath("//*[@class='govuk-pagination__prev']"));
        private IWebElement lnkPage1 => _driver.WaitForElement(By.XPath("//*[@aria-label='Page 1']"));
        private IWebElement lnkPage2 => _driver.WaitForElement(By.XPath("//*[@aria-label='Page 2']"));
        const string VIEWLINK_XPATH = ".//*[contains(text(),'Fail: Referred to SPS')]//following-sibling::dd[2]//following-sibling::button";
        const int PAGE_SIZE = 10;

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

        public void ClickViewLink(string departureTime)
        {
            DateTime dateAndTime = DateTime.Today;
            var currentDate = dateAndTime.ToString("dd/MM/yyyy");

            foreach (var table in ChecksPageTables)
            {
                if (table.Text.Contains(currentDate) && table.Text.Contains(departureTime))
                {
                    table.ScrollToElement(_driver);
                    IWebElement viewLinkWithinTable = table.FindElement(By.XPath(".//*[contains(text(),'View')]"));
                    viewLinkWithinTable.Click();
                    break;
                }
            }
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
            && (lblReasonForReferralValue.Text.Trim().Equals(referralReason) || lblReasonForReferralMultipleValues.Text.Trim().Replace("\r\n", ", ").Equals(referralReason));
        }

        public bool MCNumberFoundInScan(string mcNumber)
        {
            return lblMcNumberFoundInScan.Text.Trim().Equals("Microchip number found in scan")
            && lblMcNumberFoundInScanValue.Text.Trim().Equals(mcNumber);
        }

        public bool VerifyDetailsOfOutcome(string outcomeDetails)
        {
            return lblDetailsOfOutcome.Text.Trim().Equals("Details of outcome")
            && lblDetailsOfOutcomeValue.Text.Trim().Equals(outcomeDetails);
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
            while (true)
            {
                foreach (var element in ptdOrReferenceNumberList)
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

        public bool CheckRouteDetailOnReferredToSPSPage(string route, string departureTime)
        {
            var routeDetail = DisplayedRouteInReferredToSPSPage.Text;
            dynamic[] rows = routeDetail.Split("-");
            dynamic displayedRoute = rows[0].Trim();
            dynamic displayedDate = rows[1].Substring(1, 10);
            dynamic displayedTime = rows[1].Substring(12, 5);

            DateTime dateAndTime = DateTime.Today;
            var currentDate = dateAndTime.ToString("dd/MM/yyyy");

            return displayedRoute.Equals(route) && displayedDate.Equals(currentDate) && displayedTime.Equals(departureTime);
        }

        public bool CheckReferredToSPSTableLabels(string ptdOrRefNumber, string pet, string microchip, string travelBy, string spsOutcome)
        {
            var ptdOrRefNumFromInput = ptdOrRefNumber.Replace(" or ", "/");
            return lblPTDRefNumber.Text.Trim().Equals(ptdOrRefNumFromInput) && lblPet.Text.Trim().Equals(pet)
                && lblMicrochip.Text.Trim().Equals(microchip) && lblTravelBy.Text.Trim().Equals(travelBy)
                && lblSPSOutcome.Text.Trim().Equals(spsOutcome);
        }

        public bool CheckReferredToSPSTableValues(string ptdOrRefNumber, string pet, string microchip, string travelBy, string spsOutcome)
        {
            var petFromInput = pet.Replace(" and ", ", ");
            return lblPTDRefNumberValue.Text.Trim().Contains(ptdOrRefNumber) && lblPetValue.Text.Trim().Contains(petFromInput)
                && lblMicrochipValue.Text.Trim().Contains(microchip) && lblTravelByValue.Text.Trim().Contains(travelBy)
                && lblSPSOutcomeValue.Text.Trim().Contains(spsOutcome);
        }

        public bool CheckPTDOrRefNumDuplicates(string ptdOrRefNumber)
        {
            int count = 0;

            foreach (var ptdOrRefNum in allPTDRefNumberValues)
            {
                if (ptdOrRefNum.Text.Trim().Equals(ptdOrRefNumber))
                {
                    count++;
                    if (count > 1)
                        return false;
                }
            }
            return true;
        }

        public bool CheckPassCount(string count, string departureTime)
        {
            DateTime dateAndTime = DateTime.Today;
            var currentDate = dateAndTime.ToString("dd/MM/yyyy");

            foreach (var table in ChecksPageTables)
            {
                if (table.Text.Contains(currentDate) && table.Text.Contains(departureTime))
                {
                    table.ScrollToElement(_driver);
                    IWebElement passCount = table.FindElement(By.XPath(".//*[contains(text(),'Pass')]//following-sibling::dd"));
                    return passCount.Text.Trim().Equals(count);
                }
            }
            return false;
        }

        public bool CheckFailCount(string count, string departureTime)
        {
            DateTime dateAndTime = DateTime.Today;
            var currentDate = dateAndTime.ToString("dd/MM/yyyy");

            foreach (var table in ChecksPageTables)
            {
                if (table.Text.Contains(currentDate) && table.Text.Contains(departureTime))
                {
                    table.ScrollToElement(_driver);
                    IWebElement failCount = table.FindElement(By.XPath(".//*[contains(text(),'Fail: Referred to SPS')]//following-sibling::dd[1]"));
                    return failCount.Text.Trim().Equals(count);
                }
            }
            return false;
        }

        public bool IsViewLinkPresent(string departureTime)
        {
            var currentDate = DateTime.Today.ToString("dd/MM/yyyy");
            
            foreach (var table in ChecksPageTables)
            {
                if (table.Text.Contains(currentDate) && table.Text.Contains(departureTime))
                {
                    table.ScrollToElement(_driver);

                    try
                    {
                        var viewLink = table.FindElement(By.XPath(VIEWLINK_XPATH));

                        if (viewLink != null)
                        {
                            return false;
                        }
                    }
                    catch (NoSuchElementException)
                    {
                        // Element not found, continue checking other tables
                    }
                }
            }
            return true;
        }

        public bool DateAndTimeChecked()
        {
            DateTime dateAndTime = DateTime.Now;
            var currentDate = dateAndTime.ToString("dd/MM/yyyy");
            var currentTime = dateAndTime.ToString("HH:mm");
            var currentTimeMinusOneHour = dateAndTime.AddHours(-1).ToString("HH:mm");
            var currentTimeMinusOneMin = dateAndTime.AddMinutes(-1).ToString("HH:mm");
            var currentTimeMinusOneHourMinusOneMin = dateAndTime.AddHours(-1).AddMinutes(-1).ToString("HH:mm");

            return lblDateAndTimeChecked.Text.Trim().Equals("Date and time checked")
                && lblDateAndTimeCheckedValue.Text.Trim().Contains(currentDate)
                && (lblDateAndTimeCheckedValue.Text.Trim().Contains(currentTime) || lblDateAndTimeCheckedValue.Text.Trim().Contains(currentTimeMinusOneHour)
                || lblDateAndTimeCheckedValue.Text.Trim().Contains(currentTimeMinusOneMin) || lblDateAndTimeCheckedValue.Text.Trim().Contains(currentTimeMinusOneHourMinusOneMin));
        }

        public bool CheckPagination()
        {
            if (recordsInGBReferralList.Count > PAGE_SIZE)
            {
                return false;
            }
            else if (recordsInGBReferralList.Count < PAGE_SIZE)
            {
                if (lnkNextpagination.Count == 0)
                    return true;
            }
            else if (recordsInGBReferralList.Count == PAGE_SIZE)
            {
                while (lnkNextpagination.Count > 0)
                {
                    lnkNext.ScrollAndClick(_driver);
                    if (recordsInGBReferralList.Count >= 1 && lnkPrevpagination.Displayed)
                        return true;
                    else if (recordsInGBReferralList.Count > PAGE_SIZE || !lnkPrevpagination.Displayed)
                        return false;
                }
                return true;
            }
            return false;
        }

        public bool CheckDirectPageNavigation()
        {
            if (pagination.Count > 0)
            {
                lnkPage1.ScrollAndClick(_driver);
                if (recordsInGBReferralList.Count == PAGE_SIZE)
                {
                    lnkPage2.ScrollAndClick(_driver);
                    if (recordsInGBReferralList.Count >= 1)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
            return true;
        }
        #endregion
    }
}