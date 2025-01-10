using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class MicrochipInformationSteps
    {
        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly IHomePage _homePage;
        private readonly IPetMicrochipPage _petMicrochipPage;
        private readonly IPetMicrochipDatePage _petMicrochipDatePage;
        private readonly IGetYourPetMicrochippedPage _getYourPetMicrochippedPage;

        public MicrochipInformationSteps(ScenarioContext context, IHomePage homePage, IPetMicrochipPage petMicrochipPage, IPetMicrochipDatePage petMicrochipDatePage, 
            IGetYourPetMicrochippedPage getYourPetMicrochippedPage)
        {
            _scenarioContext = context;
            _homePage = homePage;
            _petMicrochipPage = petMicrochipPage;
            _petMicrochipDatePage = petMicrochipDatePage;
            _getYourPetMicrochippedPage = getYourPetMicrochippedPage;
        }

        [Then(@"I should redirected to Apply for a pet travel document page")]
        public void ThenIShouldRedirectedToApplyForAPetTravelDocumentPage()
        {
            Assert.True(_homePage?.IsPageLoaded(), "Apply for a pet travel document not loaded");
        }

        [When(@"I click Create a new pet travel document button")]
        public void WhenIClickCreateANewPetTravelDocumentButton()
        {
            _homePage?.ClickApplyForPetTravelDocument();

            Thread.Sleep(2000);
        }

        [Then(@"I should redirected to the Is your pet microchipped page")]
        public void ThenIShouldRedirectedToTheIsYourPetMicrochippedPage()
        {
            var pageTitle = "Is your pet microchipped?";
            Assert.IsTrue(_petMicrochipPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I selected the '([^']*)' option")]
        public void ThenISelectedTheOption(string option)
        {
            _petMicrochipPage?.SelectMicrochippedOption(option);
        }

        [Then(@"provided microchip number as (.*)")]
        public void ThenProvidedMicrochipNumberAs(string microchipNumber)
        {
            _scenarioContext.Add("MicrochipNumber", _petMicrochipPage?.EnterMicrochipNumber());
        }

        [Then(@"enter microchip number as (.*)")]
        public void ThenEnterMicrochipNumberAs(string microchipNumber)
        {
            _scenarioContext.Add("MicrochipNumber", _petMicrochipPage?.EnterGivenMicrochipNumber(microchipNumber));
        }

        [When(@"I click Continue button from microchipped page")]
        public void WhenIClickContinueButtonFromMicrochippedPage()
        {
            _petMicrochipPage?.ClickContinueButton();
        }

        [Then(@"I should redirected to When was your pet microchipped or last scanned? page")]
        public void ThenIShouldRedirectedToWhenWasYourPetMicrochippedOrLastScannedPage()
        {
            var pageTitle = "When was your pet microchipped or last scanned?";
            Assert.IsTrue(_petMicrochipDatePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have provided date of PETS microchipped")]
        public void ThenIHaveProvidedDateOfPETSMicrochipped()
        {
            var microchippedDate = _petMicrochipDatePage?.EnterDateMonthYear(DateTime.Now.AddYears(-3));
            _scenarioContext.Add("MicrochippedDate", microchippedDate);
        }

        [When(@"I click Continue button from When was your pet microchipped page")]
        public void WhenIClickContinueButtonFromWhenWasYourPetMicrochippedPage()
        {
            _petMicrochipDatePage?.ClickContinueButton();
        }

        [Then(@"I should redirected to the Get your pet microchipped before applying page")]
        public void ThenIShouldRedirectedToTheGetYourPetMicrochippedBeforeApplyingPage()
        {
            var pageTitle = "Get your pet microchipped before applying";
            Assert.IsTrue(_getYourPetMicrochippedPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }
    }
}
