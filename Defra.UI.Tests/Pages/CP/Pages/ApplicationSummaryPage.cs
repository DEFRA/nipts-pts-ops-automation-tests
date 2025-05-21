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
        private IWebElement lblDate => _driver.WaitForElement(By.XPath("(//div[@id='document-issued-card']//dt)[2]"));
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
        private IWebElement PetDetailsSection => _driver.WaitForElement(By.Id("document-pet-card"));
        private IWebElement RefNumberSection => _driver.WaitForElement(By.Id("document-issued-card"));
        private IWebElement MicrochipInfoSection => _driver.WaitForElement(By.Id("document-microchip-card"));
        private IWebElement PetOwnerDetailsSection => _driver.WaitForElement(By.Id("document-owner-card"));
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
                return (lblIssuingAuthority.Text.Equals("Issuing authority")
                    && lblIssuingAuthorityNameAndAddress.Text.Equals("Name and address of competent authority")
                    && lblIssuingAuthoritySign.Text.Equals("Signed on behalf of the competent authority (APHA)")
                    && lblIssuingAuthorityNameAndAddressValue.Text.Equals("Animal and Plant Health Agency\r\nPet Travel Section\r\nEden Bridge House\r\nLowther Street\r\nCarlisle\r\nCA3 8DX")
                    && lblIssuingAuthoritySignValue.Text.Equals("John Smith (APHA) (Signed digitally)"));
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
            MicrochipInfoSection.ScrollToElement(_driver);
            var title = MicrochipInfoSection.FindElement(By.ClassName("govuk-summary-card__title"));
            var microchipFieldList = MicrochipInfoSection.FindElements(By.ClassName("govuk-summary-list__key"));

            return title.Text.Replace("\r\n", string.Empty).Trim().Equals("Microchip information")
                && microchipFieldList[0].Text.Replace("\r\n", string.Empty).Trim().Equals("Microchip number")
                && microchipFieldList[1].Text.Replace("\r\n", string.Empty).Trim().Equals("Implant or scan date");
        }

        public bool VerifyPetDetailsTable(string species)
        {
            PetDetailsSection.ScrollToElement(_driver);

            var petDetailsFieldList = PetDetailsSection.FindElements(By.ClassName("govuk-summary-list__key"));
            var title = PetDetailsSection.FindElement(By.ClassName("govuk-summary-card__title"));

            if (species.Equals("Ferret"))
            {
                return title.Text.Replace("\r\n", string.Empty).Trim().Equals("Pet details")
                    && petDetailsFieldList[0].Text.Replace("\r\n", string.Empty).Trim().Equals("Pet name")
                    && petDetailsFieldList[1].Text.Replace("\r\n", string.Empty).Trim().Equals("Species")
                    && petDetailsFieldList[2].Text.Replace("\r\n", string.Empty).Trim().Equals("Sex")
                    && petDetailsFieldList[3].Text.Replace("\r\n", string.Empty).Trim().Equals("Date of birth")
                    && petDetailsFieldList[4].Text.Replace("\r\n", string.Empty).Trim().Equals("Colour")
                    && petDetailsFieldList[5].Text.Replace("\r\n", string.Empty).Trim().Equals("Significant features")
                    && petDetailsFieldList.Where(x => x.Text.Contains("Breed")).Count() == 0;
            }
            else
            {
                return title.Text.Replace("\r\n", string.Empty).Trim().Equals("Pet details")
                    && petDetailsFieldList[0].Text.Replace("\r\n", string.Empty).Trim().Equals("Pet name")
                    && petDetailsFieldList[1].Text.Replace("\r\n", string.Empty).Trim().Equals("Species")
                    && petDetailsFieldList[2].Text.Replace("\r\n", string.Empty).Trim().Equals("Breed")
                    && petDetailsFieldList[3].Text.Replace("\r\n", string.Empty).Trim().Equals("Sex")
                    && petDetailsFieldList[4].Text.Replace("\r\n", string.Empty).Trim().Equals("Date of birth")
                    && petDetailsFieldList[5].Text.Replace("\r\n", string.Empty).Trim().Equals("Colour")
                    && petDetailsFieldList[6].Text.Replace("\r\n", string.Empty).Trim().Equals("Significant features");
            }
        }

        public bool VerifyPetOwnerDetailsTable()
        {
            PetOwnerDetailsSection.ScrollToElement(_driver);
            var title = PetOwnerDetailsSection.FindElement(By.ClassName("govuk-summary-card__title"));
            var petOwnerDetailsFieldList = PetOwnerDetailsSection.FindElements(By.ClassName("govuk-summary-list__key"));

            return title.Text.Equals("Pet owner details")
                && petOwnerDetailsFieldList[0].Text.Equals("Name")
                && petOwnerDetailsFieldList[1].Text.Equals("Email")
                && petOwnerDetailsFieldList[2].Text.Equals("Address")
                && petOwnerDetailsFieldList[3].Text.Equals("Phone number");
        }

        public bool VerifyRefNumTableValues(string values, string status)
        {
            var value = values.Split('^');
            RefNumberSection.ScrollToElement(_driver);

            var documentIssuedFieldList = RefNumberSection.FindElements(By.ClassName("govuk-summary-list__value"));

            var refNumber = documentIssuedFieldList[0].Text.Replace("\r\n", string.Empty).Trim();
            var date = documentIssuedFieldList[1].Text.Replace("\r\n", string.Empty).Trim();

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
            MicrochipInfoSection.ScrollToElement(_driver);

            var microchipFieldList = MicrochipInfoSection.FindElements(By.ClassName("govuk-summary-list__value"));

            var mcNumber = microchipFieldList[0].Text.Replace("\r\n", string.Empty).Trim();
            var mcImplantDate = microchipFieldList[1].Text.Replace("\r\n", string.Empty).Trim();

            return mcNumber.Equals(value[0]) && mcImplantDate.Equals(value[1]);
        }

        public bool VerifyPetDetailsValues(string values, string species)
        {
            string[] value = values.Split('^');

            PetDetailsSection.ScrollToElement(_driver);

            var petDetailsList = PetDetailsSection.FindElements(By.ClassName("govuk-summary-list__value"));

            var petName = petDetailsList[0].Text.Replace("\r\n", string.Empty).Trim();
            var speciesValue = petDetailsList[1].Text.Replace("\r\n", string.Empty).Trim();

            if (species.ToUpper().Equals("FERRET"))
            {

                var sex = petDetailsList[2].Text.Replace("\r\n", string.Empty).Trim();
                var dob = petDetailsList[3].Text.Replace("\r\n", string.Empty).Trim();
                var color = petDetailsList[4].Text.Replace("\r\n", string.Empty).Trim();
                var significantFeature = petDetailsList[5].Text.Replace("\r\n", string.Empty).Trim();

                return petName.Equals(value[0])
                    && speciesValue.Equals(value[1])
                    && sex.Equals(value[2])
                    && dob.Equals(value[3])
                    && color.Equals(value[4])
                    && significantFeature.Equals(value[5]);
            }
            else if (species.ToUpper().Equals("DOG") || species.ToUpper().Equals("CAT"))
            {
                var breed = petDetailsList[2].Text.Replace("\r\n", string.Empty).Trim();
                var sex = petDetailsList[3].Text.Replace("\r\n", string.Empty).Trim();
                var dob = petDetailsList[4].Text.Replace("\r\n", string.Empty).Trim();
                var color = petDetailsList[5].Text.Replace("\r\n", string.Empty).Trim();
                var significantFeature = petDetailsList[6].Text.Replace("\r\n", string.Empty).Trim();


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

            PetOwnerDetailsSection.ScrollToElement(_driver);

            var petOwnerDetailsFieldList = PetOwnerDetailsSection.FindElements(By.ClassName("govuk-summary-list__value"));

            var name = petOwnerDetailsFieldList[0].Text.Replace("\r\n", string.Empty).Trim();
            var email = petOwnerDetailsFieldList[1].Text.Replace("\r\n", string.Empty).Trim();
            var phoneNumber = petOwnerDetailsFieldList[3].Text.Replace("\r\n", string.Empty).Trim();

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