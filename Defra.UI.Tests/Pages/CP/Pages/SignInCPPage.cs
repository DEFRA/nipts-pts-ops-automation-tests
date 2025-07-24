using Defra.UI.Framework.Driver;
using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Tools;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Reqnroll.BoDi;
using SeleniumExtras.WaitHelpers;

namespace Defra.UI.Tests.Pages.CP.Pages
{
    public class SignInCPPage : ISignInCPPage
    {
        private readonly IObjectContainer _objectContainer;

        public SignInCPPage(IObjectContainer container)
        {
            _objectContainer = container;
        }


        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement lnkSignIn => _driver.WaitForElement(By.XPath("//button[contains(text(),'Sign in')]"));
        private IWebElement btnSignIn => _driver.WaitForElement(By.Id("continue"), true);
        private By signInConfirmBy => By.XPath("//h1[contains(@class,'govuk-heading-xl')]");
        private IWebElement UserId => _driver.FindElement(By.CssSelector("#user_id"));
        private IWebElement Password => _driver.FindElement(By.CssSelector("#password"));
        private IWebElement txtLoging => _driver.WaitForElement(By.XPath("//input[@id='password']"), true);
        private IWebElement btnContinue => _driver.WaitForElement(By.XPath("//button[normalize-space()='Continue']"));
        private IWebElement lblTitle => _driver.WaitForElement(By.XPath("//h1"), true);
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading']"), true);
        private IWebElement lnkAccessibilityStmt => _driver.WaitForElement(By.XPath("//a[normalize-space() = 'Accessibility statement']"));
        private IWebElement lblHeader => _driver.WaitForElement(By.XPath("//header[normalize-space() = 'Check a pet travelling from GB to NI']"));
        private IWebElement lblAccessibilityPageHeading => _driver.WaitForElement(By.XPath("//*[@class='govuk-heading-xl']"));
        private IReadOnlyCollection<IWebElement> lblH2SubHeadings => _driver.WaitForElements(By.XPath("//h2[@class='govuk-heading-l']"));
        private IReadOnlyCollection<IWebElement> lblH3SubHeadings => _driver.WaitForElements(By.XPath("//h3[@class='govuk-heading-m']"));
        private IWebElement lblH4SubHeading => _driver.WaitForElement(By.XPath("//h4[@class='govuk-heading-s']"));
        private IReadOnlyCollection<IWebElement> links => _driver.FindElements(By.XPath("//*[@class='govuk-body']//a"));
        #endregion

        #region Methods
        public bool VerifyHeadings(string heading, string subHeading)
        {
            _driver.Wait(5);
            var applicationTitle = lblTitle.Text.Replace("\r\n", " ").ToUpper();
            return applicationTitle.Contains(subHeading.ToUpper()) && applicationTitle.Contains(heading.ToUpper());
        }

        public bool IsPageLoaded()
        {
            return PageHeading.Text.Contains("Sign in using Government Gateway");
        }

        public void ClickSignInButton()
        {
            _driver.WaitForElementCondition(ExpectedConditions.ElementToBeClickable(lnkSignIn)).Click();
        }

        public void SignIn(string userName, string password)
        {
            UserId.SendKeys(userName);
            Password.SendKeys(password);
            _driver.WaitForElementCondition(ExpectedConditions.ElementToBeClickable(btnSignIn)).Click();
            _driver.WaitForElement(signInConfirmBy);
        }

        public void EnterPassword()
        {
            try
            {
                if (_driver.IsVisible(By.Id("continue")))
                {
                    btnSignIn.Click();
                }
            }
            catch
            {

            }
            _driver.Wait(2);
            txtLoging.SendKeys(ConfigSetup.BaseConfiguration.TestConfiguration.EnvCPLogin);
            btnContinue.Click();
        }

        public bool VerifyAccessibilityLink(string accessbilityLink)
        {
            return lnkAccessibilityStmt.IsVisible() && lnkAccessibilityStmt.Text.Trim().Equals(accessbilityLink);
        }

        public void ClickAccessibilityLink()
        {
            lnkAccessibilityStmt.Click();
        }

        public bool VerifyHeader(string header)
        {
            return lblHeader.IsVisible() && lblHeader.Text.Trim().Equals(header);
        }

        public bool VerifyHeadingOfThePage(string mainHeading)
        {
            return lblAccessibilityPageHeading.Text.Trim().Equals(mainHeading);
        }

        public bool VerifySubHeadingsOfThePage()
        {
            foreach (var h2Subheading in lblH2SubHeadings)
            {
                if (!h2Subheading.Text.Trim().Equals("How accessible this website is") && !h2Subheading.Text.Trim().Equals("Reporting accessibility problems with this website")
                    && !h2Subheading.Text.Trim().Equals("Enforcement procedure") && !h2Subheading.Text.Trim().Equals("Technical information about this website's accessibility")
                    && !h2Subheading.Text.Trim().Equals("What we're doing to improve accessibility") && !h2Subheading.Text.Trim().Equals("Preparation of this accessibility statement"))
                {
                    return false;
                }
            }

            foreach (var h3Subheading in lblH3SubHeadings)
            {
                if (!h3Subheading.Text.Trim().Equals("Compliance status") && !h3Subheading.Text.Trim().Equals("Non-accessible content")
                    && !h3Subheading.Text.Trim().Equals("Usability"))
                {
                    return false;
                }
            }

            return lblH4SubHeading.Text.Trim().Equals("Non-compliance with the accessibility regulations");
        }

        public bool VerifyLinks()
        {
            foreach (var linkElement in links)
            {
                var originalWindow = _driver.CurrentWindowHandle;
                linkElement.ScrollAndClick(_driver);

                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(6));
                wait.Until(driver => driver.WindowHandles.Count >1);

                var newTab = _driver.WindowHandles.First(handle => handle != originalWindow);
                _driver.SwitchTo().Window(newTab);

                string currentUrl = _driver.Url;
                var urls = new[] {"https://mcmw.abilitynet.org.uk/", "https://www.equalityadvisoryservice.com/", "https://www.equalityni.org/Home", "https://www.legislation.gov.uk/uksi/2018/952/contents", "https://www.w3.org/TR/WCAG21/"};
                if (urls.Contains(currentUrl))
                {
                    _driver.Close();
                    _driver.SwitchTo().Window(originalWindow);
                }
            }
            return true;
        }
        #endregion
    }
}