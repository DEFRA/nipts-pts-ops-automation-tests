using BoDi;
using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class SignificantFeaturesPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private ISignificantFeaturesPage? SignificantFeaturesPage => _objectContainer.IsRegistered<ISignificantFeaturesPage>() ? _objectContainer.Resolve<ISignificantFeaturesPage>() : null;
        public SignificantFeaturesPageSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should navigate to the Does your pet have any significant features page")]
        public void ThenIShouldNavigateToTheDoesYourPetHaveAnySignificantFeaturesPage()
        {
            var pageTitle = "Does your pet have any significant features?";
            Assert.IsTrue(SignificantFeaturesPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I have selected '([^']*)' for significant features and continue")]
        public void WhenIHaveSelectedForSignificantFeaturesAndContinue(string featuresType)
        {
            SignificantFeaturesPage?.SelectSignificantFeaturesOption(featuresType);
            SignificantFeaturesPage?.ClickContinueButton();
        }
    }
}