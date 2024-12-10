namespace Defra.UI.Tests.Pages.AP.PetSpeciesPage
{
    public interface IPetSpeciesPage
    {
        bool IsNextPageLoaded(string pageTitle);
        void SelectSpecies(string petCategory);
        void ClickContinueButton();
        bool IsError(string errorMessage);
    }
}