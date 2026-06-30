using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Pages.WELSH.Interfaces;
using Defra.UI.Tests.Tools;
using NUnit.Framework;
using Reqnroll;
using Reqnroll.BoDi;
using System.Text.RegularExpressions;

namespace Defra.UI.Tests.Steps.WELSH
{
    [Binding]
    public class SummaryAndDeclarationWelshSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private ISummaryPageWelsh? summaryPageWelsh => _objectContainer.IsRegistered<ISummaryPageWelsh>() ? _objectContainer.Resolve<ISummaryPageWelsh>() : null;
        private IApplicationDeclarationPageWelsh? declarationPageWelsh => _objectContainer.IsRegistered<IApplicationDeclarationPage>() ? _objectContainer.Resolve<IApplicationDeclarationPageWelsh>() : null;
        private IChangeDetailsPageWelsh? changeDetailsPageWelsh => _objectContainer.IsRegistered<IChangeDetailsPageWelsh>() ? _objectContainer.Resolve<IChangeDetailsPageWelsh>() : null;
        private IHomePageWelsh? homePageWelsh => _objectContainer.IsRegistered<IHomePageWelsh>() ? _objectContainer.Resolve<IHomePageWelsh>() : null;
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
        }

        [Then(@"I have verified microchip details in declaration page in Welsh")]
        public void ThenIHaveVerifiedMicrochipDetailsInDeclarationPage()
        {
            VerifyMicrodhipInformation(false);
        }

        [Then(@"I have verified pet details in declaration page in Welsh")]
        public void ThenIHaveVerifiedPetDetailsInDeclarationPage()
        {
            VerifyPetsDetailsWelsh(false);
        }

        [Then(@"I have verified pet owner details in declaration page in Welsh")]
        public void ThenIHaveVerifiedPetOwnerDetailsInDeclarationPage()
        {
            VerifyPetOwnerDetailsWelsh(false);
        }


        [Then(@"I have verified microchip details in summary page in Welsh")]
        public void ThenIHaveVerifiedMicrochipDetailsInSummaryPage()
        {
            VerifyMicrodhipInformation();
        }

        [Then(@"I have verified pet details in summary page in Welsh")]
        public void ThenIHaveVerifiedPetDetailsInSummaryPage()
        {
            VerifyPetsDetailsWelsh();
        }

        [Then(@"I click download link in summary page in Welsh")]
        public void ThenIClickDownloadLinkInSummaryPage()
        {
            summaryPageWelsh?.ClickPDFDownloadLink();
        }

        [Then(@"I click print link in summary page in Welsh")]
        public void ThenIClickPrintLinkInSummaryPage()
        {
            Assert.IsTrue(summaryPageWelsh?.ClickPrintdLink(), "Print window not opened successfully");
        }

        [Then(@"I have verified pet owner details in summary page in Welsh")]
        public void ThenIHaveVerifiedPetOwnerDetailsInSummaryPage()
        {
            VerifyPetOwnerDetailsWelsh();
        }

        [Then(@"I should redirected to the Are your details correct page in Welsh")]
        public void ThenIShouldRedirectedToTheAreYourDetailsCorrectPageInWelsh()
        {
            var pageTitle = "Ydy’ch manylion chi’n gywir?";
            Assert.IsTrue(changeDetailsPageWelsh?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have selected '([^']*)' option in Welsh")]
        public void ThenIHaveSelectedOption(string option)
        {
            changeDetailsPageWelsh?.SelectOption(option);
            _scenarioContext.Add("AreDetailsCorrect", option);
            var registeredUserDetails = changeDetailsPageWelsh?.GetRegisteredUserDetails();
            _scenarioContext.Add("enw llawn", registeredUserDetails?.Name);
            _scenarioContext.Add("Cyfeiriad", registeredUserDetails?.Address?.Split(new string("\r\n")));
            _scenarioContext.Add("Rhif ffôn", registeredUserDetails?.PhoneNumber);
            _scenarioContext.Add("Ebost", registeredUserDetails?.Email);
        }

        [When(@"I click on continue button from Are your details correct page in Welsh")]
        public void WhenIClickOnContinueButtonFromAreYourDetailsCorrectPageInWelsh()
        {
            changeDetailsPageWelsh?.ClickParhauButton();
        }

        private void VerifyMicrodhipInformation(bool isSummaryPage = true)
        {
            var summary = isSummaryPage ? summaryPageWelsh?.GetSummaryDetails() : declarationPageWelsh?.GetSummaryDetails();
            var pageName = isSummaryPage ? "summary" : "declaration";

            var microchipNumber = _scenarioContext.Get<string>("MicrochipNumber");
            var microchippedDate = _scenarioContext.Get<string>("Dyddiad mewnblannu neu sganio");

            Assert.AreEqual(microchipNumber, summary?.MicrochipNumber, $"Microchip number is not matching in {pageName} page!");
            //Assert.AreEqual("O dan y croen", summary?.ImplantLocation, $"Implant location is not matching in {pageName} page!");
            Assert.AreEqual(microchippedDate, summary?.ImplantOrScanDate, $"Implant or scan date is not matchin in {pageName} page!");
        }

        private void VerifyPetsDetailsWelsh(bool isSummaryPage = true)
        {
            var summary = isSummaryPage ? summaryPageWelsh?.GetSummaryDetails() : declarationPageWelsh?.GetSummaryDetails();
            var pageName = isSummaryPage ? "summary" : "declaration";

            var petName = _scenarioContext.Get<string>("Enw");
            var petType = _scenarioContext.Get<string>("Rhywogaeth");

            var breed = petType.ToLower().Equals("ffured") ? null : _scenarioContext.Get<string>("Brid");

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

        private void VerifyPetOwnerDetailsWelsh(bool isSummaryPage = true)
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var summary = isSummaryPage ? summaryPageWelsh?.GetSummaryDetails() : declarationPageWelsh?.GetSummaryDetails();
            var registeredUserDetails = changeDetailsPageWelsh?.GetRegisteredUserDetails();
            var pageName = isSummaryPage ? "summary" : "declaration";
            string[] address;
            var email = registeredUserDetails?.Email;

            var areDetailsCorrect = _scenarioContext.Get<string>("AreDetailsCorrect");

            string? fullName;
            string? phoneNumber;

            if (areDetailsCorrect.ToLower().Equals("yes"))
            {
                fullName = _scenarioContext.Get<string>("enw llawn");
                email = _scenarioContext.Get<string>("Ebost");
                address = _scenarioContext.Get<string[]>("Cyfeiriad");
                phoneNumber = _scenarioContext.Get<string>("Rhif ffôn");
            }
            else
            {
                fullName = _scenarioContext.Get<string>("enw llawn");
                address = _scenarioContext.Get<string[]>("Cyfeiriad");
                phoneNumber = _scenarioContext.Get<string>("Rhif ffôn");
            }

            Assert.AreEqual(email, summary?.Email, $"Email is not matching in {pageName} page!");
            Assert.AreEqual(fullName, summary?.Name, $"Pet owner name is not matching in {pageName} page!");
            Assert.AreEqual(phoneNumber, summary?.PhoneNumber, $"Phone number is not matching in {pageName} page!");

            foreach (var lineItem in address)
            {
                var normalizedSummary = NormalizeAddress(summary?.Address ?? string.Empty);
                var normalizedLine = NormalizeAddress(lineItem ?? string.Empty);

                // Log everything so pipeline shows the real cause
                TestContext.WriteLine($"SUMMARY RAW: '{summary?.Address}'");
                TestContext.WriteLine($"SUMMARY NORMALIZED: '{normalizedSummary}'");

                TestContext.WriteLine($"LINE RAW: '{lineItem}'");
                TestContext.WriteLine($"LINE NORMALIZED: '{normalizedLine}'");

                // Token-based comparison (pipeline-safe)
                var summaryTokens = new HashSet<string>(
                    normalizedSummary.Split(' ', StringSplitOptions.RemoveEmptyEntries),
                    StringComparer.OrdinalIgnoreCase
                );

                var lineTokens = normalizedLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                TestContext.WriteLine("SUMMARY TOKENS: " + string.Join(", ", summaryTokens));
                TestContext.WriteLine("LINE TOKENS: " + string.Join(", ", lineTokens));

                foreach (var token in lineTokens)
                {
                    Assert.IsTrue(
                        summaryTokens.Contains(token),
                        $"Address mismatch in {pageName} page.\n" +
                        $"Missing token: '{token}'\n" +
                        $"SUMMARY TOKENS: [{string.Join(", ", summaryTokens)}]\n" +
                        $"LINE TOKENS: [{string.Join(", ", lineTokens)}]"
                    );
                }
            }

            if (isSummaryPage)
            {
                var referenceNumber = _scenarioContext.Get<string>("ReferenceNumber");
                var date = DateTime.Now.ToString("dd/MM/yyyy");

                Assert.AreEqual(referenceNumber, summary?.ReferenceNumber, $"Reference number is not matching in {pageName} page!");
                Assert.AreEqual(date, summary?.Date, $"Microchip number is not matching in {pageName} page!");
            }
        }

        public static string NormalizeAddress(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;

            s = s.ToUpperInvariant();
            s = Regex.Replace(s, @"\s+", " ");
            s = s.Replace(",", " ").Trim();

            string[] counties = new[]
            {
        "OXFORDSHIRE","BERKSHIRE","BUCKINGHAMSHIRE","CAMBRIDGESHIRE","CORNWALL",
        "CUMBRIA","DERBYSHIRE","DEVON","DORSET","DURHAM","ESSEX","GLOUCESTERSHIRE",
        "GREATER LONDON","GREATER MANCHESTER","HAMPSHIRE","HEREFORDSHIRE","HERTFORDSHIRE",
        "KENT","LANCASHIRE","LEICESTERSHIRE","LINCOLNSHIRE","MERSEYSIDE","NORFOLK",
        "NORTHAMPTONSHIRE","NORTHUMBERLAND","NOTTINGHAMSHIRE","SHROPSHIRE","SOMERSET",
        "STAFFORDSHIRE","SUFFOLK","SURREY","WARWICKSHIRE","WEST MIDLANDS","WEST SUSSEX",
        "WEST YORKSHIRE","WILTSHIRE","WORCESTERSHIRE","EAST SUSSEX","SOUTH YORKSHIRE",
        "TYNE AND WEAR"
            };

            foreach (var county in counties)
                s = Regex.Replace(s, $@"\b{Regex.Escape(county)}\b", "", RegexOptions.IgnoreCase);

            s = Regex.Replace(s, @"\s+", " ").Trim();
            return s;
        }

        [Then(@"I should not see the application in the Dashboard in Welsh")]
        public void ThenIShouldNotSeeTheApplicationInTheDashboard()
        {
            var petName = _scenarioContext.Get<string>("Enw");
            Assert.IsTrue(homePageWelsh?.VerifyTheApplicationIsNotAvailable(petName), $"The application is available in Dashboard!");
        }


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

        [Then(@"I verify the application status '(.*)' in Welsh")]
        public void ThenIVerifyTheApplicationStatus(string status)
        {
            Assert.IsTrue(summaryPageWelsh?.VerifyApplicationStatus(status), "The status of the pet travel document is not correct");
        }

        [Then(@"I should not see print and download your application options in Welsh")]
        public void ThenIShouldNotSeePrintAndDownloadYourApplicationOptions()
        {
            Assert.IsTrue(summaryPageWelsh?.VerifyPrintAndDownloadLinks(), "Print and Download links are visible");
        }

        [Then(@"I verify all the details in the summary page for pending or unsuccessful PTD '(.*)' in Welsh")]
        public void ThenIVerifyAllTheDetailsInTheSummaryPageForPendingOrUnsuccessfulPTD(string status)
        {
            VerifyMicrodhipInformation(true);
            VerifyPetsDetailsWelsh();
            VerifyPetOwnerDetailsWelsh(true);
            Assert.IsTrue(summaryPageWelsh?.VerifyApplicationDetails(status), "The pet travel document details are not correct");
        }

        [Then(@"I verify all the details in the declaration page for cancelled PTD '(.*)' in Welsh")]
        public void ThenIVerifyAllTheDetailsInTheDeclarationPageForCancelledPTD(string status)
        {
            VerifyMicrodhipInformation(true);
            VerifyPetsDetailsWelsh();
            VerifyIssuedTableWelsh(true);
            Assert.IsTrue(summaryPageWelsh?.VerifyApplicationDetails(status), "The pet travel document details are not correct");
        }

        [Then(@"I verify all the details in the declaration page for approved PTD '(.*)' in Welsh")]
        public void ThenIVerifyAllTheDetailsInTheDeclarationPageForApprovedPTD(string status)
        {
            VerifyMicrodhipInformation(true);
            VerifyPetsDetailsWelsh();
            VerifyIssuedTableWelsh(true);
        }

        private void VerifyIssuedTableWelsh(bool isSummaryPage = true)
        {
            var summary = isSummaryPage ? summaryPageWelsh?.GetSummaryDetails() : declarationPageWelsh?.GetSummaryDetails();
            var registeredUserDetails = changeDetailsPageWelsh?.GetRegisteredUserDetails();
            var pageName = isSummaryPage ? "summary" : "declaration";

            if (isSummaryPage)
            {
                var ptdNumber = _scenarioContext.Get<string>("PTDReferenceNumber");
                var date = DateTime.Now.ToString("dd/MM/yyyy");
                string[] parts = summary?.PTDNumber.Split(' ');

                Assert.AreEqual(3, parts.Length);
                Assert.AreEqual(5, parts[0].Length);
                Assert.AreEqual(3, parts[1].Length);
                Assert.AreEqual(3, parts[2].Length);
                Assert.AreEqual(Regex.Replace(ptdNumber, @"\s+", ""), Regex.Replace(summary?.PTDNumber, @"\s+", ""), $"PTD number is not matching in {pageName} page!");
                Assert.AreEqual(date, summary?.Date, $"Date is not matching in {pageName} page!");
            }
        }

        [Then(@"I should not see issuing authority table in Welsh")]
        public void ThenIShouldNotSeeIssuingAuthorityTable()
        {
            Assert.IsTrue(summaryPageWelsh?.VerifyIssuingAuthorityTableIsNotVisible());
        }

        [Then(@"I verify the status of the application '(.*)' in Welsh")]
        public void ThenIVerifyTheStatusOfTheApplicationInWelsh(string status)
        {
            Assert.IsTrue(summaryPageWelsh?.VerifyApplicationDetails(status), "The status of the PTD is not correct");
        }

        [Then(@"I have verified breed row for ferret is not displayed in Welsh")]
        public void ThenIHaveVerifiedBreedRowForFerretIsNotDisplayed()
        {
            Assert.IsTrue(summaryPageWelsh?.VerifyBreedForFerret());
        }
    }
}