namespace Defra.UI.Tests.Pages.CP.Interfaces
{
    public interface ISignInCPPage
    {
        void ClickSignInButton();
        bool IsSignedIn(string userName, string password);
        void EnterPassword();
    }
}