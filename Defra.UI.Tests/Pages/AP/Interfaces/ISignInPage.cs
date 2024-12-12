namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface ISignInPage
    {
        public bool IsPageLoaded();
        public bool IsSignedIn(string userName, string password);
        public void ClickCreateSignInDetailsLink();
        public void ClickSignedOut();
        public bool IsSignedOut();
        public bool IsSuccessfullySignedOut();
        public void SignInToDynamics(string username, string password);
    }
}
