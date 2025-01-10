using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class PetOwnerDetailsSteps
    {
        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly IApplicationSubmissionPage _applicationSubmissionPage;
        private readonly IPetOwnerNamePage _petOwnerNamePage;
        private readonly IPetOwnerAddressPage _petOwnerAddressPage;
        private readonly IPetOwnerPhoneNumberPage _petOwnerPhoneNumberPage;

        public PetOwnerDetailsSteps(ScenarioContext context, IWebDriver driver, IApplicationSubmissionPage applicationSubmissionPage, IPetOwnerNamePage petOwnerNamePage, 
            IPetOwnerAddressPage petOwnerAddressPage, IPetOwnerPhoneNumberPage petOwnerPhoneNumberPage )
        {
            _scenarioContext = context;
            _driver = driver;
            _applicationSubmissionPage = applicationSubmissionPage;
            _petOwnerNamePage = petOwnerNamePage;
            _petOwnerAddressPage = petOwnerAddressPage;
            _petOwnerPhoneNumberPage = petOwnerPhoneNumberPage;
        }

        [Then(@"I should redirected to the What is your full name page")]
        public void ThenIShouldRedirectedToTheWhatIsYourFullNamePage()
        {
            Assert.True(_petOwnerNamePage?.IsNextPageLoaded("What is your full name?"), "Application page not loaded");
        }

        [Then(@"I provided the full name of the pet keeper as '(.*)'")]
        public void ThenIProvidedTheFullNameOfThePetKeeperAs(string fullName)
        {
            _petOwnerNamePage?.EnterPetOwnerName(fullName);
            _scenarioContext.Add("FullName", fullName);
        }

        [When(@"I click Continue button from What is your full name page")]
        public void WhenIClickContinueButtonFromWhatIsYourFullNamePage()
        {
            _petOwnerNamePage?.ClickContinueButton();
        }

        [Then(@"I should redirected to What is your postcode page")]
        public void ThenIShouldRedirectedToWhatIsYourPostcodePage()
        {
            Assert.True(_petOwnerAddressPage?.IsNextPageLoaded("What is your postcode?"), "Application page not loaded");
        }

        [Then(@"I should redirected to What is the pet keeper's postcode?")]
        public void ThenIShouldRedirectedToWhatIsThePetKeepersPostcode()
        {
            Assert.True(_petOwnerAddressPage?.IsNextPageLoaded("What is the pet keeper's postcode?"), "Application page not loaded");
        }

        [When(@"I click Continue button from What is the pet keeper's postcode?")]
        public void WhenIClickContinueButtonFromWhatIsThePetKeepersPostcode()
        {
            _petOwnerAddressPage?.ClickContinueButton();
        }

        [Then(@"I provided the postcode '([^']*)'")]
        public void ThenIProvidedThePostcode(string postCode)
        {
            _petOwnerAddressPage?.EnterPostCode(postCode);
            _scenarioContext.Add("Postcode", postCode);
        }

        [When(@"I click Search button")]
        public void WhenIClickSearchButton()
        {
            _petOwnerAddressPage?.ClickSearchButton();
        }

        [Then(@"I should see a list of address in dropdownlist")]
        public void ThenIShouldSeeAListOfAddressInDropdownlist()
        {
            Assert.True(_petOwnerAddressPage?.IsAddressListFound());
        }

        [Then(@"I select the index (.*) from address list")]
        public void ThenISelectTheIndexFromAddressList(int addressIndex)
        {
            var addressLines = _petOwnerAddressPage?.SelectAnAddress(addressIndex);
            _scenarioContext.Add("Address", addressLines);
        }

        [When(@"I click Continue button from What is your postcode page")]
        public void WhenIClickContinueButtonFromWhatIsYourPostcodePage()
        {
            _petOwnerAddressPage?.ClickContinueButton();
        }

        [When(@"I click Find Address button from What is your postcode page")]
        public void WhenIClickFindAddressButtonFromWhatIsYourPostcodePage()
        {
            _petOwnerAddressPage?.ClickSearchButton();
        }

        [When(@"I click the link Enter the address manually")]
        public void WhenIClickTheLinkEnterTheAddressManually()
        {
            _petOwnerAddressPage?.ClickICannotFindTheAddressInTheListLink();
        }

        [When(@"I provided address details with postcode '([^']*)'")]
        public void WhenIProvidedAddressDetailsWithPostcode(string postCode)
        {
            _petOwnerAddressPage?.EnterAddressManually("5 AddressLine1", string.Empty, "Coventry", string.Empty, postCode);

            var addressLines = new string[] { "5 AddressLine1", "Coventry", "Coventry", postCode };
            _scenarioContext.Add("Address", addressLines);
        }

        [Then(@"I should redirected to What is your phone number page")]
        public void ThenIShouldRedirectedToWhatIsYourPhoneNumberPage()
        {
            Assert.True(_petOwnerPhoneNumberPage?.IsNextPageLoaded("What is your phone number?"), "Application page not loaded");
        }

        [Then(@"I provided the phone number '([^']*)'")]
        public void ThenIProvidedThePhoneNumber(string phoneNumber)
        {
            _petOwnerPhoneNumberPage?.EnterPetOwnerPNumber(phoneNumber);
            _scenarioContext.Add("PhoneNumber", phoneNumber);
        }

        [When(@"I click Continue button from What is your phone number page")]
        public void WhenIClickContinueButtonFromWhatIsYourPhoneNumberPage()
        {
            _petOwnerPhoneNumberPage?.ClickContinueButton();
        }

        [Then(@"I should redirected to the Application submitted page")]
        public void ThenIShouldRedirectedToTheApplicationSubmittedPage()
        {
            var pageTitle = "Application submitted";
            Assert.IsTrue(_applicationSubmissionPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I can see the unique application reference number")]
        public void ThenICanSeeTheSignificantApplicationReferenceNumber()
        {
            var applicationReferenceNumber = _applicationSubmissionPage?.GetApplicationReferenceNumber();

            _scenarioContext.Add("ReferenceNumber", applicationReferenceNumber);

            var windowHandles = _driver.WindowHandles.ToList();

            _scenarioContext.Add("WindowHandle", windowHandles[0].ToString());

            Assert.IsTrue(!string.IsNullOrEmpty(applicationReferenceNumber), "There is an issue with application submission");
        }

        [When(@"I have clicked the View all your lifelong pet travel documents link")]
        public void WhenIHaveClickedTheViewAllYourLifelongPetTravelDocumentsLink()
        {
            _applicationSubmissionPage?.ClickViewAllSubmittedPetTravelDocument();
        }

        [When(@"I click Apply for another lifelong pet travel document link")]
        public void ThenIClickApplyForAnotherLifelongPetTravelDocumentLink()
        {
            _applicationSubmissionPage?.ClickApplyForAnotherPetTravelDocument();
        }

    }
}