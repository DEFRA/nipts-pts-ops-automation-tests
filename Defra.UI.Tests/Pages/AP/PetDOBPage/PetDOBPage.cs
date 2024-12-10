using BoDi;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.AP.PetDOBPage
{
    public class PetDOBPage : IPetDOBPage
    {
        private readonly IObjectContainer _objectContainer;

        public PetDOBPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-fieldset__heading')]"), true);
        private IWebElement txtDay => _driver.WaitForElement(By.Id("Day"), true);
        private IWebElement txtMonth => _driver.WaitForElement(By.Id("Month"), true);
        private IWebElement txtYear => _driver.WaitForElement(By.Id("Year"), true);

        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));

        #endregion

        #region Methods

        public string EnterDateMonthYear(DateTime dateTime)
        {
            var day = dateTime.ToString("dd");
            var month = dateTime.ToString("MM");
            var year = dateTime.ToString("yyyy");

            txtDay.Clear();
            txtMonth.Clear();
            txtYear.Clear();

            txtDay.SendKeys(day);
            txtMonth.SendKeys(month);
            txtYear.SendKeys(year);

            return $"{day}/{month}/{year}";
        }

        public bool IsNextPageLoaded(string pageTitle)
        {
            return PageHeading.Text.Contains(pageTitle);
        }

        public bool IsError(string errorMessage)
        {
            foreach (var element in lblErrorMessages)
            {
                if (element.Text.Contains(errorMessage))
                {
                    return true;
                }
            }

            return false;
        }

        public void ClickContinueButton()
        {
            _driver.ContinueButton();
        }

        #endregion
    }
}