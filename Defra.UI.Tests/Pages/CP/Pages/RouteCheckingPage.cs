using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Tools;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using Reqnroll.BoDi;

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
        private IWebElement pageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')]"), true);
        private IWebElement signOutBy => _driver.WaitForElement(By.XPath("//a[@href='/signout']//*[name()='svg']"));
        private IWebElement rdoFerry => _driver.WaitForElement(By.XPath("//div[@class='govuk-radios__item']/label[normalize-space()='Ferry']"));
        private IWebElement rdoFlight => _driver.WaitForElement(By.XPath("//div[@class='govuk-radios__item']/label[normalize-space()='Flight']"));
        private IWebElement rdoBirkenhead => _driver.WaitForElement(By.XPath("//label[normalize-space()='Birkenhead to Belfast (Stena)']"));
        private IWebElement rdoCairnryan => _driver.WaitForElement(By.XPath("//label[normalize-space()='Cairnryan to Larne (P&O)']"));
        private IWebElement rdoLochRyan => _driver.WaitForElement(By.XPath("//label[normalize-space()='Loch Ryan to Belfast (Stena)']"));
        private IWebElement btnSaveAndContinue => _driver.WaitForElement(By.XPath("//button[normalize-space()='Save and continue']"));
        private IWebElement txtScheduledDepartureHour => _driver.WaitForElement(By.Id("sailingHour"));
        private IWebElement txtScheduledDepartureMinute => _driver.WaitForElement(By.Id("sailingMinutes"));
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
        private IWebElement lblScheduledDepartureTime => _driver.WaitForElement(By.XPath("//*[@id='time-group']//following::h2"));
        private IWebElement txtHintScheduledDepartureTime => _driver.WaitForElement(By.XPath("//*[@id='sailingHourHint']"));
        private IWebElement txtDepartDay => _driver.WaitForElement(By.XPath("//input[@id='departureDateDay']"));
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
            signOutBy.Click();
            Thread.Sleep(3000);
            return true;
        }

        public void SelectTransportationOption(string radioButtonValue)
        {
            if (radioButtonValue == "Ferry")
            {
                rdoFerry.Click(_driver);
            }
            else if (radioButtonValue == "Flight")
            {
                rdoFlight.Click(_driver);
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

        public void SetScheduledDepartureTime(string departTime)
        {
            var rows = departTime.Split(":");
            var hour = rows[0];
            var minute = rows[1];

            txtScheduledDepartureHour.Clear();
            txtScheduledDepartureMinute.Clear();
            txtScheduledDepartureHour.SendKeys(hour);
            txtScheduledDepartureMinute.SendKeys(minute);
        }

        public void SetScheduledDepartureDay(string departDay)
        {
            txtDepartDay.Clear();
            txtDepartDay.SendKeys(departDay);
        }

        public void SelectSaveAndContinue()
        {
            Console.WriteLine($"Before click URL: {_driver.Url}");

            btnSaveAndContinue.Click(_driver);

            Thread.Sleep(3000);

            Console.WriteLine($"After click URL: {_driver.Url}");
        }

        public bool FlightNumberSection(string routeFlight)
        {
            lblFlightNumber.ScrollToElement(_driver);
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
            txtScheduledDepartureHour.Clear();
            txtScheduledDepartureHour.SendKeys(hour);
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

            var dateAndTime = DateTime.Today;
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
            return txtScheduledDepartureHour.GetAttribute("value").Equals("") && txtScheduledDepartureMinute.GetAttribute("value").Equals("");
        }

        private string ParseNumber(string number)
        {
            return number.Length > 1 ? number : $"0{number}";
        }

        public void CheckDepartBefore48OrAfter24Hrs(string departureDay, string departureMonth, string departureYear, string departureHour, string departureMinute, string timeCheck)
        {
            txtScheduleDepartureDay.Clear();
            txtScheduleDepartureDay.SendKeys(departureDay);
            txtScheduleDepartureMonth.Clear();
            txtScheduleDepartureMonth.SendKeys(departureMonth);
            txtScheduleDepartureYear.Clear();
            txtScheduleDepartureYear.SendKeys(departureYear);
            txtScheduledDepartureHour.SendKeys(departureHour);

            if (timeCheck.Equals("48HoursAgo"))
            {
                txtScheduledDepartureMinute.Clear();
                txtScheduledDepartureMinute.SendKeys(departureMinute);
            }
            else if (timeCheck.Equals("After24Hours"))
            {
                var minuteAfter24Hours = int.Parse(departureMinute.ToString());
                minuteAfter24Hours = (minuteAfter24Hours + 1) % 60;
                txtScheduledDepartureHour.Clear();
                txtScheduledDepartureHour.SendKeys(minuteAfter24Hours.ToString("D2"));
            }
        }

        public void EnterInvalidURL()
        {

            string baseUrl = ConfigSetup.BaseConfiguration.TestConfiguration.ApplicationUrl;
            string Url = baseUrl + "/checker/curre";
            _driver?.Navigate().GoToUrl(Url);
        }
        #endregion
    }
}