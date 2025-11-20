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
    public class PetOwnerNamePageWelshSteps
    {

        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetOwnerNamePage? PetOwnerNamePage => _objectContainer.IsRegistered<IPetOwnerNamePage>() ? _objectContainer.Resolve<IPetOwnerNamePage>() : null;
        public PetOwnerNamePageWelshSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should navigate to Pets Owner full name page in Welsh")]
        public void ThenIShouldNavigateToPetsOwnerFullNamePage()
        {
            var pageTitle = $"What is your full name?";
            Assert.IsTrue(PetOwnerNamePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I provided '([^']*)' and continue in Welsh")]
        public void WhenIProvidedAndContinue(string userName)
        {
            PetOwnerNamePage?.EnterPetOwnerName(userName);
            PetOwnerNamePage?.ClickContinueButton();
        }
    }
}
