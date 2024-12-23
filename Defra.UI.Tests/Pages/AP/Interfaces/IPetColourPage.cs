namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface IPetColourPage
    {
        bool IsNextPageLoaded(string pageTitle);
        void SelectColorOption(string color);
        void SelectOtherColorOption(string color);
        void ClickContinueButton();
        bool IsError(string errorMessage);
    }
}