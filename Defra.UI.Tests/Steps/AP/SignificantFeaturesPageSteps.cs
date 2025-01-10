using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class SignificantFeaturesPageSteps
    {
        private readonly IWebDriver _driver;
        private readonly ISignificantFeaturesPage _significantFeaturesPage;

        public SignificantFeaturesPageSteps(IWebDriver driver, ISignificantFeaturesPage significantFeaturesPage)
        {
            _driver = driver;
            _significantFeaturesPage = significantFeaturesPage;
        }

        [Then(@"I should navigate to the Does your pet have any significant features page")]
        public void ThenIShouldNavigateToTheDoesYourPetHaveAnySignificantFeaturesPage()
        {
            var pageTitle = "Does your pet have any significant features?";
            Assert.IsTrue(_significantFeaturesPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I have selected '([^']*)' for significant features and continue")]
        public void WhenIHaveSelectedForSignificantFeaturesAndContinue(string featuresType)
        {
            _significantFeaturesPage?.SelectSignificantFeaturesOption(featuresType);
            _significantFeaturesPage?.ClickContinueButton();
        }
    }
}