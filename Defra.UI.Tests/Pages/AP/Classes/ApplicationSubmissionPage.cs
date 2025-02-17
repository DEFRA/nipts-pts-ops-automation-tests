﻿using Reqnroll.BoDi;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using Dynamitey.DynamicObjects;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.AP.Classes
{
    public class ApplicationSubmissionPage : IApplicationSubmissionPage
    {
        private readonly IObjectContainer _objectContainer;
        public ApplicationSubmissionPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public IWebElement PageHeading => _driver.WaitForElement(By.ClassName("govuk-panel__title"), true);
        private IWebElement lblUniqueReferenceNumber => _driver.WaitForElement(By.XPath("//div[@class='govuk-panel__body']/strong"));
        private IWebElement lnkApplyForAnother => _driver.WaitForElement(By.XPath("//a[contains(text(),'Apply for another')]"));
        private IWebElement lnkViewAllSubmittedApplications => _driver.WaitForElement(By.XPath("//a[contains(text(),'View all your lifelong')]"));
        #endregion

        #region Methods

        public bool IsNextPageLoaded(string pageTitle)
        {
            if (ConfigSetup.BaseConfiguration.TestConfiguration.IsAccessibilityEnabled)
            {
                Cognizant.WCAG.Compliance.Checker.Analyzer.Execute(_driver);
            }

            return PageHeading.Text.Contains(pageTitle);
        }
        public string GetApplicationReferenceNumber()
        {
            return lblUniqueReferenceNumber.Text;
        }
        public void ClickApplyForAnotherPetTravelDocument()
        {
            lnkApplyForAnother.Click();
        }
        public void ClickViewAllSubmittedPetTravelDocument()
        {
            lnkViewAllSubmittedApplications.Click();
        }

        #endregion
    }
}