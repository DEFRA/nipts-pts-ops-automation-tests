﻿using BoDi;
using Defra.UI.Tests.Pages.AP.PetOwnerNamePage;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class PetOwnerNamePageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetOwnerNamePage? PetOwnerNamePage => _objectContainer.IsRegistered<IPetOwnerNamePage>() ? _objectContainer.Resolve<IPetOwnerNamePage>() : null;
        public PetOwnerNamePageSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should navigate to Pets Owner full name page")]
        public void ThenIShouldNavigateToPetsOwnerFullNamePage()
        {
            var pageTitle = $"What is your full name?";
            Assert.IsTrue(PetOwnerNamePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I provided '([^']*)' and continue")]
        public void WhenIProvidedAndContinue(string userName)
        {
            PetOwnerNamePage?.EnterPetOwnerName(userName);
            PetOwnerNamePage?.ClickContinueButton();
        }
    }
}