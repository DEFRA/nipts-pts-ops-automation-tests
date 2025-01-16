using BoDi;
using Defra.UI.Tests.Data.Users;
using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

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

        [Then(@"I select the '([^']*)' radio option")]
        [Then(@"I select the '(.*)' radio option")]
        public void ThenISelectTheRadioOption(string routeOption)
        {
            _routeCheckingPage?.SelectFerryRouteOption(routeOption);
        }

        [Given(@"I have provided Scheduled departure time '(.*)''(.*)'")]
        [Then(@"I have provided Scheduled departure time '(.*)''(.*)'")]
        public void ThenIHaveProvidedScheduledDepartureTime(string hour, string minute)
        {
            _routeCheckingPage?.SelectDropDownDepartureTime(hour, minute);
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
        
        [Then(@"I have provided Scheduled departure time in hours field only")]
        public void ThenIHaveProvidedScheduledDepartureTimeInHoursFieldOnly()
        {
            _routeCheckingPage?.SelectDropDownDepartureTimeMinuteOnly();
        }

        [Then(@"I have selected '(.*)''(.*)''(.*)'Date option")]
        public void ThenIHaveSelectedDateOption(string departureDay, string departureMonth, string departureYear)
        {
            _routeCheckingPage?.SelectScheduledDepartureDate(departureDay,departureMonth,departureYear);
        }

        [Then(@"I should see the subheading '([^']*)' along with 3 route options")]
        public void ThenIShouldSeeTheSubheadingAlongWith3RouteOptions(string subHeading)
        {
            Assert.True(_routeCheckingPage?.CheckFerryRouteSubheading(subHeading), "Route Subheading along with 3 route options found");
        }

        [Then(@"I should see no ferry route options selected by default")]
        public void ThenIShouldSeeNoFerryRouteOptionsSelectedByDefault()
        {
            Assert.True(_routeCheckingPage?.CheckFerryRouteOptionsSelection(),"No ferry route options selected by default");
        }

        [Then(@"I should not see the footer of the page")]
        public void ThenIShouldNotSeeTheFooterOfThePage()
        {
            Assert.True(_routeCheckingPage?.CheckFooter(), "Footer of the page is not visible");
        }

        [Then(@"I should see back link in the top left of route checking page")]
        public void ThenIShouldSeeBackLinkInTheTopLeftOfRouteCheckingPage()
        {
            Assert.True(_welcomePage?.IsBackButtonDisplayed(), "Back Link is visible");
        }

        [Then(@"I click back link")]
        public void ThenIClickBackLink()
        {
            _welcomePage.ClickBackButton();
        }

        [Then(@"I should navigate to test environment prototype page")]
        public void ThenIShouldNavigateToTestEnvironmentPrototypePage()
        {
            Assert.True(_routeCheckingPage?.IsTestEnvironmentPrototypePageLoaded(), "Navigated to test environment prototype page");
        }

        [Then(@"I should see departure time on top of the home page")]
        public void ThenIShouldSeeDepartureTimeOnTopOfTheHomePage()
        {
            Assert.True(_routeCheckingPage?.CheckDepartureTimeOnHomePage(), "Selected Depature time displays in home page");
        }

        [Then(@"I should see the subheading '([^']*)' along with 2 route options")]
        public void ThenIShouldSeeTheSubheadingAlongWith2RouteOptions(string subHeading)
        {
            Assert.True(_routeCheckingPage?.CheckRouteSubheading(subHeading), "Subheading along with 2 route options found");
        }

        [Then(@"I should see no route options selected by default")]
        public void ThenIShouldSeeNoRouteOptionsSelectedByDefault()
        {
            Assert.True(_routeCheckingPage?.CheckRouteOptionsSelection(), "No route options selected by default");
        }

        [When(@"I see the subheading '([^']*)' with a text box")]
        public void WhenISeeTheSubheadingWithATextBox(string routeFlight)
        {
            Assert.True(_routeCheckingPage?.FlightNumberSection(routeFlight), "Flight number subheading along with text box is visible");
        }

        [Then(@"I should see a subsection '([^']*)'")]
        public void ThenIShouldSeeASubSection(string dateSubHeading)
        {
            Assert.True(_routeCheckingPage?.CheckDateSubheading(dateSubHeading), "Scheduled departure date subheading is displayed");
        }

        [Then(@"I should see hint '([^']*)' under the subheading")]
        public void ThenIShouldSeeHintUnderTheSubHeading(string hint)
        {
            Assert.True(_routeCheckingPage?.CheckHintOfDateSubheading(hint), "A hint under Scheduled departure date subheading is displayed");
        }
    }
}