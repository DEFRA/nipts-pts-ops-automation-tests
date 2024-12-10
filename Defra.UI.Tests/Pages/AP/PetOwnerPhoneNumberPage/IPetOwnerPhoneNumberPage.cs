namespace Defra.UI.Tests.Pages.AP.PetOwnerPhoneNumberPage
{
    public interface IPetOwnerPhoneNumberPage
    {
        bool IsNextPageLoaded(string pageTitle);
        void EnterPetOwnerPNumber(string phoneNumber);
        void ClickContinueButton();
        bool IsError(string errorMessage);
    }
}