using BoDi;
using Defra.UI.Tests.Pages.CP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.CP
{
    [Binding]
    public class ApplicationSummaryPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IApplicationSummaryPage? _applicationSummaryPage => _objectContainer.IsRegistered<IApplicationSummaryPage>() ? _objectContainer.Resolve<IApplicationSummaryPage>() : null;

        public ApplicationSummaryPageSteps (ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"I should see the application status in '([^']*)'")]
        [Then(@"I should see the application status in '([^']*)'")]
        public void ThenIShouldSeeTheApplicationStatusIn(string applicationStatus)
        {
            Assert.IsTrue(_applicationSummaryPage?.VerifyTheExpectedStatus(applicationStatus), "The submitted application is not in expected status");
        }

        [Then(@"I select Pass radio button")]
        [When(@"I select Pass radio button")]
        public void WhenISelectPassRadioButton()
        {
            _applicationSummaryPage?.SelectPassRadioButton();
        }

        [Then(@"I select Fail radio button")]
        [When(@"I select Pass radio button")]
        public void WhenISelectFailRadioButton()
        {
            _applicationSummaryPage?.SelectFailRadioButton();
        }

        [When(@"I click save and continue button from application status page")]
        public void WhenIClickSaveAndContinueButtonFromApplicationStatusPage()
        {
            _applicationSummaryPage?.SelectSaveAndContinue();
        }

        [Then(@"I should see an error message ""([^""]*)"" in application status page")]
        public void ThenIShouldSeeAnErrorMessageInApplicationStatusPage(string errorMessage)
        {
            Assert.True(_applicationSummaryPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
        }
    }
}