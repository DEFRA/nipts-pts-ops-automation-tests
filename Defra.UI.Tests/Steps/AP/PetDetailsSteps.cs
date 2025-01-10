using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class PetDetailsSteps
    {
        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly IPetSpeciesPage _petSpeciesPage;
        private readonly IPetBreedPage _breedPage;
        private readonly IPetNamePage _petNamePage;
        private readonly IPetSexPage _petSexPage;
        private readonly IPetDOBPage _petDOBPage;
        private readonly IPetColourPage _petColourPage;
        private readonly ISignificantFeaturesPage _significantFeaturesPage;

        public PetDetailsSteps(ScenarioContext context, IWebDriver driver, IPetSpeciesPage petSpeciesPage, IPetBreedPage breedPage, IPetNamePage petNamePage, 
            IPetSexPage petSexPage, IPetDOBPage petDOBPage, IPetColourPage petColourPage, ISignificantFeaturesPage significantFeaturesPage)
        {
            _scenarioContext = context;
            _driver = driver;
            _petSpeciesPage = petSpeciesPage;
            _breedPage = breedPage;
            _petNamePage = petNamePage;
            _petSexPage = petSexPage;
            _petDOBPage = petDOBPage;
            _petColourPage = petColourPage;
            _significantFeaturesPage = significantFeaturesPage;
        }

        [Then(@"I should redirected to the Is your pet a cat, dog or ferret page")]
        public void ThenIShouldRedirectedToTheIsYourPetACatDogOrFerretPage()
        {
            var pageTitle = "Is your pet a dog, cat or ferret?";
            Assert.IsTrue(_petSpeciesPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have selected an option as '([^']*)' for pet")]
        public void ThenIHaveSelectedAnOptionAsForPet(string petType)
        {
            _petSpeciesPage?.SelectSpecies(petType);
            _scenarioContext.Add("PetType", petType);
        }

        [When(@"I click on continue button from Is your pet a cat, dog or ferret page")]
        public void WhenIClickOnContinueButtonFromIsYourPetACatDogOrFerretPage()
        {
            _petSpeciesPage?.ClickContinueButton();
        }

        [Then("I should redirected to the What breed is your {string}? page")]
        public void ThenIShouldRedirectedToTheWhatBreedIsYourPage(string petType)
        {
            if (!petType.ToLower().Equals("ferret"))
            {
                var pageTitle = $"What breed is your {petType.ToLower()}";
                Assert.IsTrue(_breedPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
            }
        }

        [Then(@"I have selected (.*) as breed index from breed dropdownlist")]
        public void ThenIHaveSelectedAsBreedIndexFromBreedDropdownlist(int breedIndex)
        {
            var breed = _breedPage?.SelectPetsBreed(breedIndex);
            _scenarioContext.Add("Breed", breed);
        }

        [Then(@"I have provided freetext breed as '([^']*)'")]
        public void ThenIHaveProvidedFreetextBreedAs(string breed)
        {
            _breedPage?.EnterFreeTextBreed(breed);
            _scenarioContext.Add("Breed", breed);
        }

        [When(@"I click on continue button from What is your pet's breed page")]
        public void WhenIClickOnContinueButtonFromWhatIsYourPetssBreedPage()
        {
            _breedPage?.ClickContinueButton();
        }

        [Then(@"I should redirected to the What is your pet's name page")]
        public void ThenIShouldRedirectedToTheWhatIsYourPetsNamePage()
        {
            var pageTitle = "What is your pet's name?";
            Assert.IsTrue(_petNamePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I provided the Pets name as '([^']*)'")]
        public void ThenIProvidedThePetsNameAs(string petName)
        {
            var petFullName = $"{petName} {Utils.GenerateRandomName()}";
            _petNamePage?.EnterPetsName(petFullName);
            _scenarioContext.Add("PetName", petFullName);
        }

        [When(@"I click on continue button from What is your pet's name page")]
        public void WhenIClickOnContinueButtonFromWhatIsYourPetsNamePage()
        {
            _petNamePage?.ClickContinueButton();
        }

        [Then(@"I should redirected to the What sex is your pet page")]
        public void ThenIShouldRedirectedToTheWhatSexIsYourPetPage()
        {
            var pageTitle = "What sex is your pet?";
            Assert.IsTrue(_petSexPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have selected the option as '([^']*)' for sex")]
        public void ThenIHaveSelectedTheOptionAsForSex(string sex)
        {
            _petSexPage?.SelectPetsSexOption(sex);
            _scenarioContext.Add("Sex", sex);
        }

        [When(@"I click on continue button from What sex is your pet page")]
        public void WhenIClickOnContinueButtonFromWhatSexIsYourPetPage()
        {
            _petSexPage?.ClickContinueButton();
        }

        [Then(@"I should redirected to the Do you know your pet's date of birth page")]
        public void ThenIShouldRedirectedToTheDoYouKnowYourPetsDateOfBirthPage()
        {
            var pageTitle = "What is your pet's date of birth?";
            Assert.IsTrue(_petDOBPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have provided date of birth")]
        public void ThenIHaveProvidedDateOfBirth()
        {
            var dateOfBirth = _petDOBPage?.EnterDateMonthYear(DateTime.Now.AddYears(-8));
            _scenarioContext.Add("DateOfBirth", dateOfBirth);
        }

        [When(@"I click on continue button from Do you know your pet's date of birth? page")]
        public void WhenIClickOnContinueButtonFromDoYouKnowYourPetsDateOfBirthPage()
        {
            _petDOBPage?.ClickContinueButton();
        }

        [Then(@"I should redirected to the What is the main colour of your '([^']*)' page")]
        public void ThenIShouldRedirectedToTheWhatIsTheMainColourOfYourPage(string petCategory)
        {
            var pageTitle = $"What is the main colour of your {petCategory.ToLower()}?";
            Assert.IsTrue(_petColourPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have selected the option as '([^']*)' for color")]
        public void ThenIHaveSelectedTheOptionAsForColor(string color)
        {
            _petColourPage?.SelectColorOption(color);
            _scenarioContext.Add("Color", color);
        }

        [Then(@"I provided other color of the pet as ""([^""]*)""")]
        public void ThenIProvidedOtherColorOfThePetAs(string otherColor)
        {
            _petColourPage?.SelectOtherColorOption(otherColor);
            _scenarioContext.Add("OtherColor", otherColor);
        }

        [When(@"I click on continue button from What is the main colour of your pet page")]
        public void WhenIClickOnContinueButtonFromWhatIsTheMainColourOfYourPetPage()
        {
            _petColourPage?.ClickContinueButton();
        }

        [Then(@"I should redirected to the Does your pet have any significant features page")]
        public void ThenIShouldRedirectedToTheDoesYourPetHaveAnySignificantFeaturesPage()
        {
            var pageTitle = "Does your pet have any significant features?";
            Assert.IsTrue(_significantFeaturesPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have selected an option as '([^']*)' for significant features")]
        public void ThenIHaveSelectedAnOptionAsForSignificantFeatures(string hasSignificantFeatures)
        {
            var significantFeature = _significantFeaturesPage?.SelectSignificantFeaturesOption(hasSignificantFeatures);
            _scenarioContext.Add("SignificantFeatures", significantFeature);
        }

        [When(@"I click on continue button from Does your pet have any significant features page")]
        public void WhenIClickOnContinueButtonFromDoesYourPetHaveAnySignificantFeaturesPage()
        {
            _significantFeaturesPage?.ClickContinueButton();
        }
    }
}
