namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface IPetOwnerDetailsPage
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