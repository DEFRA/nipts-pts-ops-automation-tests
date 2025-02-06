using BoDi;
using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.AP.Classes
{
    public class PetSpeciesPage : IPetSpeciesPage
    {
        private readonly IObjectContainer _objectContainer;
        public PetSpeciesPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public IWebElement PageHeading => _driver.WaitForElement(By.ClassName("govuk-fieldset__heading"), true);
        private IWebElement DogRadioButton => _driver.WaitForElementExists(By.CssSelector("#Dog"));
        private IWebElement CatRadioButton => _driver.WaitForElementExists(By.CssSelector("#Cat"));
        private IWebElement FerretRadioButton => _driver.WaitForElementExists(By.CssSelector("#Ferret"));
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
        public void SelectSpecies(string species)
        {
            {
                switch (species)
                {
                    case "Dog":
                        DogRadioButton.Click();
                        break;
                    case "Cat":
                        CatRadioButton.Click();
                        break;
                    case "Ferret":
                        FerretRadioButton.Click();
                        break;
                }
            }
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

        #endregion
    }
}