namespace Defra.UI.Tests.Pages.WELSH.Interfaces
{
    public interface IPetColourPageWelsh
    {
        bool IsNextPageLoaded(string pageTitle);
        void SelectColorOption(string color);
        void SelectOtherColorOption(string color);
        void ClickParhauButton();
        bool IsError(string errorMessage);
    }
}