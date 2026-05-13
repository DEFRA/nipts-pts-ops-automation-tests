namespace Defra.UI.Tests.Pages.WELSH.Interfaces
{
    public interface IManageAccountPageWelsh
    {
        void ClickOnManageYourAccountLink();
        void ClickOnManageAccountLink();
        void VerifyPageContent();
        void ClickOnUpdatedetailsLink();
        void ClickOnChangePersonalInformationLink();
        void EnterPhoneNumber(string phoneNumber);
        void ClickContinue();
        void ClickBackButton();
        void ClickPetsLink();
        string EnterFirstName(string firstName);
        string EnterLastName(string surname);
        string ClickOnSearchUKPostcodeLink();
        void EnterTheValidPostcode(string postcode);
        void ClickFindAddressButton();
        string SelectTheAddress();
        void ClickNameChange();
        void ClickTelePhoneNmmnerChange();
        void ClickAddressChange();
    }
}
