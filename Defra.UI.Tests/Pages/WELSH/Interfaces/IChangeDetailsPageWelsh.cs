using Defra.UI.Tests.Contracts;

namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface IChangeDetailsPageWelsh
    {
        bool IsNextPageLoaded(string pageTitle);
        void ClickContinueButton();
        void SelectOption(string option);
        Summary GetRegisteredUserDetails();
    }
}
