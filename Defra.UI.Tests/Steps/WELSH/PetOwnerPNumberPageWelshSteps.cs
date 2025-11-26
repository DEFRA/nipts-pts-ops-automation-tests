using Defra.UI.Tests.Pages.WELSH.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;


namespace Defra.UI.Tests.Steps.WELSH
{
    [Binding]
    public class PetOwnerPNumberPageWelshSteps
    {

        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetOwnerPhoneNumberPageWelsh? PetOwnerPNumberPageWelsh => _objectContainer.IsRegistered<IPetOwnerPhoneNumberPageWelsh>() ? _objectContainer.Resolve<IPetOwnerPhoneNumberPageWelsh>() : null;
        public PetOwnerPNumberPageWelshSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should navigate to Pets Owner phone number page in Welsh")]
        public void ThenIShouldNavigateToPetsOwnerPhoneNumberPage()
        {
            var pageTitle = $"Beth yw’ch rhif ffôn?";
            Assert.IsTrue(PetOwnerPNumberPageWelsh?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I provide Pets Owner '([^']*)' and continue in Welsh")]
        public void WhenIProvidePetsOwnerAndContinue(string phoneNumber)
        {
            PetOwnerPNumberPageWelsh?.EnterPetOwnerPNumber(phoneNumber);
            PetOwnerPNumberPageWelsh?.ClickContinueButton();
        }
    }
}
