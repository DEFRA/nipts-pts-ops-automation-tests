namespace Defra.UI.Tests.Pages.AP.PetOwnerDetailsPage
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