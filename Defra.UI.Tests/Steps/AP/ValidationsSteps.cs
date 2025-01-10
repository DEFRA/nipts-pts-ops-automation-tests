
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class ValidationsSteps
    {
        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;

        private readonly IPetMicrochipPage _petMicrochipPage;
        private readonly IPetMicrochipDatePage _petMicrochipDatePage;
        private readonly IPetSpeciesPage _petSpeciesPage;
        private readonly IPetBreedPage _breedPage;
        private readonly IPetNamePage _petNamePage;
        private readonly IPetSexPage _petSexPage;
        private readonly IPetDOBPage _petsDOBPage;
        private readonly IPetColourPage _petColourPage;
        private readonly ISignificantFeaturesPage _significantFeaturesPage;
        private readonly IPetOwnerNamePage _petOwnerNamePage;
        private readonly IPetOwnerAddressPage _petOwnerAddressPage;
        private readonly IPetOwnerPhoneNumberPage _petOwnerPhoneNumberPage;

        public ValidationsSteps(ScenarioContext context, IWebDriver driver, IPetMicrochipPage petMicrochipPage, IPetMicrochipDatePage petMicrochipDatePage, IPetSpeciesPage petSpeciesPage,
            IPetBreedPage petBreedPage, IPetNamePage petNamePage, IPetSexPage petSexPage, IPetDOBPage petDOBPage, IPetColourPage petColourPage, ISignificantFeaturesPage significantFeaturesPage,
            IPetOwnerNamePage petOwnerNamePage, IPetOwnerAddressPage petOwnerAddressPage, IPetOwnerPhoneNumberPage petOwnerPhoneNumberPage)
        {
            _scenarioContext = context;
            _driver = driver;
            _petMicrochipPage = petMicrochipPage;
            _petMicrochipDatePage = petMicrochipDatePage;
            _petSpeciesPage = petSpeciesPage;
            _breedPage = petBreedPage;
            _petNamePage = petNamePage;
            _petSexPage = petSexPage;
            _petsDOBPage = petDOBPage;
            _petColourPage = petColourPage;
            _significantFeaturesPage = significantFeaturesPage;
            _petOwnerNamePage = petOwnerNamePage;
            _petOwnerAddressPage = petOwnerAddressPage;
            _petOwnerPhoneNumberPage = petOwnerPhoneNumberPage;
        }

        [Then(@"I have provided future date of birth from microchip scanned date")]
        public void ThenIHaveProvidedFutureDateOfBirthFromMicrochipScannedDate()
        {
            var microchippedDate = _scenarioContext.Get<string>("MicrochippedDate");
            _petsDOBPage?.EnterDateMonthYear(Utils.ConvertToDate(microchippedDate).AddDays(1));
        }

        [Then(@"I should not be redirected to the What is the main colour of your '([^']*)' page")]
        public void ThenIShouldNotBeRedirectedToTheWhatIsTheMainColourOfYourPage(string petCategory)
        {
            var pageTitle = $"What is your pet's date of birth?";
            Assert.IsTrue(_petsDOBPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I should see an error message ""(.*)"" in pets date of birth page")]
        public void ThenIShouldSeeAnErrorMessageInPetsDateOfBirthPage(string errorMessage)
        {
            Assert.True(_petsDOBPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
        }

        [Then(@"I should see an error message ""(.*)"" in Is your pet microchipped page")]
        public void ThenIShouldSeeAnErrorMessageInPetsMicrochippedPage(string errorMessage)
        {
            Assert.True(_petMicrochipPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
        }

        [Then(@"I should not be redirected to When was your pet microchipped or last scanned? page")]
        public void ThenIShouldNotBeRedirectedToWhenWasYourPetMicrochippedOrLastScannedPage()
        {
            var pageTitle = $"Is your pet microchipped";
            Assert.IsTrue(_petMicrochipPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have provided future date of PETS microchipped")]
        public void ThenIHaveProvidedFutureDateOfPETSMicrochipped()
        {
            _petMicrochipDatePage?.EnterDateMonthYear(DateTime.Now.AddDays(10));
        }

        [Then(@"I should not be redirected to Is your pet a dog, cat or ferret? page")]
        public void ThenIShouldNotBeRedirectedToIsYourPetADogCatOrFerretPage()
        {
            var pageTitle = $"When was your pet microchipped or last scanned?";
            Assert.IsTrue(_petMicrochipDatePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I should see an error message ""(.*)"" in pets microchipped or last scanned page")]
        public void ThenIShouldSeeAnErrorMessageInPetMicrochippedOrLastScannedPage(string errorMessage)
        {
            Assert.True(_petMicrochipDatePage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
        }

        [Then(@"I have provided older than expected date of PETS microchipped")]
        public void ThenIHaveProvidedOlderThanExpectedDateMicrochipped()
        {
            _petMicrochipDatePage?.EnterDateMonthYear(new DateTime(1989, 1, 1));
        }

        [Then(@"I have provided older than expected date of PETS date of birth")]
        public void ThenIHaveProvidedOlderThanExpectedDateOfPetsDateOfBirth()
        {
            _petsDOBPage?.EnterDateMonthYear(new DateTime(1989, 1, 1));
        }

        [Then(@"I should not be redirected to What is the main colour of your '(.*)' page")]
        public void ThenIShouldNotBeRedirectedToWhatIsTheMainColourOfYourPage(string petType)
        {
            var pageTitle = "What is your pet's date of birth?";
            Assert.IsTrue(_petsDOBPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have provided future date of PETS date of birth")]
        public void ThenIHaveProvidedFutureDateOfPETSDateOfBirth()
        {
            _petsDOBPage?.EnterDateMonthYear(DateTime.Now.AddDays(10));
        }

        [Then(@"I should not be redirected to What is your postcode page")]
        public void ThenIShouldNotBeRedirectedToWhatIsYourPostcodePage()
        {
            var pageTitle = "What is your full name?";
            Assert.IsTrue(_petOwnerNamePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I should see an error message '(.*)' in What is your full name page")]
        public void ThenIShouldSeeAnErrorMessageInWhatIsYourFullNamePage(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                Assert.True(_petOwnerNamePage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
            }
        }

        [Then(@"I should see an error message ""(.*)"" in Is your pet a dog, cat or ferret page")]
        public void ThenIShouldSeeAnErrorMessageInIsYourPetADogCatOrFerretPage(string errorMessage)
        {
            Assert.True(_petSpeciesPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
        }

        [Then(@"I should not be redirected to What breed is your '(.*)' page")]
        public void ThenIShouldNotBeRedirectedToWhatBreedIsYourPage(string petType)
        {
            var pageTitle = "Is your pet a dog, cat or ferret?";
            Assert.IsTrue(_petSpeciesPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I should see an error message '(.*)' in What is your pets name page")]
        public void ThenIShouldSeeAnErrorMessageSNamePage(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                Assert.True(_petNamePage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
            }
        }

        [Then(@"I should not be redirected to What sex is your pet page")]
        public void ThenIShouldNotBeRedirectedToWhatSexIsYourPetPage()
        {
            var pageTitle = "What is your pet's name?";
            Assert.IsTrue(_petNamePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I provided the invalid Pets name as '(.*)'")]
        public void ThenIProvidedThePetsNameAs(string petName)
        {
            _petNamePage?.EnterPetsName(petName);
        }

        [Then(@"I should see an error message ""(.*)"" in What sex is your pet page")]
        public void ThenIShouldSeeAnErrorMessageInWhatSexIsYourPetPage(string errorMessage)
        {
            Assert.True(_petSexPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
        }

        [Then(@"I should not redirected to the Do you know your pet's date of birth page")]
        public void ThenIShouldNotRedirectedToTheDoYouKnowYourPetsDateOfBirthPage()
        {
            var pageTitle = "What sex is your pet?";
            Assert.IsTrue(_petSexPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I should see an error message '(.*)' in microchipped page")]
        public void ThenIShouldSeeAnErrorMessageInMicrochippedPage(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                Assert.True(_petMicrochipPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
            }
        }

        [Then(@"I should see an error message '(.*)' in What is your phone number page")]
        public void ThenIShouldSeeAnErrorMessageInWhatIsYourPhoneNumberPage(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                Assert.True(_petOwnerPhoneNumberPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
            }
        }

        [Then(@"I should not be redirected to the Is your pet microchipped page")]
        public void ThenIShouldNotBeRedirectedToTheIsYourPetMicrochippedPage()
        {
            var pageTitle = "What is your phone number?";
            Assert.IsTrue(_petOwnerPhoneNumberPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have provided other colour value as '(.*)'")]
        public void ThenIHaveProvidedOtherColourValueAs(string otherColor)
        {
            _petColourPage?.SelectOtherColorOption(otherColor);
        }

        [Then(@"I should not be redirected to the Does your pet have any significant features page")]
        public void ThenIShouldNotBeRedirectedToTheDoesYourPetHaveAnySignificantFeaturesPage()
        {
            var pageTitle = $"What is the main colour of your";
            Assert.IsTrue(_petColourPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I should see an error message '(.*)' in What is the main colour of your pet page")]
        public void ThenIShouldSeeAnErrorMessageInWhatIsTheMainColourOfYourPetPage(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                Assert.True(_petColourPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
            }
        }

        [Then(@"I should see an error message '(.*)' in Does your pet have any significant features page")]
        public void ThenIShouldSeeAnErrorMessageInDoesYourPetHaveAnySignificantFeaturesPage(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                Assert.True(_significantFeaturesPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
            }
        }

        [Then(@"I should not be redirected to the Check your answers and sign the declaration page")]
        public void ThenIShouldNotBeRedirectedToTheCheckYourAnswersAndSignTheDeclarationPage()
        {
            var pageTitle = $"Does your pet have any significant features?";
            Assert.IsTrue(_significantFeaturesPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have provided significant features as '(.*)'")]
        public void ThenIHaveProvidedSignificantFeaturesValueAs(string significantFeatures)
        {
            _significantFeaturesPage?.EnterSignificantFeatures(significantFeatures);
        }

        [Then(@"I have provided breed value as '(.*)' in breed dropdownlist")]
        public void ThenIHaveProvidedBreedValueAsInBreedDropdownlist(string breed)
        {
            _breedPage?.EnterFreeTextBreed(breed);
        }

        [Then(@"I should see an error message '(.*)' in What breed is your pet page")]
        public void ThenIShouldSeeAnErrorMessageInWhatBreedIsYourDogPage(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                Assert.True(_breedPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
            }
        }

        [Then(@"I should not be redirected to the What is your pet's name page")]
        public void ThenIShouldNotBeRedirectedToTheWhatIsYourPetsNamePage()
        {
            var pageTitle = $"What breed is your dog?";
            Assert.IsTrue(_breedPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I should see an error message '(.*)' in What is your postcode page")]
        public void ThenIShouldSeeAnErrorMessageInWhatIsYourPostcodePage(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                Assert.True(_petOwnerAddressPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
            }
        }

        [Then(@"I have provided address details as '(.*)' for each field")]
        public void ThenIShouldSeeAnErrorMessageInWhatIsYourAddressDetaislPage(string address)
        {
            _petOwnerAddressPage?.EnterAddressManually(address, address, address, address, address);
        }

        [When(@"I click Continue button from What is your address page")]
        public void WhenIClickContinueButtonFromWhatIsYourAddressPage()
        {
            _petOwnerAddressPage?.ClickContinueButton();
        }

        [Then(@"I should see an error message '(.*)' in What is your address page")]
        public void ThenIShouldSeeAnErrorMessageInWhatIsYourAddressPage(string errorMessage)
        {
            var errorMessages = errorMessage.Split(',');
            foreach (var error in errorMessages)
            {
                Assert.True(_petOwnerAddressPage?.IsError(error), $"There is no error message found with - {error}");
            }
        }
    }
}
