namespace Defra.UI.Tests.Pages.AP.PetDOBPage
{
    public interface IPetDOBPage
    {
        bool IsNextPageLoaded(string pageTitle);
        string EnterDateMonthYear(DateTime dateTime);
        void ClickContinueButton();
        bool IsError(string errorMessage);
    }
}