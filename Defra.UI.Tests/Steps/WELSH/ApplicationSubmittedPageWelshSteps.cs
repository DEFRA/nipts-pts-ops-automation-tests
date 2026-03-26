using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Steps.WELSH
{
    [Binding]
    public class ApplicationSubmittedPageWelshSteps
    {

        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IApplicationSubmissionPageWelsh? ApplicationSubmittedPageWelsh => _objectContainer.IsRegistered<IApplicationSubmissionPageWelsh>() ? _objectContainer.Resolve<IApplicationSubmissionPageWelsh>() : null;
        public ApplicationSubmittedPageWelshSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should redirect to the Application submitted page in Welsh")]
        public void ThenIShouldRedirectToTheApplicationSubmittedPage()
        {
            var pageTitle = "Cais wedi’i gyflwyno";
            Assert.IsTrue(ApplicationSubmittedPageWelsh?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }
    }
}
