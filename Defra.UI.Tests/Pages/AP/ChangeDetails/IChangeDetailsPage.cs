using Defra.UI.Tests.Contracts;

namespace Defra.UI.Tests.Pages.AP.ChangeDetails
{
    public interface IChangeDetailsPage
    {
        bool IsNextPageLoaded(string pageTitle);
        void ClickContinueButton();
        void SelectOption(string option);
        Summary GetRegisteredUserDetails();
    }
}
