using Reqnroll.BoDi;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using Defra.UI.Tests.Configuration;

namespace Defra.UI.Tests.Pages.AP.Classes
{
    public class PetBreedPage : IPetBreedPage
    {
        private readonly IObjectContainer _objectContainer;
        public PetBreedPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-fieldset__heading')]"), true);
        public IWebElement drpBreedType => _driver.WaitForElementExists(By.Id("BreedId"));
        private IWebElement txtBreed => _driver.WaitForElement(By.Name("BreedName"));
        private IWebElement drpBreedsListBox => _driver.WaitForElement(By.Id("BreedId__listbox"));
        private IWebElement btnContinue => _driver.WaitForElement(By.XPath("//button[@class='govuk-button']"));
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

        public string SelectPetsBreed(int breedIndex, bool isUpdate = false)
        {
            _driver.Wait(2);
            drpBreedType.Click();

            if(isUpdate)
            {
                drpBreedType.Clear();
            }
            
            var selectedBreed = _driver.FindElement(By.Id($"BreedId__option--{breedIndex}"));

            var selectedBread = selectedBreed.Text;
            selectedBreed.Click();

            return selectedBread;
        }

        public void ClickContinueButton()
        {
            _driver.ContinueButton();
        }

        public void EnterFreeTextBreed(string breed)
        {
            drpBreedType.Click();

            txtBreed.SendKeys(breed);
            txtBreed.SendKeys(Keys.Tab);
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