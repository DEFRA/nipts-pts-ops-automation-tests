using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class ManageAccountSteps
    {
        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly IManageAccountPage _manageAccountPage;
        private readonly IHomePage _homePage;
        private readonly IPetOwnerDetailsPage _petOwnerDetailsPage;

        public ManageAccountSteps(ScenarioContext context, IWebDriver driver, IManageAccountPage manageAccountPage, IHomePage homePage, IPetOwnerDetailsPage petOwnerDetailsPage)
        {
            _scenarioContext = context;
            _driver = driver;
            _manageAccountPage = manageAccountPage;
            _homePage = homePage;
            _petOwnerDetailsPage = petOwnerDetailsPage;

        }

        [Then(@"I click on Manage your account")]
        public void ThenIClickOnManageYourAccount()
        {
            _manageAccountPage?.ClickOnManageYourAccountLink();
        }

        [Then(@"I click on Update Details link")]
        public void ThenIClickOnUpdateDetails()
        {
            _manageAccountPage?.ClickOnUpdatedetailsLink();
        }

        [Then(@"I click on Change Personal Information link")]
        public void ThenIClickOnChangePersonalInformationLink()
        {
            _manageAccountPage?.ClickOnChangePersonalInformationLink();
        }

        [Then(@"I click on Change Personal Address link")]
        public void ThenIClickOnChangePersonalAddressLink()
        {
            _manageAccountPage?.ClickOnChangePersonalAddressLink();
        }

        [Then(@"I enter updated Phone number")]
        public void ThenIEnterUpdatedPhoneNumber()
        {
            var updatedPhoneNumber = Utils.GenerateRandomUKPhonenumber();
            _manageAccountPage?.EnterPhoneNumber(updatedPhoneNumber);
            _scenarioContext.Add("PhoneNumber", updatedPhoneNumber);
        }

        [Then(@"I click Continue")]
        public void ThenIClickContinue()
        {
            _manageAccountPage?.ClickContinue();
            _driver?.Wait(15); //wait is applied for the personal details updates to be reflected in pets application
        }

        [Then(@"I click on Back button in Pets Application")]
        [Then(@"I click on Back button")]
        public void ThenIClickOnBackButton()
        {
            _manageAccountPage?.ClickBackButton();
        }

        [Then(@"I go back to Pets application")]
        public void ThenIGoBackToPetsApplication()
        {
            _manageAccountPage?.ClickPetsLink();
        }

        [Then(@"I enter updated First Name")]
        public void ThenIEnterUpdatedFirstName()
        {
            var firstName = "Updated";
            _scenarioContext.Add("OriginalFirstName", _manageAccountPage?.EnterFirstName(firstName));

            _scenarioContext.Add("FirstName", firstName);
        }

        [Then(@"I enter updated Last Name")]
        public void ThenIEnterUpdatedLastName()
        {
            var lastName = "User";
            _scenarioContext.Add("LastName", lastName);
            _scenarioContext.Add("OriginalLastName", _manageAccountPage?.EnterLastName(lastName));
        }

        [Then(@"I revert the Pet Owner Name to the Original Name")]
        public void ThenIRevertThePetOwnerNameToTheOriginalName()
        {
            _manageAccountPage?.EnterFirstName(_scenarioContext.Get<string>("OriginalFirstName"));
            _manageAccountPage?.EnterLastName(_scenarioContext.Get<string>("OriginalLastName"));
            ThenIClickContinue();
            ThenIClickOnBackButton();
            ThenIGoBackToPetsApplication();
            _homePage?.ClickApplyForPetTravelDocument();
            string petOwnerName = _scenarioContext.Get<string>("OriginalFirstName") + " " + _scenarioContext.Get<string>("OriginalLastName");
            Assert.IsTrue(_petOwnerDetailsPage?.VerifyUpdatedName(petOwnerName));

        }

        [Then(@"I click on Search for my address by UK Postcode link")]
        public void ThenIClickOnSearchForMyAddressByUKPostcodeLink()
        {
            _scenarioContext.Add("ExistingPostcode", _manageAccountPage?.ClickOnSearchUKPostcodeLink());
        }

        [Then(@"I enter the valid ([^']*) Postcode")]
        public void ThenIEnterTheValidPostcode(string postcode)
        {
            string[] PostCode = postcode.Split(',');
            if (!PostCode[0].Equals(_scenarioContext.Get<string>("ExistingPostcode")))
            {
                _manageAccountPage?.EnterTheValidPostcode(PostCode[0]);
            }
            else
            {
                _manageAccountPage?.EnterTheValidPostcode(PostCode[1]);
            }
        }

        [Then(@"I click find address button")]
        public void ThenIClickFindAddressButton()
        {
            _manageAccountPage?.ClickFindAddressButton();
        }

        [Then(@"I select the address")]
        public void ThenISelectTheAddress()
        {
            _scenarioContext.Add("SelectedAddress", _manageAccountPage?.SelectTheAddress());
        }
    }
}