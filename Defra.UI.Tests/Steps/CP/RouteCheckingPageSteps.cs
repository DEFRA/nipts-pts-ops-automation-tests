using Reqnroll.BoDi;
using Defra.UI.Tests.Data.Users;
using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.CP
{
    [Binding]
    public class RouteCheckingPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IUrlBuilder? urlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;
        private IRouteCheckingPage? _routeCheckingPage => _objectContainer.IsRegistered<IRouteCheckingPage>() ? _objectContainer.Resolve<IRouteCheckingPage>() : null;
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;
        private IWelcomePage? _welcomePage => _objectContainer.IsRegistered<IWelcomePage>() ? _objectContainer.Resolve<IWelcomePage>() : null;
        public RouteCheckingPageSteps (ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I should redirected to port route checker page")]
        public void ThenIShouldRedirectedToPortRouteCheckePage()
        {
            Assert.True(_routeCheckingPage?.IsPageLoaded(), "Port route checker Application page not loaded");
        }

        [Then(@"click on signout button on CP and verify the signout message")]
        public void ThenClickOnSignoutButtonOnCPAndVerifyTheSignoutMessage()
        {
            Assert.True(_routeCheckingPage?.IsSignedOut(), "Not able to sign out");
        }

        [Given(@"I have selected '(.*)' radio option")]
        [Then(@"I have selected '(.*)' radio option")]
        public void ThenIHaveSelectedRadioOption(string transportType)
        {
            _routeCheckingPage?.SelectTransportationOption(transportType);
        }

        [Given("I select the '([^']*)' radio option")]
        [Then(@"I select the '([^']*)' radio option")]
        public void GivenISelectTheRadioOption(string routeOption)
        {
            _routeCheckingPage?.SelectFerryRouteOption(routeOption);
        }

        //[Then(@"I select the '([^']*)' radio option")]
        //[Then(@"I select the '(.*)' radio option")]
        //public void ThenISelectTheRadioOption(string routeOption)
        //{
        //    _routeCheckingPage?.SelectFerryRouteOption(routeOption);
        //}

        [Given(@"I have provided Scheduled departure time '([^']*)'")]
        [Then(@"I have provided Scheduled departure time '([^']*)'")]
        public void ThenIHaveProvidedScheduledDepartureTime(string departTime)
        {
            _routeCheckingPage?.SelectDropDownDepartureTime(departTime);
        }

        [When(@"I click save and continue button from route checker page")]
        public void WhenIClickSaveAndContinueButtonFromRouteCheckePage()
        {
            _routeCheckingPage?.SelectSaveAndContinue();
        }

        [Then(@"I provide the '(.*)' in the box")]
        public void ThenIProvideTheInTheBox(string routeFlightNumber)
        {
            _routeCheckingPage?.SelectFlightNumber(routeFlightNumber);
        }

        [Then(@"I should see an error '(.*)' in route checking page")]
        public void ThenIShouldSeeAnErrorInRouteCheckingPage(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                Assert.True(_routeCheckingPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
            }
        }

        [Then(@"I should see an error message ""([^""]*)"" in route checking page")]
        public void ThenIShouldSeeAnErrorMessageInRouteCheckingPage(string errorMessage)
        {
            Assert.True(_routeCheckingPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
        }
        
        [Then(@"I have provided Scheduled departure hour '(.*)' in hours field only")]
        public void ThenIHaveProvidedScheduledDepartureHourInHoursFieldOnly(string hour)
        {
            _routeCheckingPage?.SelectDropDownDepartureTimeHourOnly(hour);
        }

        [Then(@"I have selected '(.*)''(.*)''(.*)'Date option")]
        public void ThenIHaveSelectedDateOption(string departureDay, string departureMonth, string departureYear)
        {
            _routeCheckingPage?.SelectScheduledDepartureDate(departureDay,departureMonth,departureYear);
        }

        [Then("I have selected current date '(.*)' Date option")]
        public void ThenIHaveSelectedCurrentDateDateOption(int pastDay)
        {
            var pastDate = DateTime.Now.AddDays(pastDay);
            _routeCheckingPage?.SelectScheduledDepartureDate(pastDate.Day.ToString(), pastDate.Month.ToString(), pastDate.Year.ToString());
        }

        [Then(@"I should see the subheading '([^']*)' along with 3 route options")]
        public void ThenIShouldSeeTheSubheadingAlongWith3RouteOptions(string subHeading)
        {
            Assert.True(_routeCheckingPage?.CheckFerryRouteSubheading(subHeading), "Route Subheading along with 3 route options are not found");
        }

        [Then(@"I should see no ferry route options selected by default")]
        public void ThenIShouldSeeNoFerryRouteOptionsSelectedByDefault()
        {
            Assert.True(_routeCheckingPage?.CheckFerryRouteOptionsSelection(),"Ferry route options selected by default");
        }

        [Then(@"I should not see the footer of the page")]
        public void ThenIShouldNotSeeTheFooterOfThePage()
        {
            Assert.False(_welcomePage?.CheckFooter(), "Footer of the page is visible");
        }

        [Then(@"I should see the footer of the page")]
        public void ThenIShouldSeeTheFooterOfThePage()
        {
            Assert.True(_welcomePage?.CheckFooter(), "Footer of the page is not visible");
        }

        [Then(@"I should see the header of the page with route '([^']*)' date '(.*)''(.*)''(.*)' time '([^']*)' and change link")]
        public void ThenIShouldSeeTheHeaderOfThePageWithRouteDateTimeAndChangeLink(string route, string departureDay, string departureMonth, string departureYear, string departureTime)
        {
            Assert.True(_routeCheckingPage?.CheckRouteDetailOnHomePageHeader(route), "Given route is not displayed properly on the header");
            Assert.True(_routeCheckingPage?.CheckDepartureTimeOnHomePage(departureDay, departureMonth, departureYear, departureTime), "Departure date and time are not displayed properly on the header");
            Assert.True(_welcomePage?.IsHeaderChangeLinkDisplayed(),"Change link is not displayed on the header");
        }

        [Then("I should see the header of the page with route '([^']*)' date current date '([^']*)' time '([^']*)' and change link")]
        public void ThenIShouldSeeTheHeaderOfThePageWithRouteDateCurrentDateTimeAndChangeLink(string route, int pastDay, string departureTime)
        { 
            var pastDate = DateTime.Now.AddDays(pastDay);

            Assert.True(_routeCheckingPage?.CheckRouteDetailOnHomePageHeader(route), "Given route is not displayed properly on the header");
            Assert.True(_routeCheckingPage?.CheckDepartureTimeOnHomePage(pastDate.Day.ToString(), pastDate.Month.ToString(), pastDate.Year.ToString(), departureTime), "Departure date and time are not displayed properly on the header");
            Assert.True(_welcomePage?.IsHeaderChangeLinkDisplayed(), "Change link is not displayed on the header");
        }


        [Then(@"I should see back link in the top left of route checking page")]
        public void ThenIShouldSeeBackLinkInTheTopLeftOfRouteCheckingPage()
        {
            Assert.True(_welcomePage?.IsBackButtonDisplayed(), "Back Link is not visible");
        }

        [Then(@"I click back link")]
        public void ThenIClickBackLink()
        {
            _welcomePage?.ClickBackButton();
        }

        [Then(@"I should navigate to test environment prototype page")]
        public void ThenIShouldNavigateToTestEnvironmentPrototypePage()
        {
            Assert.True(_routeCheckingPage?.IsTestEnvironmentPrototypePageLoaded(), "Navigation to test environment prototype page is not happened");
        }

        [Then("I should see departure date current date '(.*)' and time '(.*)' on top of the home page")]
        public void ThenIShouldSeeDepartureDateCurrentDateAndTimeOnTopOfTheHomePage(int pastDay, string departureTime)
        {
            var pastDate = DateTime.Now.AddDays(pastDay);
            Assert.True(_routeCheckingPage?.CheckDepartureTimeOnHomePage(pastDate.Day.ToString(), pastDate.Month.ToString(), pastDate.Year.ToString(), departureTime), "Given Depature time is not displayed in the home page");
        }

        [Then(@"I should see the subheading '([^']*)' along with 2 route options")]
        public void ThenIShouldSeeTheSubheadingAlongWith2RouteOptions(string subHeading)
        {
            Assert.True(_routeCheckingPage?.CheckRouteSubheading(subHeading), "Subheading along with 2 route options are not found");
        }

        [Then(@"I should see no route options selected by default")]
        public void ThenIShouldSeeNoRouteOptionsSelectedByDefault()
        {
            Assert.True(_routeCheckingPage?.CheckRouteOptionsSelection(), "Route option selected by default");
        }

        [When(@"I see the subheading '([^']*)' with a text box")]
        public void WhenISeeTheSubheadingWithATextBox(string routeFlight)
        {
            Assert.True(_routeCheckingPage?.FlightNumberSection(routeFlight), "Flight number subheading along with text box is not visible");
        }

        [Then(@"I should see date subsection '([^']*)' with the current date pre-population")]
        public void ThenIShouldSeeDateSubSectionWithTheCurrentDatePrePopulation(string dateSubHeading)
        {
            Assert.True(_routeCheckingPage?.CheckDateSubheading(dateSubHeading), "Scheduled departure date subheading is not displayed");
            Assert.True(_routeCheckingPage?.CheckCurrentDatePrepopulation(), "Scheduled departure date is not prepopulated with current date");
        }

        [Then(@"I should see hint '([^']*)' under the date subheading")]
        public void ThenIShouldSeeHintUnderTheDateSubHeading(string hint)
        {
            Assert.True(_routeCheckingPage?.CheckHintOfDateSubheading(hint), "No hint under Scheduled departure date subheading is displayed");
        }

        [Then(@"I should see time subsection '([^']*)'")]
        public void ThenIShouldSeeTimeSubSection(string timeSubHeading)
        {
            Assert.True(_routeCheckingPage?.CheckTimeSubheading(timeSubHeading), "Scheduled departure time subheading is not displayed");
        }

        [Then(@"I should see hint '([^']*)' under the time subheading")]
        public void ThenIShouldSeeHintUnderTheTimeSubHeading(string hint)
        {
            Assert.True(_routeCheckingPage?.CheckHintOfTimeSubheading(hint), "No hint under Scheduled departure time subheading is displayed");
        }

        [Then(@"I should see no departure time is populated by default")]
        public void ThenIShouldSeeNoDepartureTimeIsPopulatedByDefault()
        {
            Assert.True(_routeCheckingPage?.CheckNoPrepopulatedDepartureTime(), "Departure time is pre-populated by default");
        }

        [Then("I have selected departure date as current date '(.*)' and departure time as current time to check '(.*)'")]
        public void ThenIHaveSelectedDepartureDateAsCurrentDateAndDepartureTimeAsCurrentTime(int departuredate, string timeCheck)
        {
            var dateTimeTwoDaysAgo = DateTime.UtcNow.AddDays(departuredate);
            _routeCheckingPage?.CheckDepartBefore48OrAfter24Hrs(dateTimeTwoDaysAgo.Day.ToString(), dateTimeTwoDaysAgo.Month.ToString(), dateTimeTwoDaysAgo.Year.ToString(), dateTimeTwoDaysAgo.Hour.ToString("D2"), dateTimeTwoDaysAgo.Minute.ToString("D2"), timeCheck);
        }
    }
}