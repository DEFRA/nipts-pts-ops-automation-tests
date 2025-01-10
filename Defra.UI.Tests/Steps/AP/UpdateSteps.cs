using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class UpdateSteps
    {
        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;

        private readonly IPetMicrochipPage _petMicrochipPage;
        private readonly IPetMicrochipDatePage _petMicrochipDatePage;
        private readonly IPetSpeciesPage _petsCategoryPage;
        private readonly IPetBreedPage _breedPage;
        private readonly IPetNamePage _petNamePage;
        private readonly IPetSexPage _petSexPage;
        private readonly IPetDOBPage _petsDOBPage;
        private readonly IPetColourPage _petColourPage;
        private readonly ISignificantFeaturesPage _significantFeaturesPage;
        private readonly IPetOwnerNamePage _petOwnerNamePage;
        private readonly IPetOwnerAddressPage _petOwnerAddressPage;
        private readonly IPetOwnerPhoneNumberPage _petOwnerPhoneNumberPage;
        private readonly IApplicationDeclarationPage _applicationDeclarationPage;

        public UpdateSteps(ScenarioContext context, IWebDriver driver, IPetMicrochipPage petMicrochipPage, IPetMicrochipDatePage petMicrochipDatePage, IPetSpeciesPage petSpeciesPage,
            IPetBreedPage petBreedPage, IPetNamePage petNamePage, IPetSexPage petSexPage, IPetDOBPage petDOBPage, IPetColourPage petColourPage, ISignificantFeaturesPage significantFeaturesPage,
            IPetOwnerNamePage petOwnerNamePage, IPetOwnerAddressPage petOwnerAddressPage, IPetOwnerPhoneNumberPage petOwnerPhoneNumberPage, IApplicationDeclarationPage applicationDeclarationPage)
        {
            _scenarioContext = context;
            _driver = driver;
            _petMicrochipPage = petMicrochipPage;
            _petMicrochipDatePage = petMicrochipDatePage;
            _petsCategoryPage = petSpeciesPage;
            _breedPage = petBreedPage;
            _petNamePage = petNamePage;
            _petSexPage = petSexPage;
            _petsDOBPage = petDOBPage;
            _petColourPage = petColourPage;
            _significantFeaturesPage = significantFeaturesPage;
            _petOwnerNamePage = petOwnerNamePage;
            _petOwnerAddressPage = petOwnerAddressPage;
            _petOwnerPhoneNumberPage = petOwnerPhoneNumberPage;
            _applicationDeclarationPage = applicationDeclarationPage;
        }

        [Then(@"I have clicked the change option for the '(.*)' from Microchip information section")]
        public void ThenIHaveClickedChangeOptionForTheFieldFromMicrochipInformationSection(string fieldName)
        {
            _applicationDeclarationPage?.ClickMicrochipChangeLink(fieldName);
        }

        [Then(@"I have modified the microchip number with the value of '(.*)'")]
        public void ThenIHaveModifiedTheMicrochipNumberWithTheValueOf(string updatedMicrochipNumber)
        {
            _petMicrochipPage?.UpdateMicrochipNumber(updatedMicrochipNumber);
            _scenarioContext.Remove("MicrochipNumber");
            _scenarioContext.Add("MicrochipNumber", updatedMicrochipNumber);
        }

        [When(@"I click continue button from microchip number till reaching declaration page")]
        public void WhenIClickContinueButtonFromMicrochipNumberTillDeclarationPage()
        {
            _petMicrochipPage?.ClickContinueButton();
            _petMicrochipDatePage?.ClickContinueButton();
            _petsCategoryPage?.ClickContinueButton();
            ClickContinueButtonBreedPage();
            _petNamePage?.ClickContinueButton();
            _petSexPage?.ClickContinueButton();
            _petsDOBPage?.ClickContinueButton();
            _petColourPage?.ClickContinueButton();
            _significantFeaturesPage?.ClickContinueButton();
        }

        [Then(@"I have modified the microchip scanned date by adding '(.*)' days")]
        public void ThenIHaveModifiedTheMicrochipScannedDateByAddingDays(int daysToAdd)
        {
            var microchippedDateString = _scenarioContext.Get<string>("MicrochippedDate");
            var date = Utils.ConvertToDate(microchippedDateString).AddDays(daysToAdd);
            _scenarioContext.Remove("MicrochippedDate");

            var microchippedDate = _petMicrochipDatePage?.EnterDateMonthYear(date);
            _scenarioContext.Add("MicrochippedDate", microchippedDate);
        }

        [When("I click continue button from microchip scanned date till reaching declaration page")]
        public void WhenIClickContinueButtonFromMicrochipScannedDateTillReachingDeclarationPage()
        {
            _petMicrochipDatePage?.ClickContinueButton();
            _petsCategoryPage?.ClickContinueButton();
            ClickContinueButtonBreedPage();
            _petNamePage?.ClickContinueButton();
            _petSexPage?.ClickContinueButton();
            _petsDOBPage?.ClickContinueButton();
            _petColourPage?.ClickContinueButton();
            _significantFeaturesPage?.ClickContinueButton();
        }

        [When(@"I click on continue button from What is your pet's name page till reaching declaration page")]
        public void WhenIClickOnContinueButtonFromWhatIsYourPetsNamePageTillReachingDeclarationPage()
        {
            _petNamePage?.ClickContinueButton();
            _petSexPage?.ClickContinueButton();
            _petsDOBPage?.ClickContinueButton();
            _petColourPage?.ClickContinueButton();
            _significantFeaturesPage?.ClickContinueButton();
        }

        [Then(@"I have clicked the change option for the '(.*)' from Pet details section")]
        public void ThenIHaveClickedTheChangeOptionForTheFromPetDetailsSection(string fieldName)
        {
            _applicationDeclarationPage?.ClickPetDetailsChangeLink(fieldName);
        }

        [Then(@"I have clicked the change option for Ferret '(.*)' from Pet details section")]
        public void ThenIHaveClickedTheChangeOptionForFerrerFromPetDetailsSection(string fieldName)
        {
            _applicationDeclarationPage?.ClickPetDetailsChangeForFerretLink(fieldName);
        }


        [Then(@"I have modified the pet name as '(.*)'")]
        public void ThenIHaveModifiedThePetNameAs(string petName)
        {
            _scenarioContext.Remove("PetName");
            var petFullName = $"{petName} {Utils.GenerateRandomName()}";
            _petNamePage?.EnterPetsName(petFullName);
            _scenarioContext.Add("PetName", petFullName);
        }

        [Then(@"I have modified the species type as '(.*)'")]
        public void ThenIHaveModifiedTheSpeciesTypeAs(string speciesType)
        {
            _scenarioContext.Remove("PetType");
            _petsCategoryPage?.SelectSpecies(speciesType);
            _scenarioContext.Add("PetType", speciesType);
        }

        [When(@"I click continue button from Is your pet a dog, cat or ferret page till reaching declaration page along with modification of colour '(.*)' and breed (.*)")]
        public void WhenIClickContinueButtonFromIsYourPetADogCatOrFerretPageTillReachingDeclarationPageAlongWithModificationOfColourAndBreed(string color, int breedIndex)
        {
            _petsCategoryPage?.ClickContinueButton();

            _scenarioContext.Remove("Breed");
            var breed = _breedPage?.SelectPetsBreed(breedIndex);
            _scenarioContext.Add("Breed", breed);

            _breedPage?.ClickContinueButton();
            _petNamePage?.ClickContinueButton();
            _petSexPage?.ClickContinueButton();
            _petsDOBPage?.ClickContinueButton();

            _scenarioContext.Remove("Color");
            _petColourPage?.SelectColorOption(color);
            _scenarioContext.Add("Color", color);

            _petColourPage?.ClickContinueButton();
            _significantFeaturesPage?.ClickContinueButton();
        }

        [Then(@"I have modified the pets breed with the index value of '(.*)'")]
        public void ThenIHaveModifiedThePetsBreedWithTheIndexValueOf(int breedIndex)
        {
            _scenarioContext.Remove("Breed");
            var breed = _breedPage?.SelectPetsBreed(breedIndex);
            _scenarioContext.Add("Breed", breed);
        }

        [When(@"I click continue button from What breed is your dog page till reaching declaration page")]
        public void WhenIClickContinueButtonFromWhatBreedIsYourDogPageTillReachingDeclarationPage()
        {
            _breedPage?.ClickContinueButton();
            _petNamePage?.ClickContinueButton();
            _petSexPage?.ClickContinueButton();
            _petsDOBPage?.ClickContinueButton();
            _petColourPage?.ClickContinueButton();
            _significantFeaturesPage?.ClickContinueButton();
            _significantFeaturesPage?.ClickContinueButton();
        }

        [Then(@"I have modified the pets sex as '(.*)'")]
        public void ThenIHaveModifiedThePetSexAs(string sex)
        {
            _scenarioContext.Remove("Sex");
            _petSexPage?.SelectPetsSexOption(sex);
            _scenarioContext.Add("Sex", sex);
        }

        [When(@"I click on continue button from What sex is your pet page till reaching declaration page")]
        public void WhenIClickOnContinueButtonFromWhatSexIsYourPetPageTillReachingDeclarationPage()
        {
            _petSexPage?.ClickContinueButton();
            _petsDOBPage?.ClickContinueButton();
            _petColourPage?.ClickContinueButton();
            _significantFeaturesPage?.ClickContinueButton();
        }

        [Then(@"I have modified the pets date of birth by adding '(.*)' days")]
        public void ThenIHaveModifiedThePetsDateOfBirthByAddingDays(int daysToAdd)
        {
            var dateOfBirth = _scenarioContext.Get<string>("DateOfBirth");
            var date = Utils.ConvertToDate(dateOfBirth).AddDays(daysToAdd);
            _scenarioContext.Remove("DateOfBirth");

            var dateOfBirthDate = _petsDOBPage?.EnterDateMonthYear(date);
            _scenarioContext.Add("DateOfBirth", dateOfBirthDate);
        }

        [When("I click on continue button from What is your pet's date of birth page till reaching declaration page")]
        public void WhenIClickContinueButtonFromWhatIsYourPetsDateOfBirthPageTillReachingDeclarationPage()
        {
            _petsDOBPage?.ClickContinueButton();
            _petColourPage?.ClickContinueButton();
            _significantFeaturesPage?.ClickContinueButton();
        }

        [Then(@"I have modified the pets colour as '(.*)'")]
        public void ThenIHaveModifiedThePetsColourAs(string color)
        {
            _scenarioContext.Remove("Color");
            _petColourPage?.SelectColorOption(color);
            _scenarioContext.Add("Color", color);
        }

        [When("I click on continue button from What is the main colour of your pet page till reaching declaration page")]
        public void WhenIClickContinueButtonFromWhatIsTheMainColorOfYourPetPageTillReachingDeclarationPage()
        {
            _petColourPage?.ClickContinueButton();
            _significantFeaturesPage?.ClickContinueButton();
        }

        [Then(@"I have modified the pets significant feature as '(.*)'")]
        public void ThenIHaveModifiedTheSignificantFeaturesAs(string hasUniqueFeatures)
        {
            _scenarioContext.Remove("SignificantFeatures");
            var significantFeature = _significantFeaturesPage?.SelectSignificantFeaturesOption(hasUniqueFeatures);
            _scenarioContext.Add("SignificantFeatures", significantFeature);
        }

        [Then(@"I have clicked the change option for the '(.*)' from Pet owner details section")]
        public void ThenIHaveClickedTheChangeOptionForTheFromPetOwnerDetailsSection(string fieldName)
        {
            _applicationDeclarationPage?.ClickPetOwnerChangeLink(fieldName);
        }

        [Then(@"I have modified the pet owner name with the value of '(.*)'")]
        public void ThenIHaveModifiedThePetOwnerNameWithTheValueOf(string petOwnerName)
        {
            _scenarioContext.Remove("FullName");
            _petOwnerNamePage?.EnterPetOwnerName(petOwnerName);
            _scenarioContext.Add("FullName", petOwnerName);
        }

        [When(@"I click continue button from pet owner name page till reaching declaration page")]
        public void WhenIClickContinueButtonFromPetOwnerNamePageTillDeclarationPage()
        {
            _petOwnerNamePage?.ClickContinueButton();
        }

        [Then(@"I have modified the pet owner phone number with the value of '(.*)'")]
        public void ThenIHaveModifiedThePetOwnerPhoneNumberWithTheValueOf(string phoneNumber)
        {
            _scenarioContext.Remove("PhoneNumber");
            _petOwnerPhoneNumberPage?.EnterPetOwnerPNumber(phoneNumber);
            _scenarioContext.Add("PhoneNumber", phoneNumber);
        }

        [When(@"I click continue button from postcode search page till reaching declaration page")]
        public void WhenIClickContinueButtonFromPostCodeSearchPageTillDeclarationPage()
        {
            _petOwnerAddressPage?.ClickContinueButton();

            var phoneNumber = _scenarioContext.Get<string>("PhoneNumber");
            _petOwnerPhoneNumberPage?.EnterPetOwnerPNumber(phoneNumber);
            _petOwnerPhoneNumberPage?.ClickContinueButton();
            _petMicrochipPage?.ClickContinueButton();
            _petMicrochipDatePage?.ClickContinueButton();
            _petsCategoryPage?.ClickContinueButton();
            ClickContinueButtonBreedPage();
            _petNamePage?.ClickContinueButton();
            _petSexPage?.ClickContinueButton();
            _petsDOBPage?.ClickContinueButton();
            _petColourPage?.ClickContinueButton();
            _significantFeaturesPage?.ClickContinueButton();
        }

        [Then(@"I have modified the pet owner postcode and address with the value of '(.*)' and phone number '(.*)'")]
        public void ThenIHaveModifiedThePetOwnerPostcodeWithAddressWithTheValueOf(string postCode, string phoneNumber)
        {
            _scenarioContext.Remove("Postcode");
            _scenarioContext.Remove("Address");
            _petOwnerAddressPage?.EnterPostCode(postCode);
            _scenarioContext.Add("Postcode", postCode);

            if (_scenarioContext.ContainsKey("PhoneNumber"))
            {
                _scenarioContext.Remove("PhoneNumber");
            }

            _scenarioContext.Add("PhoneNumber", phoneNumber);
        }

        [When(@"I click continue button from What is your phone number page till reaching declaration page")]
        public void WhenIClickContinueButtonFromWhatIsYourPhoneNumberPageTillReachingDeclarationPage()
        {
            _petOwnerPhoneNumberPage?.ClickContinueButton();
            _petMicrochipPage?.ClickContinueButton();
            _petMicrochipDatePage?.ClickContinueButton();
            _petsCategoryPage?.ClickContinueButton();
            ClickContinueButtonBreedPage();
            _petNamePage?.ClickContinueButton();
            _petSexPage?.ClickContinueButton();
            _petsDOBPage?.ClickContinueButton();
            _petColourPage?.ClickContinueButton();
            _significantFeaturesPage?.ClickContinueButton();
        }

        private void ClickContinueButtonBreedPage()
        {
            var petsSelected = _scenarioContext.Get<string>("PetType");

            if (!petsSelected.ToUpper().Equals("FERRET"))
            {
                _breedPage?.ClickContinueButton();
            }
        }
    }
}
