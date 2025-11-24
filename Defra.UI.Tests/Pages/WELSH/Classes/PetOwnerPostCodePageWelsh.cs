using OpenQA.Selenium;
using Reqnroll.BoDi;
using Defra.UI.Tests.Pages.WELSH.Interfaces;
using Defra.UI.Tests.Tools;

namespace Defra.UI.Tests.Pages.WELSH.Classes
{
    public class PetOwnerPostCodePageWelsh : IPetOwnerPostCodePageWelsh
    {

        private readonly IObjectContainer _objectContainer;
        public PetOwnerPostCodePageWelsh(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement PetOwnerPostCodePageHeading => _driver.WaitForElement(By.Id("documents"), true);
        private IWebElement PostCodeTextBox => _driver.WaitForElement(By.CssSelector("#Postcode"));
        private IWebElement FindAddressButton => _driver.WaitForElement(By.XPath("//button[normalize-space(text()) ='Dod o hyd i gyfeiriad']"));
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
            FindAddressButton.Click();
        }

        public void ClickManuallyAddressLink()
        {
            ManuallyAddressLink.Click();
        }
        #endregion
    }
}
