using Defra.UI.Tests.Pages.WELSH.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Steps.WELSH
{
    [Binding]
    public class ApplicationDeclarationPageWelshSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IApplicationDeclarationPageWelsh? ApplicationDeclarationPageWelsh => _objectContainer.IsRegistered<IApplicationDeclarationPageWelsh>() ? _objectContainer.Resolve<IApplicationDeclarationPageWelsh>() : null;
        public ApplicationDeclarationPageWelshSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I navigate to the Check your answers and sign the declaration page in Welsh")]
        public void ThenINavigateToTheCheckYourAnswersAndSignTheDeclarationPageInWelsh()
        {
            var pageTitle = "Gwiriwch eich atebion a llofnodwch y datganiad";
            Assert.IsTrue(ApplicationDeclarationPageWelsh?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I should see an error message ""([^""]*)"" in declaration page in Welsh")]
        public void ThenIShouldSeeAnErrorMessageInDeclarationPageInWelsh(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                Assert.True(ApplicationDeclarationPageWelsh?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
            }
        }
    }
}