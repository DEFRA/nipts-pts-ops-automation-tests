namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface ISignificantFeaturesPage
    {
        bool IsNextPageLoaded(string pageTitle);
        string SelectSignificantFeaturesOption(string featuresOption);
        void ClickContinueButton();
        bool IsError(string errorMessage);
        void EnterSignificantFeatures(string significantFeatures);
    }
}