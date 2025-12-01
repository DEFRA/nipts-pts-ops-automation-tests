using Reqnroll.BoDi;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using NUnit.Framework;
using Reqnroll;
using Defra.UI.Tests.Pages.AP.Classes;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class PetDetailsWelshSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IPetSpeciesPageWelsh? petSpeciesPageWelsh => _objectContainer.IsRegistered<IPetSpeciesPageWelsh>() ? _objectContainer.Resolve<IPetSpeciesPageWelsh>() : null;
        private IPetBreedPageWelsh? breedPageWelsh => _objectContainer.IsRegistered<IPetBreedPageWelsh>() ? _objectContainer.Resolve<IPetBreedPageWelsh>() : null;
        private IPetNamePageWelsh? petNamePageWelsh => _objectContainer.IsRegistered<IPetNamePageWelsh>() ? _objectContainer.Resolve<IPetNamePageWelsh>() : null;
        private IPetSexPage? petSexPage => _objectContainer.IsRegistered<IPetSexPage>() ? _objectContainer.Resolve<IPetSexPage>() : null;
        private IPetSexPageWelsh? petSexPageWelsh => _objectContainer.IsRegistered<IPetSexPageWelsh>() ? _objectContainer.Resolve<IPetSexPageWelsh>() : null;
        private IPetDOBPage? petDOBPage => _objectContainer.IsRegistered<IPetDOBPage>() ? _objectContainer.Resolve<IPetDOBPage>() : null;
        private IPetDOBPageWelsh? petDOBPageWelsh => _objectContainer.IsRegistered<IPetDOBPageWelsh>() ? _objectContainer.Resolve<IPetDOBPageWelsh>() : null;
        private IPetColourPage? petColourPag => _objectContainer.IsRegistered<IPetColourPage>() ? _objectContainer.Resolve<IPetColourPage>() : null;
        private IPetColourPageWelsh? petColourPageWelsh => _objectContainer.IsRegistered<IPetColourPageWelsh>() ? _objectContainer.Resolve<IPetColourPageWelsh>() : null;
        private ISignificantFeaturesPageWelsh? significantFeaturesPageWelsh => _objectContainer.IsRegistered<ISignificantFeaturesPageWelsh>() ? _objectContainer.Resolve<ISignificantFeaturesPageWelsh>() : null;

        public PetDetailsWelshSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I should redirected to the Is your pet a cat, dog or ferret page in Welsh")]
        public void ThenIShouldRedirectedToTheIsYourPetACatDogOrFerretPageInWelsh()
        {
            var pageTitle = "Pa un o'r rhain yw eich anifail anwes chi?".Replace("\u2019", "'").Replace("\u2018", "'");
            Assert.IsTrue(petSpeciesPageWelsh?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have selected an option as '([^']*)' for pet in Welsh")]
        public void ThenIHaveSelectedAnOptionAsForPetinWelsh(string petType)
        {
            petSpeciesPageWelsh?.SelectSpecies(petType);
            _scenarioContext.Add("Rhywogaeth", petType);
        }

        [When(@"I click on continue button from Is your pet a cat, dog or ferret page in Welsh")]
        public void WhenIClickOnContinueButtonFromIsYourPetACatDogOrFerretPageInWelsh()
        {
            petSpeciesPageWelsh?.ClickParhauButton();
        }

        [Then(@"I should redirected to the What breed is your {string}? page in Welsh")]
        public void ThenIShouldRedirectedToTheWhatBreedIsYourPageInWelsh(string petType)
        {
            if (!petType.ToLower().Equals("Ffured"))
            {
                var pageTitle = $"Pa frid yw’ch {petType.ToLower()} chi".Replace("\u2019", "'").Replace("\u2018", "'");
                Assert.IsTrue(breedPageWelsh?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
            }
        }

        [When(@"I click on continue button from What is your pet's breed page in Welsh")]
        public void WhenIClickOnContinueButtonFromWhatIsYourPetssBreedPageInWelsh()
        {
            breedPageWelsh?.ClickParhauButton();
        }

        /*        [Then(@"I have provided freetext breed as '([^']*)'")]
                public void ThenIHaveProvidedFreetextBreedAs(string breed)
                {
                    breedPage?.EnterFreeTextBreed(breed);
                    _scenarioContext.Add("Breed", breed);
                }*/


        [Then(@"I should redirected to the What is your pet's name page in Welsh")]
        public void ThenIShouldRedirectedToTheWhatIsYourPetsNamePageInWelsh()
        {
            var pageTitle = "Beth yw enw’ch anifail anwes?".Replace("\u2019", "'").Replace("\u2018", "'");
            Assert.IsTrue(petNamePageWelsh?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I click on continue button from What is your pet's name page in Welsh")]
        public void WhenIClickOnContinueButtonFromWhatIsYourPetsNamePage()
        {
            petNamePageWelsh?.ClickParhauButton();
        }

        [Then(@"I should redirected to the What sex is your pet page in Welsh")]
        public void ThenIShouldRedirectedToTheWhatSexIsYourPetPageInWelsh()
        {
            var pageTitle = "Beth yw rhyw eich anifail anwes?";
            Assert.IsTrue(petSexPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I click on continue button from What sex is your pet page in Welsh")]
        public void WhenIClickOnContinueButtonFromWhatSexIsYourPetPage()
        {
            petSexPageWelsh?.ClickParhauButton();
        }

        [Then(@"I should redirected to the Do you know your pet's date of birth page in Welsh")]
        public void ThenIShouldRedirectedToTheDoYouKnowYourPetsDateOfBirthPageInWelsh()
        {
            var pageTitle = "Beth yw dyddiad geni eich anifail anwes?";
            Assert.IsTrue(petDOBPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I click on continue button from Do you know your pet's date of birth? page in Welsh")]
        public void WhenIClickOnContinueButtonFromDoYouKnowYourPetsDateOfBirthPageInWelsh()
        {
            petDOBPageWelsh?.ClickParhauButton();
        }

        [Then(@"I should redirected to the What is the main colour of your '([^']*)' page in Welsh")]
        public void ThenIShouldRedirectedToTheWhatIsTheMainColourOfYourPageInWelsh(string petCategory)
        {
            var pageTitle = $"Beth yw prif liw eich {petCategory.ToLower()}?";
            Assert.IsTrue(petColourPag?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have selected the option as '([^']*)' for color in Welsh")]
        public void ThenIHaveSelectedTheOptionAsForColorInWelsh(string color)
        {
            petColourPageWelsh?.SelectColorOption(color);
            _scenarioContext.Add("Lliw", color);
        }

/*        [Then(@"I provided other color of the pet as ""([^""]*)""")]
        public void ThenIProvidedOtherColorOfThePetAs(string otherColor)
        {
            petColourPag?.SelectOtherColorOption(otherColor);
            _scenarioContext.Add("OtherColor", otherColor);
        }*/

        [When(@"I click on continue button from What is the main colour of your pet page in Welsh")]
        public void WhenIClickOnContinueButtonFromWhatIsTheMainColourOfYourPetPageInWelsh()
        {
            petColourPageWelsh?.ClickParhauButton();
        }

        [Then(@"I should redirected to the Does your pet have any significant features page in Welsh")]
        public void ThenIShouldRedirectedToTheDoesYourPetHaveAnySignificantFeaturesPageInWelsh()
        {
            var pageTitle = "Oes gan eich anifail anwes unrhyw nodweddion arwyddocaol?";
            Assert.IsTrue(significantFeaturesPageWelsh?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have selected an option as '([^']*)' for significant features in Welsh")]
        public void ThenIHaveSelectedAnOptionAsForSignificantFeatures(string hasSignificantFeatures)
        {
            var significantFeature = significantFeaturesPageWelsh?.SelectSignificantFeaturesOption(hasSignificantFeatures);
            _scenarioContext.Add("Nodweddion arwyddocaol", significantFeature);
        }

        [When(@"I click on continue button from Does your pet have any significant features page in Welsh")]
        public void WhenIClickOnContinueButtonFromDoesYourPetHaveAnySignificantFeaturesPageInWelsh()
        {
            significantFeaturesPageWelsh?.ClickParhauButton();
        }

        [Then(@"I provided the Pets name as '([^']*)' in Welsh")]
        public void ThenIProvidedThePetsNameAs(string petName)
        {
            var petFullName = $"{petName} {Utils.GenerateRandomName()}";
            petNamePageWelsh?.EnterPetsName(petFullName);
            _scenarioContext.Add("Enw", petFullName);
        }

        [Then(@"I have selected {int} as breed index from breed dropdownlist in Welsh")]
        public void ThenIHaveSelectedAsBreedIndexFromBreedDropdownlist(int breedIndex)
        {
            var breed = breedPageWelsh?.SelectPetsBreed(breedIndex);
            _scenarioContext.Add("Brid", breed);
        }

        [Then(@"I have selected the option as '([^']*)' for sex in Welsh")]
        public void ThenIHaveSelectedTheOptionAsForSex(string sex)
        {
            petSexPageWelsh?.SelectPetsSexOption(sex);
            _scenarioContext.Add("Rhyw", sex);
        }
    }
}
