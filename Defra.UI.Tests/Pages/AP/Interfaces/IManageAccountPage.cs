namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface IManageAccountPage
    {
        void ClickOnManageYourAccountLink();
        void ClickOnUpdatedetailsLink();
        void ClickOnChangePersonalInformationLink();
        void ClickOnChangePersonalAddressLink();
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
    }
}
