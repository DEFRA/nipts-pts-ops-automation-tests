using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Pages.WELSH.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Pages.WELSH.Classes
{
    public class SignificantFeaturesPageWelsh : ISignificantFeaturesPageWelsh
    {
        private readonly IObjectContainer _objectContainer;

        public SignificantFeaturesPageWelsh(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public IWebElement PageHeading => _driver.WaitForElementExists(By.ClassName("govuk-fieldset__heading"), true);
        private IWebElement SignificantFeaturesRadioButtonYes => _driver.WaitForElementExists(By.CssSelector("#HasUniqueFeatureYes"), true);
        private IWebElement SignificantFeaturesRadioButtonNo => _driver.WaitForElementExists(By.CssSelector("#HasUniqueFeatureNo"), true);
        private IWebElement SignificantFeaturesTextBox => _driver.WaitForElementExists(By.ClassName("govuk-textarea"));
        private IWebElement SignificantFeaturesYesOptionHint => _driver.WaitForElementExists(By.XPath("//*[@id='conditional-feature']//label"));
        private IWebElement txtUniqueFeatures => _driver.WaitForElement(By.Id("featureinput"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));

        #endregion

        #region Methods

        public bool IsNextPageLoaded(string pageTitle)
        {
            if (ConfigSetup.BaseConfiguration.TestConfiguration.IsAccessibilityEnabled)
            {
                Cognizant.WCAG.Compliance.Checker.Analyzer.Execute(_driver);
            }

            return PageHeading.Text.Contains(pageTitle);
        }

        public string SelectSignificantFeaturesOption(string hasSignificantFeatures)
        {
            var significantFeatures = "Black Mark on Shoulder";
            var fontWeight = SignificantFeaturesYesOptionHint.GetCssValue("font-weight");
            if (hasSignificantFeatures.ToLower().Equals("oes"))
            {
                SignificantFeaturesRadioButtonYes.Click();
                if (SignificantFeaturesYesOptionHint.Text.Trim().Equals("Disgrifiwch nodwedd arwyddocaol eich anifail anwes yn fyr")
                && fontWeight == "700")
                {
                    SignificantFeaturesTextBox.SendKeys(significantFeatures);
                    return significantFeatures;
                }
            }
            else if (hasSignificantFeatures.ToLower().Equals("nac oes"))
            {
                Thread.Sleep(1000);
                SignificantFeaturesRadioButtonNo.Click();
                return "Nac oes";
            }

            return "Nac oes";
        }

        public void ClickParhauButton()
        {
            _driver.ParhauButton();
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