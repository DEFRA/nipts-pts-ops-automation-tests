using Reqnroll.BoDi;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.AP.Classes
{
    public class GetYourPetMicrochippedPage : IGetYourPetMicrochippedPage
    {

        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl']"), true);
        private IWebElement SurveyLink => _driver.WaitForElement(By.LinkText("What did you think of this service?"));
        private IReadOnlyCollection<IWebElement> SurveyLinkMicrochipPage => _driver.FindElements(By.XPath("//*[@id='main-content']//p[3]"));
        private IWebElement SurveyLinkTextMicrochipPage => _driver.FindElement(By.XPath("//*[@id='main-content']//p[3]"));
        private IReadOnlyCollection<IWebElement> SurveyLinkSubmissionPage => _driver.FindElements(By.XPath("//*[@id='main-content']//p[8]"));
        private IWebElement SurveyLinkTextSubmissionPage => _driver.FindElement(By.XPath("//*[@id='main-content']//p[8]"));
        public GetYourPetMicrochippedPage(IObjectContainer container)
        {
            _objectContainer = container;
        }
        public bool IsNextPageLoaded(string pageTitle)
        {
            return PageHeading.Text.Contains(pageTitle);
        }

        public void ClickSurveyLink(string surveyLink)
        {
            if(SurveyLinkMicrochipPage.Count > 0 && SurveyLinkTextMicrochipPage.Text.Equals(surveyLink))
            {
                SurveyLink.ScrollAndClick(_driver);
            }
            else if (SurveyLinkSubmissionPage.Count > 0 && SurveyLinkTextSubmissionPage.Text.Equals(surveyLink))
            {
                SurveyLink.ScrollAndClick(_driver);
            }
        }
    }
}
