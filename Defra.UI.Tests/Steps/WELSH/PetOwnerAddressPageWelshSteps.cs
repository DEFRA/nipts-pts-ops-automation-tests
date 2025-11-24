using Defra.UI.Tests.Pages.AP.Classes;
using Defra.UI.Tests.Pages.WELSH.Classes;
using Defra.UI.Tests.Pages.WELSH.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;


namespace Defra.UI.Tests.Steps.WELSH
{
    [Binding]
    public class PetOwnerAddressPageWelshSteps
    {

        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetOwnerAddressPageWelsh? PetOwnerAddressPageWelsh => _objectContainer.IsRegistered<IPetOwnerAddressPageWelsh>() ? _objectContainer.Resolve<IPetOwnerAddressPageWelsh>() : null;
        private IPetOwnerAddressManuallyPageWelsh? PetOwnerAddressManuallyPageWelsh => _objectContainer.IsRegistered<IPetOwnerAddressManuallyPageWelsh>() ? _objectContainer.Resolve<IPetOwnerAddressManuallyPageWelsh>() : null;
        public PetOwnerAddressPageWelshSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [When(@"I select Pets Owner Address from dropdown and continue in Welsh")]
        public void WhenISelectPetsOwnerAddressFromDropdownAndContinue()
        {
            PetOwnerAddressPageWelsh?.SelectAnAddress(3);
            PetOwnerAddressPageWelsh?.ClickContinueButton();
        }

        //[Then(@"I should navigate to Pets Owner manually address page in Welsh")]
        //public void ThenIShouldNavigateToPetsOwnerManuallyAddressPage()
        //{
        //    var pageTitle = $"Beth yw’ch cyfeiriad?";
        //    Assert.IsTrue(PetOwnerAddressManuallyPageWelsh?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        //}
    }
}
