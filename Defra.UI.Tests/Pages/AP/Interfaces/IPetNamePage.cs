namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface IPetNamePage
    {
        bool IsNextPageLoaded(string pageTitle);
        void ClickContinueButton();
        void EnterPetsName(string petsName);
        bool IsError(string errorMessage);
    }
}