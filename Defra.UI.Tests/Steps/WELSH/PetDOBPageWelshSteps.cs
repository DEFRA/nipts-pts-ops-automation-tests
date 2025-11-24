using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defra.UI.Tests.Steps.WELSH
{
    [Binding]
    public class PetDOBPageWelshSteps
    {

        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetDOBPageWelsh? PetDOBPageWelsh => _objectContainer.IsRegistered<IPetDOBPageWelsh>() ? _objectContainer.Resolve<IPetDOBPageWelsh>() : null;
        public PetDOBPageWelshSteps(IObjectContainer container)
        {
            _objectContainer = container;
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
    }
}
