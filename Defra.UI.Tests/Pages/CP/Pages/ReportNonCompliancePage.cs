using BoDi;
using Defra.UI.Tests.Tools;
using Defra.UI.Tests.Pages.CP.Interfaces;
using OpenQA.Selenium;
using static Microsoft.Dynamics365.UIAutomation.Api.Pages.ActivityFeed;


namespace Defra.UI.Tests.Pages.CP.Pages
{
    public class ReportNonCompliancePage : IReportNonCompliancePage
    {
        private readonly IObjectContainer _objectContainer;

        public ReportNonCompliancePage (IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement pageHeading => _driver.WaitForElement(By.XPath("//h1[normalize-space()='Report non-compliance']"));
        private IWebElement btnReportNonCompliance => _driver.WaitForElement(By.XPath("//button[normalize-space()='Report non-compliance']"));
        private IWebElement lnkPetTravelDocumentDetails => _driver.WaitForElement(By.XPath("//span[normalize-space()='Pet Travel Document details']"));
        private IWebElement btnFootPassengerRadio=> _driver.WaitForElementExists(By.CssSelector("#footPassenger"));
        private IWebElement bntVehicleRadio => _driver.WaitForElementExists(By.CssSelector("#vehiclePassenger"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        #endregion

        #region Methods
        public bool IsPageLoaded()
        {
            Cognizant.WCAG.Compliance.Checker.Analyzer.Execute(_driver);
            return pageHeading.Text.Contains("Report non-compliance");
        }

        public void SelectReportNonComplianceButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", btnReportNonCompliance);
            btnReportNonCompliance.Click();
        }

        public void ClickPetTravelDocumentDetailsLnk()
        {
            lnkPetTravelDocumentDetails.Click();
        }

        public bool VerifyTheExpectedStatus(string status)
        {
            return _driver.WaitForElement(By.XPath($"//dd[@class='govuk-summary-list__value']//strong[contains(text(), '{status}')]")).Text.Trim().Equals(status);
        }

        public void SelectTypeOfPassenger(string radioButtonValue)
        {

            if (radioButtonValue.Equals("Foot passenger"))
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", btnFootPassengerRadio);
                btnFootPassengerRadio.Click();
            }
            else
            {
                try
                {
                    ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", bntVehicleRadio);
                    bntVehicleRadio.Click();
                }
                catch
                {
                    bntVehicleRadio.FindElement(By.CssSelector("#vehiclePassenger")).Click();
                }
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