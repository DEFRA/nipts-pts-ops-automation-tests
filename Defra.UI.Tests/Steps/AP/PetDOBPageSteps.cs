using Reqnroll.BoDi;
using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class PetDOBPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetDOBPage? PetDOBPage => _objectContainer.IsRegistered<IPetDOBPage>() ? _objectContainer.Resolve<IPetDOBPage>() : null;
        public PetDOBPageSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should navigate to the Do you know your pet's date of birth page")]
        public void ThenIShouldNavigateToTheDoYouKnowYourPetsDateOfBirthPage()
        {
            var pageTitle = "What is your pet's date of birth?";
            Assert.IsTrue(PetDOBPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I have provided date of birth for pet and continue")]
        public void WhenIHaveProvidedDateOfBirthForPetAndContinue()
        {
            PetDOBPage?.EnterDateMonthYear(DateTime.Now.AddYears(-8));
            PetDOBPage?.ClickContinueButton();
        }
    }
}