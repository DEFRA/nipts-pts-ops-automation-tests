using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.AP.PetOwnerAddressPage
{
    public interface IPetOwnerAddressPage
    {
        bool IsNextPageLoaded(string pageTitle);
        void EnterPostCode(string postCode);
        bool IsAddressListFound();
        string[] SelectAnAddress(int index);
        void ClickContinueButton();
        void ClickSearchButton();
        void ClickEnterAddressManuallyLink();
        void EnterAddressManually(string addressLine1, string addressLine2, string town, string county, string postCode);
        bool IsError(string errorMessage);
    }
}