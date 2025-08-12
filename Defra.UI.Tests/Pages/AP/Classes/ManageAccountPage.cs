using Reqnroll.BoDi;
using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Defra.UI.Tests.Pages.AP.Classes
{
    public class ManageAccountPage : IManageAccountPage
    {
        private readonly IObjectContainer _objectContainer;

        public ManageAccountPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public IWebElement lnkManageYourAccount => _driver.WaitForElement(By.XPath("//a[normalize-space(text()) ='manage your account']"), true);
        public IWebElement lnkUpdateDetails => _driver.WaitForElement(By.XPath("//a[normalize-space(text()) ='Update details']"));
        public IWebElement lnkChangePersonalInformation => _driver.WaitForElement(By.XPath("//*[normalize-space(text()) ='Personal information']/following::a[1]"));
        public IWebElement txtboxPhoneNumber => _driver.WaitForElement(By.Id("telephoneNumber"));
        public IWebElement lnkNameChange=> _driver.WaitForElement(By.Id("change-personal-information-name-link"));
        public IWebElement lnkPhoneNumberChange => _driver.WaitForElement(By.Id("change-personal-information-phone-link"));
        public IWebElement lnkAddressChange=> _driver.WaitForElement(By.Id("change-personal-address-link"));
        public IWebElement btnContine => _driver.WaitForElement(By.XPath("//button[normalize-space(text()) ='Continue']"));
        public IWebElement btnBack => _driver.WaitForElement(By.XPath("//a[normalize-space(text())='Back']"));
        public IWebElement lnkTakinaAPetFromBritainToNorthernIreland => _driver.WaitForElement(By.XPath("//*[@id='link-taking-a-pet-from-great-britain-to-northern-ireland']"), true);
        public IWebElement txtboxFirstName => _driver.WaitForElement(By.Id("firstName"));
        public IWebElement txtboxSurname => _driver.WaitForElement(By.Id("lastName"));
        public IWebElement originalPostcode => _driver.WaitForElement(By.Id("postcode"));
        public IWebElement lnkSearchMyAddress => _driver.WaitForElement(By.Id("personal-postcode"));
        public IWebElement txtboxEnterPostcode => _driver.WaitForElement(By.Id("postcode"));
        public IWebElement btnFindAddress => _driver.WaitForElement(By.XPath("//button[normalize-space(text())='Find address']"));
        public IWebElement selectAddress => _driver.WaitForElement(By.Id("address"));
        public IWebElement lnkManageAccount => _driver.WaitForElement(By.XPath("//a[normalize-space(text()) ='Manage account']"), true);

        #endregion

        #region Methods
        public void ClickOnManageYourAccountLink()
        {
            lnkManageYourAccount.Click();
        }

        public void ClickOnManageAccountLink()
        {
            lnkManageAccount.Click();
        }

        public void ClickOnUpdatedetailsLink()
        {
            lnkUpdateDetails.Click();
        }

        public void ClickOnChangePersonalInformationLink()
        {
            lnkChangePersonalInformation.Click();
        }

        public void EnterPhoneNumber(string phoneNumber)
        {
            txtboxPhoneNumber.Clear();
            txtboxPhoneNumber.SendKeys(phoneNumber);
        }

        public void ClickContinue()
        {
            btnContine.Click();
        }

        public void ClickBackButton()
        {
            btnBack.Click();
        }

        public void ClickPetsLink()
        {

            var environment = ConfigSetup.BaseConfiguration.TestConfiguration.Environment;
            if (!environment.ToLower().Equals("pre"))
            {
                _driver.Navigate().GoToUrl(ConfigSetup.BaseConfiguration.TestConfiguration.ApplicationUrl);
            }
            else
            {
                lnkTakinaAPetFromBritainToNorthernIreland.Click();
            }
        }

        public void ClickNameChange()
        {
            lnkNameChange.Click();
        }

        public void ClickTelePhoneNmmnerChange()
        {
            lnkPhoneNumberChange.Click();
        }

        public void ClickAddressChange()
        {
            lnkAddressChange.Click();
        }

        public string EnterFirstName(string firstName)
        {
            string existingFirstName = txtboxFirstName.GetAttribute("value");
            txtboxFirstName.Clear();
            txtboxFirstName.SendKeys(firstName);
            return existingFirstName;
        }

        public string EnterLastName(string lastName)
        {
            string existingLastName = txtboxSurname.GetAttribute("value");
            txtboxSurname.Clear();
            txtboxSurname.SendKeys(lastName);
            return existingLastName;
        }

        public string ClickOnSearchUKPostcodeLink()
        {
            string currentPostcode = originalPostcode.GetAttribute("value");
            lnkSearchMyAddress.Click();
            return currentPostcode;
        }

        public void EnterTheValidPostcode(string postcode)
        {
            txtboxEnterPostcode.SendKeys(postcode);
        }

        public void ClickFindAddressButton()
        {
            btnFindAddress.Click();
        }

        public string SelectTheAddress()
        {
            SelectElement s = new SelectElement(selectAddress);
            s.SelectByIndex(1);
            return s.SelectedOption.Text.Trim();
        }
        #endregion
    }
}
