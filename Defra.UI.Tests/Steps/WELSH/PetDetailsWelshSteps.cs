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
        private IPetDOBPage? petDOBPage => _objectContainer.IsRegistered<IPetDOBPage>() ? _objectContainer.Resolve<IPetDOBPage>() : null;
        private IPetColourPage? petColourPag => _objectContainer.IsRegistered<IPetColourPage>() ? _objectContainer.Resolve<IPetColourPage>() : null;
        private ISignificantFeaturesPage? significantFeaturesPage => _objectContainer.IsRegistered<ISignificantFeaturesPage>() ? _objectContainer.Resolve<ISignificantFeaturesPage>() : null;

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
            _scenarioContext.Add("PetType", petType);
        }

        [When(@"I click on continue button from Is your pet a cat, dog or ferret page in Welsh")]
        public void WhenIClickOnContinueButtonFromIsYourPetACatDogOrFerretPageInWelsh()
        {
            petSpeciesPageWelsh?.ClickContinueButton();
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

        [Then(@"I should redirected to the What sex is your pet page in Welsh")]
        public void ThenIShouldRedirectedToTheWhatSexIsYourPetPageInWelsh()
        {
            var pageTitle = "Beth yw rhyw eich anifail anwes?";
            Assert.IsTrue(petSexPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I should redirected to the Do you know your pet's date of birth page in Welsh")]
        public void ThenIShouldRedirectedToTheDoYouKnowYourPetsDateOfBirthPageInWelsh()
        {
            var pageTitle = "Beth yw dyddiad geni eich anifail anwes?";
            Assert.IsTrue(petDOBPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have provided date of birth")]
        public void ThenIHaveProvidedDateOfBirth()
        {
            var dateOfBirth = petDOBPage?.EnterDateMonthYear(DateTime.Now.AddYears(-8));
            _scenarioContext.Add("DateOfBirth", dateOfBirth);
        }


    /* [When(@"I click on continue button from Do you know your pet's date of birth? page")]
        public void WhenIClickOnContinueButtonFromDoYouKnowYourPetsDateOfBirthPage()
        {
            petDOBPage?.ClickContinueButton();
        }*/

        [Then(@"I should redirected to the What is the main colour of your '([^']*)' page")]
        public void ThenIShouldRedirectedToTheWhatIsTheMainColourOfYourPage(string petCategory)
        {
            var pageTitle = $"What is the main colour of your {petCategory.ToLower()}?";
            Assert.IsTrue(petColourPag?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have selected the option as '([^']*)' for color")]
        public void ThenIHaveSelectedTheOptionAsForColor(string color)
        {
            petColourPag?.SelectColorOption(color);
            _scenarioContext.Add("Color", color);
        }

        [Then(@"I provided other color of the pet as ""([^""]*)""")]
        public void ThenIProvidedOtherColorOfThePetAs(string otherColor)
        {
            petColourPag?.SelectOtherColorOption(otherColor);
            _scenarioContext.Add("OtherColor", otherColor);
        }

        [When(@"I click on continue button from What is the main colour of your pet page")]
        public void WhenIClickOnContinueButtonFromWhatIsTheMainColourOfYourPetPage()
        {
            petColourPag?.ClickContinueButton();
        }

        [Then(@"I should redirected to the Does your pet have any significant features page")]
        public void ThenIShouldRedirectedToTheDoesYourPetHaveAnySignificantFeaturesPage()
        {
            var pageTitle = "Does your pet have any significant features?";
            Assert.IsTrue(significantFeaturesPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have selected an option as '([^']*)' for significant features")]
        public void ThenIHaveSelectedAnOptionAsForSignificantFeatures(string hasSignificantFeatures)
        {
            var significantFeature = significantFeaturesPage?.SelectSignificantFeaturesOption(hasSignificantFeatures);
            _scenarioContext.Add("SignificantFeatures", significantFeature);
        }

        [When(@"I click on continue button from Does your pet have any significant features page")]
        public void WhenIClickOnContinueButtonFromDoesYourPetHaveAnySignificantFeaturesPage()
        {
            significantFeaturesPage?.ClickContinueButton();
        }

        [Then(@"I have provided date of birth as '(.*)''(.*)''(.*)'")]
        public void ThenIHaveProvidedDateOfBirthAs(string day, string month, string year)
        {
            petDOBPage?.EnterPetDateOfBirth(day, month, year);
        }
    }
}
