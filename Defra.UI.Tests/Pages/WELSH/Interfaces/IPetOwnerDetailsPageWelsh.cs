namespace Defra.UI.Tests.Pages.WELSH.Interfaces
{
    public interface IPetOwnerDetailsPageWelsh
    {
        bool IsNextPageLoaded(string pageTitle);
        void ClickContinueButton();
        void SelectIsOwnerDetailsCorrect(string petsOwnerDetails);
        bool VerifyUpdatedPhoneNumber(string phoneNumber);
        bool VerifyUpdatedName(string petOwnerName);
        bool VerifyUpdatedPetOwnerAddress(string petOwnerAddress);
        public bool IsError(string errorMessage);
    }
}
