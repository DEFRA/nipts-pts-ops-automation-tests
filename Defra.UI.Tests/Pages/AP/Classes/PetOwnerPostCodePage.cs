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
            DismissCookieBannerIfPresent();

            var urlBeforeClick = _driver.Url;
            var button = _driver.FindElement(By.XPath("//button[normalize-space(text()) ='Find address']"));

            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", button);

            try
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(5)).Until(d => d.Url != urlBeforeClick);
            }
            catch (WebDriverTimeoutException)
            {
                var retryButton = _driver.FindElement(By.XPath("//button[normalize-space(text()) ='Find address']"));
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", retryButton);
            }
        }

        private void DismissCookieBannerIfPresent()
        {
            try
            {
                var rejectButtons = _driver.FindElements(By.XPath("//button[contains(text(),'Reject additional cookies')]"));
                if (rejectButtons.Count > 0)
                {
                    ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", rejectButtons[0]);
                    Thread.Sleep(300);

                    var hideButtons = _driver.FindElements(By.XPath("//button[contains(text(),'Hide cookie message')]"));
                    if (hideButtons.Count > 0)
                    {
                        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", hideButtons[0]);
                        Thread.Sleep(300);
                    }
                }
            }
            catch (Exception)
            {
                // Banner/confirmation not present or already dismissed - safe to continue.
            }
        }

        public void ClickManuallyAddressLink()
        {
            ManuallyAddressLink.Click();
        }
        #endregion
    }
}