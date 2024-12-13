using BoDi;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.AP.Classes
{
    public class PetOwnerPostCodePage : IPetOwnerPostCodePage
    {
        private readonly IObjectContainer _objectContainer;
        public PetOwnerPostCodePage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement PetOwnerPostCodePageHeading => _driver.WaitForElement(By.Id("documents"), true);
        private IWebElement PostCodeTextBox => _driver.WaitForElement(By.CssSelector("#Postcode"));
        private IWebElement FindAddressButton => _driver.WaitForElement(By.CssSelector(".govuk-button"));
        private IWebElement ManuallyAddressLink => _driver.WaitForElement(By.XPath("//*[@id='main-content']/div/div/p/a"));
        #endregion

        #region Methods
        public bool IsNextPageLoaded(string pageTitle)
        {
            Cognizant.WCAG.Compliance.Checker.Analyzer.Execute(_driver, false);
            return PetOwnerPostCodePageHeading.Text.Contains(pageTitle);
        }

        public void EnterPetOwnerPostCode(string PostCode)
        {
            PostCodeTextBox.Click();
            PostCodeTextBox.SendKeys(PostCode);
        }

        public void ClickFindAddressButton()
        {
            FindAddressButton.Click();
        }

        public void ClickManuallyAddressLink()
        {
            ManuallyAddressLink.Click();
        }
        #endregion
    }
}