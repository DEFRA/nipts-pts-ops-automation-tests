using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class ApplicationSubmittedPageSteps
    {
        private readonly IWebDriver _driver;
        private readonly IApplicationSubmissionPage _applicationSubmittedPage;
        public ApplicationSubmittedPageSteps(IWebDriver driver, IApplicationSubmissionPage applicationSubmittedPage)
        {
            _driver = driver;
            _applicationSubmittedPage = applicationSubmittedPage;
        }

        [Then(@"I should redirect to the Application submitted page")]
        public void ThenIShouldRedirectToTheApplicationSubmittedPage()
        {
            var pageTitle = "Application submitted";
            Assert.IsTrue(_applicationSubmittedPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I can see the application reference number")]
        public void ThenICanSeeTheApplicationReferenceNumber()
        {
            Assert.IsTrue(!string.IsNullOrEmpty(_applicationSubmittedPage?.GetApplicationReferenceNumber()), "There is an issue with application submission");
        }
    }
}