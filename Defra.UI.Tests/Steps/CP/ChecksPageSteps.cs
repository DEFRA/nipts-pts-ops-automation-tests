using Defra.UI.Tests.Pages.CP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.CP
{
    [Binding]
    public class ChecksPageSteps
    {
        private readonly IWebDriver _driver;
        private readonly IWelcomePage _welcomePage;

        public ChecksPageSteps(IWebDriver driver, IWelcomePage welcomePage)
        {
            _driver = driver;
            _welcomePage = welcomePage;
        }

        [Then(@"I should navigate to Checks page")]
        public void ThenIShouldNavigateToChecksPage()
        {
            Assert.True(_welcomePage?.IsPageLoaded(), "Checks page not loaded");
        }

        [When(@"I click search button from footer")]
        public void WhenIClickSearchButtonFromFooter()
        {
            _welcomePage?.FooterSearchButton();
        }

        [Then(@"I click change link from headers")]
        public void ThenIClickChangeLinkFromHeaders()
        {
            _welcomePage?.HeadersChangeLink();
        }

        [When(@"I click footer home icon")]
        public void WhenIClickFooterHomeIcon()
        {
            _welcomePage?.FooterHomeIcon();
        }
    }
}