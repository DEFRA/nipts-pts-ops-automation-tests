using Defra.UI.Tests.Pages.WELSH.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Steps.WELSH
{
    [Binding]
    public class PetOwnerAddressManuallyPageWelshSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetOwnerAddressManuallyPageWelsh? PetOwnerAddressManuallyPageWelsh => _objectContainer.IsRegistered<IPetOwnerAddressManuallyPageWelsh>() ? _objectContainer.Resolve<IPetOwnerAddressManuallyPageWelsh>() : null;
        public PetOwnerAddressManuallyPageWelshSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should navigate to Pets Owner manually address page in Welsh")]
        public void ThenIShouldNavigateToPetsOwnerManuallyAddressPage()
        {
            var pageTitle = $"Beth yw’ch cyfeiriad?";
            Assert.IsTrue(PetOwnerAddressManuallyPageWelsh?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I fill in '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)'and continue in Welsh")]
        public void WhenIFillInAndContinue(string firstLine, string secondLine, string city, string county, string postCode)
        {
            PetOwnerAddressManuallyPageWelsh?.EnterAddressManually(firstLine, secondLine, city, county, postCode);
            PetOwnerAddressManuallyPageWelsh?.ClickContinueButton();
        }
    }
}
