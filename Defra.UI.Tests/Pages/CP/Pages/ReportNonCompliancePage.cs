using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Tools;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using Reqnroll.BoDi;
using System.Collections.ObjectModel;


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
        private IWebElement btnFootPassengerRadio => _driver.WaitForElementExists(By.XPath("//*[@id='passengerType']/following-sibling::label"));
        private IWebElement btnVehicleRadio => _driver.WaitForElementExists(By.XPath("//*[@id='vehiclePassenger']/following-sibling::label"));
        private IWebElement btnAirlineRadio => _driver.WaitForElementExists(By.XPath("//*[@id='airlinePassenger']/following-sibling::label"));
        private IWebElement chkGBOutcome1 => _driver.WaitForElementExists(By.XPath("//label[normalize-space()='Passenger referred to DAERA/SPS at NI port']"));
        private IWebElement chkGBOutcome2 => _driver.WaitForElementExists(By.XPath("//label[normalize-space()='Passenger advised not to travel']"));
        private IWebElement chkGBOutcome3 => _driver.WaitForElementExists(By.XPath("//label[normalize-space()='Passenger says they will not travel']"));
        private IWebElement chkSPSOutcome1 => _driver.WaitForElementExists(By.XPath("//h2[text()='SPS outcome']//following::label[1]"));
        private IWebElement chkSPSOutcome2 => _driver.WaitForElementExists(By.XPath("//h2[text()='SPS outcome']//following::label[2]"));
        private IWebElement txtareaSPSOutcome => _driver.WaitForElementExists(By.Id("spsOutcomeDetails"));
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
        private IWebElement lblMCTableHeading => _driver.WaitForElement(By.XPath("//h2[normalize-space()='Microchip information from PTD or Application']"));
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
        private IWebElement btnSaveOutCome=> _driver.WaitForElementExists(By.XPath("//button[normalize-space()='Save outcome']"));
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
            btnReportNonCompliance.Click(_driver);
        }

        public void ClickPetTravelDocumentDetailsLnk()
        {
            lnkPetTravelDocumentDetails.Click(_driver);
        }

        public bool CheckPetTravelDocumentDetailsSection(string status)
        {
            var cnt = lblPetTravelDocumentDetails.Count;
            if (cnt > 0)
            {
                lblPTDStatus.ScrollIntoView(_driver);
                return lblPTDStatus.Text.Contains(status);
            }
            return false;
        }

        public bool VerifyTheTableNameInPTDLink(string tableName)
        {
            lblTableNameApplicationDetails.ScrollIntoView(_driver);
            return lblTableNameApplicationDetails.Text.Trim().Equals(tableName);
        }
        public bool VerifyTableNameForApprovedAndRevokedInPTDLink(string tableName)
        {
            lblTableNamePTD.ScrollIntoView(_driver);
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
                case "Pending":
                    expectedColor = "#BBD4EA";
                    break;
                case "Cancelled":
                case "Unsuccessful":
                    expectedColor = "#F4CDC6";
                    break;
            }

            return txtValueStatus.Text.Trim().Equals(applicationStatus) && expectedColor.Equals(hexColor);
        }
        public bool VerifyThePTDNumber(string ptdNumber)
        {
            txtValuePTDNumber.ScrollIntoView(_driver);
            return txtValuePTDNumber.Text.Trim().Equals($"GB826 {ptdNumber}");
        }
        public bool VerifyTheDateOfIssuance(string dateOfIssuance)
        {
            txtValueDate.ScrollIntoView(_driver);
            return txtValueDate.Text.Trim().Equals(dateOfIssuance);
        }
        public bool VerifyTheReferenceNumber(string referenceNumber)
        {
            txtValueReferenceNumber.ScrollIntoView(_driver);
            return txtValueReferenceNumber.Text.Trim().Equals(referenceNumber);
        }
        public bool VerifyReasonsHeadingWithHint(string reasons, string hint)
        {
            string reasonsHeading = lblReasonsHeading.Text;
            return reasonsHeading.Equals(reasons) && lblReasonsHint.Text.Trim().Equals(hint);
        }

        public void SelectTypeOfPassenger(string radioButtonValue)
        {

            if (radioButtonValue.Equals("Ferry foot passenger"))
            {
                btnFootPassengerRadio.ScrollAndClick(_driver);
            }
            else if (radioButtonValue.Equals("Vehicle on ferry"))
            {
                try
                {
                    btnVehicleRadio.ScrollAndClick(_driver);
                }
                catch
                {
                    btnVehicleRadio.ScrollAndClick(_driver);
                }
            }
            else
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", btnAirlineRadio);
                btnAirlineRadio.Click();
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
            chkGBOutcome1.ScrollIntoView(_driver);
            return (gbOutcomeCheckbox[0].Equals(chkGBOutcome1.Text) && gbOutcomeCheckbox[1].Equals(chkGBOutcome2.Text) && gbOutcomeCheckbox[2].Equals(chkGBOutcome3.Text));
        }

        public void ClickGBOutcomeCheckbox(string GBOutcome)
        {
            if (GBOutcome.Equals("Passenger referred to DAERA/SPS at NI port"))
            {
                chkGBOutcome1.ScrollAndClick(_driver);
            }
            else if (GBOutcome.Equals("Passenger advised not to travel"))
            {
                chkGBOutcome2.ScrollAndClick(_driver);
            }
            else if (GBOutcome.Equals("Passenger says they will not travel"))
            {
                chkGBOutcome3.ScrollAndClick(_driver);
            }
        }

        public bool VerifySPSOutcomeCheckboxes(string checkboxValues)
        {
            var spsOutcomeCheckbox = checkboxValues.Split('|');
            chkSPSOutcome1.ScrollIntoView(_driver);
            return (spsOutcomeCheckbox[0].Equals(chkSPSOutcome1.Text) && spsOutcomeCheckbox[1].Equals(chkSPSOutcome2.Text));
        }

        public bool VerifySPSCheckboxesAreNotChecked()
        {
            chkSPSOutcome2.ScrollIntoView(_driver);
            return (chkSPSOutcome2.HasAttribute("Checked") && chkSPSOutcome1.HasAttribute("Checked"));
        }
        public bool VerifyGBCheckboxesAreNotChecked()
        {
            chkGBOutcome1.ScrollIntoView(_driver);
            return (chkGBOutcome1.HasAttribute("Checked") && chkGBOutcome2.HasAttribute("Checked") && chkGBOutcome3.HasAttribute("Checked"));
        }
        public bool VerifyDetailsOfOutcome()
        {
            lblDetailsOfOutcome.ScrollIntoView(_driver);
            return lblDetailsOfOutcome.Text.Contains("Details of outcome");
        }

        public bool VerifyMaxLengthOfDetailsOfOutcomeTextarea(string maxLength)
        {
            txtareaSPSOutcome.ScrollIntoView(_driver);

            return txtareaSPSOutcome.GetAttribute("maxlength").Equals(maxLength);
        }

        public bool VerifyAnyRelavantCommentsTextarea(string heading, string hint, string maxLength)
        {
            lblAnyRelavantComments.ScrollIntoView(_driver);
            return lblAnyRelavantComments.Text.Contains(heading)
                   && lblAnyRelavantCommentsHint.Text.Contains(hint);
                   //&& TxtAnyRelavantComments.GetAttribute("maxlength").Equals(maxLength);
        }

        public bool VerifyTypeOfPassengerSubheading(string subHeading, string sectionName)
        {
            lblPassengerDetails.ScrollIntoView(_driver);
            return lblPassengerDetails.Text.Contains(sectionName) && lblTypeOfPassenger.Text.Contains(subHeading);
        }

        public bool VerifyVCAndPetOwnerDetailSubheading(string subHeading)
        {
           
            if (subHeading.Equals("Visual check"))
            {
                lblVisualCheck.ScrollIntoView(_driver);
                return lblVisualCheck.Text.Contains(subHeading);
            }
            lblPetOwnerDetailsSubHeading.ScrollIntoView(_driver);
            return lblPetOwnerDetailsSubHeading.Text.Contains(subHeading);
        }

        public bool VerifyPetDetailsFromPTDLink(string linkName)
        {
            lnkPetDetailsFromPTD.Click(_driver);
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
            lblOtherReasonHint.ScrollIntoView(_driver);
            return lblOtherReasonHint.Text.ToLower().Contains(hint.ToLower());
        }

        public bool VerifyOtherIssuesCheckboxesAreNotChecked()
        {
            lblOtherIssuesOption1.ScrollIntoView(_driver);
            return lblOtherIssuesOption1.HasAttribute("Checked")
                && lblOtherIssuesOption2.HasAttribute("Checked")
                && lblOtherIssuesOption3.HasAttribute("Checked");
        }

        public bool VerifyMicrochipSection()
        {
            lblMCHeader.ScrollIntoView(_driver);
            return lblMCHeader.Text.Contains("Microchip")
                   && lblMCCheckbox1.Text.Contains("Microchip number does not match the PTD")
                   && lblMCCheckbox2.Text.Contains("Cannot find microchip")
                   && lblMCDetailsLink.Text.Contains("Microchip details from PTD")
                   && !lblMCCheckbox1.Selected
                   && !lblMCCheckbox2.Selected;
        }

        public bool VerifyMCDetailsPTDTableWithValues(string MCDetails)
        {
            lblMCDetailsLink.Click(_driver);
            string[] MCNumberAndDate = MCDetails.Split('|');
            return lblMCTableHeading.Text.Equals("Microchip information from PTD or Application") 
                && lblMCNumber.Text.Equals("Microchip number") 
                && lblMCImplantOrScanDate.Text.Equals("Implant or scan date") 
                && lblMCNumberValue.Text.Equals(MCNumberAndDate[0]) 
                && lblMCImplantOrScanDateValue.Text.Equals(MCNumberAndDate[1]);
        }

        public void ClickOnMCCheckbox(string mcCheckbox)
        {
            if (mcCheckbox.Equals("Microchip number does not match the PTD"))
            {
                lblMCCheckbox1.ScrollAndClick(_driver);
            }
            else if (mcCheckbox.Equals("Cannot find microchip"))
            {
                lblMCCheckbox2.ScrollAndClick(_driver);
            }
        }

        public void EnterMCNumber(string MCNumber)
        {
            lblMCNumberNotFoundInScan.ScrollIntoView(_driver);
            lblMCNumberNotFoundInScan.Text.Equals("Microchip number found in scan");
            txtMCNumberNotFoundInScan.Clear();
            txtMCNumberNotFoundInScan.SendKeys(MCNumber);
        }
        public bool VerifyNameAndEmailOfPetOwner(string name, string email)
        {
            lblPetOwnerName.ScrollIntoView(_driver);
            return lblPetOwnerName.Text.Contains(name)
                && lblPetOwnerEmail.Text.Contains(email);
        }

        public bool VerifyAddressAndPhoneNumberOfPetOwner(string address, string phoneNumber)
        {
            lblPetOwnerAddress.ScrollIntoView(_driver);
            var addressReplaceNewLine = lblPetOwnerAddress.Text.ReplaceLineEndings("\n");
            var addressDetail = addressReplaceNewLine.Replace('\n', ',');

            return addressDetail.Contains(address)
                && lblPetOwnerPhoneNumber.Text.Contains(phoneNumber);
        }

        public bool VerifyInfoSubmittedMessage(string submittedMessage)
        {
            lblInfoSubmittedMessage.ScrollIntoView(_driver);
            return lblInfoSubmittedMessage.Text.Contains(submittedMessage);
        }

        public void ClickSaveOutComeButton()
        {
            btnSaveOutCome.ScrollAndClick(_driver);
        }

        public bool VerifyTypeOfPassengerRadioButtons(string ferryFootPassenger, string vehicleOnFerry, string airline)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", btnFootPassengerRadio);
            return btnFootPassengerRadio.Text.Contains(ferryFootPassenger)
                && btnVehicleRadio.Text.Contains(vehicleOnFerry)
                && btnAirlineRadio.Text.Contains(airline)
                && !btnFootPassengerRadio.Selected && !btnVehicleRadio.Selected
                && !btnAirlineRadio.Selected;
        }
        #endregion
    }
}