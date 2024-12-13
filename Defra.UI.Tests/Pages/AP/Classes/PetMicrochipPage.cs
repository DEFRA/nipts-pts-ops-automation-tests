﻿using BoDi;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace Defra.UI.Tests.Pages.AP.Classes
{
    public class PetMicrochipPage : IPetMicrochipPage
    {
        private readonly IObjectContainer _objectContainer;
        public PetMicrochipPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-fieldset__heading']"), true);
        private IWebElement btnContinue => _driver.WaitForElement(By.XPath("//button[@type='submit']"), true);
        private IWebElement rdoYes => _driver.WaitForElement(By.XPath("//div[@class='govuk-radios__item']/label[@for='MicrochippedYes']"));
        private IWebElement rdoNo => _driver.WaitForElement(By.XPath("//div[@class='govuk-radios__item']/label[@for='MicrochippedNo']"));
        private IWebElement txtMicroshipNumber => _driver.WaitForElement(By.XPath("//input[@id='MicrochipNumber']"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));

        #endregion

        #region Methods
        public void ClickContinueButton()
        {
            _driver.ContinueButton();
        }

        public string EnterMicrochipNumber()
        {
            var microchipNumber = Utils.GenerateMicrochipNumber();
            txtMicroshipNumber.Clear();
            txtMicroshipNumber.SendKeys(microchipNumber);
            return microchipNumber;
        }

        public string EnterGivenMicrochipNumber(string microChipNumber)
        {
            txtMicroshipNumber.Clear();
            txtMicroshipNumber.SendKeys(microChipNumber);
            return microChipNumber;
        }

        public void UpdateMicrochipNumber(string microChipNumber)
        {
            txtMicroshipNumber.Clear();
            txtMicroshipNumber.SendKeys(microChipNumber);
        }

        public bool IsNextPageLoaded(string pageTitle)
        {
            Cognizant.WCAG.Compliance.Checker.Analyzer.Execute(_driver, false);
            return PageHeading.Text.Contains(pageTitle);
        }

        public void SelectMicrochippedOption(string option)
        {
            var microChipOrTattoOption = option.ToLower();

            if (microChipOrTattoOption.Equals("yes"))
            {
                rdoYes.Click();
            }
            else if (microChipOrTattoOption.Equals("no"))
            {
                rdoNo.Click();
            }
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