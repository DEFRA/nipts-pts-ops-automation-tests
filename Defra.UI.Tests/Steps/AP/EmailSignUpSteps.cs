using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Steps.AP
{

    [Binding]
    public class EmailSignUpSteps
    {
        private readonly object _lock = new object();
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IEmailSignUpPage? EmailSignUpPage => _objectContainer.IsRegistered<IEmailSignUpPage>() ? _objectContainer.Resolve<IEmailSignUpPage>() : null;
        private IFetchCodeFromEmail? FetchCodeFromEmail => _objectContainer.IsRegistered<IFetchCodeFromEmail>() ? _objectContainer.Resolve<IFetchCodeFromEmail>() : null;
        private ISignInPage? Signin => _objectContainer.IsRegistered<ISignInPage>() ? _objectContainer.Resolve<ISignInPage>() : null;


        public EmailSignUpSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I click on Create Sign In Details")]
        public void ThenClickOnCreateSignInDetails()
        {
            Signin?.ClickCreateSignInDetailsLink();
        }

        [When(@"I enter an email address with reference '([^']*)' to receive a confirmation code and continue")]
        public async Task GivenIEnterAnEmailAddressWithReferenceToReceiveAConfirmationCodeAndContinue(string emailRef)
        {
            Random rand = new Random();
            int number = rand.Next(0, 100000); //returns random number between 0-99999
            string randomText = number.ToString();

            //string domainName = "team707045.testinator.com";
            string emailText = emailRef + randomText;
            string emailAddress = emailText + "@team707045.testinator.com";

            //Assert.True(EmailSignUpPage.IsPageLoaded, "Enter email address page is not displayed"); 
            EmailSignUpPage?.EnterEmailAddress(emailAddress);
            Thread.Sleep(3000);
            EmailSignUpPage?.ClickContinueButton();

            FetchCodeFromEmail fetchCode = new FetchCodeFromEmail(_scenarioContext);
            string code = await fetchCode.GetCodeFromEmail(emailText);
            lock (_lock)
            {
                _scenarioContext.Add("emailText", emailText);
                _scenarioContext.Add("emailAddress", emailAddress);
                _scenarioContext.Add("confirmationCode", code);                
            }
        }

        [When(@"I enter the Confirmation code")]
        public void WhenIEnterConfirmationCode()
        {
            EmailSignUpPage?.EnterConfirmationCode(_scenarioContext.Get<string>("confirmationCode"));
        }

        [When(@"I Click on Contine Button")]
        [When(@"I click on Confirm and complete registeration")]
        public void WhenIClickONContinue()
        {
            EmailSignUpPage?.ClickContinueButton();
        }
                
        [When(@"I enter full name '(.*)'")]
        public void WhenIEnterFullName(string Name)
        {
            EmailSignUpPage?.EnterFullName(Name);
        }

        [When(@"I enter the Password '(.*)'")]
        public void WhenIEnterThePassword(string Password)
        {
            EmailSignUpPage?.EnterThePassword(Password);
        } 
        
        [Then(@"I Save the GGID")]
        public void ThenISaveTheGGID()
        {
            _scenarioContext.Add("GGID", EmailSignUpPage?.IsGGIDCreated());
            Assert.IsNotEmpty(_scenarioContext.Get<string>("GGID"));
        }

        [When(@"I select a Individual User")]
        public void WhenISelectAIndividualUser()
        {
            EmailSignUpPage?.SelectIndividualUser();
        }
        
        [When(@"I enter the First name '(.*)' and Last name '(.*)'")]
        public void WhenIEnterFirstAndLastName(string firstName, string lastName)
        {
            EmailSignUpPage?.EnterFirstAndLastName(firstName, lastName);
        } 
        
        [When(@"I enter the telephone number '(.*)'")]
        public void WhenIEnterTelephoneNumber(string telephoneNumber)
        {
            EmailSignUpPage?.EnterTelephoneNumber(telephoneNumber);
        }
        
        [When(@"I enter the Postcode '(.*)'")]
        public void WhenIEnterPostcode(string postCode)
        {
            EmailSignUpPage?.EnterPostCode(postCode);
        }
        
        [When(@"I select the address from the dropdown")]
        public void WhenISelectAdddressFromDropdown()
        {
            EmailSignUpPage?.SelectAddress();
        }
        
        [When(@"I enter the memorable word '(.*)' and hint '(.*)'")]
        public void WhenIEnterMemorableWordAndHint(string MemorableWord, String Hint)
        {
            EmailSignUpPage?.EnterMemorableWordAndHint(MemorableWord, Hint);
        }



        
        



    }
}
