namespace Defra.UI.Tests.Pages.CP.Interfaces
{
    public interface IWelcomePage
    {
        bool IsPageLoaded();
        void FooterSearchButton();
        void HeadersChangeLink();
        void FooterHomeIcon();
        bool IsBackButtonDisplayed();
        void ClickBackButton();
        bool CheckFooter();
        bool CheckHeader();
        bool IsHeaderChangeLinkDisplayed();
        bool IsConfirmationBoxDisplayed();
        bool CheckFlightHomePageContent(string content, string contentList1, string contentList2, string contentList3);
        bool ChecksPageRouteFilter(string selectedRoute);
        bool SailingDetailsInChecksPageTables();
        void OpenNewTab();
    }
}