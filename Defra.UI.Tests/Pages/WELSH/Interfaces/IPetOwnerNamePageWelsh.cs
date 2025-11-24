namespace Defra.UI.Tests.Pages.WELSH.Interfaces
{
    public interface IPetOwnerNamePageWelsh
    {
        bool IsNextPageLoaded(string pageTitle);
        void EnterPetOwnerName(string onwerName);
        void ClickContinueButton();
        bool IsError(string errorMessage);
    }
}