namespace Defra.UI.Tests.Pages.WELSH.Interfaces
{
    public interface IPetOwnerAddressManuallyPageWelsh
    {
        bool IsNextPageLoaded(string pageTitle);
        void EnterAddressManually(string firstLine, string secondLine, string city, string county, string postCode);
        void ClickContinueButton();
    }
}
