using Defra.UI.Tests.Data.Users;
using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll.BoDi;
using Reqnroll;

namespace Defra.UI.Tests.Steps.CP
{
    [Binding]
    public class UpdateReferralOutcomeSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IUrlBuilder? urlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;
        private IUpdateReferralOutcomePage? _updateReferalOutcomePage => _objectContainer.IsRegistered<IUpdateReferralOutcomePage>() ? _objectContainer.Resolve<IUpdateReferralOutcomePage>() : null;
        private IRouteCheckingPage? _routeCheckingPage => _objectContainer.IsRegistered<IRouteCheckingPage>() ? _objectContainer.Resolve<IRouteCheckingPage>() : null;
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;

        public UpdateReferralOutcomeSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I should see Update referral outcome page")]
        public void ThenIShouldSeeUpdateReferralOutcomePage()
        {
            Assert.True(_updateReferalOutcomePage?.IsPageLoaded(), "Update referral outcome page not loaded");
        }
        
        [When(@"I select ""(.*)"" in Update Referral Outcome page")]
        public void WhenISelectAllowOrNotAllowed(string Outcome)
        {
            if (Outcome.ToLower().Equals("allowed"))
            {
                _updateReferalOutcomePage?.ClickAllowed();
            }
            else
            {
                _updateReferalOutcomePage?.ClickNotAllowed();
            }
        }
        
        [When(@"I Click Save in Update referral outcome page")]
        public void WhenIClickSaveInUpdateReferralOutcomePage()
        {
            _updateReferalOutcomePage?.ClickSave();
        }
        
        [When(@"I enter details of outcome (.*) in Update referral outcome page")]
        public void WhenIEnterDetailsOfOutcome(string outcome)
        {
            _updateReferalOutcomePage?.EnterDetailsOfOutcome(outcome);
        }
    }
}
