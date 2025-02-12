using BoDi;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Pages.CP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.CP
{

    [Binding]
    public class SearchDocumentPageSteps
    {

        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private ISummaryPage? summaryPage => _objectContainer.IsRegistered<ISummaryPage>() ? _objectContainer.Resolve<ISummaryPage>() : null;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private ISearchDocumentPage? _searchDocumentPage => _objectContainer.IsRegistered<ISearchDocumentPage>() ? _objectContainer.Resolve<ISearchDocumentPage>() : null;
        private IReportNonCompliancePage? _reportNonCompliancePage => _objectContainer.IsRegistered<IReportNonCompliancePage>() ? _objectContainer.Resolve<IReportNonCompliancePage>() : null;

        public SearchDocumentPageSteps (ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
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

        [Then(@"I see the values are deleted")]
        public void ThenISeeTheValuesAreCleared()
        {
            Assert.True(_searchDocumentPage?.VerifyTheValuesAreCleared(), $"The Values in Search page is not cleared");
        }

        [Then(@"I should see the already entered PTD number '(.*)' in the text box")]
        public void ThenIShouldSeeTheAlreadyEnteredPTDNumberInTheTextBox(string alreadyEnteredPTDNumber)
        {
            Assert.True(_searchDocumentPage?.VerifyAlreadyEnteredPTDNumber(alreadyEnteredPTDNumber), "There is no PTD number exists in the text box");
        }

        [Then(@"I should see the already entered application number '(.*)' in the text box")]
        public void ThenIShouldSeeTheAlreadyEnteredApplicationNumberInTheTextBox(string alreadyEnteredApplicationNumber)
        {
            Assert.True(_searchDocumentPage?.VerifyAlreadyEnteredApplicationNumber(alreadyEnteredApplicationNumber), "There is no Application number exists in the text box");
        }

        [When("I select Search by PTD number radio button and then selected the Search by application number radio button")]
        public void WhenISelectSearchByPTDNumberRadioButtonAndThenSelectedTheSearchByApplicationNumberRadioButton()
        {
            _searchDocumentPage?.SelectAndSwapToApplicationNumberRadioButton();
        }

        [Then(@"I should see the already entered microchip number '(.*)' in the text box")]
        public void ThenIShouldSeeTheAlreadyEnteredMicrochipNumberInTheTextBox(string alreadyEnteredMicrochipNumber)
        {
            Assert.True(_searchDocumentPage?.VerifyAlreadyEnteredMicrochipNumber(alreadyEnteredMicrochipNumber), "There is no Microchip number exists in the text box");
        }

        [Then(@"I should navigate to '(.*)' error page")]
        public void ThenIShouldNavigateToErrorPage(string errorPageHeading)
        {
            Assert.True(_searchDocumentPage?.VerifyYouCannotAccessPage(errorPageHeading), "You cannot access this page or perform this action page is not loaded");
        }

        [When(@"I click go back to the previous page link")]
        public void WhenIClickGoBackToThePreviousLink()
        {
            _searchDocumentPage?.VerifyGoBackToPreviousPageLink();
        }
    }
}