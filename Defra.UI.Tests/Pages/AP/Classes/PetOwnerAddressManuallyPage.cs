using BoDi;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defra.UI.Tests.Pages.AP.Classes
{
    public class PetOwnerAddressManuallyPage : IPetOwnerAddressManuallyPage
    {
        private readonly IObjectContainer _objectContainer;
        public PetOwnerAddressManuallyPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement PetOwnerAddressManuallyPageHeading => _driver.WaitForElement(By.CssSelector(".govuk-fieldset__heading"), true);
        private IWebElement FirstAddressLine => _driver.WaitForElement(By.CssSelector("#AddressLineOne"));
        private IWebElement SecondAddressLine => _driver.WaitForElement(By.CssSelector("#AddressLineTwo"));
        private IWebElement CityAddressLine => _driver.WaitForElement(By.CssSelector("#TownOrCity"));
        private IWebElement CountyAddressLine => _driver.WaitForElement(By.CssSelector("#County"));
        private IWebElement PostCodeAddressLine => _driver.WaitForElement(By.CssSelector("#Postcode"));
        #endregion

        #region Methods
        public bool IsNextPageLoaded(string pageTitle)
        {
            return PetOwnerAddressManuallyPageHeading.Text.Contains(pageTitle);
        }

        public void EnterAddressManually(string firstLine, string secondLine, string city, string county, string postCode)
        {
            FirstAddressLine.SendKeys(firstLine);
            SecondAddressLine.SendKeys(secondLine);
            CityAddressLine.SendKeys(city);
            CountyAddressLine.SendKeys(county);
            PostCodeAddressLine.SendKeys(postCode);
        }

        public void ClickContinueButton()
        {
            _driver.ContinueButton();
        }
        #endregion
    }
}