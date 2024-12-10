namespace Defra.UI.Tests.Pages.AP.LandingPage
{
    public interface ILandingPage
    {
        bool IsPageLoaded(string pageName);
        void EnterPassword();
        void ClickContinueButton();
    }
}
