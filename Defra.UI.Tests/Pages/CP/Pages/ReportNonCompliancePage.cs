using Reqnroll.BoDi;
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
        private IReadOnlyCollection<IWebElement> lblPetTravelDocumentDetails => _driver.FindElements(By.XPath("//span[@class='govuk-heading-s']"));
        private IWebElement lblPTDStatus => _driver.WaitForElementExists(By.XPath("//p[@class='govuk-body govuk-!-margin-bottom-0 pts-checker-check']"));
        private IWebElement lblReasonsHeading => _driver.WaitForElement(By.XPath($"//h2[@class='govuk-fieldset__heading']"));
        private IWebElement lblReasonsHint => _driver.WaitForElementExists(By.Id("event-name-hint"));
        private IWebElement lblTableName => _driver.WaitForElement(By.XPath($"//div[@class='govuk-summary-card__title-wrapper']/h2[normalize-space()='Pet Travel Document (PTD)']"));
        #endregion

        #region Methods
        public bool IsPageLoaded()
        {
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

        public bool CheckPetTravelDocumentDetailsSection(string status)
        {
            var cnt = lblPetTravelDocumentDetails.Count;
            if (cnt > 0)
            {
                return lblPTDStatus.Text.Contains(status);
            }
            return false;
        }

        public bool VerifyTheTableNameInPTDLink(string tableName)
        {
            return lblTableName.Text.Trim().Equals(tableName);
        }
        public bool VerifyTheExpectedStatus(string status)
        {
            return _driver.WaitForElement(By.XPath($"//dd[@class='govuk-summary-list__value']//strong[contains(text(), '{status}')]")).Text.Trim().Equals(status);
        }
        public bool VerifyReasonsHeadingWithHint(string reasons, string hint)
        {
            string reasonsHeading = lblReasonsHeading.Text;
            if(reasonsHeading.Equals(reasons) && lblReasonsHint.Text.Trim().Equals(hint))
            return true;
            else return false;
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