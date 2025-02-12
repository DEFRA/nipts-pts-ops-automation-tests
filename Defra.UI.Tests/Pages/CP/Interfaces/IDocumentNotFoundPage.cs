namespace Defra.UI.Tests.Pages.CP.Interfaces
{
    public interface IDocumentNotFoundPage
    {
        void ClickGoBackToSearchLink();
        bool IsPageLoaded();
        bool VerifyGoBackLink();
        bool VerifyMessage(string appNumber);
    }
}