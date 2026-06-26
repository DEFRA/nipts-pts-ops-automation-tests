namespace Defra.UI.Tests.Pages.WELSH.Interfaces
{
    public interface IPetMicrochipPageWelsh
    {
        bool IsNextPageLoaded(string pageTitle);
        void SelectMicrochippedOption(string option);
        string EnterMicrochipNumber();
        string EnterGivenMicrochipNumber(string microChipNumber);
        void UpdateMicrochipNumber(string microChipNumber);
        void ClickParhauButton();
        bool IsError(string errorMessage);
        bool VerifyAlreadyEnteredMCNumber(string alreadyEnteredMCNumber);
        void ClickGoBackToThePreviousPageLink();
    }
}