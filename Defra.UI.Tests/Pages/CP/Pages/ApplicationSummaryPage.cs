using BoDi;
using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Tools;
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
        private IWebElement lblDate => _driver.WaitForElement(By.XPath("(//div[@id='document-issued-card']//dt)[2]"));
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

        public bool VerifyTheBannerColor(String Color)
        {
            string[] ActualColor = colorBanner.GetAttribute("style").Split('#', 2);
            bool value;
            switch (Color)
            {
                case "Amber":
                    value = ActualColor.Contains("background-color: rgb(181, 136, 64);");  
                    break;
                case "Red":
                   value = ActualColor.Contains("background-color: rgb(212, 53, 28);");
                    break;
                case "Green":
                    value = ActualColor.Contains("");
                    break;
                default:
                    value = false;
                    break;
            }                 
            return value;
        }

        public bool VerifyReferenceNumberTable(String Status)
        {
            bool value = false;
            if (Status.Equals("Unsuccessful") || Status.Equals("Awaiting verification"))
            {
                return (lblDocCardHeading.Text.Equals("Reference number") && lblRefNumber.Text.Equals("Application reference number") && lblDate.Text.Equals("Date"))
            }
            else if (Status.Equals("Approved") || Status.Equals("Revoked"))
            {
                return (lblDocCardHeading.Text.Equals("Issued") && lblRefNumber.Text.Equals("PTD number") && lblDate.Text.Equals("Date"))
            }
            return value;
        }
        #endregion
    }
}