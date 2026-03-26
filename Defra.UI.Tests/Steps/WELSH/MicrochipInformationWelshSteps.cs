using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using Reqnroll;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Steps.WELSH
{
    [Binding]
    public class MicrochipInformationWelshSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IHomePageWelsh? homePageWelsh => _objectContainer.IsRegistered<IHomePageWelsh>() ? _objectContainer.Resolve<IHomePageWelsh>() : null;
        private IPetMicrochipPageWelsh? petMicrochipPageWelsh => _objectContainer.IsRegistered<IPetMicrochipPageWelsh>() ? _objectContainer.Resolve<IPetMicrochipPageWelsh>() : null;
        private IPetMicrochipDatePageWelsh? petMicrochipDatePageWelsh => _objectContainer.IsRegistered<IPetMicrochipDatePageWelsh>() ? _objectContainer.Resolve<IPetMicrochipDatePageWelsh>() : null;
        private IGetYourPetMicrochippedPageWelsh? getYourPetMicrochippedPageWelsh => _objectContainer.IsRegistered<IGetYourPetMicrochippedPageWelsh>() ? _objectContainer.Resolve<IGetYourPetMicrochippedPageWelsh>() : null;

        public MicrochipInformationWelshSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"I click apply for a document button in Welsh")]
        public void WhenIClickApplyForADocumentButtonInWelsh()
        {
            homePageWelsh?.ClickApplyForADocumentInWelsh();
            Thread.Sleep(2000);
        }

        [Then(@"I should redirected to the Is your pet microchipped page in Welsh")]
        public void ThenIShouldRedirectedToTheIsYourPetMicrochippedPageInWelsh()
        {
            var pageTitle = "Oes microsglodyn wedi’i osod ar eich anifail anwes?";
            Assert.IsTrue(petMicrochipPageWelsh?.IsNextPageLoaded(pageTitle), $"Is your pet microchipped page is not loaded!");
            Thread.Sleep(1000);
        }

        [Then(@"I should redirected to When was your pet microchipped or last scanned? page in Welsh")]
        public void ThenIShouldRedirectedToWhenWasYourPetMicrochippedOrLastScannedPageInWelsh()
        {
            var pageTitle = "Pryd oedd y tro diwethaf i’ch anifail anwes gael microsglodyn wedi’i osod neu wedi’i sganio?";
            Assert.IsTrue(petMicrochipDatePageWelsh?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I should not be redirected to Is your pet a dog, cat or ferret? page in Welsh")]
        public void ThenIShouldNotBeRedirectedToIsYourPetADogCatOrFerretPageInWelsh()
        {
            var pageTitle = $"Pa un o’r rhain yw eich anifail anwes chi ?";
            Assert.IsFalse(petMicrochipDatePageWelsh?.IsNextPageLoaded(pageTitle), $"When was your pet microchipped or last scanned? page not loaded!");
        }

        [Then(@"I should redirected to the Get your pet microchipped before applying page in Welsh")]
        public void ThenIShouldRedirectedToTheGetYourPetMicrochippedBeforeApplyingPage()
        {
            var pageTitle = "Trefnwch osod microsglodyn ar eich anifail anwes cyn gwneud cais";
            Assert.IsTrue(getYourPetMicrochippedPageWelsh?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I click the survey link ""([^""]*)"" in Welsh")]
        public void ThenIClickTheSurveyLinkInWelsh(string surveyLink)
        {
            getYourPetMicrochippedPageWelsh?.ClickSurveyLink(surveyLink);
        }

        [When(@"I click Continue button from microchipped page in Welsh")]
        public void WhenIClickContinueButtonFromMicrochippedPageInWelsh()
        {
            petMicrochipPageWelsh?.ClickParhauButton();
        }

        [When(@"I click Continue button from When was your pet microchipped page in Welsh")]
        public void WhenIClickContinueButtonFromWhenWasYourPetMicrochippedPage()
        {
            petMicrochipDatePageWelsh?.ClickParhauButton();
            Thread.Sleep(2000);
        }

        [When(@"provided microchip number as (.*) in Welsh")]
        public void ThenProvidedMicrochipNumberAs(string microchipNumber)
        {
            _scenarioContext.Add("Rhif y microsglodyn", petMicrochipPageWelsh?.EnterMicrochipNumber());
        }

        [Then(@"I have provided date of PETS microchipped in Welsh")]
        public void ThenIHaveProvidedDateOfPETSMicrochipped()
        {
            var microchippedDate = petMicrochipDatePageWelsh?.EnterDateMonthYear(DateTime.Now.AddYears(-3));
            _scenarioContext.Add("Dyddiad mewnblannu neu sganio", microchippedDate);
        }
    }
}