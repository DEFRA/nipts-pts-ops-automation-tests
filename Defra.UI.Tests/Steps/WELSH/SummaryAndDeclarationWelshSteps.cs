using Reqnroll.BoDi;
using Defra.UI.Tests.Pages.AP.Interfaces;
using NUnit.Framework;
using Reqnroll;
using Defra.UI.Tests.Pages.AP.Classes;
using System.Text.RegularExpressions;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class SummaryAndDeclarationWelshSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private ISummaryPageWelsh? summaryPageWelsh => _objectContainer.IsRegistered<ISummaryPageWelsh>() ? _objectContainer.Resolve<ISummaryPageWelsh>() : null;
        private IApplicationDeclarationPageWelsh? declarationPageWelsh => _objectContainer.IsRegistered<IApplicationDeclarationPage>() ? _objectContainer.Resolve<IApplicationDeclarationPageWelsh>() : null;
        private IChangeDetailsPageWelsh? changeDetailsPageWelsh => _objectContainer.IsRegistered<IChangeDetailsPageWelsh>() ? _objectContainer.Resolve<IChangeDetailsPageWelsh>() : null;
      //  private IHomePage? homePage => _objectContainer.IsRegistered<IHomePage>() ? _objectContainer.Resolve<IHomePage>() : null;
        public SummaryAndDeclarationWelshSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I click on Back button on the Pets Application in Welsh")]
        public void ThenIClickOnBackButton()
        {
            summaryPageWelsh?.ClickBackButton();
        }

        [Then(@"I should redirected to the Check your answers and sign the declaration page in Welsh")]
        public void ThenIShouldRedirectedToTheCheckYourAnswersAndSignTheDeclarationPage()
        {
            var pageTitle = "Gwiriwch eich atebion a llofnodwch y datganiad";
            Assert.IsTrue(declarationPageWelsh?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"The submitted application should be displayed in summary view in Welsh")]
        public void ThenTheSubmittedApplicationShouldBeDisplayedInSummaryView()
        {
            var pageTitle = "Crynodeb o’ch cais";
            Assert.IsTrue(declarationPageWelsh?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }/*

        [Then(@"I have verified microchip details in declaration page")]
        public void ThenIHaveVerifiedMicrochipDetailsInDeclarationPage()
        {
            VerifyMicrodhipInformation(false);
        }

        [Then(@"I have verified pet details in declaration page")]
        public void ThenIHaveVerifiedPetDetailsInDeclarationPage()
        {
            VerifyPetsDetails(false);
        }

        [Then(@"I have verified pet owner details in declaration page")]
        public void ThenIHaveVerifiedPetOwnerDetailsInDeclarationPage()
        {
            VerifyPetOwnerDetails(false);
        }


        [Then(@"I have verified microchip details in summary page")]
        public void ThenIHaveVerifiedMicrochipDetailsInSummaryPage()
        {
            VerifyMicrodhipInformation();
        }*/

        [Then(@"I have verified pet details in summary page in Welsh")]
        public void ThenIHaveVerifiedPetDetailsInSummaryPage()
        {
            VerifyPetsDetailsWelsh();
        }
        
        /*

        [Then(@"I click download link in summary page")]
        public void ThenIClickDownloadLinkInSummaryPage()
        {
            summaryPage?.ClickPDFDownloadLink();
        }

        [Then(@"I click print link in summary page")]
        public void ThenIClickPrintLinkInSummaryPage()
        {
            Assert.IsTrue(summaryPage?.ClickPrintdLink(), "Print window not opened successfully");
        }

        [Then(@"I have verified pet owner details in summary page")]
        public void ThenIHaveVerifiedPetOwnerDetailsInSummaryPage()
        {
            VerifyPetOwnerDetails();
        }*/

        [Then(@"I should redirected to the Are your details correct page in Welsh")]
        public void ThenIShouldRedirectedToTheAreYourDetailsCorrectPageInWelsh()
        {
            var pageTitle = "Ydy’ch manylion chi’n gywir?";
            Assert.IsTrue(changeDetailsPageWelsh?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

/*        [Then(@"I have selected '([^']*)' option")]
        public void ThenIHaveSelectedOption(string option)
        {
            changeDetailsPageWelsh?.SelectOption(option);
            _scenarioContext.Add("AreDetailsCorrect", option);
        }*/

        [When(@"I click on continue button from Are your details correct page in Welsh")]
        public void WhenIClickOnContinueButtonFromAreYourDetailsCorrectPageInWelsh()
        {
            changeDetailsPageWelsh?.ClickParhauButton();
        }

        /*[When(@"I captured Application PTD number")]
        public void WhenICapturedApplicationPTDNumber()
        {
            var summary = summaryPage?.GetSummaryDetails();
            _scenarioContext.Add("PTDNumber", summary.PTDNumber);
        }

        private void VerifyMicrodhipInformation(bool isSummaryPage = true)
        {
            var summary = isSummaryPage ? summaryPage?.GetSummaryDetails() : declarationPage?.GetSummaryDetails();
            var pageName = isSummaryPage ? "summary" : "declaration";

            var microchipNumber = _scenarioContext.Get<string>("MicrochipNumber");
            var microchippedDate = _scenarioContext.Get<string>("MicrochippedDate");

            Assert.AreEqual(microchipNumber, summary?.MicrochipNumber, $"Microchip number is not matching in {pageName} page!");
            Assert.AreEqual("Under the skin", summary?.ImplantLocation, $"Implant location is not matching in {pageName} page!");
            Assert.AreEqual(microchippedDate, summary?.ImplantOrScanDate, $"Implant or scan date is not matchin in {pageName} page!");
        }
        */
        private void VerifyPetsDetailsWelsh(bool isSummaryPage = true)
        {
            var summary = isSummaryPage ? summaryPageWelsh?.GetSummaryDetails() : declarationPageWelsh?.GetSummaryDetails();
            var pageName = isSummaryPage ? "summary" : "declaration";

            var petName = _scenarioContext.Get<string>("Enw");
            var petType = _scenarioContext.Get<string>("Rhywogaeth");

            var breed = petType.ToLower().Equals("Ffured") ? null : _scenarioContext.Get<string>("Brid");

            var sex = _scenarioContext.Get<string>("Rhyw");
            var dateOfBirth = _scenarioContext.Get<string>("Dyddiad geni");
            var color = _scenarioContext.Get<string>("Lliw");
            var significantFeatures = _scenarioContext.Get<string>("Nodweddion arwyddocaol");

            if (color.Equals("Other"))
            {
                color = _scenarioContext.Get<string>("OtherColor");
            }

            Assert.AreEqual(petName, summary?.PetName, $"Pet name is not matchin in {pageName} page!");
            Assert.AreEqual(petType, summary?.Species, $"Species is not matching in {pageName} page!");
            Assert.AreEqual(breed, summary?.Breed, $"Breed is not matching in {pageName} page!");
            Assert.AreEqual(sex, summary?.Sex, $"Sex is not matching in {pageName} page!");
            Assert.AreEqual(dateOfBirth, summary?.DateOfBirth, $"Date of birth is not matching in {pageName} page!");
            Assert.AreEqual(color, summary?.Colour, $"Color is not matching in {pageName} page!");
            Assert.AreEqual(significantFeatures, summary?.SignificantFeatures, $"Significant feature is not matching in {pageName} page!");
        }
        /*
        private void VerifyPetOwnerDetails(bool isSummaryPage = true)
        {
            var summary = isSummaryPage ? summaryPage?.GetSummaryDetails() : declarationPage?.GetSummaryDetails();
            var registeredUserDetails = changeDetailsPage?.GetRegisteredUserDetails();
            var pageName = isSummaryPage ? "summary" : "declaration";
            string[] address;
            var email = registeredUserDetails?.Email;

            var areDetailsCorrect = _scenarioContext.Get<string>("AreDetailsCorrect");

            string? fullName;
            string? phoneNumber;

            if (areDetailsCorrect.ToLower().Equals("yes"))
            {
                fullName = registeredUserDetails?.Name;
                address = registeredUserDetails?.Address?.Split(new string("\r\n"));
                phoneNumber = registeredUserDetails?.PhoneNumber;
            }
            else
            {
                fullName = _scenarioContext.Get<string>("FullName");
                address = _scenarioContext.Get<string[]>("Address");
                phoneNumber = _scenarioContext.Get<string>("PhoneNumber");
            }

            Assert.AreEqual(email, summary?.Email, $"Email is not matching in {pageName} page!");
            Assert.AreEqual(fullName, summary?.Name, $"Pet owner name is not matching in {pageName} page!");
            Assert.AreEqual(phoneNumber, summary?.PhoneNumber, $"Phone number is not matching in {pageName} page!");

            foreach (var lineItem in address)
            {
                Assert.IsTrue(summary?.Address.Contains(lineItem.Trim()), $"Address is not matching in {pageName} page!");
            }

            if (isSummaryPage)
            {
                var referenceNumber = _scenarioContext.Get<string>("ReferenceNumber");
                var date = DateTime.Now.ToString("dd/MM/yyyy");

                Assert.AreEqual(referenceNumber, summary?.ReferenceNumber, $"Reference number is not matching in {pageName} page!");
                Assert.AreEqual(date, summary?.Date, $"Microchip number is not matching in {pageName} page!");
            }
        }

        [Then(@"I should not see the application in the Dashboard")]
        public void ThenIShouldNotSeeTheApplicationInTheDashboard()
        {
            var petName = _scenarioContext.Get<string>("PetName");
            Assert.IsTrue(homePage?.VerifyTheApplicationIsNotAvailable(petName), $"The application is available in Dashboard!");
        }

        */
        [Then(@"I should see a table named '(.*)' with a column '(.*)' in approved document in Welsh")]
        public void ThenIShouldSeeATableNamedWithAColumnInApprovedDocument(string tableName, string columnName)
        {
            Assert.IsTrue(summaryPageWelsh?.VerifyIssuingAuthorityTable(tableName, columnName));
        }
        
        [Then(@"the address of authority should be '(.*)' '(.*)' in Welsh")]
        public void ThenTheAddressOfAuthorityShouldBe(string addressLine1, string addressLine2)
        {
            Assert.IsTrue(summaryPageWelsh?.VerifyIssuingAuthorityAddress(addressLine1, addressLine2));
        }
        
        [Then(@"I should see '(.*)' column with signed person name and designation in Welsh")]
        public void ThenIShouldSeeColumnWithSignedPersonNameAndDesignation(string signatureColName)
        {
            Assert.IsTrue(summaryPageWelsh?.VerifyIssuingAuthoritySignatureRow(signatureColName));
        }
        /*
        [Then(@"I verify the application status '(.*)'")]
        public void ThenIVerifyTheApplicationStatus(string status)
        {
            Assert.IsTrue(summaryPage?.VerifyApplicationStatus(status), "The status of the pet travel document is not correct");
        }

        [Then(@"I should not see print and download your application options")]
        public void ThenIShouldNotSeePrintAndDownloadYourApplicationOptions()
        {
            Assert.IsTrue(summaryPage?.VerifyPrintAndDownloadLinks(), "Print and Download links are visible");
        }

        [Then(@"I verify all the details in the summary page for pending or unsuccessful PTD '(.*)'")]
        public void ThenIVerifyAllTheDetailsInTheSummaryPageForPendingOrUnsuccessfulPTD(string status)
        {
            VerifyMicrodhipInformation(true);
            VerifyPetsDetails();
            VerifyPetOwnerDetails(true);
            Assert.IsTrue(summaryPage?.VerifyApplicationDetails(status), "The pet travel document details are not correct");
        }

        [Then(@"I verify all the details in the declaration page for cancelled PTD '(.*)'")]
        public void ThenIVerifyAllTheDetailsInTheDeclarationPageForCancelledPTD(string status)
        {
            VerifyMicrodhipInformation(true);
            VerifyPetsDetails();
            VerifyIssuedTable(true);
            Assert.IsTrue(summaryPage?.VerifyApplicationDetails(status), "The pet travel document details are not correct");
        }

        [Then(@"I verify all the details in the declaration page for approved PTD '(.*)'")]
        public void ThenIVerifyAllTheDetailsInTheDeclarationPageForApprovedPTD(string status)
        {
            VerifyMicrodhipInformation(true);
            VerifyPetsDetails();
            VerifyIssuedTable(true);
        }

        private void VerifyIssuedTable(bool isSummaryPage = true)
        {
            var summary = isSummaryPage ? summaryPage?.GetSummaryDetails() : declarationPage?.GetSummaryDetails();
            var registeredUserDetails = changeDetailsPage?.GetRegisteredUserDetails();
            var pageName = isSummaryPage ? "summary" : "declaration";

            if (isSummaryPage)
            {
                var ptdNumber = _scenarioContext.Get<string>("PTDReferenceNumber");
                var date = DateTime.Now.ToString("dd/MM/yyyy");
                string[] parts = summary?.PTDNumber.Split(' ');

                Assert.AreEqual(3, parts.Length);
                Assert.AreEqual(5, parts[0].Length);
                Assert.AreEqual(3, parts [1].Length);
                Assert.AreEqual (3, parts [2].Length);
                Assert.AreEqual(Regex.Replace(ptdNumber, @"\s+", ""), Regex.Replace(summary?.PTDNumber, @"\s+", ""), $"PTD number is not matching in {pageName} page!");
                Assert.AreEqual(date, summary?.Date, $"Date is not matching in {pageName} page!");
            }
        }

        [Then(@"I should not see issuing authority table")]
        public void ThenIShouldNotSeeIssuingAuthorityTable()
        {
            Assert.IsTrue(summaryPage?.VerifyIssuingAuthorityTableIsNotVisible());
        }*/

        [Then(@"I verify the status of the application '(.*)' in Welsh")]
        public void ThenIVerifyTheStatusOfTheApplicationInWelsh(string status)
        {
            Assert.IsTrue(summaryPageWelsh?.VerifyApplicationDetails(status), "The status of the PTD is not correct");
        }

       /* [When(@"I have clicked the first ptd view hyperlink from dashboard")]
        public void WhenIHaveClickedTheFirstPtdViewHyperlinkFromDashboard()
        {
            summaryPage?.ClickFirstViewHyperLink();
        }

        [Then(@"I have verified breed row for ferret is not displayed")]
        public void ThenIHaveVerifiedBreedRowForFerretIsNotDisplayed()
        {
            Assert.IsTrue(summaryPage?.VerifyBreedForFerret());
        }*/
    }
}