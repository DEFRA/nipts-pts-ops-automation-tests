namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface IPetBreedPageWelsh
    {
        bool IsNextPageLoaded(string pageTitle);
        string SelectPetsBreed(int breedIndex, bool isUpdate = false);
        void ClickParhauButton();
        void EnterFreeTextBreed(string breed);
        bool IsError(string errorMessage);
        bool VerifyBreedsList(string species);
    }
}