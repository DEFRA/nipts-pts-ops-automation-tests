using Reqnroll.BoDi;
using Defra.UI.Tests.Pages.WELSH.Interfaces;
using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class PetOwnerDetailsWelshSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IApplicationSubmissionPageWelsh? applicationSubmissionPageWelsh => _objectContainer.IsRegistered<IApplicationSubmissionPageWelsh>() ? _objectContainer.Resolve<IApplicationSubmissionPageWelsh>() : null;
        private IPetOwnerNamePageWelsh? petOwnerNamePage => _objectContainer.IsRegistered<IPetOwnerNamePageWelsh>() ? _objectContainer.Resolve<IPetOwnerNamePageWelsh>() : null;
        private IPetOwnerAddressPage? petOwnerAddressPage => _objectContainer.IsRegistered<IPetOwnerAddressPage>() ? _objectContainer.Resolve<IPetOwnerAddressPage>() : null;
        private IPetOwnerPhoneNumberPage? petOwnerPhoneNumberPage => _objectContainer.IsRegistered<IPetOwnerPhoneNumberPage>() ? _objectContainer.Resolve<IPetOwnerPhoneNumberPage>() : null;

        public PetOwnerDetailsWelshSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I should redirected to the What is your full name page in Welsh")]
        public void ThenIShouldRedirectedToTheWhatIsYourFullNamePage()
        {
            Assert.True(petOwnerNamePage?.IsNextPageLoaded("What is your full name?"), "Application page not loaded");
        }

        [Then(@"I provided the full name of the pet keeper as '(.*)' in Welsh")]
        public void ThenIProvidedTheFullNameOfThePetKeeperAs(string fullName)
        {
            petOwnerNamePage?.EnterPetOwnerName(fullName);
            _scenarioContext.Add("FullName", fullName);
        }

        [When(@"I click Continue button from What is your full name page in Welsh")]
        public void WhenIClickContinueButtonFromWhatIsYourFullNamePage()
        {
            petOwnerNamePage?.ClickContinueButton();
        }

        [Then(@"I should redirected to What is your postcode page in Welsh")]
        public void ThenIShouldRedirectedToWhatIsYourPostcodePage()
        {
            Assert.True(petOwnerAddressPage?.IsNextPageLoaded("What is your postcode?"), "Application page not loaded");
        }

        [Then(@"I should redirected to What is the pet keeper's postcode? in Welsh")]
        public void ThenIShouldRedirectedToWhatIsThePetKeepersPostcode()
        {
            Assert.True(petOwnerAddressPage?.IsNextPageLoaded("What is the pet keeper's postcode?"), "Application page not loaded");
        }

        [When(@"I click Continue button from What is the pet keeper's postcode? in Welsh")]
        public void WhenIClickContinueButtonFromWhatIsThePetKeepersPostcode()
        {
            petOwnerAddressPage?.ClickContinueButton();
        }

        [Then(@"I provided the postcode '([^']*)' in Welsh")]
        public void ThenIProvidedThePostcode(string postCode)
        {
            petOwnerAddressPage?.EnterPostCode(postCode);
            _scenarioContext.Add("Postcode", postCode);
        }

        [When(@"I click Search button in Welsh")]
        public void WhenIClickSearchButton()
        {
            petOwnerAddressPage?.ClickSearchButton();
        }

        [Then(@"I should see a list of address in dropdownlist in Welsh")]
        public void ThenIShouldSeeAListOfAddressInDropdownlist()
        {
            Assert.True(petOwnerAddressPage?.IsAddressListFound());
        }

        [Then(@"I select the index (.*) from address list in Welsh")]
        public void ThenISelectTheIndexFromAddressList(int addressIndex)
        {
            var addressLines = petOwnerAddressPage?.SelectAnAddress(addressIndex);
            _scenarioContext.Add("Address", addressLines);
        }

        [When(@"I click Continue button from What is your postcode page in Welsh")]
        public void WhenIClickContinueButtonFromWhatIsYourPostcodePage()
        {
            petOwnerAddressPage?.ClickContinueButton();
        }

        [When(@"I click Find Address button from What is your postcode page in Welsh")]
        public void WhenIClickFindAddressButtonFromWhatIsYourPostcodePage()
        {
            petOwnerAddressPage?.ClickSearchButton();
        }

        [When(@"I click the link Enter the address manually in Welsh")]
        public void WhenIClickTheLinkEnterTheAddressManually()
        {
            petOwnerAddressPage?.ClickICannotFindTheAddressInTheListLink();
        }

        [When(@"I provided address details with postcode '([^']*)' in Welsh")]
        public void WhenIProvidedAddressDetailsWithPostcode(string postCode)
        {
            petOwnerAddressPage?.EnterAddressManually("5 AddressLine1", string.Empty, "Coventry", string.Empty, postCode);

            var addressLines = new string[] { "5 AddressLine1", "Coventry", "Coventry", postCode };
            _scenarioContext.Add("Address", addressLines);
        }

        [Then(@"I should redirected to What is your phone number page in Welsh")]
        public void ThenIShouldRedirectedToWhatIsYourPhoneNumberPage()
        {
            Assert.True(petOwnerPhoneNumberPage?.IsNextPageLoaded("What is your phone number?"), "Application page not loaded");
        }

        [Then(@"I provided the phone number '([^']*)' in Welsh")]
        public void ThenIProvidedThePhoneNumber(string phoneNumber)
        {
            petOwnerPhoneNumberPage?.EnterPetOwnerPNumber(phoneNumber);
            _scenarioContext.Add("PhoneNumber", phoneNumber);
        }

        [When(@"I click Continue button from What is your phone number page in Welsh")]
        public void WhenIClickContinueButtonFromWhatIsYourPhoneNumberPage()
        {
            petOwnerPhoneNumberPage?.ClickContinueButton();
        }

        [Then(@"I should redirected to the Application submitted page in Welsh")]
        public void ThenIShouldRedirectedToTheApplicationSubmittedPageInWelsh()
        {
            var pageTitle = "Cais wedi’i gyflwyno";
            Assert.IsTrue(applicationSubmissionPageWelsh?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I have clicked the View all your lifelong pet travel documents link")]
        public void WhenIHaveClickedTheViewAllYourLifelongPetTravelDocumentsLink()
        {
            applicationSubmissionPageWelsh?.ClickViewAllSubmittedPetTravelDocument();
        }

        [When(@"I click Apply for another lifelong pet travel document link in Welsh")]
        public void ThenIClickApplyForAnotherLifelongPetTravelDocumentLink()
        {
            applicationSubmissionPageWelsh?.ClickApplyForAnotherPetTravelDocument();
        }

    }
}