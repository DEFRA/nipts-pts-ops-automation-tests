using Defra.UI.Tests.Pages.CP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.CP
{

    [Binding]
    public class SearchDocumentPageSteps
    {
        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly ISearchDocumentPage _searchDocumentPage;

        public SearchDocumentPageSteps (ScenarioContext context, IWebDriver driver, ISearchDocumentPage searchDocumentPage)
        {
            _scenarioContext = context;
            _driver = driver;
            _searchDocumentPage = searchDocumentPage;
        }

        [Then(@"I navigate to Find a document page")]
        public void ThenINavigateToFindADocumentPage()
        {
            Assert.True(_searchDocumentPage?.IsPageLoaded(), "Find a document page not loaded");
        }

        [Then(@"I provided the PTD number of the application")]
        public void ThenIProvidedThePTDNumberOfTheApplication()
        {
            var ptdNumber = _scenarioContext.Get<string>("PTDReferenceNumber");
            var ptdNumber1= ptdNumber.Substring(5);
            _searchDocumentPage?.EnterPTDNumber(ptdNumber1);
        }

        [Then(@"I provided the Reference number of the application")]
        public void ThenIProvidedTheReferenceNumberOfTheApplication()
        {
            var referenceNumber = _scenarioContext.Get<string>("ReferenceNumber");   
            _searchDocumentPage?.EnterApplicationNumber(referenceNumber);
        }

        [Then(@"I provided the Microchip number of the application")]
        public void ThenIProvidedTheMicrochipNumberOfTheApplication()
        {
            var microchipNumber = _scenarioContext.Get<string>("MicrochipNumber");
            _searchDocumentPage?.EnterMicrochipNumber(microchipNumber);
        }

        [When(@"I click search button")]
        public void WhenIClickSearchButton()
        {
            _searchDocumentPage?.SearchButton();
        }

        [When(@"I click clear search button")]
        public void WhenIClickClearSearchButton()
        {
            _searchDocumentPage?.ClearSearchButton();
        }

        [Then(@"I provided the '(.*)' of the application")]
        public void ThenIProvidedTheOfTheApplication(string ptdNumber)
        {
            _searchDocumentPage?.EnterPTDNumber(ptdNumber);
        }

        [Then(@"I provided the Reference number '(.*)' of the application")]
        public void ThenIProvidedTheReferenceNumberOfTheApplication(string referenceNumber)
        {
            _searchDocumentPage?.EnterApplicationNumber(referenceNumber);
        }

        [Then(@"I provided the Microchip number '(.*)' of the application")]
        public void ThenIProvidedTheMicrochipNumberOfTheApplication(string microchipNumber)
        {
            _searchDocumentPage?.EnterMicrochipNumber(microchipNumber);
        }

        [Then(@"I click search by '(.*)' radio button")]
        public void ThenIClickSearchByRadioButton(string radioButton)
        {
            _searchDocumentPage?.SelectSearchRadioOption(radioButton);
        }

        [Then(@"I provided the Application Number '(.*)' of the application")]
        public void ThenIProvidedTheApplicationNumberOfTheApplication(string referenceNumber)
        {
            _searchDocumentPage?.EnterApplicationNumber(referenceNumber);
        }

        [Then(@"I should see an error message ""([^""]*)"" in Find a document page")]
        public void ThenIShouldSeeAnErrorMessageInFindADocumentPage(string errorMessage)
        {
            Assert.True(_searchDocumentPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
        }
    }
}