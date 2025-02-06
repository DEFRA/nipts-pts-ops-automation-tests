using BoDi;
using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Tools;
using Dynamitey;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.CP.Pages
{
    public class SearchDocumentPage : ISearchDocumentPage
    {

        private readonly IObjectContainer _objectContainer;

        public SearchDocumentPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement pageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')]"));
        private IWebElement btnSearch => _driver.WaitForElement(By.XPath("//button[normalize-space()='Search']"));
        private IWebElement btnClearSearch => _driver.WaitForElement(By.XPath("//a[@id='clearSearchButton']"));
        private IWebElement txtPTDSearchBox => _driver.WaitForElement(By.XPath("//input[@id='ptdNumberSearch']"));
        private IWebElement txtApplicationNumberSearchBox => _driver.WaitForElement(By.XPath("//input[@id='applicationNumberSearch']"));
        private IWebElement txtMicrochipNumberSearchBox => _driver.WaitForElement(By.XPath("//input[@id='microchipNumber']"));
        private IWebElement expectedText => _driver.WaitForElement(By.XPath("//div[@class='ons-panel__body']"));
        private IWebElement rdoApplicatioNumbere => _driver.WaitForElement(By.XPath("//label[normalize-space()='Search by application number']"));
        private IWebElement rdoMicrochipNumbere => _driver.WaitForElement(By.XPath("//label[normalize-space()='Search by microchip number']"));
        private IWebElement rdoSearchByPTDNumber => _driver.WaitForElement(By.XPath("//input[@id = 'documentSearch-1']"));
        private IWebElement rdoSearchByAppNumber => _driver.WaitForElement(By.XPath("//input[@id = 'documentSearch-2']"));
        private IWebElement rdoSearchByMCNumber => _driver.WaitForElement(By.XPath("//input[@id = 'documentSearch-3']"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        #endregion

        #region Methods
        public bool IsPageLoaded()
        {
            _driver.ChangePageView(50);
            return pageHeading.Text.Contains("Find a document");
        }

        public void SelectSearchRadioOption(string radioButtonValue)
        {
            _driver.ChangePageView(50);

            if (radioButtonValue == "Search by application number")
            {

                if (!rdoApplicatioNumbere.Selected)
                {
                    rdoApplicatioNumbere.Click();
                }
            }
            else if (radioButtonValue == "Search by microchip number")
            {

                if (!rdoMicrochipNumbere.Selected)
                {
                    rdoMicrochipNumbere.Click();
                }
            }
        }
        public void EnterPTDNumber(string ptdNumber1) 
        {
            txtPTDSearchBox.SendKeys(ptdNumber1);
        }

        public void EnterMicrochipNumber(string microchipNumber)
        {
            txtMicrochipNumberSearchBox.SendKeys(microchipNumber);
        }

        public void EnterApplicationNumber(string applicationNumber)
        {
            txtApplicationNumberSearchBox.SendKeys(applicationNumber);
        }

        public void SearchButton()
        {
            btnSearch.Click();
        }

        public void ClearSearchButton()
        {
            btnClearSearch.Click();
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

        public bool VerifyTheValuesAreCleared()
        {
            return rdoSearchByPTDNumber.GetAttribute("aria-expanded").Equals("true") && txtPTDSearchBox.Text.Equals("") && rdoSearchByAppNumber.GetAttribute("aria-expanded").Equals("false") && rdoSearchByMCNumber.GetAttribute("aria-expanded").Equals("false");
        }
        #endregion
    }
}