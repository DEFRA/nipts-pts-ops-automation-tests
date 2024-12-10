namespace Defra.UI.Tests.Pages.AP.PetBreedPage
{
    public interface IPetBreedPage
    {
        bool IsNextPageLoaded(string pageTitle);
        string SelectPetsBreed(int breedIndex);
        void ClickContinueButton();
        void EnterFreeTextBreed(string breed);
        bool IsError(string errorMessage);
    }
}