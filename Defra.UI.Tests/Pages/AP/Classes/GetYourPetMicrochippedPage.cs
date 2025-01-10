
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.AP.Classes
{
    public class GetYourPetMicrochippedPage : IGetYourPetMicrochippedPage
    {

        private readonly IWebDriver _driver;
        
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl']"), true);

        public GetYourPetMicrochippedPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public bool IsNextPageLoaded(string pageTitle)
        {
            return PageHeading.Text.Contains(pageTitle);
        }
    }
}
