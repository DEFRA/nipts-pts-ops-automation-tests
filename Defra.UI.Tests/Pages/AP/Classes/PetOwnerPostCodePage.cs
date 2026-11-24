using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Reqnroll.BoDi;

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
        private IWebElement FindAddressButton => _driver.WaitForElement(By.XPath("//button[normalize-space(text()) ='Find address']"));
        private IWebElement ManuallyAddressLink => _driver.WaitForElement(By.XPath("//*[@id='main-content']/div/div/p/a"));
        #endregion

        #region Methods
        public bool IsNextPageLoaded(string pageTitle)
        {
            return PetOwnerPostCodePageHeading.Text.Contains(pageTitle);
        }

        public void EnterPetOwnerPostCode(string PostCode)
        {
            PostCodeTextBox.Click();
            PostCodeTextBox.SendKeys(PostCode);
        }

        public void ClickFindAddressButton()
        {
            var urlBeforeClick = _driver.Url;
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", FindAddressButton);
            Thread.Sleep(300);

            FindAddressButton.Click();

            try
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(5)).Until(d => d.Url != urlBeforeClick);
            }
            catch (WebDriverTimeoutException)
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", FindAddressButton);
            }

            try
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(d => d.Url != urlBeforeClick);
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception("Find address button click did not navigate away from the postcode page.");
            }
        }

        public void ClickManuallyAddressLink()
        {
            ManuallyAddressLink.Click();
        }
        #endregion
    }
}