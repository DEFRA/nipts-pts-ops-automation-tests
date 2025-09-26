namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface IGovernmentGatewayTypePage
    {
        bool IsPageLoaded(string pageName);
        void SelectLoginType(string loginType);
        void ClickContinueButton();
    }
}
