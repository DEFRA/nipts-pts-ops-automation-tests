namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface IPetSexPage
    {
        bool IsNextPageLoaded(string pageTitle);
        void SelectPetsSexOption(string sexType);
        void ClickContinueButton();
        bool IsError(string errorMessage);
    }
}