using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.CP.Pages
{
    public class DocumentNotFoundPage : IDocumentNotFoundPage
    {
        private readonly IWebDriver _driver;

        public DocumentNotFoundPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Page objects
        
        private IWebElement pageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')]"));
        #endregion

        #region Methods
        public bool IsPageLoaded()
        {
            return pageHeading.Text.Contains("Document not found");
        }
        #endregion
    }
}