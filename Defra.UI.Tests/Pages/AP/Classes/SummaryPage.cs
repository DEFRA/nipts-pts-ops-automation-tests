using Reqnroll.BoDi;
using Defra.UI.Tests.Contracts;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using DocumentFormat.OpenXml.Wordprocessing;
using Reqnroll;

namespace Defra.UI.Tests.Pages.AP.Classes
{
    public class SummaryPage : ISummaryPage
    {
        private readonly IObjectContainer _objectContainer;

        public SummaryPage(IObjectContainer container)
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
        private IWebElement lblIssuingAuthority => _driver.WaitForElement(By.XPath("//h2[normalize-space()='Issuing authority']"));
        private IWebElement lblNameAndAddressOfAuthority => _driver.WaitForElement(By.XPath("//dt[normalize-space()='Name and address of competent authority']"));
        private IWebElement lblAuthorityAddress => _driver.WaitForElement(By.XPath("//dd[contains(normalize-space(.),'Woodham Lane')]"));
        private IWebElement lblStatusValue => _driver.WaitForElement(By.XPath("//dt[normalize-space()='Status']/following-sibling::dd"));
        private IReadOnlyCollection<IWebElement> IssuingAuthorityTable => _driver.FindElements(By.XPath("//div[@id='document-authority-card']"));
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
                        case "DATE":
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
                var elementTitle = element.FindElement(By.TagName("dt"))?.Text?.Replace("\r\n", string.Empty).Trim()?.ToUpper();
                var elementValue = element.FindElements(By.TagName("dd"))?[0].Text?.Replace("\r\n", string.Empty).Trim();

                switch (elementTitle)
                {
                    case "REFERENCE NUMBER":
                        summary.ReferenceNumber = elementValue;
                        break;
                    case "DATE":
                        summary.Date = elementValue;
                        break;
                }
            }

            foreach (var element in divMicrochipInformation)
            {
                var elementTitle = element.FindElement(By.TagName("dt"))?.Text?.Replace("\r\n", string.Empty).Trim()?.ToUpper();
                var elementValue = element.FindElements(By.TagName("dd"))?[0].Text?.Replace("\r\n", string.Empty).Trim();

                switch (elementTitle)
                {
                    case "MICROCHIP NUMBER":
                        summary.MicrochipNumber = elementValue;
                        break;
                    case "IMPLANT OR SCAN DATE":
                        summary.ImplantOrScanDate = elementValue;
                        break;
                }
            }

            foreach (var element in divPetDetails)
            {
                var elementTitle = element.FindElement(By.TagName("dt"))?.Text?.Replace("\r\n", string.Empty).Trim()?.ToUpper();
                var elementValue = element.FindElements(By.TagName("dd"))?[0].Text?.Replace("\r\n", string.Empty).Trim();

                switch (elementTitle)
                {
                    case "NAME":
                        summary.PetName = elementValue;
                        break;
                    case "SPECIES":
                        summary.Species = elementValue;
                        break;
                    case "BREED":
                        summary.Breed = elementValue;
                        break;
                    case "SEX":
                        summary.Sex = elementValue;
                        break;
                    case "DATE OF BIRTH":
                        summary.DateOfBirth = elementValue;
                        break;
                    case "COLOUR":
                        summary.Colour = elementValue;
                        break;
                    case "SIGNIFICANT FEATURES":
                        summary.SignificantFeatures = elementValue;
                        break;
                }
            }

            foreach (var element in divPetOwnerDetails)
            {
                var elementTitle = element.FindElement(By.TagName("dt"))?.Text?.Replace("\r\n", string.Empty).Trim()?.ToUpper();
                var elementValue = element.FindElements(By.TagName("dd"))?[0].Text?.Replace("\r\n", string.Empty).Trim();

                switch (elementTitle)
                {
                    case "NAME":
                        summary.Name = elementValue;
                        break;
                    case "ADDRESS":
                        summary.Address = elementValue;
                        break;
                    case "PHONE NUMBER":
                        summary.PhoneNumber = elementValue;
                        break;
                    case "EMAIL":
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
            return lblStatusValue.Text.Contains(status);
        }

        public bool VerifyIssuingAuthorityTableIsNotVisible()
        {
            return IssuingAuthorityTable.Count == 0;
        }
    }
}
#endregion