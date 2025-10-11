using Reqnroll.BoDi;
using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using Reqnroll;
using Defra.UI.Tests.Pages.AP.Classes;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class MicrochipInformationSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IHomePage? homePage => _objectContainer.IsRegistered<IHomePage>() ? _objectContainer.Resolve<IHomePage>() : null;
        private IPetMicrochipPage? petMicrochipPage => _objectContainer.IsRegistered<IPetMicrochipPage>() ? _objectContainer.Resolve<IPetMicrochipPage>() : null;
        private IPetMicrochipDatePage? petMicrochipDatePage => _objectContainer.IsRegistered<IPetMicrochipDatePage>() ? _objectContainer.Resolve<IPetMicrochipDatePage>() : null;
        private IGetYourPetMicrochippedPage? getYourPetMicrochippedPage => _objectContainer.IsRegistered<IGetYourPetMicrochippedPage>() ? _objectContainer.Resolve<IGetYourPetMicrochippedPage>() : null;
        private IHomePage? HomePage => _objectContainer.IsRegistered<IHomePage>() ? _objectContainer.Resolve<IHomePage>() : null;

        public MicrochipInformationSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I should redirected to Apply for a pet travel document page")]
        public void ThenIShouldRedirectedToApplyForAPetTravelDocumentPage()
        {
            Assert.True(homePage?.IsPageLoaded(), "Apply for a pet travel document not loaded");
        }

        [When(@"I click Create a new pet travel document button")]
        public void WhenIClickCreateANewPetTravelDocumentButton()
        {
            homePage?.ClickApplyForPetTravelDocument();

            Thread.Sleep(2000);
        }

        [Then(@"I should redirected to the Is your pet microchipped page")]
        public void ThenIShouldRedirectedToTheIsYourPetMicrochippedPage()
        {
            var pageTitle = "Is your pet microchipped?";
            Assert.IsTrue(petMicrochipPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I selected the '([^']*)' option")]
        public void ThenISelectedTheOption(string option)
        {
            petMicrochipPage?.SelectMicrochippedOption(option);
        }

        [Then(@"provided microchip number as (.*)")]
        public void ThenProvidedMicrochipNumberAs(string microchipNumber)
        {
            _scenarioContext.Add("MicrochipNumber", petMicrochipPage?.EnterMicrochipNumber());
        }

        [Then(@"provided microchip number through auto-generated")]
        public void ThenProvidedMicrochipNumberThroughAuto_Generated()
        {
            _scenarioContext.Add("MicrochipNumber", petMicrochipPage?.EnterMicrochipNumber());
        }

        [Then(@"enter microchip number as (.*)")]
        public void ThenEnterMicrochipNumberAs(string microchipNumber)
        {
            _scenarioContext.Add("MicrochipNumber", petMicrochipPage?.EnterGivenMicrochipNumber(microchipNumber));
        }

        [When(@"I click Continue button from microchipped page")]
        public void WhenIClickContinueButtonFromMicrochippedPage()
        {
            petMicrochipPage?.ClickContinueButton();
        }

        [Then(@"I should redirected to When was your pet microchipped or last scanned? page")]
        public void ThenIShouldRedirectedToWhenWasYourPetMicrochippedOrLastScannedPage()
        {
            var pageTitle = "When was your pet microchipped or last scanned?";
            Assert.IsTrue(petMicrochipDatePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have provided date of PETS microchipped")]
        public void ThenIHaveProvidedDateOfPETSMicrochipped()
        {
            var microchippedDate = petMicrochipDatePage?.EnterDateMonthYear(DateTime.Now.AddYears(-3));
            _scenarioContext.Add("MicrochippedDate", microchippedDate);
        }

        [When(@"I click Continue button from When was your pet microchipped page")]
        public void WhenIClickContinueButtonFromWhenWasYourPetMicrochippedPage()
        {
            petMicrochipDatePage?.ClickContinueButton();
        }

        [Then(@"I should redirected to the Get your pet microchipped before applying page")]
        public void ThenIShouldRedirectedToTheGetYourPetMicrochippedBeforeApplyingPage()
        {
            var pageTitle = "Get your pet microchipped before applying";
            Assert.IsTrue(getYourPetMicrochippedPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I click the survey link '([^']*)'")]
        public void ThenIClickTheSurveyLink(string surveyLink)
        {
            getYourPetMicrochippedPage?.ClickSurveyLink(surveyLink);
        }

        [Then(@"I should navigate to the feedback page in new tab")]
        public void ThenIShouldNavigateToTheFeedbackPageInNewTab()
        {
            var pageTitle = "Give feedback on Taking your pet from Great Britain to Northern Ireland";
            Assert.IsTrue(HomePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I provided microchip number as hyphen (.*)")]
        public void ThenIProvidedMicrochipNumberAsHyphen(string microchipNumber)
        {
            petMicrochipPage?.EnterGivenMicrochipNumber(microchipNumber);
        }

        [Then(@"I should see the already entered hyphen (.*) in the microchip number text box")]
        public void ThenIShouldSeeTheAlreadyEnteredHyphenInTheMicrochipNumberTextBox(string alreadyEnteredMCNumber)
        {
            Assert.True(petMicrochipPage?.VerifyAlreadyEnteredMCNumber(alreadyEnteredMCNumber), "There is no MC number or hyphen exists in the text box");
        }

        [Then(@"I click go back to the previous page link")]
        public void ThenIClickGoBackToThePreviousPageLink()
        {
            petMicrochipPage?.ClickGoBackToThePreviousPageLink();
        }
    }
}