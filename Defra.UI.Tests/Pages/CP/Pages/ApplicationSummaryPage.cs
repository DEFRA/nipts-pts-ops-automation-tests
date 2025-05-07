using Reqnroll.BoDi;
using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Tools;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using Microsoft.Identity.Client;


namespace Defra.UI.Tests.Pages.CP.Pages
{
    public class ApplicationSummaryPage : IApplicationSummaryPage
    {
        private readonly IObjectContainer _objectContainer;

        public ApplicationSummaryPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement lblTitle => _driver.WaitForElement(By.XPath("//h1[normalize-space(.)='Your application summary']"));
        private IWebElement rdoPass => _driver.WaitForElement(By.XPath("//label[normalize-space()='Pass']"));
        private IWebElement rdobtnPass => _driver.WaitForElement(By.XPath("//input[@value='Pass']"));
        private IWebElement rdoFail => _driver.WaitForElement(By.XPath("//label[normalize-space()='Fail or referred to SPS']"));
        private IWebElement btnSaveAndContinue => _driver.WaitForElement(By.XPath("//*[@id='saveAndContinue']"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        private IWebElement colorBanner => _driver.WaitForElement(By.XPath("//div[contains(@class , 'govuk-panel govuk-panel--confirmation govuk')]"));
        private IWebElement lblDocCardHeading => _driver.WaitForElement(By.XPath("//div[@id='document-issued-card']/div/h2"));
        private IWebElement lblRefNumber => _driver.WaitForElement(By.XPath("(//div[@id='document-issued-card']//dt)[1]"));
        private IWebElement lblRefNumberValue => _driver.WaitForElement(By.XPath("(//div[@id='document-issued-card']//dt)[1]/following-sibling::dd"));
        private IWebElement lblDateValue => _driver.WaitForElement(By.XPath("(//div[@id='document-issued-card']//dt)[2]/following-sibling::dd"));
        private IWebElement lblDate => _driver.WaitForElement(By.XPath("(//div[@id='document-issued-card']//dt)[2]"));
        private IWebElement lblMCInfo => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Microchip information']"));
        private IWebElement lblMCNumber => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Microchip information']/following::dt[@class='govuk-summary-list__key'][1]"));
        private IWebElement lblMCNumberValue => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Microchip information']/following::dt[@class='govuk-summary-list__key'][1]/following-sibling::dd"));
        private IWebElement lblMCImplantDate => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Microchip information']/following::dt[@class='govuk-summary-list__key'][2]"));
        private IWebElement lblMCImplantDateValue => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Microchip information']/following::dt[@class='govuk-summary-list__key'][2]/following-sibling::dd"));
        private IWebElement lblPetDetails => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet details']"));
        private IWebElement lblPetName => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet details']/following::dt[normalize-space() = 'Pet name']"));
        private IWebElement lblPetNameValue => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet details']/following::dt[normalize-space() = 'Pet name']/following-sibling::dd"));
        private IWebElement lblSpecies => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet details']/following::dt[normalize-space() = 'Species']"));
        private IWebElement lblSpeciesValue => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet details']/following::dt[normalize-space() = 'Species']/following-sibling::dd"));
        private IWebElement lblBreed => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet details']/following::dt[normalize-space() = 'Breed']"));
        private IWebElement lblBreedValue => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet details']/following::dt[normalize-space() = 'Breed']/following-sibling::dd"));
        private IWebElement lblSex => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet details']/following::dt[normalize-space() = 'Sex']"));
        private IWebElement lblSexValue => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet details']/following::dt[normalize-space() = 'Sex']/following-sibling::dd"));
        private IWebElement lblDOB => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet details']/following::dt[normalize-space() = 'Date of birth']"));
        private IWebElement lblDOBValue => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet details']/following::dt[normalize-space() = 'Date of birth']/following-sibling::dd"));
        private IWebElement lblColor => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet details']/following::dt[normalize-space() = 'Colour']"));
        private IWebElement lblColorValue => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet details']/following::dt[normalize-space() = 'Colour']/following-sibling::dd"));
        private IWebElement lblSignificantFeature => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet details']/following::dt[normalize-space() = 'Significant features']"));
        private IWebElement lblSignificantFeatureValue => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet details']/following::dt[normalize-space() = 'Significant features']/following-sibling::dd"));
        private IWebElement lblPetOwnerDetails => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet owner details']"));
        private IWebElement lblName => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet owner details']/following::dt[normalize-space() = 'Name']"));
        private IWebElement lblNameValue => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet owner details']/following::dt[normalize-space() = 'Name']/following-sibling::dd"));
        private IWebElement lblEmail => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet owner details']/following::dt[normalize-space() = 'Email']"));
        private IWebElement lblEmailValue => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet owner details']/following::dt[normalize-space() = 'Email']/following-sibling::dd"));
        private IWebElement lblAddress => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet owner details']/following::dt[normalize-space() = 'Address']"));
        private IWebElement lblAddressValue => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet owner details']/following::dt[normalize-space() = 'Address']/following-sibling::dd"));
        private IWebElement lblPhoneNumber => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet owner details']/following::dt[normalize-space() = 'Phone number']"));
        private IWebElement lblPhoneNumberValue => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet owner details']/following::dt[normalize-space() = 'Phone number']/following-sibling::dd"));
        private IWebElement lblIssuingAuthority => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Issuing authority']"));
        private IWebElement lblIssuingAuthorityNameAndAddress => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Issuing authority']/following::dt[normalize-space() = 'Name and address of competent authority']"));
        private IWebElement lblIssuingAuthorityNameAndAddressValue => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Issuing authority']/following::dt[normalize-space() = 'Name and address of competent authority']/following-sibling::dd"));
        private IWebElement lblIssuingAuthoritySign => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Issuing authority']/following::dt[normalize-space() = 'Signed on behalf of the competent authority (APHA)']"));
        private IWebElement lblIssuingAuthoritySignValue => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Issuing authority']/following::dt[normalize-space() = 'Signed on behalf of the competent authority (APHA)']/following-sibling::dd"));
        private IWebElement lblChecks => _driver.WaitForElement(By.XPath("//*[@id='searchradio-group']//h1"));
        private IWebElement lblCheckSubheading => _driver.WaitForElement(By.XPath("//*[@id='searchradio-group']//p"));
        private IWebElement lblCheckpoint1 => _driver.WaitForElement(By.XPath("//*[@id='searchradio-group']//li[1]"));
        private IWebElement lblCheckpoint2 => _driver.WaitForElement(By.XPath("//*[@id='searchradio-group']//li[2]"));
        private IWebElement lblCheckpoint3 => _driver.WaitForElement(By.XPath("//*[@id='searchradio-group']//li[3]"));
        private IWebElement lblCheckpoint4 => _driver.WaitForElement(By.XPath("//*[@id='searchradio-group']//li[4]"));
        private IReadOnlyCollection<IWebElement> rdobuttons => _driver.FindElements(By.CssSelector("input[type='radio']"));
        private IWebElement lblPassRadioButtonHint => _driver.WaitForElement(By.XPath("//*[@id='pass-hint']"));
        private IWebElement lblFailRadioButtonHint => _driver.WaitForElement(By.XPath("//*[@id='fail-hint']"));
        private IWebElement lblErrorTitle => _driver.WaitForElement(By.XPath("//*[@id='error-summary-title']"));
        #endregion

        #region Methods
        public bool VerifyTheExpectedStatus(string status)
        {
            if (ConfigSetup.BaseConfiguration.TestConfiguration.IsAccessibilityEnabled)
            {
                Cognizant.WCAG.Compliance.Checker.Analyzer.Execute(_driver, true);
            }

            return _driver.WaitForElement(By.XPath($"(//h1[normalize-space()='{status}'])[1]"), true).Text.Trim().Equals(status);
        }

        public void SelectPassRadioButton()
        {
            rdobtnPass.Click(_driver);
        }

        public void SelectFailRadioButton()
        {
            rdoFail.Click(_driver);
        }

        public void SelectSaveAndContinue()
        {
            btnSaveAndContinue.Click(_driver);
        }

        public bool IsError(string errorMessage)
        {
            foreach (var element in lblErrorMessages)
            {
                if (element.Text.Contains(errorMessage) && lblErrorTitle.Text.Contains("There is a problem"))
                {
                    return true;
                }
            }
            return false;
        }

        public bool VerifyTheBannerColor(string color)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            string bgColor = (string)js.ExecuteScript("return window.getComputedStyle(arguments[0]).backgroundColor;", colorBanner);
            var actualColor = colorBanner.GetAttribute("style").Split('#', 2);
            bool value;
            switch (color)
            {
                case "Amber":
                    value = actualColor.Contains("background-color: rgb(29, 112, 184);");
                    break;
                case "Red":
                    value = actualColor.Contains("background-color: rgb(212, 53, 28);");
                    break;
                case "Green":
                    value = bgColor.Contains("rgb(0, 112, 60)");
                    break;
                default:
                    value = false;
                    break;
            }
            return value;
        }

        public bool VerifyReferenceNumberTable(string status)
        {
            bool value = false;
            if (status.Equals("Unsuccessful") || status.Equals("Pending"))
            {
                return (lblDocCardHeading.Text.Equals("Reference number") && lblRefNumber.Text.Equals("Application reference number") && lblDate.Text.Equals("Date"));
            }
            else if (status.Equals("Approved") || status.Equals("Cancelled"))
            {
                return (lblDocCardHeading.Text.Equals("Issued") && lblRefNumber.Text.Equals("PTD number") && lblDate.Text.Equals("Date"));
            }
            return value;
        }

        public bool VerifyIssuingAuthorityTable(string status)
        {
            if (status.Equals("Approved") || status.Equals("Unsuccessful"))
            {
                return (lblIssuingAuthority.Text.Equals("Issuing authority") && lblIssuingAuthorityNameAndAddress.Text.Equals("Name and address of competent authority") && lblIssuingAuthoritySign.Text.Equals("Signed on behalf of the competent authority (APHA)") && lblIssuingAuthorityNameAndAddressValue.Text.Equals("Animal and Plant Health Agency\r\nPet Travel Section\r\nEden Bridge House\r\nLowther Street\r\nCarlisle\r\nCA3 8DX") && lblIssuingAuthoritySignValue.Text.Equals("John Smith (APHA) (Signed digitally)"));
            }
            else if (status.Equals("Pending"))
            {
                return _driver.FindElements(By.XPath("//h2[normalize-space() = 'Issuing authority']")).Count.Equals(0);
            }
            else if (status.Equals("Cancelled"))
            {
                return true;
            }

            return false;
        }

        public bool VerifyMicrochipInformationTable()
        {
            lblMCInfo.ScrollToElement(_driver);
            return lblMCInfo.Text.Replace("\r\n", string.Empty).Trim().Equals("Microchip information")
                && lblMCNumber.Text.Replace("\r\n", string.Empty).Trim().Equals("Microchip number")
                && lblMCImplantDate.Text.Replace("\r\n", string.Empty).Trim().Equals("Implant or scan date");
        }

        public bool VerifyPetDetailsTable(string species)
        {
            lblPetDetails.ScrollToElement(_driver);

            if (species.Equals("Ferret"))
            {
                return lblPetDetails.Text.Replace("\r\n", string.Empty).Trim().Equals("Pet details")
                    && lblPetName.Text.Replace("\r\n", string.Empty).Trim().Equals("Pet name")
                    && lblSpecies.Text.Replace("\r\n", string.Empty).Trim().Equals("Species")
                    && lblSex.Text.Replace("\r\n", string.Empty).Trim().Equals("Sex")
                    && lblDOB.Text.Replace("\r\n", string.Empty).Trim().Equals("Date of birth")
                    && lblColor.Text.Replace("\r\n", string.Empty).Trim().Equals("Colour")
                    && lblSignificantFeature.Text.Replace("\r\n", string.Empty).Trim().Equals("Significant features")
                    && _driver.FindElements(By.XPath("//h2[normalize-space() = 'Pet details']/following::dt[normalize-space() = 'Breed']")).Count.Equals(0);
            }
            else
            {
                return lblPetDetails.Text.Replace("\r\n", string.Empty).Trim().Equals("Pet details")
                    && lblPetName.Text.Replace("\r\n", string.Empty).Trim().Equals("Pet name")
                    && lblSpecies.Text.Replace("\r\n", string.Empty).Trim().Equals("Species")
                    && lblBreed.Text.Replace("\r\n", string.Empty).Trim().Equals("Breed")
                    && lblSex.Text.Replace("\r\n", string.Empty).Trim().Equals("Sex")
                    && lblDOB.Text.Replace("\r\n", string.Empty).Trim().Equals("Date of birth")
                    && lblColor.Text.Replace("\r\n", string.Empty).Trim().Equals("Colour")
                    && lblSignificantFeature.Text.Replace("\r\n", string.Empty).Trim().Equals("Significant features");
            }
        }

        public bool VerifyPetOwnerDetailsTable()
        {
            lblPetOwnerDetails.ScrollToElement(_driver);
            return lblPetOwnerDetails.Text.Equals("Pet owner details") && lblName.Text.Equals("Name") && lblEmail.Text.Equals("Email") && lblAddress.Text.Equals("Address") && lblPhoneNumber.Text.Equals("Phone number");
        }

        public bool VerifyRefNumTableValues(string values, string status)
        {
            var value = values.Split('^');
            lblRefNumberValue.ScrollToElement(_driver);

            var refNumber = lblRefNumberValue.Text.Replace("\r\n", string.Empty).Trim();
            var date = lblDateValue.Text.Replace("\r\n", string.Empty).Trim();

            if (status.Equals("Unsuccessful") || status.Equals("Pending"))
            {
                return refNumber.Equals(value[0]) && date.Equals(value[1]);
            }
            else if (status.Equals("Approved") || status.Equals("Cancelled"))
            {
                return refNumber.Equals("GB826 " + value[0]) && date.Equals(value[1]);
            }
            return false;
        }

        public bool VerifyMCTableValues(string values, string status)
        {
            string[] value = values.Split('^');
            lblMCNumberValue.ScrollToElement(_driver);

            var mcNumber = lblMCNumberValue.Text.Replace("\r\n", string.Empty).Trim();
            var mcImplantDate = lblMCImplantDateValue.Text.Replace("\r\n", string.Empty).Trim();

            return mcNumber.Equals(value[0]) && mcImplantDate.Equals(value[1]);
        }

        public bool VerifyPetDetailsValues(string values, string species)
        {
            string[] value = values.Split('^');

            lblPetNameValue.ScrollToElement(_driver);

            var petName = lblPetNameValue.Text.Replace("\r\n", string.Empty).Trim();
            var speciesValue = lblSpeciesValue.Text.Replace("\r\n", string.Empty).Trim();
            var sex = lblSexValue.Text.Replace("\r\n", string.Empty).Trim();
            var dob = lblDOBValue.Text.Replace("\r\n", string.Empty).Trim();
            var color = lblColorValue.Text.Replace("\r\n", string.Empty).Trim();
            var significantFeature = lblSignificantFeatureValue.Text.Replace("\r\n", string.Empty).Trim();
            var breed = lblBreedValue.Text.Replace("\r\n", string.Empty).Trim();

            if (species.ToUpper().Equals("FERRET"))
            {
                return petName.Equals(value[0])
                    && speciesValue.Equals(value[1])
                    && sex.Equals(value[2])
                    && dob.Equals(value[3])
                    && color.Equals(value[4])
                    && significantFeature.Equals(value[5]);
            }
            else if (species.ToUpper().Equals("DOG") || species.ToUpper().Equals("CAT"))
            {
                return petName.Equals(value[0])
                    && speciesValue.Equals(value[1])
                    && breed.Equals(value[2])
                    && sex.Equals(value[3])
                    && dob.Equals(value[4])
                    && color.Equals(value[5])
                    && significantFeature.Equals(value[6]);
            }

            return false;
        }

        public bool VerifyPetOwnerDetailsValues(string values)
        {
            string[] value = values.Split('^');

            var name = lblNameValue.Text.Replace("\r\n", string.Empty).Trim();
            var email = lblEmailValue.Text.Replace("\r\n", string.Empty).Trim();
            var phoneNumber = lblPhoneNumberValue.Text.Replace("\r\n", string.Empty).Trim();

            return name.Equals(value[0])
                    && email.Equals(value[1])
                    && phoneNumber.Equals(value[3]);
        }

        public bool VerifyChecksSection(string heading, string subHeading, string checkpoints)
        {
            var checkpointLabel = checkpoints.Split('|');

            var checksLabel = lblChecks.Text.Replace("\r\n", string.Empty).Trim();
            var checkSubheadingLabel = lblCheckSubheading.Text.Replace("\r\n", string.Empty).Trim();
            var checkpoint1Label = lblCheckpoint1.Text.Replace("\r\n", string.Empty).Trim();
            var checkpoint2Label = lblCheckpoint2.Text.Replace("\r\n", string.Empty).Trim();
            var checkpoint3Label = lblCheckpoint3.Text.Replace("\r\n", string.Empty).Trim();
            var checkpoint4Label = lblCheckpoint4.Text.Replace("\r\n", string.Empty).Trim();

            return checksLabel.Equals(heading) && checkSubheadingLabel.Equals(subHeading + ":")
                && checkpointLabel[0].Equals(checkpoint1Label) && checkpointLabel[1].Equals(checkpoint2Label)
                && checkpointLabel[2].Equals(checkpoint3Label) && checkpointLabel[3].Equals(checkpoint4Label);
        }

        public bool VerifyChecksSectionRadioButtonsNotPresent()
        {
            lblChecks.ScrollToElement(_driver);
            return rdobuttons.Count == 0;
        }

        public bool IsApplicationSummayPageLoaded(string pageTitle)
        {
            return lblTitle.Text.Contains(pageTitle);
        }

        public bool VerifyChecksSectionRadioButtonsWithHints(string radiobuttons, string hint)
        {
            lblChecks.ScrollToElement(_driver);
            var radiobuttonsLabel = radiobuttons.Split('|');
            var hintLabel = hint.Split('|');

            return radiobuttonsLabel[0].Equals(rdoPass.Text) && radiobuttonsLabel[1].Equals(rdoFail.Text)
                && hintLabel[0].Equals(lblPassRadioButtonHint.Text) && hintLabel[1].Equals(lblFailRadioButtonHint.Text);
        }
        #endregion
    }
}