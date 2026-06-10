using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Pages.WELSH.Interfaces;
using NUnit.Framework;
using Reqnroll;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Steps.WELSH
{
    [Binding]
    public class ValidationsWelshSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IPetMicrochipPage? petMicrochipPage => _objectContainer.IsRegistered<IPetMicrochipPage>() ? _objectContainer.Resolve<IPetMicrochipPage>() : null;
        private IPetMicrochipDatePage? petMicrochipDatePage => _objectContainer.IsRegistered<IPetMicrochipDatePage>() ? _objectContainer.Resolve<IPetMicrochipDatePage>() : null;
        private IPetSpeciesPage? petSpeciesPage => _objectContainer.IsRegistered<IPetSpeciesPage>() ? _objectContainer.Resolve<IPetSpeciesPage>() : null;
        private IPetBreedPage? breedPage => _objectContainer.IsRegistered<IPetBreedPage>() ? _objectContainer.Resolve<IPetBreedPage>() : null;
        private IPetBreedPageWelsh? breedPageWelsh => _objectContainer.IsRegistered<IPetBreedPageWelsh>() ? _objectContainer.Resolve<IPetBreedPageWelsh>() : null;
        private IPetNamePage? petNamePage => _objectContainer.IsRegistered<IPetNamePage>() ? _objectContainer.Resolve<IPetNamePage>() : null;
        private IPetSexPage? petSexPage => _objectContainer.IsRegistered<IPetSexPage>() ? _objectContainer.Resolve<IPetSexPage>() : null;
        private IPetDOBPage? petDOBPage => _objectContainer.IsRegistered<IPetDOBPage>() ? _objectContainer.Resolve<IPetDOBPage>() : null;
        private IPetColourPage? petColourPage => _objectContainer.IsRegistered<IPetColourPage>() ? _objectContainer.Resolve<IPetColourPage>() : null;
        private ISignificantFeaturesPage? significantFeaturesPage => _objectContainer.IsRegistered<ISignificantFeaturesPage>() ? _objectContainer.Resolve<ISignificantFeaturesPage>() : null;
        private IPetOwnerNamePage? petKeeperPage => _objectContainer.IsRegistered<IPetOwnerNamePage>() ? _objectContainer.Resolve<IPetOwnerNamePage>() : null;
        private IPetOwnerAddressPageWelsh? petOwnerAddressPageWelsh => _objectContainer.IsRegistered<IPetOwnerAddressPageWelsh>() ? _objectContainer.Resolve<IPetOwnerAddressPageWelsh>() : null;
        private IPetOwnerPhoneNumberPage? petOwnerPhoneNumberPage => _objectContainer.IsRegistered<IPetOwnerPhoneNumberPage>() ? _objectContainer.Resolve<IPetOwnerPhoneNumberPage>() : null;

        public ValidationsWelshSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I should not be redirected to the What is the main colour of your '([^']*)' page in Welsh")]
        public void ThenIShouldNotBeRedirectedToTheWhatIsTheMainColourOfYourPageInWelsh(string petCategory)
        {
            var pageTitle = $"Beth yw prif liw eich {petCategory}?";
            Assert.IsFalse(petColourPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I should not be redirected to When was your pet microchipped or last scanned? page in Welsh")]
        public void ThenIShouldNotBeRedirectedToWhenWasYourPetMicrochippedOrLastScannedPageInWelsh()
        {
            var pageTitle = $"Pryd oedd y tro diwethaf i’ch anifail anwes gael microsglodyn wedi’i osod neu wedi’i sganio?";
            Assert.IsFalse(petMicrochipPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }



        [Then(@"I should not be redirected to What is your postcode page in Welsh")]
        public void ThenIShouldNotBeRedirectedToWhatIsYourPostcodePage()
        {
            var pageTitle = "Beth yw’ch enw llawn?";
            Assert.IsTrue(petOwnerAddressPageWelsh?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }



        [Then(@"I should not be redirected to What breed is your '(.*)' page in Welsh")]
        public void ThenIShouldNotBeRedirectedToWhatBreedIsYourPage(string petType)
        {
            var pageTitle = "Pa un o’r rhain yw eich anifail anwes chi ?";
            Assert.IsTrue(petSpeciesPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }



        [Then(@"I should not be redirected to What sex is your pet page in Welsh")]
        public void ThenIShouldNotBeRedirectedToWhatSexIsYourPetPage()
        {
            var pageTitle = "Beth yw enw’ch anifail anwes?";
            Assert.IsTrue(petNamePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }


        [Then(@"I should not redirected to the Do you know your pet's date of birth page in Welsh")]
        public void ThenIShouldNotRedirectedToTheDoYouKnowYourPetsDateOfBirthPageinWelsh()
        {
            var pageTitle = "Beth yw rhyw eich anifail anwes?";
            Assert.IsTrue(petSexPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }


        [Then(@"I should not be redirected to the Is your pet microchipped page in Welsh")]
        public void ThenIShouldNotBeRedirectedToTheIsYourPetMicrochippedPage()
        {
            var pageTitle = "Beth yw’ch rhif ffôn?";
            Assert.IsTrue(petOwnerPhoneNumberPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I should not be redirected to the Does your pet have any significant features page in Welsh")]
        public void ThenIShouldNotBeRedirectedToTheDoesYourPetHaveAnySignificantFeaturesPage()
        {
            var pageTitle = $"Beth yw prif liw eich";
            Assert.IsTrue(petColourPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }


        [Then(@"I should not be redirected to the Check your answers and sign the declaration page in Welsh")]
        public void ThenIShouldNotBeRedirectedToTheCheckYourAnswersAndSignTheDeclarationPageInWelsh()
        {
            var pageTitle = $"Oes gan eich anifail anwes unrhyw nodweddion arwyddocaol?";
            Assert.IsTrue(significantFeaturesPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I should not be redirected to the What is your pet's name page in Welsh")]
        public void ThenIShouldNotBeRedirectedToTheWhatIsYourPetsNamePageInWelsh()
        {
            var pageTitle = $"Pa frid yw’ch ci chi?";
            Assert.IsTrue(breedPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I click Continue button from What is your address page in Welsh")]
        public void WhenIClickContinueButtonFromWhatIsYourAddressPage()
        {
            petOwnerAddressPageWelsh?.ClickContinueButton();
        }

        [Then(@"I verify the breeds displayed in the breed dropdownlist for '(.*)' species in Welsh")]
        public void ThenIVerifyTheBreedsDisplayedInTheBreedDropdownlistForSpeciesInWelsh(string species)
        {
            Assert.True(breedPageWelsh?.VerifyBreedsListInWelsh(species));
        }
    }
}
