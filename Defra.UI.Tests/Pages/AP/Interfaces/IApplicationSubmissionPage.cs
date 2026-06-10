namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface IApplicationSubmissionPage
    {
        bool IsNextPageLoaded(string pageTitle);
        string GetApplicationReferenceNumber();
        void ClickApplyForAnotherPetTravelDocument();
        void ClickViewAllSubmittedPetTravelDocument();
    }
}