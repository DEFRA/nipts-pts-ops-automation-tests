using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Pages.WELSH.Interfaces;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Steps.WELSH
{
    [Binding]
    public class ManageAccountWelshSteps
    {

        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IManageAccountPageWelsh? ManageAccountPageWelsh => _objectContainer.IsRegistered<IManageAccountPageWelsh>() ? _objectContainer.Resolve<IManageAccountPageWelsh>() : null;
        private IHomePageWelsh? homePageWelsh => _objectContainer.IsRegistered<IHomePageWelsh>() ? _objectContainer.Resolve<IHomePageWelsh>() : null;
        private IPetOwnerDetailsPage? PetOwnerDetailsPage => _objectContainer.IsRegistered<IPetOwnerDetailsPage>() ? _objectContainer.Resolve<IPetOwnerDetailsPage>() : null;

        public ManageAccountWelshSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I click on Manage your account in Welsh")]
        public void ThenIClickOnManageYourAccount()
        {
            ManageAccountPageWelsh?.ClickOnManageYourAccountLink();
        }

        [Then(@"I verify the Manage your account page content in Welsh")]
        public void ThenIVerifyTheManageAccountPageContent()
        {
            ManageAccountPageWelsh?.VerifyPageContent();
        }

        [When(@"I click on Manage account in Welsh")]
        public void ThenIClickOnManageAccount()
        {
            ManageAccountPageWelsh?.ClickOnManageAccountLink();
        }
    }
}
