using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Pages.WELSH.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Pages.WELSH.Classes
{
    public class PetOwnerPhoneNumberPageWelsh : IPetOwnerPhoneNumberPageWelsh
    {
        private readonly IObjectContainer _objectContainer;

        public PetOwnerPhoneNumberPageWelsh(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@for='Phone']"), true);
        private IWebElement txtPhoneNumber => _driver.WaitForElement(By.Id("Phone"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));

        #endregion

        #region Methods

        public bool IsNextPageLoaded(string pageTitle)
        {
            return PageHeading.Text.Contains(pageTitle);
        }

        public void EnterPetOwnerPNumber(string phoneNumber)
        {
            txtPhoneNumber.Clear();
            txtPhoneNumber.SendKeys(phoneNumber);
        }

        public void ClickContinueButton()
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
