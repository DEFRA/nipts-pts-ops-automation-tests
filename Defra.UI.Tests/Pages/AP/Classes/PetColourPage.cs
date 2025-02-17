using Reqnroll.BoDi;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.AP.Classes
{
    public class PetColourPage : IPetColourPage
    {
        private readonly IObjectContainer _objectContainer;
        public PetColourPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public IWebElement PetColourPageHeading => _driver.WaitForElement(By.ClassName("govuk-fieldset__heading"), true);
        private IWebElement PetColourOtherRadioButton => _driver.WaitForElement(By.CssSelector("#PetColourOther"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        private IWebElement txtPetColorOther => _driver.WaitForElement(By.Id("PetColourOther"));

        #endregion

        #region Methods
        public bool IsNextPageLoaded(string pageTitle)
        {
            if (ConfigSetup.BaseConfiguration.TestConfiguration.IsAccessibilityEnabled)
            {
                Cognizant.WCAG.Compliance.Checker.Analyzer.Execute(_driver);
            }

            return PetColourPageHeading.Text.Contains(pageTitle);
        }

        public void SelectOtherColorOption(string otherColor)
        {
            txtPetColorOther.Clear();
            txtPetColorOther.SendKeys(otherColor);
        }

        public void ClickContinueButton()
        {
            _driver.ContinueButton();
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

        public void SelectColorOption(string color)
        {
            if (color.Equals("Other"))
            {
                var rdoColor = _driver.WaitForElement(By.XPath($"//div[@class='govuk-radios__item']/label[@for='rBtnPetColourOther']"));
                rdoColor.Click();
            }
            else if (!string.IsNullOrEmpty(color))
            {
                var rdoColor = _driver.WaitForElement(By.XPath($"//div[@class='govuk-radios__item']/label[@for='{color.Replace(" ", string.Empty)}']"));
                rdoColor.Click();
            }
        }

        #endregion
    }
}