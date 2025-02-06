using BoDi;
using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Tools;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;


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
        private IWebElement lblDate => _driver.WaitForElement(By.XPath("(//div[@id='document-issued-card']//dt)[2]"));
        private IWebElement lblMCInfo => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Microchip information']"));
        private IWebElement lblMCNumber => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Microchip information']/following::dt[@class='govuk-summary-list__key'][1]"));
        private IWebElement lblMCImplantDate => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Microchip information']/following::dt[@class='govuk-summary-list__key'][2]"));
        private IWebElement lblPetDetails => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet details']"));
        private IWebElement lblPetName => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet details']/following::dt[normalize-space() = 'Pet name']"));
        private IWebElement lblSpecies => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet details']/following::dt[normalize-space() = 'Species']"));
        private IWebElement lblBreed => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet details']/following::dt[normalize-space() = 'Breed']"));
        private IWebElement lblSex => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet details']/following::dt[normalize-space() = 'Sex']"));
        private IWebElement lblDOB => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet details']/following::dt[normalize-space() = 'Date of birth']"));
        private IWebElement lblColor => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet details']/following::dt[normalize-space() = 'Colour']"));
        private IWebElement lblSignificantFeature => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet details']/following::dt[normalize-space() = 'Significant features']"));
        private IWebElement lblPetOwnerDetails => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet owner details']"));
        private IWebElement lblName => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet owner details']/following::dt[normalize-space() = 'Name']"));
        private IWebElement lblEmail => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet owner details']/following::dt[normalize-space() = 'Email']"));
        private IWebElement lblAddress => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet owner details']/following::dt[normalize-space() = 'Address']"));
        private IWebElement lblPhoneNumber => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Pet owner details']/following::dt[normalize-space() = 'Phone number']"));
        private IWebElement lblIssuingAuthority => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Issuing authority']"));
        private IWebElement lblIssuingAuthorityNameAndAddress => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Issuing authority']/following::dt[normalize-space() = 'Name and address of competent authority']"));
        private IWebElement lblIssuingAuthoritySign => _driver.WaitForElement(By.XPath("//h2[normalize-space() = 'Issuing authority']/following::dt[normalize-space() = 'Signed on behalf of the competent authority (APHA)']"));

        private IWebElement lblChecks => _driver.WaitForElement(By.XPath("//*[@id='searchradio-group']//h1"));
        private IWebElement lblCheckSubheading => _driver.WaitForElement(By.XPath("//*[@id='searchradio-group']//p"));
        private IWebElement lblCheckpoint1 => _driver.WaitForElement(By.XPath("//*[@id='searchradio-group']//li[1]"));
        private IWebElement lblCheckpoint2 => _driver.WaitForElement(By.XPath("//*[@id='searchradio-group']//li[2]"));
        private IWebElement lblCheckpoint3 => _driver.WaitForElement(By.XPath("//*[@id='searchradio-group']//li[3]"));
        private IWebElement lblCheckpoint4 => _driver.WaitForElement(By.XPath("//*[@id='searchradio-group']//li[4]"));
        private IReadOnlyCollection<IWebElement> rdobuttons => _driver.FindElements(By.CssSelector("input[type='radio']"));
        #endregion

        #region Methods
        public bool VerifyTheExpectedStatus(string status)
        {
            if (ConfigSetup.BaseConfiguration.TestConfiguration.IsAccessibilityEnabled)
            {
                Cognizant.WCAG.Compliance.Checker.Analyzer.Execute(_driver,true);
            }

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
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            string bgColor = (string)js.ExecuteScript("return window.getComputedStyle(arguments[0]).backgroundColor;", colorBanner);
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
                return (lblIssuingAuthority.Text.Equals("Issuing authority") && lblIssuingAuthorityNameAndAddress.Text.Equals("Name and address of competent authority") && lblIssuingAuthoritySign.Text.Equals("Signed on behalf of the competent authority (APHA)"));
            }else if (status.Equals("Awaiting verification"))
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
        public bool VerifyChecksSection(string heading, string subHeading, string checkpoints)
        {
            var checkpointLabel = checkpoints.Split('|');
            return lblChecks.Text.Equals(heading) && lblCheckSubheading.Text.Equals(subHeading + ":")
                && checkpointLabel[0].Equals(lblCheckpoint1.Text) && checkpointLabel[1].Equals(lblCheckpoint2.Text)
                && checkpointLabel[2].Equals(lblCheckpoint3.Text) && checkpointLabel[3].Equals(lblCheckpoint4.Text);
        }
        public bool VerifyChecksSectionRadioButtons()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", lblChecks);
            return rdobuttons.Count == 0;
        }
        #endregion
    }
}