using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Pages.WELSH.Interfaces;
using Defra.UI.Tests.Tools;
using Reqnroll;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Steps.WELSH
{
    [Binding]
    public class UpdateWelshSteps
    {

        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IPetMicrochipPageWelsh? petMicrochipPageWelsh => _objectContainer.IsRegistered<IPetMicrochipPageWelsh>() ? _objectContainer.Resolve<IPetMicrochipPageWelsh>() : null;
        private IPetMicrochipDatePageWelsh? petMicrochipDatePageWelsh => _objectContainer.IsRegistered<IPetMicrochipDatePageWelsh>() ? _objectContainer.Resolve<IPetMicrochipDatePageWelsh>() : null;
        private IPetSpeciesPageWelsh? petsCategoryPageWelsh => _objectContainer.IsRegistered<IPetSpeciesPageWelsh>() ? _objectContainer.Resolve<IPetSpeciesPageWelsh>() : null;
        private IPetBreedPageWelsh? breedPageWelsh => _objectContainer.IsRegistered<IPetBreedPageWelsh>() ? _objectContainer.Resolve<IPetBreedPageWelsh>() : null;
        private IPetNamePage? petNamePage => _objectContainer.IsRegistered<IPetNamePage>() ? _objectContainer.Resolve<IPetNamePage>() : null;
        private IPetSexPageWelsh? petSexPageWelsh => _objectContainer.IsRegistered<IPetSexPageWelsh>() ? _objectContainer.Resolve<IPetSexPageWelsh>() : null;
        private IPetDOBPageWelsh? petsDOBPageWelsh => _objectContainer.IsRegistered<IPetDOBPageWelsh>() ? _objectContainer.Resolve<IPetDOBPageWelsh>() : null;
        private IPetColourPageWelsh? petColourPageWelsh => _objectContainer.IsRegistered<IPetColourPageWelsh>() ? _objectContainer.Resolve<IPetColourPageWelsh>() : null;
        private ISignificantFeaturesPageWelsh? significantFeaturesPageWelsh => _objectContainer.IsRegistered<ISignificantFeaturesPageWelsh>() ? _objectContainer.Resolve<ISignificantFeaturesPageWelsh>() : null;
        private IPetOwnerNamePageWelsh? petOwnerNamePageWelsh => _objectContainer.IsRegistered<IPetOwnerNamePageWelsh>() ? _objectContainer.Resolve<IPetOwnerNamePageWelsh>() : null;
        private IPetOwnerAddressPageWelsh? petOwnerAddressPageWelsh => _objectContainer.IsRegistered<IPetOwnerAddressPageWelsh>() ? _objectContainer.Resolve<IPetOwnerAddressPageWelsh>() : null;
        private IPetOwnerPhoneNumberPage? petOwnerPhoneNumberPage => _objectContainer.IsRegistered<IPetOwnerPhoneNumberPage>() ? _objectContainer.Resolve<IPetOwnerPhoneNumberPage>() : null;
        private IApplicationDeclarationPage? declarationPage => _objectContainer.IsRegistered<IApplicationDeclarationPage>() ? _objectContainer.Resolve<IApplicationDeclarationPage>() : null;

        public UpdateWelshSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        /*[Then(@"I have clicked the change option for the '(.*)' from Microchip information section in Welsh")]
        public void ThenIHaveClickedChangeOptionForTheFieldFromMicrochipInformationSection(string fieldName)
        {
            declarationPage?.ClickMicrochipChangeLink(fieldName);
        }
        */
        [Then(@"I have modified the microchip number with the value of '(.*)' in Welsh")]
        public void ThenIHaveModifiedTheMicrochipNumberWithTheValueOf(string updatedMicrochipNumber)
        {
            petMicrochipPageWelsh?.UpdateMicrochipNumber(updatedMicrochipNumber);
            _scenarioContext.Remove("Rhif y microsglodyn");
            _scenarioContext.Add("Rhif y microsglodyn", updatedMicrochipNumber);
        }

        [Then(@"I have modified the microchip scanned date by adding '(.*)' days in Welsh")]
        public void ThenIHaveModifiedTheMicrochipScannedDateByAddingDays(int daysToAdd)
        {
            var microchippedDateString = _scenarioContext.Get<string>("Dyddiad mewnblannu neu sganio");
            var date = Utils.ConvertToDate(microchippedDateString).AddDays(daysToAdd);
            _scenarioContext.Remove("Dyddiad mewnblannu neu sganio");

            var microchippedDate = petMicrochipDatePageWelsh?.EnterDateMonthYear(date);
            _scenarioContext.Add("Dyddiad mewnblannu neu sganio", microchippedDate);
        }

        [Then(@"I have modified the pet name as '(.*)' in Welsh")]
        public void ThenIHaveModifiedThePetNameAs(string petName)
        {
            _scenarioContext.Remove("Enw");
            var petFullName = $"{petName} {Utils.GenerateRandomName()}";
            petNamePage?.EnterPetsName(petFullName);
            _scenarioContext.Add("Enw", petFullName);
        }

        [Then(@"I have modified the species type as '(.*)' in Welsh")]
        public void ThenIHaveModifiedTheSpeciesTypeAs(string speciesType)
        {
            _scenarioContext.Remove("Rhywogaeth");
            petsCategoryPageWelsh?.SelectSpecies(speciesType);
            _scenarioContext.Add("Rhywogaeth", speciesType);
        }

        [When(@"I click continue button from Is your pet a dog, cat or ferret page till reaching declaration page along with modification of color '(.*)' and breed (.*) in Welsh")]
        public void WhenIClickContinueButtonFromIsYourPetADogCatOrFerretPageTillReachingDeclarationPageAlongWithModificationOfColourAndBreedInWelsh(string color, int breedIndex)
        {
            petsCategoryPageWelsh?.ClickParhauButton();

            _scenarioContext.Remove("Brid");
            var breed = breedPageWelsh?.SelectPetsBreed(breedIndex);
            _scenarioContext.Add("Brid", breed);

            breedPageWelsh?.ClickParhauButton();

            _scenarioContext.Remove("Lliw");
            petColourPageWelsh?.SelectColorOption(color);
            _scenarioContext.Add("Lliw", color);

            petColourPageWelsh?.ClickParhauButton();
        }

        [Then("I have modified the pets breed with the index value of {string} in Welsh")]
        public void ThenIHaveModifiedThePetsBreedWithTheIndexValueOf(int breedIndex)
        {
            _scenarioContext.Remove("Brid");
            var breed = breedPageWelsh?.SelectPetsBreed(breedIndex, true);
            _scenarioContext.Add("Brid", breed);
        }

        [Then(@"I have modified the pets sex as '(.*)' in Welsh")]
        public void ThenIHaveModifiedThePetSexAs(string sex)
        {
            _scenarioContext.Remove("Rhyw");
            petSexPageWelsh?.SelectPetsSexOption(sex);
            _scenarioContext.Add("Rhyw", sex);
        }

        [Then(@"I have modified the pets date of birth by adding '(.*)' days in Welsh")]
        public void ThenIHaveModifiedThePetsDateOfBirthByAddingDays(int daysToAdd)
        {
            var dateOfBirth = _scenarioContext.Get<string>("Dyddiad geni");
            var date = Utils.ConvertToDate(dateOfBirth).AddDays(daysToAdd);
            _scenarioContext.Remove("Dyddiad geni");

            var dateOfBirthDate = petsDOBPageWelsh?.EnterDateMonthYear(date);
            _scenarioContext.Add("Dyddiad geni", dateOfBirthDate);
        }

        [Then(@"I have modified the pets colour as '(.*)' in Welsh")]
        public void ThenIHaveModifiedThePetsColourAs(string color)
        {
            _scenarioContext.Remove("Lliw");
            petColourPageWelsh?.SelectColorOption(color);
            _scenarioContext.Add("Lliw", color);
        }

        [Then(@"I have modified the pets significant feature as {string} in Welsh")]
        public void ThenIHaveModifiedThePetsSignificantFeatureAsInWelsh(string hasUniqueFeatures)
        {
            _scenarioContext.Remove("Nodweddion arwyddocaol");
            var significantFeature = significantFeaturesPageWelsh?.SelectSignificantFeaturesOption(hasUniqueFeatures);
            _scenarioContext.Add("Nodweddion arwyddocaol", significantFeature);
        }

        [Then(@"I have modified the pet owner name with the value of '(.*)' in Welsh")]
        public void ThenIHaveModifiedThePetOwnerNameWithTheValueOf(string petOwnerName)
        {
            _scenarioContext.Remove("enw llawn");
            petOwnerNamePageWelsh?.EnterPetOwnerName(petOwnerName);
            _scenarioContext.Add("enw llawn", petOwnerName);
        }

        [When(@"I click continue button from pet owner name page in Welsh")]
        public void WhenIClickContinueButtonFromPetOwnerNamePage()
        {
            petOwnerNamePageWelsh?.ClickContinueButton();
        }

        [Then(@"I have modified the pet owner phone number with the value of '(.*)' in Welsh")]
        public void ThenIHaveModifiedThePetOwnerPhoneNumberWithTheValueOf(string phoneNumber)
        {
            _scenarioContext.Remove("Rhif ffôn");
            petOwnerPhoneNumberPage?.EnterPetOwnerPNumber(phoneNumber);
            _scenarioContext.Add("Rhif ffôn", phoneNumber);
        }

        [When(@"I click continue button from postcode search page in Welsh")]
        public void WhenIClickContinueButtonFromPostCodeSearchPage()
        {
            petOwnerAddressPageWelsh?.ClickContinueButton();
        }

        [Then(@"I have modified the pet owner postcode and address with the value of '(.*)' in Welsh")]
        public void ThenIHaveModifiedThePetOwnerPostcodeWithAddressWithTheValueOf(string postCode)
        {
            _scenarioContext.Remove("Cod post");
            _scenarioContext.Remove("Cyfeiriad");
            petOwnerAddressPageWelsh?.EnterPostCode(postCode);
            _scenarioContext.Add("Cod post", postCode);
        }

        [Then(@"I have modified the microchip scanned date before to the date of birth in Welsh")]
        public void ThenIHaveModifiedTheMicrochipScannedDateBeforeToTheDateOfBirth()
        {
            var dateOfBirthString = _scenarioContext.Get<string>("Dyddiad geni");
            var date = Utils.ConvertToDate(dateOfBirthString).AddDays(-10);
            _scenarioContext.Remove("Dyddiad mewnblannu neu sganio");

            var microchippedDate = petMicrochipDatePageWelsh?.EnterDateMonthYear(date);
            _scenarioContext.Add("Dyddiad mewnblannu neu sganio", microchippedDate);

        }
    }
}
