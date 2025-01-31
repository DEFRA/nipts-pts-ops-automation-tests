using BoDi;
using Defra.UI.Tests.Tools;
using Defra.UI.Tests.Pages.CP.Interfaces;
using OpenQA.Selenium;
using static Microsoft.Dynamics365.UIAutomation.Api.Pages.ActivityFeed;
using System.Drawing;
using FluentAssertions;
using AngleSharp.Text;
using OpenQA.Selenium.DevTools.V122.Overlay;
using Microsoft.Dynamics365.UIAutomation.Browser;


namespace Defra.UI.Tests.Pages.CP.Pages
{
    public class ReportNonCompliancePage : IReportNonCompliancePage
    {
        private readonly IObjectContainer _objectContainer;

        public ReportNonCompliancePage (IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement pageHeading => _driver.WaitForElement(By.XPath("//h1[normalize-space()='Report non-compliance']"));
        private IWebElement btnReportNonCompliance => _driver.WaitForElement(By.XPath("//button[normalize-space()='Report non-compliance']"));
        private IWebElement lnkPetTravelDocumentDetails => _driver.WaitForElement(By.XPath("//span[normalize-space()='Pet Travel Document details']"));
        private IWebElement btnFootPassengerRadio=> _driver.WaitForElementExists(By.CssSelector("#footPassenger"));
        private IWebElement bntVehicleRadio => _driver.WaitForElementExists(By.CssSelector("#vehiclePassenger"));
        private IWebElement chkGBOutcome1 => _driver.WaitForElementExists(By.XPath("//h2[text()='GB outcome']//following::label[1]"));
        private IWebElement chkGBOutcome2 => _driver.WaitForElementExists(By.XPath("//h2[text()='GB outcome']//following::label[2]"));
        private IWebElement chkGBOutcome3 => _driver.WaitForElementExists(By.XPath("//h2[text()='GB outcome']//following::label[3]"));
        private IWebElement chkSPSOutcome1 => _driver.WaitForElementExists(By.XPath("//h2[text()='SPS outcome']//following::label[1]"));
        private IWebElement chkSPSOutcome2 => _driver.WaitForElementExists(By.XPath("//h2[text()='SPS outcome']//following::label[2]"));
        private IWebElement txtareaSPSOutcome => _driver.WaitForElementExists(By.XPath("//textarea[@name='spsOutcomeDetails']"));
        private IWebElement lblDetailsOfOutcome => _driver.WaitForElementExists(By.XPath("//b[text()='Details of outcome']"));
        private IWebElement lblAnyRelavantComments => _driver.WaitForElementExists(By.XPath("//label[normalize-space()='Any relevant comments']"));
        private IWebElement lblAnyRelavantCommentsHint => _driver.WaitForElementExists(By.XPath("//label[normalize-space()='Any relevant comments']/following::div[1]"));
        private IWebElement TxtAnyRelavantComments => _driver.WaitForElementExists(By.XPath("//label[normalize-space()='Any relevant comments']/following::div[1]/following::textarea[1]"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        private IReadOnlyCollection<IWebElement> lblPetTravelDocumentDetails => _driver.FindElements(By.XPath("//span[@class='govuk-heading-s']"));
        private IWebElement lblPTDStatus => _driver.WaitForElementExists(By.XPath("//p[@class='govuk-body govuk-!-margin-bottom-0 pts-checker-check']"));
        private IWebElement lblReasonsHeading => _driver.WaitForElement(By.XPath("//h2[@class='govuk-fieldset__heading']"));
        private IWebElement lblReasonsHint => _driver.WaitForElementExists(By.Id("event-name-hint"));
        private IWebElement lblTableNamePTD => _driver.WaitForElement(By.XPath("//*[@id='document-microchip-card']//h2[normalize-space()='Pet Travel Document (PTD)']"));
        private IWebElement lblTableNameApplicationDetails => _driver.WaitForElement(By.XPath("//*[@id='document-microchip-card']//h2[normalize-space()='Application Details']"));
        private IWebElement txtValueReferenceNumber => _driver.WaitForElement(By.XPath("//*[contains(text(),'Reference number')]/following-sibling::dd"));
        private IWebElement txtValueDate => _driver.WaitForElement(By.XPath("//*[@id='document-microchip-card']//*[contains(text(),'Date')]/following-sibling::dd"));
        private IWebElement txtValueStatus => _driver.WaitForElement(By.XPath("//*[contains(text(),'Status')]/following-sibling::dd/strong"));
        private IWebElement txtValuePTDNumber => _driver.WaitForElement(By.XPath("//*[contains(text(),'PTD number')]/following-sibling::dd"));
        #endregion

        #region Methods
        public bool IsPageLoaded()
        {
            return pageHeading.Text.Contains("Report non-compliance");
        }

        public void SelectReportNonComplianceButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", btnReportNonCompliance);
            btnReportNonCompliance.Click();
        }

        public void ClickPetTravelDocumentDetailsLnk()
        {
            lnkPetTravelDocumentDetails.Click();
        }

        public bool CheckPetTravelDocumentDetailsSection(string status)
        {
            var cnt = lblPetTravelDocumentDetails.Count;
            if (cnt > 0)
            {
                return lblPTDStatus.Text.Contains(status);
            }
            return false;
        }

        public bool VerifyTheTableNameInPTDLink(string tableName)
        {
            return lblTableNameApplicationDetails.Text.Trim().Equals(tableName);
        }
        public bool VerifyTableNameForApprovedAndRevokedInPTDLink(string tableName)
        {
            return lblTableNamePTD.Text.Trim().Equals(tableName);
        }
        public bool VerifyTheExpectedStatus(string applicationStatus)
        {
            var bgColor = txtValueStatus.GetCssValue("background-color");
            dynamic[] rgbValues = bgColor.Replace("rgba(", "").Replace(")", "").Split(',');
            int r = int.Parse(rgbValues[0]);
            int g = int.Parse(rgbValues[1]);
            int b = int.Parse(rgbValues[2]);
            string hexColor = "#" + r.ToString("X2") + g.ToString("X2") + b.ToString("X2");
            string expectedColor = null;

            switch (applicationStatus)
            {
                case "Approved":
                    expectedColor = "#CCE2D8";
                    break;
                case "Awaiting verification":
                    expectedColor = "#FFF7BF";
                    break;
                case "Revoked":
                    expectedColor = "#FCD6C3";
                    break;
                case "Unsuccessful":
                    expectedColor = "#F4CDC6";
                    break;
            }

            return txtValueStatus.Text.Trim().Equals(applicationStatus) && expectedColor.Equals(hexColor);
        }
        public bool VerifyThePTDNumber(string ptdNumber)
        {
            var actualPTDNumber = "GB826" + ptdNumber;
            return txtValuePTDNumber.Text.Trim().Equals(actualPTDNumber);
        }
        public bool VerifyTheDateOfIssuance(string dateOfIssuance)
        {
            return txtValueDate.Text.Trim().Equals(dateOfIssuance);
        }
        public bool VerifyTheReferenceNumber(string referenceNumber)
        {
            return txtValueReferenceNumber.Text.Trim().Equals(referenceNumber);
        }
        public bool VerifyReasonsHeadingWithHint(string reasons, string hint)
        {
            string reasonsHeading = lblReasonsHeading.Text;
            return reasonsHeading.Equals(reasons) && lblReasonsHint.Text.Trim().Equals(hint);
        }

        public void SelectTypeOfPassenger(string radioButtonValue)
        {

            if (radioButtonValue.Equals("Foot passenger"))
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", btnFootPassengerRadio);
                btnFootPassengerRadio.Click();
            }
            else
            {
                try
                {
                    ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", bntVehicleRadio);
                    bntVehicleRadio.Click();
                }
                catch
                {
                    bntVehicleRadio.FindElement(By.CssSelector("#vehiclePassenger")).Click();
                }
            }
        }

        public bool IsError(string errorMessage)
        {
            foreach (var element in lblErrorMessages)
            {
                if (element.Text.Contains(errorMessage))
                {
                    return true;
                }
            }
            return false;
        }

        public bool VerifyGBOutcomeCheckboxes(string checkboxValues)
        {
            var gbOutcomeCheckbox = checkboxValues.Split('|');
            return (gbOutcomeCheckbox[0].Equals(chkGBOutcome1.Text) && gbOutcomeCheckbox[1].Equals(chkGBOutcome2.Text) && gbOutcomeCheckbox[2].Equals(chkGBOutcome3.Text));
        }
        
        public bool VerifySPSOutcomeCheckboxes(string checkboxValues)
        {
            var spsOutcomeCheckbox = checkboxValues.Split('|');
            return (spsOutcomeCheckbox[0].Equals(chkSPSOutcome1.Text) && spsOutcomeCheckbox[1].Equals(chkSPSOutcome2.Text));
        }

        public bool VerifySPSCheckboxesAreNotChecked()
        {
            return (chkSPSOutcome2.HasAttribute("Checked") && chkSPSOutcome1.HasAttribute("Checked"));
        }       
        public bool VerifyGBCheckboxesAreNotChecked()
        {
            return (chkGBOutcome1.HasAttribute("Checked") && chkGBOutcome2.HasAttribute("Checked") && chkGBOutcome3.HasAttribute("Checked"));
        }
        public bool VerifyDetailsOfOutcome()
        {
            return lblDetailsOfOutcome.Text.Contains("Details of outcome");
        }
        public bool VerifyMaxLengthOfDetailsOfOutcomeTextarea(String maxLength)
        {
            return txtareaSPSOutcome.GetAttribute("maxlength").Equals(maxLength);
        }

        public bool VerifyAnyRelavantCommentsTextarea(String heading, String hint, String maxLength)
        {
            return lblAnyRelavantComments.Text.Contains(heading) && lblAnyRelavantCommentsHint.Text.Contains(hint) && TxtAnyRelavantComments.GetAttribute("maxlength").Equals(maxLength);
        }
        #endregion
    }
}