﻿using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Defra.UI.Tests.Pages.CP.Pages
{
    public class RouteCheckingPage : IRouteCheckingPage
    {
        private readonly IWebDriver _driver;

        public RouteCheckingPage (IWebDriver driver)
        {
            _driver = driver;
        }

        #region Page objects
        
        private IWebElement signOutPageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl']"));
        private IWebElement pageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')]"));
        private IWebElement signOutBy => _driver.WaitForElement(By.XPath("//a[@href='/signout']//*[name()='svg']"));
        private IWebElement rdoFerry => _driver.WaitForElement(By.XPath("//div[@class='govuk-radios__item']/label[@for='routeOption']"));
        private IWebElement rdoFlight => _driver.WaitForElement(By.XPath("//div[@class='govuk-radios__item']/label[@for='routeOption-2']"));
        private IWebElement rdoBirkenhead => _driver.WaitForElement(By.XPath("//label[normalize-space()='Birkenhead to Belfast (Stena)']"));
        private IWebElement rdoCairnryan => _driver.WaitForElement(By.XPath("//label[normalize-space()='Cairnryan to Larne (P&O)']"));
        private IWebElement rdoLochRyan => _driver.WaitForElement(By.XPath("//label[normalize-space()='Loch Ryan to Belfast (Stena)']"));
        private IWebElement btnSaveAndContinue => _driver.WaitForElement(By.XPath("//button[normalize-space()='Save and continue']"));
        private IWebElement hourDropdown => _driver.WaitForElement(By.CssSelector("#sailingHour"));
        private IWebElement minuteDropdown => _driver.WaitForElement(By.CssSelector("#sailingMinutes"));
        private IWebElement txtBoxFlighterNumber => _driver.WaitForElement(By.XPath("//input[@id='routeFlight']"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        private IWebElement txtScheduleDepartureDay => _driver.WaitForElement(By.Id("departureDateDay"));
        private IWebElement txtScheduleDepartureMonth => _driver.WaitForElement(By.Id("departureDateMonth"));
        private IWebElement txtScheduleDepartureYear => _driver.WaitForElement(By.Id("departureDateYear"));
        #endregion

        #region Methods
        public bool IsPageLoaded()
        {
            return pageHeading.Text.Contains("What route are you checking?");
        }

        public bool IsSignedOut()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", signOutBy);
            signOutBy.Click();
            return true; 
        }

        public void SelectTransportationOption(string radioButtonValue)
        {
            _driver.ChangePageView(50);
            
            if (radioButtonValue == "Ferry")
            {
                
                if (!rdoFerry.Selected)
                {
                    rdoFerry.Click();
                }
            }
            else if (radioButtonValue == "Flight")
            {
                
                if (!rdoFlight.Selected)
                {
                    rdoFlight.Click();
                }
            }
        }

        public void SelectFerryRouteOption(string routeOption)
        {
            switch (routeOption)
            {
                case "Birkenhead to Belfast (Stena)":
                    rdoBirkenhead.Click();
                    break;
                case "Cairnryan to Larne (P&O)":
                    rdoCairnryan.Click();
                    break;
                case "Loch Ryan to Belfast (Stena)":
                    rdoLochRyan.Click();
                    break;
            }
        }

        public void SelectDropDownDepartureTime()
        {
            
            SelectElement selectHour = new SelectElement(hourDropdown);
            selectHour.SelectByValue("10");
            SelectElement selectMinute = new SelectElement(minuteDropdown);
            selectMinute.SelectByValue("30");
        }

        public void SelectSaveAndContinue()
        {
            btnSaveAndContinue.Click();
        }

        public void SelectFlightNumber(string routeFlight)
        {
            txtBoxFlighterNumber.Clear();
            txtBoxFlighterNumber.SendKeys(routeFlight);
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

        public void SelectScheduledDepartureDate(string departureDay,string departureMonth,string departureYear)
        {
            txtScheduleDepartureDay.Clear();
            txtScheduleDepartureDay.SendKeys(departureDay);
            txtScheduleDepartureMonth.Clear();
            txtScheduleDepartureMonth.SendKeys(departureMonth);
            txtScheduleDepartureYear.Clear();
            txtScheduleDepartureYear.SendKeys(departureYear);
        }

        public void SelectDropDownDepartureTimeMinuteOnly()
        {

            SelectElement selectMinute = new SelectElement(minuteDropdown);
            selectMinute.SelectByValue("30");
        }

        #endregion
    }
}