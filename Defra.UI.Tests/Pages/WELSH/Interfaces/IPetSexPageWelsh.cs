namespace Defra.UI.Tests.Pages.WELSH.Interfaces
{
    public interface IPetSexPageWelsh
    {
        bool IsNextPageLoaded(string pageTitle);
        void SelectPetsSexOption(string sexType);
        void ClickParhauButton();
        bool IsError(string errorMessage);
    }
}