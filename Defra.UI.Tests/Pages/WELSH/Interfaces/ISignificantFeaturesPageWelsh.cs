namespace Defra.UI.Tests.Pages.WELSH.Interfaces
{
    public interface ISignificantFeaturesPageWelsh
    {
        bool IsNextPageLoaded(string pageTitle);
        string SelectSignificantFeaturesOption(string featuresOption);
        void ClickParhauButton();
        bool IsError(string errorMessage);
        void EnterSignificantFeatures(string significantFeatures);
    }
}