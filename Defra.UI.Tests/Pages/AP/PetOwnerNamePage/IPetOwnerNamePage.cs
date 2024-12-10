namespace Defra.UI.Tests.Pages.AP.PetOwnerNamePage
{
    public interface IPetOwnerNamePage
    {
        bool IsNextPageLoaded(string pageTitle);
        void EnterPetOwnerName(string onwerName);
        void ClickContinueButton();
        bool IsError(string errorMessage);
    }
}