namespace Defra.UI.Tests.Pages.CP.Interfaces
{
    public interface IUpdateReferralOutcomePage
    {
        bool IsPageLoaded();
        void EnterDetailsOfOutcome(string outcome);
        void ClickSave();
        void ClickNotAllowed();
        void ClickAllowed();
    }
}
