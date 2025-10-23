using Defra.UI.Tests.Contracts;

namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface ISummaryPage
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
    }
}