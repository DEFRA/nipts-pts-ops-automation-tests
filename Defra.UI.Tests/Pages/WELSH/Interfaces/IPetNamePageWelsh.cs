namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface IPetNamePageWelsh
    {
        bool IsNextPageLoaded(string pageTitle);
        void ClickParhauButton();
        void EnterPetsName(string petsName);
        bool IsError(string errorMessage);
    }
}