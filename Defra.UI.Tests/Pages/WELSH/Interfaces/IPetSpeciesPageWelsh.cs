namespace Defra.UI.Tests.Pages.WELSH.Interfaces
{
    public interface IPetSpeciesPageWelsh
    {
        bool IsNextPageLoaded(string pageTitle);
        void SelectSpecies(string petCategory);
        void ClickParhauButton();
        bool IsError(string errorMessage);
    }
}