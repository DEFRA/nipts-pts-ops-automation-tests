using BoDi;
using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Tools;
using Microsoft.Xrm.Sdk.Metadata;
using OpenQA.Selenium;
using System.Collections;


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
        private IWebElement rdoPass => _driver.WaitForElement(By.XPath("//label[normalize-space()='Pass']"));
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

        #endregion

        #region Methods
        public bool VerifyTheExpectedStatus(string status)
        {
            return _driver.WaitForElement(By.XPath($"(//h1[normalize-space()='{status}'])[1]")).Text.Trim().Equals(status);
        }

        public void SelectPassRadioButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", rdoPass);
            rdoPass.Click();
        }
        public void SelectFailRadioButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", rdoFail);
            rdoFail.Click();
        }

        public void SelectSaveAndContinue()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", btnSaveAndContinue);
            btnSaveAndContinue.Click();
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

        public bool VerifyTheBannerColor(string color)
        {
            var actualColor = colorBanner.GetAttribute("style").Split('#', 2);
            bool value;
            switch (color)
            {
                case "Amber":
                    value = actualColor.Contains("background-color: rgb(181, 136, 64);");  
                    break;
                case "Red":
                   value = actualColor.Contains("background-color: rgb(212, 53, 28);");
                    break;
                case "Green":
                    value = actualColor.Contains("");
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
            if (status.Equals("Unsuccessful") || status.Equals("Awaiting verification"))
            {
                return (lblDocCardHeading.Text.Equals("Reference number") && lblRefNumber.Text.Equals("Application reference number") && lblDate.Text.Equals("Date"));
            }
            else if (status.Equals("Approved") || status.Equals("Revoked"))
            {
                return (lblDocCardHeading.Text.Equals("Issued") && lblRefNumber.Text.Equals("PTD number") && lblDate.Text.Equals("Date"));
            }
            return value;
        }
        
        public bool VerifyIssuingAuthorityTable(string status)
        {
            if (status.Equals("Approved") || status.Equals("Unsuccessful") || status.Equals("Revoked"))
            {
                return (lblIssuingAuthority.Text.Equals("Issuing authority") && lblIssuingAuthorityNameAndAddress.Text.Equals("Name and address of competent authority") && lblIssuingAuthoritySign.Text.Equals("Signed on behalf of the competent authority (APHA)") && lblIssuingAuthorityNameAndAddressValue.Text.Equals("Animal and Plant Health Agency\r\nPet Travel Section\r\nEden Bridge House\r\nLowther Street\r\nCarlisle\r\nCA3 8DX") && lblIssuingAuthoritySignValue.Text.Equals("John Smith (APHA) (Signed digitally)"));
            }
            else if (status.Equals("Awaiting verification"))
            {
                return _driver.FindElements(By.XPath("//h2[normalize-space() = 'Issuing authority']")).Count.Equals(0);
            }
            return false;
        }

        public bool VerifyMicrochipInformationTable()
        {
            return lblMCInfo.Text.Equals("Microchip information") && lblMCNumber.Text.Equals("Microchip number") && lblMCImplantDate.Text.Equals("Implant or scan date");
        }

        public bool VerifyPetDetailsTable(string species)
        {
            if(species.Equals("Ferret"))
                return lblPetDetails.Text.Equals("Pet details") && lblPetName.Text.Equals("Pet name") && lblSpecies.Text.Equals("Species") && lblSex.Text.Equals("Sex") && lblDOB.Text.Equals("Date of birth") && lblColor.Text.Equals("Colour") && lblSignificantFeature.Text.Equals("Significant features") && _driver.FindElements(By.XPath("//h2[normalize-space() = 'Pet details']/following::dt[normalize-space() = 'Breed']")).Count.Equals(0);
            else
                return lblPetDetails.Text.Equals("Pet details") && lblPetName.Text.Equals("Pet name") && lblSpecies.Text.Equals("Species") && lblBreed.Text.Equals("Breed") && lblSex.Text.Equals("Sex") && lblDOB.Text.Equals("Date of birth") && lblColor.Text.Equals("Colour") && lblSignificantFeature.Text.Equals("Significant features");
        } 

        public bool VerifyPetOwnerDetailsTable()
        {
            return lblPetOwnerDetails.Text.Equals("Pet owner details") && lblName.Text.Equals("Name") && lblEmail.Text.Equals("Email") && lblAddress.Text.Equals("Address") && lblPhoneNumber.Text.Equals("Phone number");
        }

        public bool VerifyRefNumTableValues(string values , string status)
        {
            string[] value = values.Split('^');
            return lblRefNumberValue.Text.Equals(value[0]) && lblDateValue.Text.Equals(value[1]);
        }

        public bool VerifyMCTableValues(string values , string status)
        {
            string[] value = values.Split('^');
            return lblMCNumberValue.Text.Equals(value[0]) && lblMCImplantDateValue.Text.Equals(value[1]);
        } 
        
        public bool VerifyPetDetailsValues(string Values , string Species)
        {
            string[] value = Values.Split('^');
            if (Species.ToUpper().Equals("FERRET"))
            {
                return lblPetNameValue.Text.Equals(value[0])
                    && lblSpeciesValue.Text.Equals(value[1])
                    && lblSexValue.Text.Equals(value[2])
                    && lblDOBValue.Text.Equals(value[3])
                    && lblColorValue.Text.Equals(value[4])
                    && lblSignificantFeatureValue.Text.Equals(value[5]);
            }
            else if(Species.ToUpper().Equals("DOG") || Species.ToUpper().Equals("CAT"))
            {
                return lblPetNameValue.Text.Equals(value[0])
                    && lblSpeciesValue.Text.Equals(value[1])
                    && lblBreedValue.Text.Equals(value[2])
                    && lblSexValue.Text.Equals(value[3])
                    && lblDOBValue.Text.Equals(value[4])
                    && lblColorValue.Text.Equals(value[5])
                    && lblSignificantFeatureValue.Text.Equals(value[6]);
            }
            return false;
        }

        public bool VerifyPetOwnerDetailsValues(string Values)
        {
            string[] value = Values.Split('^');
            return lblNameValue.Text.Equals(value[0])
                    && lblEmailValue.Text.Equals(value[1])
                    //&& lblAddressValue.Text.Equals(value[2])
                    && lblPhoneNumberValue.Text.Equals(value[3]);
        }
            #endregion
    }
}