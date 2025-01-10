
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.AP.Classes
{
    public class PetOwnerDetailsPage : IPetOwnerDetailsPage
    {
        private readonly IWebDriver _driver;
        public PetOwnerDetailsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Page objects
        
        private IWebElement PetOwnerDetailsPageHeading => _driver.WaitForElement(By.ClassName("govuk-fieldset__heading"), true);
        private IWebElement DetailsRadioButtonYes => _driver.WaitForElementExists(By.CssSelector("#Yes"));
        private IWebElement DetailsRadioButtonNo => _driver.WaitForElementExists(By.CssSelector("#No"));
        public IWebElement petOwnersPhoneNumber => _driver.WaitForElement(By.XPath("//*[normalize-space(text())='Phone number']/following-sibling::dd"), true);
        public IWebElement petOwnerName => _driver.WaitForElement(By.XPath("//*[normalize-space(text())='Name']/following-sibling::dd"));
        public IWebElement updatedPetOwnerAddress => _driver.WaitForElement(By.XPath("//*[normalize-space(text())='Address']//following-sibling::dd"), true);
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        #endregion

        #region Methods
        public bool IsNextPageLoaded(string pageTitle)
        {
            return PetOwnerDetailsPageHeading.Text.Contains(pageTitle);
        }
        public void SelectIsOwnerDetailsCorrect(string radioOption)
        {
            if (radioOption.Equals("Yes"))
            {
                DetailsRadioButtonYes.Click();
            }
            else
            {
                DetailsRadioButtonNo.Click();
            }
        }
        public void ClickContinueButton()
        {
            _driver.ContinueButton();
        }
        public bool VerifyUpdatedPhoneNumber(string phoneNumber)
        {
            return petOwnersPhoneNumber.Text.Equals(phoneNumber);
        }
        public bool VerifyUpdatedName(string name)
        {
            _driver.WaitForPageToLoad();
            return petOwnerName.Text.Equals(name);
        }
        public bool VerifyUpdatedPetOwnerAddress(string petOwnerAddress)
        {
            var updatedAddress = updatedPetOwnerAddress.Text.Replace("\r\n", "").Replace(" ", string.Empty);
            return updatedAddress.Equals(petOwnerAddress.Replace(",", string.Empty).Replace(" ", string.Empty));
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