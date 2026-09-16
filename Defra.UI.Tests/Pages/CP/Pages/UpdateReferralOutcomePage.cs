using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Pages.CP.Pages
{
    public class UpdateReferralOutcomePage : IUpdateReferralOutcomePage
    {
        private readonly IObjectContainer _objectContainer;

        public UpdateReferralOutcomePage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement pageHeading => _driver.WaitForElement(By.XPath("//h1"), true);
        private IWebElement txtAreadDetailsOfOutcome => _driver.WaitForElement(By.XPath("//textarea"));
        private IWebElement btnSave => _driver.WaitForElement(By.XPath("//button"));
        private IWebElement rdoNotAllowed => _driver.WaitForElement(By.XPath("//label[normalize-space()='Not allowed to travel under Windsor Framework']"));
        private IWebElement rdoAllowed => _driver.WaitForElement(By.XPath("//label[normalize-space()='Allowed to travel under Windsor Framework using PTD or SUPTD issued']"));
        #endregion

        #region Methods
        public bool IsPageLoaded()
        {
            return pageHeading.Text.Contains("Update referral outcome");
        }

        public void ClickAllowed()
        {
            rdoAllowed.Click();
        }

        public void ClickNotAllowed()
        {
            rdoNotAllowed.Click();
        }
        
        public void ClickSave()
        {
            btnSave.Click();
        }
        
        public void EnterDetailsOfOutcome(string Outcome)
        {
            txtAreadDetailsOfOutcome.SendKeys(Outcome);
        }
        #endregion
    }
}
