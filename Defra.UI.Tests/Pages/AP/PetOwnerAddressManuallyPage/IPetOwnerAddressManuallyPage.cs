namespace Defra.UI.Tests.Pages.AP.PetOwnerAddressManuallyPage
{
    public interface IPetOwnerAddressManuallyPage
    {
        bool IsNextPageLoaded(string pageTitle);
        void EnterAddressManually(string firstLine, string secondLine, string city, string county, string postCode);
        void ClickContinueButton();
    }
}