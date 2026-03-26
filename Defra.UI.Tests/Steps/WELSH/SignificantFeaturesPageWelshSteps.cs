using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Steps.WELSH
{
    [Binding]
    public class SignificantFeaturesPageWelshSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private ISignificantFeaturesPageWelsh? SignificantFeaturesPageWelsh => _objectContainer.IsRegistered<ISignificantFeaturesPageWelsh>() ? _objectContainer.Resolve<ISignificantFeaturesPageWelsh>() : null;
        public SignificantFeaturesPageWelshSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should navigate to the Does your pet have any significant features page in Welsh")]
        public void ThenIShouldNavigateToTheDoesYourPetHaveAnySignificantFeaturesPageInWelsh()
        {
            var pageTitle = "Oes gan eich anifail anwes unrhyw nodweddion arwyddocaol?";
            Assert.IsTrue(SignificantFeaturesPageWelsh?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I have selected '([^']*)' for significant features and continue in Welsh")]
        public void WhenIHaveSelectedForSignificantFeaturesAndContinueInWelsh(string featuresType)
        {
            SignificantFeaturesPageWelsh?.SelectSignificantFeaturesOption(featuresType);
            SignificantFeaturesPageWelsh?.ClickParhauButton();
        }
    }
}