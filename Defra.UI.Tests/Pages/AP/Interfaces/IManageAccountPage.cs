namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface IManageAccountPage
    {
        void ClickOnManageYourAccountLink();
        void ClickOnManageAccountLink();
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
