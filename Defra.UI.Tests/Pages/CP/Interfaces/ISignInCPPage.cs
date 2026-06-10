namespace Defra.UI.Tests.Pages.CP.Interfaces
{
    public interface ISignInCPPage
    {
        bool IsPageLoaded();
        void ClickSignInButton();
        void SignIn(string userName, string password);
        void EnterPassword();
        bool VerifyHeadings(string heading, string subHeading);
        bool VerifyAccessibilityLink(string accessbilityLink);
        void ClickAccessibilityLink();
        bool VerifyHeader(string header);
        bool VerifyHeadingOfThePage(string mainHeading);
        bool VerifySubHeadingsOfThePage();
        bool VerifyLinks();
    }
}