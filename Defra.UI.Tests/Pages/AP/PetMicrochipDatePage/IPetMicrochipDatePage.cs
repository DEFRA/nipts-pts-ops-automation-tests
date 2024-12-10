namespace Defra.UI.Tests.Pages.AP.PetMicrochipDatePage
{
    public interface IPetMicrochipDatePage
    {
        bool IsNextPageLoaded(string pageTitle);
        string EnterDateMonthYear(DateTime dateTime);
        void ClickContinueButton();
        bool IsError(string errorMessage);
    }
}