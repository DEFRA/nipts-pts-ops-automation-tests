using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class _applicationDeclarationPageSteps
    {
        private readonly IWebDriver _driver;
        private readonly IApplicationDeclarationPage _applicationDeclarationPage;
        public _applicationDeclarationPageSteps(IWebDriver driver, IApplicationDeclarationPage applicationDeclarationPage)
        {
            _driver = driver;
            _applicationDeclarationPage = applicationDeclarationPage;
        }

        [Then(@"I navigate to the Check your answers and sign the declaration page")]
        public void ThenINavigateToTheCheckYourAnswersAndSignTheDeclarationPage()
        {
            var pageTitle = "Check your answers and sign the declaration";
            Assert.IsTrue(_applicationDeclarationPage.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have ticked the checkbox I agree to the declaration")]
        public void ThenIHaveTickedTheCheckboxIAgreeToTheDeclaration()
        {
            _applicationDeclarationPage?.TickAgreedToDeclaration();
        }

        [When(@"I click Send Application button in Declaration page")]
        public void WhenIClickSendApplicationButtonInDeclarationPage()
        {
            _applicationDeclarationPage?.ClickSendApplicationButton();
        }
    }
}