﻿using BoDi;
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

        public RouteCheckingPageSteps (ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I should redirected to port route checke page")]
        public void ThenIShouldRedirectedToPortRouteCheckePage()
        {
            Assert.True(_routeCheckingPage?.IsPageLoaded(), "Port route checker Application page not loaded");
        }

        [Then(@"click on signout button on CP and verify the signout message")]
        public void ThenClickOnSignoutButtonOnCPAndVerifyTheSignoutMessage()
        {
            Assert.True(_routeCheckingPage?.IsSignedOut(), "Not able to sign out");
        }

        [Given(@"I have selected '([^']*)' radio option")]
        [Then(@"I have selected '(.*)' radio option")]
        public void ThenIHaveSelectedRadioOption(string transportType)
        {
            _routeCheckingPage?.SelectTransportationOption(transportType);
        }

        [Given(@"I select the '([^']*)' radio option")]
        [Then(@"I select the '(.*)' radio option")]
        public void ThenISelectTheRadioOption(string routeOption)
        {
            _routeCheckingPage?.SelectFerryRouteOption(routeOption);
        }

        [Given(@"I have provided Scheduled departure time")]
        [Then(@"I have provided Scheduled departure time")]
        public void ThenIHaveProvidedScheduledDepartureTime()
        {
            _routeCheckingPage?.SelectDropDownDepartureTime();
        }

        [When(@"I click save and continue button from route checke page")]
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
    }
}