namespace Defra.UI.Tests.Pages.CP.Interfaces
{
    public interface IGBChecksReferralPage
    {
        bool IsPageLoaded(); 
        void ClickViewLink();
        void ClickPTDOrReferenceNumber();
        bool IsGBCheckReportPageLoaded();
    }
}