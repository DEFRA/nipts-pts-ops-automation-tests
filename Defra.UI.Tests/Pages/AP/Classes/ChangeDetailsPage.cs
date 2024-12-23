using BoDi;
using Defra.UI.Tests.Contracts;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.AP.Classes
{
    public class ChangeDetailsPage : IChangeDetailsPage
    {
        private readonly IObjectContainer _objectContainer;

        public ChangeDetailsPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-fieldset__heading']"), true);
        private IWebElement rdoYes => _driver.WaitForElement(By.XPath("//div[@class='govuk-radios__item']/label[@for='Yes']"));
        private IWebElement rdoNo => _driver.WaitForElement(By.XPath("//div[@class='govuk-radios__item']/label[@for='No']"));
        private IReadOnlyCollection<IWebElement> divPetOwnerDetailsList => _driver.WaitForElements(By.XPath("//dl/div"));


        public void ClickContinueButton()
        {
            _driver.ContinueButton();
        }

        public bool IsNextPageLoaded(string pageTitle)
        {
            return PageHeading.Text.Contains(pageTitle);
        }

        public void SelectOption(string option)
        {
            if (option.ToLower().Equals("yes"))
            {
                rdoYes.Click();
            }
            else
            {
                rdoNo.Click();
            }
        }

        public Summary GetRegisteredUserDetails()
        {
            var summary = new Summary();

            foreach (var element in divPetOwnerDetailsList)
            {
                var elementTitle = element.FindElement(By.TagName("dt"))?.Text?.Replace("\r\n", string.Empty).Trim()?.ToUpper();
                var elementValue = element.FindElements(By.TagName("dd"))?[0].Text?.Replace("\r\n", string.Empty).Trim();

                switch (elementTitle)
                {
                    case "NAME":
                        summary.Name = elementValue;
                        break;
                    case "EMAIL":
                        summary.Email = elementValue;
                        break;
                    case "ADDRESS":
                        summary.Address = elementValue;
                        break;
                    case "PHONE NUMBER":
                        summary.PhoneNumber = elementValue;
                        break;

                }
            }

            return summary;
        }
    }
}
