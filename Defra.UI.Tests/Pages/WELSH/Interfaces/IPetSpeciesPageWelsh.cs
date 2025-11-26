namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface IPetSpeciesPageWelsh
    {
        bool IsNextPageLoaded(string pageTitle);
        void SelectSpecies(string petCategory);
        void ClickParhauButton();
        bool IsError(string errorMessage);
    }
}