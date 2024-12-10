using Defra.UI.Tests.Contracts;

namespace Defra.UI.Tests.Pages.AP.ApplicationDeclarationPage
{
    public interface IApplicationDeclarationPage
    {
        bool IsNextPageLoaded(string pageTitle);
        void TickAgreedToDeclaration();
        void ClickSendApplicationButton();
        Summary GetSummaryDetails();
        void ClickMicrochipChangeLink(string fieldName);
        void ClickPetDetailsChangeLink(string fieldName);
        void ClickPetOwnerChangeLink(string fieldName);
        void ClickPetDetailsChangeForFerretLink(string fieldName);
    }
}