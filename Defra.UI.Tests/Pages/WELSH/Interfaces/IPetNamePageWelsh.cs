namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface IPetNamePageWelsh
    {
        bool IsNextPageLoaded(string pageTitle);
        void ClickContinueButton();
        void EnterPetsName(string petsName);
        bool IsError(string errorMessage);
    }
}