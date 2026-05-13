using Defra.UI.Tests.Contracts;

namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface ISummaryPageWelsh
    {
        bool IsNextPageLoaded(string pageTitle);
        Summary GetSummaryDetails();
        public void ClickPDFDownloadLink();
        public bool ClickPrintdLink();
        bool VerifyIssuingAuthorityTable(string tableName, string columnName);
        bool VerifyIssuingAuthorityAddress(string addressLine1, string addressLine2);
        bool VerifyApplicationStatus(string status);
        bool VerifyPrintAndDownloadLinks();
        bool VerifyApplicationDetails(string status);
        bool VerifyIssuingAuthorityTableIsNotVisible();
        void ClickFirstViewHyperLink();
        bool VerifyBreedForFerret();
        bool VerifyIssuingAuthoritySignatureRow(string signatureColName);
        void ClickBackButton();
    }
}