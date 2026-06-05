using Defra.UI.Tests.Pages.WELSH.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Steps.WELSH
{
    [Binding]
    public class PetOwnerPostCodePageWelshSteps
    {

        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetOwnerPostCodePageWelsh? PetOwnerPostCodePageWelsh => _objectContainer.IsRegistered<IPetOwnerPostCodePageWelsh>() ? _objectContainer.Resolve<IPetOwnerPostCodePageWelsh>() : null;
        public PetOwnerPostCodePageWelshSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should navigate to Pets Owner address postcode page in Welsh")]
        public void ThenIShouldNavigateToPetsOwnerAddressPostcodePage()
        {
            var pageTitle = $"Beth yw’ch cod post?";
            Assert.IsTrue(PetOwnerPostCodePageWelsh?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I provide Pets Owner '([^']*)' and click find address in Welsh")]
        public void WhenIProvidePetsOwnerAndClickFindAddress(string postCode)
        {
            PetOwnerPostCodePageWelsh?.EnterPetOwnerPostCode(postCode);
            PetOwnerPostCodePageWelsh?.ClickFindAddressButton();
        }

        [When(@"I click on Enter the address manually link from postcode page in Welsh")]
        public void WhenIIClickOnEnterTheAddressManuallyLinkFromPostcodePage()
        {
            PetOwnerPostCodePageWelsh?.ClickManuallyAddressLink();
        }
    }
}