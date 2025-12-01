using Reqnroll.BoDi;
using Defra.UI.Tests.Contracts;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.AP.Classes
{
    public class SummaryPageWelsh : ISummaryPageWelsh
    {
        private readonly IObjectContainer _objectContainer;

        public SummaryPageWelsh(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl']"), true);
        private IReadOnlyCollection<IWebElement> divDocumentIssueDetails => _driver.WaitForElements(By.XPath("//div[@id='document-issued-card']//dl/div"));
        private IReadOnlyCollection<IWebElement> divDocumentIssue => _driver.WaitForElements(By.XPath("//div[@id='document-issued-card']//dl/div"));
        private IReadOnlyCollection<IWebElement> divMicrochipInformation => _driver.WaitForElements(By.XPath("//div[@id='document-microchip-card']//dl/div"));
        private IReadOnlyCollection<IWebElement> divPetDetails => _driver.WaitForElements(By.XPath("//div[@id='document-pet-card']//dl/div"));
        private IReadOnlyCollection<IWebElement> divPetOwnerDetails => _driver.WaitForElements(By.XPath("//div[@id='document-owner-card']//dl/div"));
        private IWebElement lnkPDFDownload => _driver.WaitForElement(By.XPath("//a[normalize-space(text())='Download your application' or normalize-space(text())='Download your document']"));
        private IWebElement lnkPrint => _driver.WaitForElement(By.Id("print-this-page"));
        private IWebElement lblIssuingAuthority => _driver.WaitForElement(By.XPath("//h2[normalize-space()='Awdurdod dyroddi']"));
        private IWebElement lblNameAndAddressOfAuthority => _driver.WaitForElement(By.XPath("//dt[normalize-space()='Enw a chyfeiriad yr awdurdod cymwys']"));
        private IWebElement lblAuthorityAddress => _driver.WaitForElement(By.XPath("//dd[contains(normalize-space(.),'Woodham Lane')]"));
        private IWebElement lblSignedColumn => _driver.WaitForElement(By.XPath("//div[@id='document-authority-card']/div[2]/dl/div[2]/dt"));
        private IWebElement lblSignedName => _driver.WaitForElement(By.XPath("//p[contains(normalize-space(.),'Irene Cristofaro')]"));
        private IWebElement lblDesignation => _driver.WaitForElement(By.XPath("//div[@id='document-authority-card']/div[2]/dl/div[2]/dd/p[2]"));
        private IWebElement lblStatusValue => _driver.WaitForElement(By.XPath("//dt[normalize-space()='Status']/following-sibling::dd"));
        private IWebElement lblStatusValueWelsh => _driver.WaitForElement(By.XPath("//dt[normalize-space()='Statws']/following-sibling::dd"));
        private IReadOnlyCollection<IWebElement> IssuingAuthorityTable => _driver.FindElements(By.XPath("//div[@id='document-authority-card']"));
        private IWebElement lnkFirstViewLink => _driver.WaitForElement(By.XPath("//tr[@class='govuk-table__row'][1]//li"));
        private IWebElement btnBack => _driver.WaitForElement(By.XPath("//a[normalize-space(text())='Yn ôl']"));

        private IReadOnlyCollection<IWebElement> lblFerretBreedRow => _driver.FindElements(By.XPath("//dt[normalize-space()='Breed']"));
        #endregion

        #region Methods
        public bool IsNextPageLoaded(string pageTitle)
        {
            return PageHeading.Text.Contains(pageTitle);
        }

        public void ClickPDFDownloadLink()
        {
            lnkPDFDownload.Click();
        }

        public bool ClickPrintdLink()
        {
            return lnkPrint.IsClickable();
        }

        public Summary GetSummaryDetails()
        {
            var summary = new Summary();
            try
            {
                foreach (var element in divDocumentIssue)
                {
                    var elementTitle = element.FindElement(By.TagName("dt"))?.Text?.Replace("\r\n", string.Empty).Trim()?.ToUpper();
                    var elementValue = element.FindElements(By.TagName("dd"))?[0].Text?.Replace("\r\n", string.Empty).Trim();

                    switch (elementTitle)
                    {
                        case "PET TRAVEL DOCUMENT NUMBER":
                            summary.PTDNumber = elementValue;
                            break;
                        case "Dyddiad":
                            summary.Date = elementValue;
                            break;
                    }
                }
            }
            catch
            {

            }


            foreach (var element in divDocumentIssueDetails)
            {
                var elementTitle = element.FindElement(By.TagName("dt"))?.Text?.Replace("\r\n", string.Empty).Trim();
                var elementValue = element.FindElements(By.TagName("dd"))?[0].Text?.Replace("\r\n", string.Empty).Trim();

                switch (elementTitle)
                {
                    case "Rhif cyfeirnod":
                        summary.ReferenceNumber = elementValue;
                        break;
                    case "Dyddiad":
                        summary.Date = elementValue;
                        break;
                }
            }

            foreach (var element in divMicrochipInformation)
            {
                var elementTitle = element.FindElement(By.TagName("dt"))?.Text?.Replace("\r\n", string.Empty).Trim();
                var elementValue = element.FindElements(By.TagName("dd"))?[0].Text?.Replace("\r\n", string.Empty).Trim();

                switch (elementTitle)
                {
                    case "Rhif y microsglodyn":
                        summary.MicrochipNumber = elementValue;
                        break;
                    case "Dyddiad mewnblannu neu sganio":
                        summary.ImplantOrScanDate = elementValue;
                        break;
                }
            }

            foreach (var element in divPetDetails)
            {
                var elementTitle = element.FindElement(By.TagName("dt"))?.Text?.Replace("\r\n", string.Empty).Trim();
                var elementValue = element.FindElements(By.TagName("dd"))?[0].Text?.Replace("\r\n", string.Empty).Trim();

                switch (elementTitle)
                {
                    case "Enw":
                        summary.PetName = elementValue;
                        break;
                    case "Rhywogaeth":
                        summary.Species = elementValue;
                        break;
                    case "Brid":
                        summary.Breed = elementValue;
                        break;
                    case "Rhyw":
                        summary.Sex = elementValue;
                        break;
                    case "Dyddiad geni":
                        summary.DateOfBirth = elementValue;
                        break;
                    case "Lliw":
                        summary.Colour = elementValue;
                        break;
                    case "Nodweddion arwyddocaol":
                        summary.SignificantFeatures = elementValue;
                        break;
                }
            }

            foreach (var element in divPetOwnerDetails)
            {
                var elementTitle = element.FindElement(By.TagName("dt"))?.Text?.Replace("\r\n", string.Empty).Trim();
                var elementValue = element.FindElements(By.TagName("dd"))?[0].Text?.Replace("\r\n", string.Empty).Trim();

                switch (elementTitle)
                {
                    case "Enw":
                        summary.Name = elementValue;
                        break;
                    case "Cyfeiriad":                        
                        summary.Address = elementValue;
                        break;
                    case "Rhif ffôn":
                        summary.PhoneNumber = elementValue;
                        break;
                    case "Ebost":
                        summary.Email = elementValue;
                        break;
                }
            }

            return summary;
        }

        public bool VerifyIssuingAuthorityTable(string tableName, string columnName)
        {
            return lblIssuingAuthority.Text.Equals(tableName) && lblNameAndAddressOfAuthority.Text.Equals(columnName);
        }

        public bool VerifyIssuingAuthorityAddress(string addressLine1, string addressLine2)
        {
            var address = lblAuthorityAddress.Text;
            string[] separateLines = address.Split(new String[] {"\r\n", "\n", "\r"}, StringSplitOptions.RemoveEmptyEntries);
            string firstAddressLine = separateLines[0];
            string secondAddressLine = separateLines[1];

            return firstAddressLine.Equals(addressLine1) && secondAddressLine.Equals(addressLine2);
        }

        public bool VerifyIssuingAuthoritySignatureRow(string signatureColName)
        {
            return lblSignedColumn.Text.Contains(signatureColName) && lblSignedName.Text.Contains("Irene Cristofaro")
                && lblDesignation.Text.Contains("Pennaeth Milfeddygol Masnach Ryngwladol");
        }

        public void ClickBackButton()
        {
            btnBack.Click();
        }

        public bool VerifyApplicationStatus(string status)
        {
            return lblStatusValue.Text.Contains(status);
        }

        public bool VerifyPrintAndDownloadLinks()
        {
            _driver.WaitForPageToLoad();
            var printLink = _driver.FindElements(By.Id("print-this-page")).Count;
            var downloadLink = _driver.FindElements(By.XPath("//a[normalize-space(text())='Download your application' or normalize-space(text())='Download your document']")).Count;

            if (printLink.Equals(0) && downloadLink.Equals(0))
            {
                return true;
            }
            return false;       
        }

        public bool VerifyApplicationDetails(string status)
        {
            return lblStatusValueWelsh.Text.Contains(status);
        }

        public bool VerifyIssuingAuthorityTableIsNotVisible()
        {
            return IssuingAuthorityTable.Count == 0;
        }

        public void ClickFirstViewHyperLink()
        {
            lnkFirstViewLink.Click();
        }

        public bool VerifyBreedForFerret()
        {
            return lblFerretBreedRow.Count == 0;
        }
    }
}
#endregion