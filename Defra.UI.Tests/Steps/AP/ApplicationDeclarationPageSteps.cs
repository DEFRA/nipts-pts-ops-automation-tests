using Reqnroll.BoDi;
using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class ApplicationDeclarationPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IApplicationDeclarationPage? ApplicationDeclarationPage => _objectContainer.IsRegistered<IApplicationDeclarationPage>() ? _objectContainer.Resolve<IApplicationDeclarationPage>() : null;
        public ApplicationDeclarationPageSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I navigate to the Check your answers and sign the declaration page")]
        public void ThenINavigateToTheCheckYourAnswersAndSignTheDeclarationPage()
        {
            var pageTitle = "Check your answers and sign the declaration";
            Assert.IsTrue(ApplicationDeclarationPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have ticked the checkbox I agree to the declaration")]
        public void ThenIHaveTickedTheCheckboxIAgreeToTheDeclaration()
        {
            ApplicationDeclarationPage?.TickAgreedToDeclaration();
        }

        [When(@"I click Send Application button in Declaration page")]
        public void WhenIClickSendApplicationButtonInDeclarationPage()
        {
            ApplicationDeclarationPage?.ClickSendApplicationButton();
        }
    }
}