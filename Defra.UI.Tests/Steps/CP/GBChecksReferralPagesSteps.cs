using Reqnroll.BoDi;
using Defra.UI.Tests.Data.Users;
using Defra.UI.Tests.Pages.CP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Defra.UI.Tests.Pages.CP.Pages;

namespace Defra.UI.Tests.Steps.CP
{
    [Binding]
    public class GBChecksReferralPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IWelcomePage? _welcomePage => _objectContainer.IsRegistered<IWelcomePage>() ? _objectContainer.Resolve<IWelcomePage>() : null;
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;
        private IGBChecksReferralPage? _gbChecksReferralPage => _objectContainer.IsRegistered<IGBChecksReferralPage>() ? _objectContainer.Resolve<IGBChecksReferralPage>() : null;

        public GBChecksReferralPageSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"I click View link in Fail Referred to SPS row with count more than 0")]
        public void WhenIClickViewLinkInFailReferredToSPSRowWithCountMoreThan0()
        {
            _gbChecksReferralPage?.ClickViewLink();
        }

        [Then(@"I should navigate to Referred to SPS page")]
        public void ThenIShouldNavigateToReferredToSPSPage()
        {
            Assert.IsTrue(_gbChecksReferralPage?.IsPageLoaded(), "Referred to SPS page not loaded ");
        }

        [When(@"I click first link in PTD or Reference number")]
        public void WhenIClickFirstLinkInPTDOrReferenceNumber()
        {
            _gbChecksReferralPage?.ClickPTDOrReferenceNumber();
        }

        [Then(@"I should navigate to GB check report page")]
        public void ThenIShouldNavigateToGBCheckReportPage()
        {
            Assert.IsTrue(_gbChecksReferralPage?.IsGBCheckReportPageLoaded(), "GB check report page not loaded ");
        }

    }
}