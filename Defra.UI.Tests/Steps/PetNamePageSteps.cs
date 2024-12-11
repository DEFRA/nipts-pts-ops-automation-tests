using BoDi;
using Defra.UI.Tests.Pages.AP.PetNamePage;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps
{
    [Binding]
    public class PetNamePageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetNamePage? PetNamePage => _objectContainer.IsRegistered<IPetNamePage>() ? _objectContainer.Resolve<IPetNamePage>() : null;
        public PetNamePageSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should navigate to the What is your pet's name page")]
        public void ThenIShouldNavigateToTheWhatIsYourPetsNamePage()
        {
            var pageTitle = "What is your pet's name?";
            Assert.IsTrue(PetNamePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have provided the Pets name as '([^']*)' and continue")]
        public void ThenIHaveProvidedThePetsNameAsAndContinue(string petName)
        {
            PetNamePage?.EnterPetsName(petName);
            PetNamePage?.ClickContinueButton();
        }
    }
}