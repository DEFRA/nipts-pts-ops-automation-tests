﻿using BoDi;
using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Defra.UI.Tests.Pages.AP.ManageAccountPage
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
        public IWebElement lnkChangePersonalInformation => _driver.WaitForElement(By.XPath("//*[normalize-space(text()) ='Personal Information']/following::a[1]"));
        public IWebElement lnkChangePersonalAddress => _driver.WaitForElement(By.XPath("//*[normalize-space(text()) ='Personal Address']/following::a[1]"));
        public IWebElement txtboxPhoneNumber => _driver.WaitForElement(By.XPath("//*[normalize-space(text()) ='Telephone number']/following::input[1]"));
        public IWebElement btnContine => _driver.WaitForElement(By.XPath("//button[normalize-space(text()) ='Continue']"));
        public IWebElement btnBack => _driver.WaitForElement(By.XPath("//a[normalize-space(text())='Back']"));
        public IWebElement lnkTakinaAPetFromBritainToNorthernIreland => _driver.WaitForElement(By.XPath("//*[@id='link-taking-a-pet-from-great-britain-to-northern-ireland']"), true);
        public IWebElement txtboxFirstName => _driver.WaitForElement(By.XPath("//*[normalize-space(text())='First or given name']/following::input[1]"));
        public IWebElement txtboxSurname => _driver.WaitForElement(By.XPath("//*[normalize-space(text())='Surname or family name']/following::input[1]"));
        public IWebElement originalPostcode => _driver.WaitForElement(By.XPath("//*[normalize-space(text())='Zip or postal code']/following::input"));
        public IWebElement lnkSearchMyAddress => _driver.WaitForElement(By.XPath("//a[normalize-space(text())='Search for my address by UK Postcode']"));
        public IWebElement txtboxEnterPostcode => _driver.WaitForElement(By.XPath("//*[normalize-space(text())='Enter your postcode']/following::input[1]"));
        public IWebElement btnFindAddress => _driver.WaitForElement(By.XPath("//button[normalize-space(text())='Find address']"));
        public IWebElement selectAddress => _driver.WaitForElement(By.XPath("//*[normalize-space(text())='Select your address']/following::select"));
        #endregion

        #region Methods
        public void ClickOnManageYourAccountLink()
        {
            lnkManageYourAccount.Click();
        }

        public void ClickOnUpdatedetailsLink()
        {
            lnkUpdateDetails.Click();
        }

        public void ClickOnChangePersonalInformationLink()
        {
            lnkChangePersonalInformation.Click();
        }

        public void ClickOnChangePersonalAddressLink()
        {
            lnkChangePersonalAddress.Click();
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
