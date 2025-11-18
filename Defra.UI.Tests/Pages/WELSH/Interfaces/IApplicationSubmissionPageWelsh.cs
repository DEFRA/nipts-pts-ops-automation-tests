namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface IApplicationSubmissionPageWelsh
    {
        bool IsNextPageLoaded(string pageTitle);
        string GetApplicationReferenceNumber();
        void ClickApplyForAnotherPetTravelDocument();
        void ClickViewAllSubmittedPetTravelDocument();
    }
}