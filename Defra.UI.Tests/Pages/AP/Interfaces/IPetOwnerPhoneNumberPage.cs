namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface IPetOwnerPhoneNumberPage
    {
        bool IsNextPageLoaded(string pageTitle);
        void EnterPetOwnerPNumber(string phoneNumber);
        void ClickContinueButton();
        bool IsError(string errorMessage);
    }
}