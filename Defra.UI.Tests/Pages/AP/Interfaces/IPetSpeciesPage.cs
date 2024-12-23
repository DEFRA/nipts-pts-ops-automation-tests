namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface IPetSpeciesPage
    {
        bool IsNextPageLoaded(string pageTitle);
        void SelectSpecies(string petCategory);
        void ClickContinueButton();
        bool IsError(string errorMessage);
    }
}