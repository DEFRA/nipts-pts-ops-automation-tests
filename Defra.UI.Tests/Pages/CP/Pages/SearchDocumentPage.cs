using BoDi;
using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Tools;
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
        private IWebElement rdoApplicationNumber => _driver.WaitForElement(By.XPath("//label[normalize-space()='Search by application number']"));
        private IWebElement rdoMicrochipNumber => _driver.WaitForElement(By.XPath("//label[normalize-space()='Search by microchip number']"));
        private IWebElement rdoPTDNumber => _driver.WaitForElement(By.XPath("//label[normalize-space()='Search by PTD number']"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        private IWebElement lblYouCannotAccessPageHeading => _driver.WaitForElement(By.Id("dialog-title-notsignedin"));
        private IWebElement lnkGobackToPrevPage => _driver.WaitForElement(By.XPath("//a[contains(.,'go back to the previous page')]"));
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
                if (!rdoApplicationNumber.Selected)
                {
                    rdoApplicationNumber.Click();
                }
            }
            else if (radioButtonValue == "Search by microchip number")
            {
                if (!rdoMicrochipNumber.Selected)
                {
                    rdoMicrochipNumber.Click();
                }
            }
            else if (radioButtonValue == "Search by PTD number")
            {
                if (!rdoPTDNumber.Selected)
                {
                    rdoPTDNumber.Click();
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
        public bool VerifyAlreadyEnteredPTDNumber(string alreadyEnteredPTDNumber)
        {
            return txtPTDSearchBox.GetAttribute("value").Contains(alreadyEnteredPTDNumber);
        }
        public bool VerifyAlreadyEnteredApplicationNumber(string alreadyEnteredApplicationNumber)
        {
            return txtApplicationNumberSearchBox.GetAttribute("value").Contains(alreadyEnteredApplicationNumber);
        }
        public bool VerifyAlreadyEnteredMicrochipNumber(string alreadyEnteredMicrochipNumber)
        {
            return txtMicrochipNumberSearchBox.GetAttribute("value").Contains(alreadyEnteredMicrochipNumber);
        }
        public bool VerifyYouCannotAccessPage(string errorPageHeading)
        {
            return lblYouCannotAccessPageHeading.Text.Contains(errorPageHeading);
        }
        public void VerifyGoBackToPreviousPageLink()
        {
            lnkGobackToPrevPage.Click();
        }
        #endregion
    }
}