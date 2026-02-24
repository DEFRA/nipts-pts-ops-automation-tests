namespace Defra.UI.Tests.Pages.AP.Interfaces
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