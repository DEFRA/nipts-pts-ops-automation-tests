using AventStack.ExtentReports.Gherkin.Model;
using Defra.UI.Tests.Data.Users;
using Defra.UI.Tests.Pages.CP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Steps.CP
{
    [Binding]
    public class ChecksPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IWelcomePage? _welcomePage => _objectContainer.IsRegistered<IWelcomePage>() ? _objectContainer.Resolve<IWelcomePage>() : null;
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;

        public ChecksPageSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I should navigate to Checks page")]
        public void ThenIShouldNavigateToChecksPage()
        {
            Assert.True(_welcomePage?.IsPageLoaded(), "Checks page not loaded");
        }

        [When(@"I click search button from footer")]
        public void WhenIClickSearchButtonFromFooter()
        {
            _welcomePage?.FooterSearchButton();
        }

        [Then(@"I click change link from headers")]
        public void ThenIClickChangeLinkFromHeaders()
        {
            _welcomePage?.HeadersChangeLink();
        }

        [When(@"I click footer home icon")]
        public void WhenIClickFooterHomeIcon()
        {
            _welcomePage?.FooterHomeIcon();
        }

        [When(@"I Click on Back button")]
        public void WhenIClickOnBackButton()
        {
            _welcomePage?.ClickBackButton();
        }

        [Then(@"The Confirmation box is displayed in Checks page")]
        public void VerifyConfirmationBoxIsDisplayed()
        {
            Assert.True(_welcomePage?.IsConfirmationBoxDisplayed(), "Confirmation Box is not Displayed");
        }

        [Then(@"I should see content '([^']*)' with list '([^']*)' '([^']*)' '([^']*)'")]
        public void ThenIShouldSeeContentWithList(string content, string contentList1, string contentList2, string contentList3)
        {
            _welcomePage?.CheckFlightHomePageContent(content, contentList1, contentList2, contentList3);
        }

        [Then(@"I should see route displayed in all the tables of Checks page should be '([^']*)'")]
        public void ThenIShouldSeeRouteDisplayedInAllTheTablesOfChecksPageShouldBe(string selectedRoute)
        {
            Assert.True(_welcomePage?.ChecksPageRouteFilter(selectedRoute), "Checks Page have different routes than the selected route");
        }

        [Then(@"I should see departure date and time displayed in all tables of Checks page")]
        public void ThenIShouldSeeDepartureDateAndTimeDisplayedInAllTablesOfChecksPage()
        {
            Assert.True(_welcomePage?.SailingDetailsInChecksPageTables(), "Sailing details are not displayed properly in Checks Page tables");
        }

        [When(@"I open a new tab in the same browser window")]
        public void WhenIOpenANewTabInTheSameBrowserWindow()
        {
            _welcomePage?.OpenNewTab();
        }
    }
}