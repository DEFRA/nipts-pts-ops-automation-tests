using Defra.UI.Tests.Contracts;

namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface ISummaryPage
    {
        bool IsNextPageLoaded(string pageTitle);
        Summary GetSummaryDetails();
        public void ClickPDFDownloadLink();
        public bool ClickPrintdLink();
    }
}