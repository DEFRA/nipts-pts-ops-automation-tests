﻿using BoDi;
using Defra.UI.Tests.Pages.AP.ApplicationSubmittedPage;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps
{
    [Binding]
    public class ApplicationSubmittedPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IApplicationSubmissionPage? ApplicationSubmittedPage => _objectContainer.IsRegistered<IApplicationSubmissionPage>() ? _objectContainer.Resolve<IApplicationSubmissionPage>() : null;
        public ApplicationSubmittedPageSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should redirect to the Application submitted page")]
        public void ThenIShouldRedirectToTheApplicationSubmittedPage()
        {
            var pageTitle = "Application submitted";
            Assert.IsTrue(ApplicationSubmittedPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I can see the application reference number")]
        public void ThenICanSeeTheApplicationReferenceNumber()
        {
            Assert.IsTrue(!string.IsNullOrEmpty(ApplicationSubmittedPage?.GetApplicationReferenceNumber()), "There is an issue with application submission");
        }
    }
}