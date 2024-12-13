using BoDi;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.AP.Classes
{
    public class SignificantFeaturesPage : ISignificantFeaturesPage
    {
        private readonly IObjectContainer _objectContainer;

        public SignificantFeaturesPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public IWebElement PageHeading => _driver.WaitForElementExists(By.ClassName("govuk-fieldset__heading"), true);
        private IWebElement SignificantFeaturesRadioButtonYes => _driver.WaitForElementExists(By.CssSelector("#HasUniqueFeatureYes"), true);
        private IWebElement SignificantFeaturesRadioButtonNo => _driver.WaitForElementExists(By.CssSelector("#HasUniqueFeatureNo"), true);
        private IWebElement SignificantFeaturesTextBox => _driver.WaitForElementExists(By.ClassName("govuk-textarea"));
        private IWebElement txtUniqueFeatures => _driver.WaitForElement(By.Id("featureinput"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));

        #endregion

        #region Methods

        public bool IsNextPageLoaded(string pageTitle)
        {
            Cognizant.WCAG.Compliance.Checker.Analyzer.Execute(_driver, false);
            return PageHeading.Text.Contains(pageTitle);
        }

        public string SelectSignificantFeaturesOption(string hasSignificantFeatures)
        {
            var significantFeatures = "Black Mark on Shoulder";

            if (hasSignificantFeatures.ToLower().Equals("yes"))
            {
                SignificantFeaturesRadioButtonYes.Click();
                SignificantFeaturesTextBox.SendKeys(significantFeatures);
                return significantFeatures;
            }
            else if (hasSignificantFeatures.ToLower().Equals("no"))
            {
                SignificantFeaturesRadioButtonNo.Click();
                return "No";
            }

            return "No";
        }

        public void ClickContinueButton()
        {
            _driver.ContinueButton();
        }

        public void EnterSignificantFeatures(string significantFeatures)
        {
            SignificantFeaturesTextBox.Clear();
            SignificantFeaturesTextBox.SendKeys(significantFeatures);
        }

        public bool IsError(string errorMessage)
        {
            foreach (var element in lblErrorMessages)
            {
                if (element.Text.Contains(errorMessage))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}