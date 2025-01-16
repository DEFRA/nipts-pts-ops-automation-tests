using BoDi;
using OpenQA.Selenium;
using Defra.UI.Tests.Tools;
using Defra.UI.Tests.Pages.CP.Interfaces;
using OpenQA.Selenium.Support.UI;
using Defra.UI.Framework.Driver;

namespace Defra.UI.Tests.Pages.CP.Pages
{
    public class RouteCheckingPage : IRouteCheckingPage
    {
        private readonly IObjectContainer _objectContainer;

        public RouteCheckingPage (IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
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
        private IWebElement lblFlightNumber => _driver.WaitForElement(By.XPath("//label[normalize-space()='Flight number']"));
        private IWebElement txtBoxFlightNumber => _driver.WaitForElement(By.XPath("//input[@id='routeFlight']"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        private IWebElement txtScheduleDepartureDay => _driver.WaitForElement(By.Id("departureDateDay"));
        private IWebElement txtScheduleDepartureMonth => _driver.WaitForElement(By.Id("departureDateMonth"));
        private IWebElement txtScheduleDepartureYear => _driver.WaitForElement(By.Id("departureDateYear"));
        private IWebElement lblRouteSubheading => _driver.WaitForElement(By.XPath("//*[@id='ferry-form']//h2"));
        private IWebElement pageFooter => _driver.WaitForElement(By.XPath("//div[@class='govuk-width-container']/ul"));
        private IWebElement lblDeparture => _driver.WaitForElement(By.XPath("//div[@class='govuk-width-container']//b[2]"));
        private IWebElement txtDateAndTime => _driver.WaitForElement(By.XPath("//div[@class='govuk-width-container']/p"));
        private IWebElement lblSailingOrFlightSubheading => _driver.WaitForElement(By.XPath("//*[@id='sailingForm']/div[1]/fieldset/legend/h2"));
        #endregion
        public string departDay;
        public string departMonth;
        public string departYear;
        public string departHour;
        public string departMinute;

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
            var hourOptions = hourDropdown.FindElements(By.XPath("//*[@id='sailingHour']/option")).Select(o => o.Text).ToList();
            hourOptions.Remove("");
            foreach (var option in hourOptions)
            {
                if (!(int.TryParse(option, out var hour) && hour >= 0 && hour <= 23))
                {
                    Console.WriteLine($"Invalid hour found:" + option);
                    break;
                }
            }
            selectHour.SelectByValue("10");
            departHour = "10";

            SelectElement selectMinute = new SelectElement(minuteDropdown);
            var minuteOptions = minuteDropdown.FindElements(By.XPath("//*[@id='sailingMinutes']/option")).Select(o => o.Text).ToList();
            minuteOptions.Remove("");
            foreach (var option in minuteOptions)
            {
                if (!(int.TryParse(option, out var minute) && minute >= 0 && minute <= 59))
                {
                    Console.WriteLine($"Invalid Minute found:" + option);
                    break;
                }
            }
            selectMinute.SelectByValue("30");
            departMinute = "30";
        }

        public void SelectSaveAndContinue()
        {
            btnSaveAndContinue.Click();
        }

        public bool FlightNumberSection(string routeFlight)
        {
            if(lblFlightNumber.Displayed && txtBoxFlightNumber.Displayed)
                return true;
            else return false;
        }
        public void SelectFlightNumber(string routeFlight)
        {
            txtBoxFlightNumber.Clear();
            txtBoxFlightNumber.SendKeys(routeFlight);
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
            departDay = departureDay;
            txtScheduleDepartureMonth.Clear();
            txtScheduleDepartureMonth.SendKeys(departureMonth);
            departMonth = departureMonth;
            txtScheduleDepartureYear.Clear();
            txtScheduleDepartureYear.SendKeys(departureYear);
            departYear = departureYear;
        }

        public void SelectDropDownDepartureTimeMinuteOnly()
        {

            SelectElement selectMinute = new SelectElement(minuteDropdown);
            selectMinute.SelectByValue("30");
        }
        public bool CheckFerryRouteSubheading(string subHeading)
        {
            if(lblRouteSubheading.Displayed && rdoBirkenhead.Displayed && rdoCairnryan.Displayed && rdoLochRyan.Displayed)
            {
                return true;
            }
            return false;
        }

        public bool CheckFerryRouteOptionsSelection()
        {
            if (!rdoBirkenhead.Selected && !rdoCairnryan.Selected && !rdoLochRyan.Selected)
            {
                return true;
            }
            return false;
        }

        public bool IsTestEnvironmentPrototypePageLoaded()
        {
            return pageHeading.Text.Contains("This is a test environment");
        }

        public bool CheckFooter()
        {
            return !pageFooter.Displayed;
        }

        public bool CheckDepartureTimeOnHomePage()
        {
            string header = txtDateAndTime.Text;
            string[] rows = header.Split("Departure:");
            string displayedDate = rows[1].Substring(1,10);
            string displayedTime = rows[1].Substring(12, 5);

            string givenDate = departDay + "/" + departMonth + "/" + departYear;
            string givenTime = departHour + ":" + departMinute;

            if (lblDeparture.Text.Equals("Departure:") && displayedDate.Equals(givenDate) && displayedTime.Equals(givenTime))
            {
                return true;
            }
            else return false;
        }

        public bool CheckRouteSubheading(string subHeading)
        {
            if (lblSailingOrFlightSubheading.Displayed && rdoFerry.Displayed && rdoFlight.Displayed)
            {
                return true;
            }
            return false;
        }

        public bool CheckRouteOptionsSelection()
        {
            if (!rdoFerry.Selected && !rdoFlight.Selected)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}