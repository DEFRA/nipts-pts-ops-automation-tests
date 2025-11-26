namespace Defra.UI.Tests.Pages.WELSH.Interfaces
{
    public interface IPetOwnerPhoneNumberPageWelsh
    {

        bool IsNextPageLoaded(string pageTitle);
        void EnterPetOwnerPNumber(string phoneNumber);
        void ClickContinueButton();
        bool IsError(string errorMessage);
    }
}
