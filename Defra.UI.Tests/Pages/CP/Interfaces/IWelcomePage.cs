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
        bool IsHeaderChangeLinkDisplayed();
        bool IsConfirmationBoxDisplayed();
    }
}