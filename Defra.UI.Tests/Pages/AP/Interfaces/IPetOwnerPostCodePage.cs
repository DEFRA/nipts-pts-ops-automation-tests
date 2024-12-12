namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface IPetOwnerPostCodePage
    {
        bool IsNextPageLoaded(string pageTitle);
        void EnterPetOwnerPostCode(string PostCode);
        void ClickFindAddressButton();
        void ClickManuallyAddressLink();
    }
}