using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Contracts;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Pages.AP.Classes
{
    public class ApplicationDeclarationPageWelsh : IApplicationDeclarationPageWelsh
    {
        private readonly IObjectContainer _objectContainer;

        public ApplicationDeclarationPageWelsh(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public IWebElement PageHeading => _driver.WaitForElement(By.ClassName("govuk-heading-xl"), true);
        private IWebElement btnSendApplication => _driver.WaitForElementExists(By.Id("submitButton"));
        private IWebElement chkAgreesToDeclaration => _driver.WaitForElementExists(By.XPath("//input[@id='AgreedToDeclaration']"));
        private IReadOnlyCollection<IWebElement> divMicrochipInformationTitleList => _driver.WaitForElements(By.XPath("//div[@id='document-microchip-card']//dl/div/descendant::dt"));
        private IReadOnlyCollection<IWebElement> divMicrochipInformationValueList => _driver.WaitForElements(By.XPath("//div[@id='document-microchip-card']//dl/div/descendant::dd[1]"));
        private IReadOnlyCollection<IWebElement> divMicrochipInformationActionList => _driver.WaitForElements(By.XPath("//div[@id='document-microchip-card']//dl/div/descendant::dd[2]/a"));
        private IReadOnlyCollection<IWebElement> divPetDetailsTitleList => _driver.WaitForElements(By.XPath("//div[@id='document-pet-card']//dl/div/descendant::dt"));
        private IReadOnlyCollection<IWebElement> divPetDetailsValueList => _driver.WaitForElements(By.XPath("//div[@id='document-pet-card']//dl/div/descendant::dd[1]"));
        private IReadOnlyCollection<IWebElement> divPetDetailsActionList => _driver.WaitForElements(By.XPath("//div[@id='document-pet-card']//dl/div/descendant::dd[2]/a"));
        private IReadOnlyCollection<IWebElement> divPetOwnerDetailsTitleList => _driver.WaitForElements(By.XPath("//div[@id='document-owner-card']//dl/div/descendant::dt"));
        private IReadOnlyCollection<IWebElement> divPetOwnerDetailsValueList => _driver.WaitForElements(By.XPath("//div[@id='document-owner-card']//dl/div/descendant::dd[1]"));
        private IReadOnlyCollection<IWebElement> divPetOwnerDetailsActionList => _driver.WaitForElements(By.XPath("//div[@id='document-owner-card']//dl/div/descendant::dd[2]/a"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        #endregion

        #region Methods
        public bool IsNextPageLoaded(string pageTitle)
        {
            if (ConfigSetup.BaseConfiguration.TestConfiguration.IsAccessibilityEnabled)
            {
                Cognizant.WCAG.Compliance.Checker.Analyzer.Execute(_driver);
            }

            return PageHeading.Text.Contains(pageTitle);
        }

        public void TickAgreedToDeclaration()
        {
            chkAgreesToDeclaration.Click();
        }

        public void ClickSendApplicationButton()
        {
            btnSendApplication.Click();
        }

        public Summary GetSummaryDetails()
        {
            var summary = new Summary();

            for (int i = 0; i < divMicrochipInformationTitleList.Count; i++)
            {
                var elementTitle = divMicrochipInformationTitleList.ElementAt(i)?.Text?.Replace("\r\n", string.Empty).Trim();
                var elementValue = divMicrochipInformationValueList.ElementAt(i).Text?.Replace("\r\n", string.Empty).Trim();

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

            for (int i = 0; i < divPetDetailsTitleList.Count; i++)
            {
                var elementTitle = divPetDetailsTitleList.ElementAt(i)?.Text?.Replace("\r\n", string.Empty).Trim();
                var elementValue = divPetDetailsValueList.ElementAt(i).Text?.Replace("\r\n", string.Empty).Trim();

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

            for (int i = 0; i < divPetOwnerDetailsTitleList.Count; i++)
            {
                var elementTitle = divPetOwnerDetailsTitleList.ElementAt(i)?.Text?.Replace("\r\n", string.Empty).Trim();
                var elementValue = divPetOwnerDetailsValueList.ElementAt(i).Text?.Replace("\r\n", ", ").Trim();

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

            summary.Date = DateTime.Now.ToString("dd/MM/yyyy");

            return summary;
        }

        public void ClickMicrochipChangeLink(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "MICROCHIP NUMBER":
                    divMicrochipInformationActionList.ElementAt(0)?.Click();
                    break;
                case "IMPLANT OR SCAN DATE":
                    divMicrochipInformationActionList.ElementAt(1)?.Click();
                    break;
            }
        }

        public void ClickPetDetailsChangeLink(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "NAME":
                    divPetDetailsActionList.ElementAt(0)?.Click();
                    break;
                case "SPECIES":
                    divPetDetailsActionList.ElementAt(1)?.Click();
                    break;
                case "BREED":
                    divPetDetailsActionList.ElementAt(2)?.Click();
                    break;
                case "SEX":
                    divPetDetailsActionList.ElementAt(3)?.Click();
                    break;
                case "DATE OF BIRTH":
                    divPetDetailsActionList.ElementAt(4)?.Click();
                    break;
                case "COLOUR":
                    divPetDetailsActionList.ElementAt(5)?.Click();
                    break;
                case "SIGNIFICANT FEATURES":
                    divPetDetailsActionList.ElementAt(6)?.Click();
                    break;
            }
        }

        public void ClickPetDetailsChangeForFerretLink(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "NAME":
                    divPetDetailsActionList.ElementAt(0)?.Click();
                    break;
                case "SPECIES":
                    divPetDetailsActionList.ElementAt(1)?.Click();
                    break;
                case "SEX":
                    divPetDetailsActionList.ElementAt(2)?.Click();
                    break;
                case "DATE OF BIRTH":
                    divPetDetailsActionList.ElementAt(3)?.Click();
                    break;
                case "COLOUR":
                    divPetDetailsActionList.ElementAt(4)?.Click();
                    break;
                case "SIGNIFICANT FEATURES":
                    divPetDetailsActionList.ElementAt(5)?.Click();
                    break;
            }
        }

        public void ClickPetOwnerChangeLink(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "NAME":
                    divPetOwnerDetailsActionList.ElementAt(0)?.Click();
                    break;
                case "ADDRESS":
                    divPetOwnerDetailsActionList.ElementAt(1)?.Click();
                    break;
                case "PHONE NUMBER":
                    divPetOwnerDetailsActionList.ElementAt(2)?.Click();
                    break;
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
        #endregion
    }
}