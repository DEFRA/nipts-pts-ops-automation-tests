namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface ILandingPage
    {
        bool IsPageLoaded(string pageName);
        void EnterPassword();
        void ClickContinueButton();
    }
}
