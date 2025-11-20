namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface IPetSexPageWelsh
    {
        bool IsNextPageLoaded(string pageTitle);
        void SelectPetsSexOption(string sexType);
        void ClickParhauButton();
        bool IsError(string errorMessage);
    }
}