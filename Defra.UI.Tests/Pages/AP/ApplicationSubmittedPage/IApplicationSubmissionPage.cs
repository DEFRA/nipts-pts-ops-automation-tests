namespace Defra.UI.Tests.Pages.AP.ApplicationSubmittedPage
{
    public interface IApplicationSubmissionPage
    {
        bool IsNextPageLoaded(string pageTitle);
        string GetApplicationReferenceNumber();
        void ClickApplyForAnotherPetTravelDocument();
        void ClickViewAllSubmittedPetTravelDocument();
    }
}