namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface IPetBreedPage
    {
        bool IsNextPageLoaded(string pageTitle);
        string SelectPetsBreed(int breedIndex, bool isUpdate = false);
        void ClickContinueButton();
        void EnterFreeTextBreed(string breed);
        bool IsError(string errorMessage);
    }
}