namespace Defra.UI.Tests.Pages.AP.PetOwnerPostCodePage
{
    public interface IPetOwnerPostCodePage
    {
        bool IsNextPageLoaded(string pageTitle);
        void EnterPetOwnerPostCode(string PostCode);
        void ClickFindAddressButton();
        void ClickManuallyAddressLink();
    }
}