using Reqnroll.BoDi;
using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.CP.Pages
{
    public class DocumentNotFoundPage : IDocumentNotFoundPage
    {
        private readonly IObjectContainer _objectContainer;

        public DocumentNotFoundPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement pageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')]"));
        private IWebElement lblmessage => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')]/following::p[1]"));
        private IWebElement lnkGoBackToSearch => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')]/following::p[2]/a"));
        private IWebElement lnkGoBackToSearchText => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')]/following::p[2]"));
        #endregion

        #region Methods
        public bool IsPageLoaded()
        {
            return pageHeading.Text.Contains("Document not found");
        }

        public bool VerifyMessage(string appNumber)
        {
            return lblmessage.Text.Contains(appNumber + " has not been found.");
        }

        public bool VerifyGoBackLink()
        {
            return lnkGoBackToSearchText.Text.Contains("Go back to search.");
        }

        public void ClickGoBackToSearchLink()
        {
            lnkGoBackToSearch.Click();
        }
        #endregion
    }
}