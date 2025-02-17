using Reqnroll.BoDi;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class UpdateSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IPetMicrochipPage? petMicrochipPage => _objectContainer.IsRegistered<IPetMicrochipPage>() ? _objectContainer.Resolve<IPetMicrochipPage>() : null;
        private IPetMicrochipDatePage? petMicrochipDatePage => _objectContainer.IsRegistered<IPetMicrochipDatePage>() ? _objectContainer.Resolve<IPetMicrochipDatePage>() : null;
        private IPetSpeciesPage? petsCategoryPage => _objectContainer.IsRegistered<IPetSpeciesPage>() ? _objectContainer.Resolve<IPetSpeciesPage>() : null;
        private IPetBreedPage? breedPage => _objectContainer.IsRegistered<IPetBreedPage>() ? _objectContainer.Resolve<IPetBreedPage>() : null;
        private IPetNamePage? petNamePage => _objectContainer.IsRegistered<IPetNamePage>() ? _objectContainer.Resolve<IPetNamePage>() : null;
        private IPetSexPage? petSexPage => _objectContainer.IsRegistered<IPetSexPage>() ? _objectContainer.Resolve<IPetSexPage>() : null;
        private IPetDOBPage? petsDOBPage => _objectContainer.IsRegistered<IPetDOBPage>() ? _objectContainer.Resolve<IPetDOBPage>() : null;
        private IPetColourPage? petColourPage => _objectContainer.IsRegistered<IPetColourPage>() ? _objectContainer.Resolve<IPetColourPage>() : null;
        private ISignificantFeaturesPage? significantFeaturesPage => _objectContainer.IsRegistered<ISignificantFeaturesPage>() ? _objectContainer.Resolve<ISignificantFeaturesPage>() : null;
        private IPetOwnerNamePage? petOwnerNamePage => _objectContainer.IsRegistered<IPetOwnerNamePage>() ? _objectContainer.Resolve<IPetOwnerNamePage>() : null;
        private IPetOwnerAddressPage? petOwnerAddressPage => _objectContainer.IsRegistered<IPetOwnerAddressPage>() ? _objectContainer.Resolve<IPetOwnerAddressPage>() : null;
        private IPetOwnerPhoneNumberPage? petOwnerPhoneNumberPage => _objectContainer.IsRegistered<IPetOwnerPhoneNumberPage>() ? _objectContainer.Resolve<IPetOwnerPhoneNumberPage>() : null;
        private IApplicationDeclarationPage? declarationPage => _objectContainer.IsRegistered<IApplicationDeclarationPage>() ? _objectContainer.Resolve<IApplicationDeclarationPage>() : null;

        public UpdateSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I have clicked the change option for the '(.*)' from Microchip information section")]
        public void ThenIHaveClickedChangeOptionForTheFieldFromMicrochipInformationSection(string fieldName)
        {
            declarationPage?.ClickMicrochipChangeLink(fieldName);
        }

        [Then(@"I have modified the microchip number with the value of '(.*)'")]
        public void ThenIHaveModifiedTheMicrochipNumberWithTheValueOf(string updatedMicrochipNumber)
        {
            petMicrochipPage?.UpdateMicrochipNumber(updatedMicrochipNumber);
            _scenarioContext.Remove("MicrochipNumber");
            _scenarioContext.Add("MicrochipNumber", updatedMicrochipNumber);
        }

        [Then(@"I have modified the microchip scanned date by adding '(.*)' days")]
        public void ThenIHaveModifiedTheMicrochipScannedDateByAddingDays(int daysToAdd)
        {
            var microchippedDateString = _scenarioContext.Get<string>("MicrochippedDate");
            var date = Utils.ConvertToDate(microchippedDateString).AddDays(daysToAdd);
            _scenarioContext.Remove("MicrochippedDate");

            var microchippedDate = petMicrochipDatePage?.EnterDateMonthYear(date);
            _scenarioContext.Add("MicrochippedDate", microchippedDate);
        }

        [Then(@"I have clicked the change option for the '(.*)' from Pet details section")]
        public void ThenIHaveClickedTheChangeOptionForTheFromPetDetailsSection(string fieldName)
        {
            declarationPage?.ClickPetDetailsChangeLink(fieldName);
        }

        [Then(@"I have clicked the change option for Ferret '(.*)' from Pet details section")]
        public void ThenIHaveClickedTheChangeOptionForFerrerFromPetDetailsSection(string fieldName)
        {
            declarationPage?.ClickPetDetailsChangeForFerretLink(fieldName);
        }


        [Then(@"I have modified the pet name as '(.*)'")]
        public void ThenIHaveModifiedThePetNameAs(string petName)
        {
            _scenarioContext.Remove("PetName");
            var petFullName = $"{petName} {Utils.GenerateRandomName()}";
            petNamePage?.EnterPetsName(petFullName);
            _scenarioContext.Add("PetName", petFullName);
        }

        [Then(@"I have modified the species type as '(.*)'")]
        public void ThenIHaveModifiedTheSpeciesTypeAs(string speciesType)
        {
            _scenarioContext.Remove("PetType");
            petsCategoryPage?.SelectSpecies(speciesType);
            _scenarioContext.Add("PetType", speciesType);
        }

        [When(@"I click continue button from Is your pet a dog, cat or ferret page till reaching declaration page along with modification of colour '(.*)' and breed (.*)")]
        public void WhenIClickContinueButtonFromIsYourPetADogCatOrFerretPageTillReachingDeclarationPageAlongWithModificationOfColourAndBreed(string color, int breedIndex)
        {
            petsCategoryPage?.ClickContinueButton();

            _scenarioContext.Remove("Breed");
            var breed = breedPage?.SelectPetsBreed(breedIndex);
            _scenarioContext.Add("Breed", breed);

            breedPage?.ClickContinueButton();
            
            _scenarioContext.Remove("Color");
            petColourPage?.SelectColorOption(color);
            _scenarioContext.Add("Color", color);

            petColourPage?.ClickContinueButton();
        }

        [Then("I have modified the pets breed with the index value of {string}")]
        public void ThenIHaveModifiedThePetsBreedWithTheIndexValueOf(int breedIndex)
        {
            _scenarioContext.Remove("Breed");
            var breed = breedPage?.SelectPetsBreed(breedIndex,true);
            _scenarioContext.Add("Breed", breed);
        }

        [Then(@"I have modified the pets sex as '(.*)'")]
        public void ThenIHaveModifiedThePetSexAs(string sex)
        {
            _scenarioContext.Remove("Sex");
            petSexPage?.SelectPetsSexOption(sex);
            _scenarioContext.Add("Sex", sex);
        }

        [Then(@"I have modified the pets date of birth by adding '(.*)' days")]
        public void ThenIHaveModifiedThePetsDateOfBirthByAddingDays(int daysToAdd)
        {
            var dateOfBirth = _scenarioContext.Get<string>("DateOfBirth");
            var date = Utils.ConvertToDate(dateOfBirth).AddDays(daysToAdd);
            _scenarioContext.Remove("DateOfBirth");

            var dateOfBirthDate = petsDOBPage?.EnterDateMonthYear(date);
            _scenarioContext.Add("DateOfBirth", dateOfBirthDate);
        }

        [Then(@"I have modified the pets colour as '(.*)'")]
        public void ThenIHaveModifiedThePetsColourAs(string color)
        {
            _scenarioContext.Remove("Color");
            petColourPage?.SelectColorOption(color);
            _scenarioContext.Add("Color", color);
        }

        [Then(@"I have modified the pets significant feature as '(.*)'")]
        public void ThenIHaveModifiedTheSignificantFeaturesAs(string hasUniqueFeatures)
        {
            _scenarioContext.Remove("SignificantFeatures");
            var significantFeature = significantFeaturesPage?.SelectSignificantFeaturesOption(hasUniqueFeatures);
            _scenarioContext.Add("SignificantFeatures", significantFeature);
        }

        [Then(@"I have clicked the change option for the '(.*)' from Pet owner details section")]
        public void ThenIHaveClickedTheChangeOptionForTheFromPetOwnerDetailsSection(string fieldName)
        {
            declarationPage?.ClickPetOwnerChangeLink(fieldName);
        }

        [Then(@"I have modified the pet owner name with the value of '(.*)'")]
        public void ThenIHaveModifiedThePetOwnerNameWithTheValueOf(string petOwnerName)
        {
            _scenarioContext.Remove("FullName");
            petOwnerNamePage?.EnterPetOwnerName(petOwnerName);
            _scenarioContext.Add("FullName", petOwnerName);
        }

        [When(@"I click continue button from pet owner name page")]
        public void WhenIClickContinueButtonFromPetOwnerNamePage()
        {
            petOwnerNamePage?.ClickContinueButton();
        }

        [Then(@"I have modified the pet owner phone number with the value of '(.*)'")]
        public void ThenIHaveModifiedThePetOwnerPhoneNumberWithTheValueOf(string phoneNumber)
        {
            _scenarioContext.Remove("PhoneNumber");
            petOwnerPhoneNumberPage?.EnterPetOwnerPNumber(phoneNumber);
            _scenarioContext.Add("PhoneNumber", phoneNumber);
        }

        [When(@"I click continue button from postcode search page")]
        public void WhenIClickContinueButtonFromPostCodeSearchPage()
        {
            petOwnerAddressPage?.ClickContinueButton();
        }

        [Then(@"I have modified the pet owner postcode and address with the value of '(.*)' and phone number '(.*)'")]
        public void ThenIHaveModifiedThePetOwnerPostcodeWithAddressWithTheValueOf(string postCode, string phoneNumber)
        {
            _scenarioContext.Remove("Postcode");
            _scenarioContext.Remove("Address");
            petOwnerAddressPage?.EnterPostCode(postCode);
            _scenarioContext.Add("Postcode", postCode);

            if (_scenarioContext.ContainsKey("PhoneNumber"))
            {
                _scenarioContext.Remove("PhoneNumber");
            }

            _scenarioContext.Add("PhoneNumber", phoneNumber);
        }

        [When(@"I click continue button from What is your phone number page")]
        public void WhenIClickContinueButtonFromWhatIsYourPhoneNumberPage()
        {
            petOwnerPhoneNumberPage?.ClickContinueButton();
        }

        private void ClickContinueButtonBreedPage()
        {
            var petsSelected = _scenarioContext.Get<string>("PetType");

            if (!petsSelected.ToUpper().Equals("FERRET"))
            {
                breedPage?.ClickContinueButton();
            }
        }
    }
}
