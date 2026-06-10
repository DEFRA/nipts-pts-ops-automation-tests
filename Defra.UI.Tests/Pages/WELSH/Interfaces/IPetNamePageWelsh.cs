namespace Defra.UI.Tests.Pages.WELSH.Interfaces
{
    public interface IPetNamePageWelsh
    {
        bool IsNextPageLoaded(string pageTitle);
        void ClickParhauButton();
        void EnterPetsName(string petsName);
        bool IsError(string errorMessage);
    }
}