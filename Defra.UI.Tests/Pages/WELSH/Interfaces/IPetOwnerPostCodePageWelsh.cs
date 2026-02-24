namespace Defra.UI.Tests.Pages.WELSH.Interfaces
{
    public interface IPetOwnerPostCodePageWelsh
    {
        bool IsNextPageLoaded(string pageTitle);
        void EnterPetOwnerPostCode(string PostCode);
        void ClickFindAddressButton();
        void ClickManuallyAddressLink();
    }
}
