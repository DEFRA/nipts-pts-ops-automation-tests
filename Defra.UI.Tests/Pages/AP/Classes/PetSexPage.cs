using Reqnroll.BoDi;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.AP.Classes
{
    public class PetSexPage : IPetSexPage
    {
        private readonly IObjectContainer _objectContainer;
        public PetSexPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public IWebElement PageHeading => _driver.WaitForElement(By.ClassName("govuk-fieldset__heading"), true);
        public IWebElement rdoFemale => _driver.WaitForElementExists(By.CssSelector("#Female"), true);
        public IWebElement rdoMale => _driver.WaitForElementExists(By.CssSelector("#Male"), true);
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        #endregion

        #region Methods
        public bool IsNextPageLoaded(string pageTitle)
        {
            return PageHeading.Text.Contains(pageTitle);
        }

        public void SelectPetsSexOption(string sex)
        {
            if (sex.ToLower().Equals("male"))
            {
                rdoMale.Click();
            }
            else
            {
                try
                {
                    rdoFemale.Click();
                }
                catch
                {
                    rdoFemale.FindElement(By.CssSelector("#Female")).Click();
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