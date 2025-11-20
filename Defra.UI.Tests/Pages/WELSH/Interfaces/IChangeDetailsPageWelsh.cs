using Defra.UI.Tests.Contracts;

namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface IChangeDetailsPageWelsh
    {
        bool IsNextPageLoaded(string pageTitle);
        void ClickParhauButton();
        void SelectOption(string option);
        Summary GetRegisteredUserDetails();

    }
}
