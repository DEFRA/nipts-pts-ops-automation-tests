using BoDi;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.AP.PetOwnerNamePage
{
    public class PetOwnerNamePage : IPetOwnerNamePage
    {
        private readonly IObjectContainer _objectContainer;
        public PetOwnerNamePage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@for='Name']"), true);
        public IWebElement txtPetOwnerName => _driver.WaitForElement(By.CssSelector("#Name"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        #endregion

        #region Methods
        public bool IsNextPageLoaded(string pageTitle)
        {
            return PageHeading.Text.Contains(pageTitle);
        }
        public void EnterPetOwnerName(string onwerName)
        {
            txtPetOwnerName.Clear();
            txtPetOwnerName.SendKeys(onwerName);
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