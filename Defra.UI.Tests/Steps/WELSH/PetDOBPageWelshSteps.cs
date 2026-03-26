using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Steps.WELSH
{
    [Binding]
    public class PetDOBPageWelshSteps
    {

        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetDOBPageWelsh? PetDOBPageWelsh => _objectContainer.IsRegistered<IPetDOBPageWelsh>() ? _objectContainer.Resolve<IPetDOBPageWelsh>() : null;
        public PetDOBPageWelshSteps(IObjectContainer container, ScenarioContext context)
        {
            _objectContainer = container;
            _scenarioContext = context;
        }

        [Then(@"I should navigate to the Do you know your pet's date of birth page in Welsh")]
        public void ThenIShouldNavigateToTheDoYouKnowYourPetsDateOfBirthPage()
        {
            var pageTitle = "";
            Assert.IsTrue(PetDOBPageWelsh?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I have provided date of birth for pet and continue in Welsh")]
        public void WhenIHaveProvidedDateOfBirthForPetAndContinue()
        {
            PetDOBPageWelsh?.EnterDateMonthYear(DateTime.Now.AddYears(-8));
            PetDOBPageWelsh?.ClickParhauButton();
        }

        [Then(@"I have provided date of birth in Welsh")]
        public void ThenIHaveProvidedDateOfBirth()
        {
            var dateOfBirth = PetDOBPageWelsh?.EnterDateMonthYear(DateTime.Now.AddYears(-8));
            _scenarioContext.Add("Dyddiad geni", dateOfBirth);
        }
    }
}
