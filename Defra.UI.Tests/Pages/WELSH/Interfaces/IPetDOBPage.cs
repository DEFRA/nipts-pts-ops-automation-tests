namespace Defra.UI.Tests.Pages.WELSH.Interfaces
{
    public interface IPetDOBPageWelsh
    {
        bool IsNextPageLoaded(string pageTitle);
        string EnterDateMonthYear(DateTime dateTime);
        void ClickParhauButton();
        bool IsError(string errorMessage);
        void EnterPetDateOfBirth(string day, string month, string year);
    }
}