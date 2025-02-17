using BoDi;
using OpenQA.Selenium;
using Defra.UI.Tests.Tools;
using Defra.UI.Tests.Pages.CP.Interfaces;
using OpenQA.Selenium.Support.UI;
using Defra.UI.Framework.Driver;
using Defra.UI.Tests.Configuration;

namespace Defra.UI.Tests.Pages.CP.Pages
{
    public class RouteCheckingPage : IRouteCheckingPage
    {
        private readonly IObjectContainer _objectContainer;

        public RouteCheckingPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement signOutPageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl']"));
        private IWebElement pageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')]"),true);
        private IWebElement signOutBy => _driver.WaitForElement(By.XPath("//a[@href='/signout']//*[name()='svg']"));
        private IWebElement rdoFerry => _driver.WaitForElement(By.XPath("//div[@class='govuk-radios__item']/label[normalize-space()='Ferry']"));
        private IWebElement rdoFlight => _driver.WaitForElement(By.XPath("//div[@class='govuk-radios__item']/label[normalize-space()='Flight']"));
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
        private IWebElement lblDeparture => _driver.WaitForElement(By.XPath("//div[@class='govuk-width-container']//b[2]"));
        private IWebElement txtHeader => _driver.WaitForElement(By.XPath("//div[@class='govuk-width-container']/p"));
        private IWebElement lblSailingOrFlightSubheading => _driver.WaitForElement(By.XPath("//h2[text()='Are you checking a ferry or a flight?']"));
        private IWebElement lblScheduledDepartureDate => _driver.WaitForElement(By.XPath("//h2[normalize-space()='Scheduled departure date']"));
        private IWebElement txtHintScheduledDepartureDate => _driver.WaitForElement(By.XPath("//*[@id='departure-date-hint']"));
        private IWebElement lblScheduledDepartureTime => _driver.WaitForElement(By.XPath("//*[@id='time-group']//b"));
        private IWebElement txtHintScheduledDepartureTime => _driver.WaitForElement(By.XPath("//*[@id='sailingHourHint']"));
        #endregion

        #region Methods
        public bool IsPageLoaded()
        {
            if (ConfigSetup.BaseConfiguration.TestConfiguration.IsAccessibilityEnabled)
            {
                Cognizant.WCAG.Compliance.Checker.Analyzer.Execute(_driver);
            }

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
            if (radioButtonValue == "Ferry")
            {

                if (!rdoFerry.Selected)
                {
                    rdoFerry.Click(_driver);
                }
            }
            else if (radioButtonValue == "Flight")
            {

                if (!rdoFlight.Selected)
                {
                    rdoFlight.Click(_driver);
                }
            }
        }

        public void SelectFerryRouteOption(string routeOption)
        {
            switch (routeOption)
            {
                case "Birkenhead to Belfast (Stena)":
                    rdoBirkenhead.Click(_driver);
                    break;
                case "Cairnryan to Larne (P&O)":
                    rdoCairnryan.Click(_driver);
                    break;
                case "Loch Ryan to Belfast (Stena)":
                    rdoLochRyan.Click(_driver);
                    break;
            }
        }

        public void SelectDropDownDepartureTime(string departTime)
        {
            var time = departTime;
            dynamic[] rows = departTime.Split(":");
            dynamic hour = rows[0];
            dynamic minute = rows[1];

            var selectHour = new SelectElement(hourDropdown);
            var hourOptions = hourDropdown.FindElements(By.XPath("//*[@id='sailingHour']/option")).Select(o => o.Text).ToList();
            hourOptions.Remove("");
            foreach (var option in hourOptions)
            {
                if (!(int.TryParse(option, out var hourValue) && hourValue >= 0 && hourValue <= 23))
                {
                    Console.WriteLine($"Invalid hour found:" + option);
                    break;
                }
            }

            selectHour.SelectByValue(hour);

            var selectMinute = new SelectElement(minuteDropdown);
            var minuteOptions = minuteDropdown.FindElements(By.XPath("//*[@id='sailingMinutes']/option")).Select(o => o.Text).ToList();
            minuteOptions.Remove("");
            foreach (var option in minuteOptions)
            {
                if (!(int.TryParse(option, out var minuteValue) && minuteValue >= 0 && minuteValue <= 59))
                {
                    Console.WriteLine($"Invalid Minute found:" + option);
                    break;
                }
            }
            selectMinute.SelectByValue(minute);
        }

        public void SelectSaveAndContinue()
        {
            btnSaveAndContinue.Click(_driver);
        }

        public bool FlightNumberSection(string routeFlight)
        {
            return lblFlightNumber.Displayed && txtBoxFlightNumber.Displayed;
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

        public void SelectScheduledDepartureDate(string departureDay, string departureMonth, string departureYear)
        {
            txtScheduleDepartureDay.Clear();
            txtScheduleDepartureDay.SendKeys(departureDay);
            txtScheduleDepartureMonth.Clear();
            txtScheduleDepartureMonth.SendKeys(departureMonth);
            txtScheduleDepartureYear.Clear();
            txtScheduleDepartureYear.SendKeys(departureYear);
        }

        public void SelectDropDownDepartureTimeHourOnly(string hour)
        {
            var selectHour = new SelectElement(hourDropdown);
            selectHour.SelectByValue(hour);
        }

        public bool CheckFerryRouteSubheading(string subHeading)
        {
            return lblRouteSubheading.Displayed && rdoBirkenhead.Displayed && rdoCairnryan.Displayed && rdoLochRyan.Displayed;
        }

        public bool CheckFerryRouteOptionsSelection()
        {
            return !rdoBirkenhead.Selected && !rdoCairnryan.Selected && !rdoLochRyan.Selected;
        }

        public bool IsTestEnvironmentPrototypePageLoaded()
        {
            return pageHeading.Text.Contains("This is a test environment");
        }

        public bool CheckDepartureTimeOnHomePage(string departureDay, string departureMonth, string departureYear, string departureTime)
        {
            var header = txtHeader.Text;
            dynamic[] rows = header.Split("Departure:");
            dynamic displayedDate = rows[1].Substring(1, 10);
            dynamic displayedTime = rows[1].Substring(12, 5);

            var givenDate = $"{ParseNumber(departureDay)}/{ParseNumber(departureMonth)}/{departureYear}";
            
            return lblDeparture.Text.Equals("Departure:") && displayedDate.Equals(givenDate) && displayedTime.Equals(departureTime);
        }

        public bool CheckRouteSubheading(string subHeading)
        {
            return lblSailingOrFlightSubheading.Displayed && rdoFerry.Displayed && rdoFlight.Displayed;
        }

        public bool CheckRouteOptionsSelection()
        {
            return !rdoFerry.Selected && !rdoFlight.Selected;
        }

        public bool CheckDateSubheading(string dateSubHeading)
        {
            return lblScheduledDepartureDate.Text.Equals(dateSubHeading);
        }

        public bool CheckHintOfDateSubheading(string hint)
        {
            return txtHintScheduledDepartureDate.Text.Equals(hint);
        }

        public bool CheckTimeSubheading(string timeSubHeading)
        {
            return lblScheduledDepartureTime.Text.Equals(timeSubHeading);
        }

        public bool CheckHintOfTimeSubheading(string hint)
        {
            var timeHint = txtHintScheduledDepartureTime.Text.Replace("\r\n", "");
            return timeHint.Equals(hint);
        }

        public bool CheckCurrentDatePrepopulation()
        {
            var existingDate = txtScheduleDepartureDay.GetAttribute("value") + "/" + txtScheduleDepartureMonth.GetAttribute("value") + "/" + txtScheduleDepartureYear.GetAttribute("value");

            DateTime dateAndTime = DateTime.Today;
            var currentDate = dateAndTime.ToString("dd/MM/yyyy");
            return existingDate.Equals(currentDate);
        }

        public bool CheckRouteDetailOnHomePageHeader(string route)
        {
            var header = txtHeader.Text;
            dynamic[] rows = header.Split("Departure:");
            dynamic displayedRoute = rows[0].Trim();

            var givenRoute = "Route: " + route;
            return displayedRoute.Equals(givenRoute);
        }

        public bool CheckNoPrepopulatedDepartureTime()
        {
            return hourDropdown.GetAttribute("value").Equals("") && minuteDropdown.GetAttribute("value").Equals("");
        }

        private string ParseNumber(string number)
        {
            return number.Length > 1 ? number : $"0{number}";
        }

        #endregion
    }
}