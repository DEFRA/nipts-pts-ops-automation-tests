using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Pages.WELSH.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Pages.WELSH.Classes
{
    public class ManageAccountPageWelsh : IManageAccountPageWelsh
    {
        private readonly IObjectContainer _objectContainer;

        public ManageAccountPageWelsh(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public IWebElement lnkManageYourAccount => _driver.WaitForElement(By.XPath("//a[normalize-space(text()) ='reoli’ch cyfrif']"), true);
        public IWebElement TxtTitle => _driver.WaitForElement(By.XPath("//h1"));
        public IWebElement TxtWarningText => _driver.WaitForElement(By.XPath("//strong[contains(@class,\"warning-text\")]"));
        public IWebElement LnkPTD => _driver.WaitForElement(By.XPath("//a[contains(@href, 'Travel') and contains(@class, 'govuk-link')]"));
        public IWebElement lnkUpdateDetails => _driver.WaitForElement(By.XPath("//a[normalize-space(text()) ='Update details']"));
        public IWebElement lnkChangePersonalInformation => _driver.WaitForElement(By.XPath("//*[normalize-space(text()) ='Personal information']/following::a[1]"));
        public IWebElement txtboxPhoneNumber => _driver.WaitForElement(By.Id("telephoneNumber"));
        public IWebElement lnkNameChange => _driver.WaitForElement(By.Id("change-personal-information-name-link"));
        public IWebElement lnkPhoneNumberChange => _driver.WaitForElement(By.Id("change-personal-information-phone-link"));
        public IWebElement lnkAddressChange => _driver.WaitForElement(By.Id("change-personal-address-link"));
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

        public void VerifyPageContent()
        {
            TxtTitle.Text.Equals("Rheoli’ch cyfrif Defra");
            LnkPTD.Text.Equals("Gweld eich dogfennau teithio gydol oes i anifeiliaid anwes neu wneud cais am un newydd.");
            TxtWarningText.Text.Equals("Os byddwch yn newid eich manylion personol fel eich enw a’ch cyfeiriad, mae angen ichi wneud cais am ddogfen deithio anifeiliaid anwes gydol oes newydd ar gyfer pob anifail anwes.");
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
