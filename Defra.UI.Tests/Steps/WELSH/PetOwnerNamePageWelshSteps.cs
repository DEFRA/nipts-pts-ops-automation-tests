using Defra.UI.Tests.Pages.WELSH.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Steps.WELSH
{
    [Binding]
    public class PetOwnerNamePageWelshSteps
    {

        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetOwnerNamePageWelsh? PetOwnerNamePageWelsh => _objectContainer.IsRegistered<IPetOwnerNamePageWelsh>() ? _objectContainer.Resolve<IPetOwnerNamePageWelsh>() : null;
        public PetOwnerNamePageWelshSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should navigate to Pets Owner full name page in Welsh")]
        public void ThenIShouldNavigateToPetsOwnerFullNamePage()
        {
            var pageTitle = $"Beth yw’ch enw llawn?";
            Assert.IsTrue(PetOwnerNamePageWelsh?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I provided '([^']*)' and continue in Welsh")]
        public void WhenIProvidedAndContinue(string userName)
        {
            PetOwnerNamePageWelsh?.EnterPetOwnerName(userName);
            PetOwnerNamePageWelsh?.ClickContinueButton();
        }
    }
}
