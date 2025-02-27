namespace Defra.UI.Tests.Pages.CP.Interfaces
{
    public interface ISignInCPPage
    {
        bool IsPageLoaded();
        void ClickSignInButton();
        void SignIn(string userName, string password);
        void EnterPassword();
        bool VerifyHeadings(string heading, string subHeading);
    }
}