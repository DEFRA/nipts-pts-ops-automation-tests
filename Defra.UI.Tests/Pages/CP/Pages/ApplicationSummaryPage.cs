using BoDi;
using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Tools;
using Microsoft.Dynamics365.UIAutomation.Browser;
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