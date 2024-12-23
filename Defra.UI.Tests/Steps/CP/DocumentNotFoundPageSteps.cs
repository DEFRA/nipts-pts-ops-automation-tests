﻿using BoDi;
using Defra.UI.Tests.Pages.CP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.CP
{
    [Binding]
    public class DocumentNotFoundPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IDocumentNotFoundPage? _documentNotFoundPage => _objectContainer.IsRegistered<IDocumentNotFoundPage>() ? _objectContainer.Resolve<IDocumentNotFoundPage>() : null;
       

        public DocumentNotFoundPageSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I should navigate to Document not found page")]
        public void ThenIShouldNavigateToDocumentNotFoundPage()
        {
            Assert.True(_documentNotFoundPage?.IsPageLoaded(), "Document not found page not loaded");
        }
    }
}