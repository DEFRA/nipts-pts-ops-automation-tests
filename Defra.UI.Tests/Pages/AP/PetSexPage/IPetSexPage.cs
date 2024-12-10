namespace Defra.UI.Tests.Pages.AP.PetSexPage
{
    public interface IPetSexPage
    {
        bool IsNextPageLoaded(string pageTitle);
        void SelectPetsSexOption(string sexType);
        void ClickContinueButton();
        bool IsError(string errorMessage);
    }
}