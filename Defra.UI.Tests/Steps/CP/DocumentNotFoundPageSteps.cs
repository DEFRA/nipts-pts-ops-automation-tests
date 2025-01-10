using Defra.UI.Tests.Pages.CP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.CP
{
    [Binding]
    public class DocumentNotFoundPageSteps
    {
        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly IDocumentNotFoundPage _documentNotFoundPage;
       

        public DocumentNotFoundPageSteps(ScenarioContext context, IWebDriver driver, IDocumentNotFoundPage documentNotFoundPage)
        {
            _scenarioContext = context;
            _driver = driver;
            _documentNotFoundPage = documentNotFoundPage;
        }

        [Then(@"I should navigate to Document not found page")]
        public void ThenIShouldNavigateToDocumentNotFoundPage()
        {
            Assert.True(_documentNotFoundPage?.IsPageLoaded(), "Document not found page not loaded");
        }
    }
}