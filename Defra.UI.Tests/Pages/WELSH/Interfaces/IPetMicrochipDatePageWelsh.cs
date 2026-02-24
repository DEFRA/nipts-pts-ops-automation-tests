namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface IPetMicrochipDatePageWelsh
    {
        bool IsNextPageLoaded(string pageTitle);
        string EnterDateMonthYear(DateTime dateTime);
        void ClickParhauButton();
        bool IsError(string errorMessage);
        void EnterMicrochippedDate(string day, string month, string year);
    }
}