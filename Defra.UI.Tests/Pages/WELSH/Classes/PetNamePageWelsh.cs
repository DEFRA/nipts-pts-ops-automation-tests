using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Pages.WELSH.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Pages.WELSH.Classes
{
    public class PetNamePageWelsh : IPetNamePageWelsh
    {
        private readonly IObjectContainer _objectContainer;
        public PetNamePageWelsh(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1/label[@for='PetName']"), true);
        private IWebElement txtPetsName => _driver.WaitForElement(By.Id("PetName"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));

        #endregion

        #region Methods

        public bool IsNextPageLoaded(string pageTitle)
        {
            if (ConfigSetup.BaseConfiguration.TestConfiguration.IsAccessibilityEnabled)
            {
                Cognizant.WCAG.Compliance.Checker.Analyzer.Execute(_driver);
            }
            string heading = PageHeading.Text.Trim().Replace("\u2019", "'").Replace("\u2018", "'");
            return heading.Contains(pageTitle);
        }

        public void EnterPetsName(string petName)
        {
            txtPetsName.Clear();
            txtPetsName.SendKeys(petName);
        }

        public void ClickParhauButton()
        {
            _driver.ParhauButton();
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