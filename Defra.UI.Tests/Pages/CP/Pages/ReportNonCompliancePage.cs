﻿using Reqnroll.BoDi;
using Defra.UI.Tests.Tools;
using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Tools;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;


namespace Defra.UI.Tests.Pages.CP.Pages
{
    public class ReportNonCompliancePage : IReportNonCompliancePage
    {
        private readonly IObjectContainer _objectContainer;

        public ReportNonCompliancePage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement pageHeading => _driver.WaitForElement(By.XPath("//h1[normalize-space()='Report non-compliance']"));
        private IWebElement btnReportNonCompliance => _driver.WaitForElement(By.XPath("//button[normalize-space()='Save outcome']"));
        private IWebElement lnkPetTravelDocumentDetails => _driver.WaitForElement(By.XPath("//span[normalize-space()='Pet Travel Document details']"));
        private IWebElement btnFootPassengerRadio => _driver.WaitForElementExists(By.CssSelector("#passengerType"));
        private IWebElement bntVehicleRadio => _driver.WaitForElementExists(By.CssSelector("#vehiclePassenger"));
        private IWebElement bntAirlineRadio => _driver.WaitForElementExists(By.CssSelector("#airlinePassenger"));
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
        private IWebElement lblTableNameApplicationDetails => _driver.WaitForElement(By.XPath("//*[@id='document-microchip-card']//h2[normalize-space()='Application details']"));
        private IWebElement txtValueReferenceNumber => _driver.WaitForElement(By.XPath("//*[contains(text(),'Application reference number')]/following-sibling::dd"));
        private IWebElement txtValueDate => _driver.WaitForElement(By.XPath("//*[@id='document-microchip-card']//*[contains(text(),'Date')]/following-sibling::dd"));
        private IWebElement txtValueStatus => _driver.WaitForElement(By.XPath("//*[contains(text(),'Status')]/following-sibling::dd/strong"));
        private IWebElement txtValuePTDNumber => _driver.WaitForElement(By.XPath("//*[contains(text(),'PTD number')]/following-sibling::dd"));
        private IWebElement lblPassengerDetails => _driver.WaitForElement(By.XPath("//*[@id='nonComplianceForm']//h2[2]"));
        private IWebElement lblTypeOfPassenger => _driver.WaitForElement(By.XPath("//*[@id='passengerFormGroup']//h3"));
        private IWebElement lblVisualCheck => _driver.WaitForElement(By.XPath("//h3[normalize-space()='Visual check']"));
        private IWebElement lnkPetDetailsFromPTD => _driver.WaitForElement(By.XPath("//span[normalize-space()='Pet details from PTD']"));
        private IWebElement lblVisualCheckCheckBox => _driver.WaitForElement(By.XPath("//label[normalize-space()='Pet does not match the PTD']"));
        private IWebElement lblVisualCheckTableName => _driver.WaitForElement(By.XPath("//*[@id='document-pet-card']//h2"));
        private IWebElement lblVisualCheckTableSpecies => _driver.WaitForElement(By.XPath("//*[contains(text(),'Species')]/following-sibling::dd"));
        private IWebElement lblVisualCheckTableBreed => _driver.WaitForElement(By.XPath("//*[contains(text(),'Breed')]/following-sibling::dd"));
        private IWebElement lblVisualCheckTableSex => _driver.WaitForElement(By.XPath("//*[contains(text(),'Sex')]/following-sibling::dd"));
        private IWebElement lblVisualCheckTableDateOfBirth => _driver.WaitForElement(By.XPath("//*[contains(text(),'Date of birth')]/following-sibling::dd"));
        private IWebElement lblVisualCheckTableColour => _driver.WaitForElement(By.XPath("//*[contains(text(),'Colour')]/following-sibling::dd"));
        private IWebElement lblVisualCheckTableSignificantFeature => _driver.WaitForElement(By.XPath("//*[contains(text(),'Significant feature')]/following-sibling::dd"));
        private IWebElement lblOtherIssues => _driver.WaitForElement(By.XPath("//h3[normalize-space()='Other issues']"));
        private IWebElement lblOtherIssuesOption1 => _driver.WaitForElement(By.XPath("//h3[normalize-space()='Other issues']//following::label[1]"));
        private IWebElement lblOtherIssuesOption2 => _driver.WaitForElement(By.XPath("//h3[normalize-space()='Other issues']//following::label[2]"));
        private IWebElement lblOtherIssuesOption3 => _driver.WaitForElement(By.XPath("//h3[normalize-space()='Other issues']//following::label[3]"));
        private IWebElement lblOtherReasonHint => _driver.WaitForElement(By.Id("somethingRadio-item-hint"));
        private IWebElement lblMCHeader => _driver.WaitForElement(By.XPath("//h3[normalize-space()='Microchip']"));
        private IWebElement lblMCDetailsLink => _driver.WaitForElement(By.XPath("//span[normalize-space()='Microchip details from PTD']"));
        private IWebElement lblMCCheckbox1 => _driver.WaitForElement(By.XPath("//span[normalize-space()='Microchip details from PTD']/following::label[1]"));
        private IWebElement lblMCCheckbox2 => _driver.WaitForElement(By.XPath("//span[normalize-space()='Microchip details from PTD']/following::label[3]"));
        private IWebElement lblMCNumber => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Microchip number')]"));
        private IWebElement lblMCNumberValue => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Microchip number')]/following-sibling::dd"));
        private IWebElement lblMCImplantOrScanDate => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Implant or scan date')]"));
        private IWebElement lblMCImplantOrScanDateValue => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Implant or scan date')]/following-sibling::dd"));
        private IWebElement lblMCNumberNotFoundInScan => _driver.WaitForElement(By.XPath("//label[normalize-space()='Microchip number found in scan']"));
        private IWebElement txtMCNumberNotFoundInScan => _driver.WaitForElement(By.XPath("//label[normalize-space()='Microchip number found in scan']/following::input[1]"));
        private IWebElement lblPetOwnerDetailsSubHeading => _driver.WaitForElement(By.XPath("//h2[@class='govuk-heading-l govuk-!-margin-top-9']"));
        private IWebElement lblPetOwnerDetailsTableName => _driver.WaitForElement(By.XPath("//*[@id='document-owner-card']//h2"));
        private IWebElement lblPetOwnerName => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Name')]/following-sibling::dd"));
        private IWebElement lblPetOwnerEmail => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Email')]/following-sibling::dd"));
        private IWebElement lblPetOwnerAddress => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Address')]/following-sibling::dd"));
        private IWebElement lblPetOwnerPhoneNumber => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Phone number')]/following-sibling::dd"));
        private IWebElement lblInfoSubmittedMessage => _driver.WaitForElement(By.XPath("//*[@id='success-id']"));
        private IWebElement bntSaveOutCome=> _driver.WaitForElementExists(By.XPath("//button[normalize-space()='Save outcome']"));
        #endregion

        #region Methods
        public bool IsPageLoaded()
        {
            if (ConfigSetup.BaseConfiguration.TestConfiguration.IsAccessibilityEnabled)
            {
                Cognizant.WCAG.Compliance.Checker.Analyzer.Execute(_driver, true);
            }

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
            var ptd = txtValuePTDNumber.Text;
            return txtValuePTDNumber.Text.Trim().Equals($"GB826 {ptdNumber}");
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

        public void ClickGBOutcomeCheckbox(string GBOutcome)
        {
            if (GBOutcome.Equals("Passenger referred to DAERA/SPS at NI port"))
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", chkGBOutcome1);
                chkGBOutcome1.Click();
            }
            else if (GBOutcome.Equals("Passenger advised not to travel"))
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", chkGBOutcome2);
                chkGBOutcome2.Click();
            }
            else if (GBOutcome.Equals("Passenger says they will not travel"))
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", chkGBOutcome3);
                chkGBOutcome3.Click();
            }
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
        public bool VerifyMaxLengthOfDetailsOfOutcomeTextarea(string maxLength)
        {
            return txtareaSPSOutcome.GetAttribute("maxlength").Equals(maxLength);
        }

        public bool VerifyAnyRelavantCommentsTextarea(string heading, string hint, string maxLength)
        {
            return lblAnyRelavantComments.Text.Contains(heading)
                   && lblAnyRelavantCommentsHint.Text.Contains(hint)
                   && TxtAnyRelavantComments.GetAttribute("maxlength").Equals(maxLength);
        }

        public bool VerifyTypeOfPassengerSubheading(string subHeading, string sectionName)
        {
            return lblPassengerDetails.Text.Contains(sectionName) && lblTypeOfPassenger.Text.Contains(subHeading);
        }

        public bool VerifyVCAndPetOwnerDetailSubheading(string subHeading)
        {
            if (subHeading.Equals("Visual check"))
                return lblVisualCheck.Text.Contains(subHeading);
            return lblPetOwnerDetailsSubHeading.Text.Contains(subHeading);
        }

        public bool VerifyPetDetailsFromPTDLink(string linkName)
        {
            _driver.ExecuteScript("arguments[0].scrollIntoView();", lnkPetDetailsFromPTD);
            lnkPetDetailsFromPTD.Click();
            return lnkPetDetailsFromPTD.Text.Contains(linkName);
        }

        public bool VerifyPetDoesNotMatchThePTDCheckBox(string checkBoxValue)
        {
            return lblVisualCheckCheckBox.Text.Contains(checkBoxValue);
        }

        public bool VerifyVCAndPetOwnerDetailTableName(string tableName)
        {
            return tableName.ToUpper().Equals("PET DETAILS FROM PTD OR APPLICATION") ? lblVisualCheckTableName.Text.ToUpper().Contains(tableName.ToUpper()) : lblPetOwnerDetailsTableName.Text.ToUpper().Contains(tableName.ToUpper());
        }

        public bool VerifyVisualCheckTableFields(string species, string breed, string sex, string dob, string colour, string significantFeature)
        {
            return lblVisualCheckTableSpecies.Text.Contains(species) && lblVisualCheckTableBreed.Text.Contains(breed)
                && lblVisualCheckTableSex.Text.Contains(sex) && lblVisualCheckTableDateOfBirth.Text.Contains(dob)
                && lblVisualCheckTableColour.Text.Contains(colour) && lblVisualCheckTableSignificantFeature.Text.Contains(significantFeature);
        }

        public bool VerifyOtherIssuesSubheading(string subHeading)
        {
            return lblOtherIssues.Text.Contains(subHeading);
        }

        public bool VerifyOtherIssuesCheckboxes(string checkboxOptions)
        {
            var otherIssuesCheckbox = checkboxOptions.Split('|');
            return otherIssuesCheckbox[0].Equals(lblOtherIssuesOption1.Text)
                && otherIssuesCheckbox[1].Equals(lblOtherIssuesOption2.Text)
                && otherIssuesCheckbox[2].Equals(lblOtherIssuesOption3.Text);
        }

        public bool VerifyOtherReasonOptionHint(string hint)
        {
            return lblOtherReasonHint.Text.ToLower().Contains(hint.ToLower());
        }

        public bool VerifyOtherIssuesCheckboxesAreNotChecked()
        {
            return lblOtherIssuesOption1.HasAttribute("Checked")
                && lblOtherIssuesOption2.HasAttribute("Checked")
                && lblOtherIssuesOption3.HasAttribute("Checked");
        }

        public bool VerifyMicrochipSection()
        {
            return lblMCHeader.Text.Contains("Microchip")
                   && lblMCCheckbox1.Text.Contains("Microchip number does not match the PTD")
                   && lblMCCheckbox2.Text.Contains("Cannot find microchip")
                   && lblMCDetailsLink.Text.Contains("Microchip details from PTD");
        }

        public bool VerifyMCDetailsPTDTableWithValues(string MCDetails)
        {
            _driver.ExecuteScript("arguments[0].scrollIntoView();", lblMCDetailsLink);
            lblMCDetailsLink.Click();
            string[] MCNumberAndDate = MCDetails.Split('|');
            return lblMCNumber.Text.Equals("Microchip number") && lblMCImplantOrScanDate.Text.Equals("Implant or scan date") && lblMCNumberValue.Text.Equals(MCNumberAndDate[0]) && lblMCImplantOrScanDateValue.Text.Equals(MCNumberAndDate[1]);
        }

        public void ClickOnMCCheckbox(string mcCheckbox)
        {
            if (mcCheckbox.Equals("Microchip number does not match the PTD"))
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", lblMCCheckbox1);
                lblMCCheckbox1.Click();
            }
            else if (mcCheckbox.Equals("Cannot find microchip"))
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", lblMCCheckbox2);
                lblMCCheckbox2.Click();
            }
        }

        public void EnterMCNumber(string MCNumber)
        {
            lblMCNumberNotFoundInScan.Text.Equals("Microchip number found in scan");
            txtMCNumberNotFoundInScan.Clear();
            txtMCNumberNotFoundInScan.SendKeys(MCNumber);
        }
        public bool VerifyNameAndEmailOfPetOwner(string name, string email)
        {
            return lblPetOwnerName.Text.Contains(name)
                && lblPetOwnerEmail.Text.Contains(email);
        }

        public bool VerifyAddressAndPhoneNumberOfPetOwner(string address, string phoneNumber)
        {
            var addressReplaceNewLine = lblPetOwnerAddress.Text.ReplaceLineEndings("\n");
            var addressDetail = addressReplaceNewLine.Replace('\n', ',');

            return addressDetail.Contains(address)
                && lblPetOwnerPhoneNumber.Text.Contains(phoneNumber);
        }

        public bool VerifyInfoSubmittedMessage(string submittedMessage)
        {
            return lblInfoSubmittedMessage.Text.Contains(submittedMessage);
        }

        public void ClickSaveOutComeButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", bntSaveOutCome);
            bntSaveOutCome.Click();
        }

        #endregion
    }
}