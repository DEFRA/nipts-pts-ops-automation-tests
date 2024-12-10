﻿using BoDi;
using Defra.UI.Tests.Pages.AP.HomePage;
using Defra.UI.Tests.Pages.AP.ManageAccountPage;
using Defra.UI.Tests.Pages.AP.PetOwnerDetailsPage;
using Defra.UI.Tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class ManageAccountSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IManageAccountPage? ManageAccountPage => _objectContainer.IsRegistered<IManageAccountPage>() ? _objectContainer.Resolve<IManageAccountPage>() : null;
        private IHomePage? homePage => _objectContainer.IsRegistered<IHomePage>() ? _objectContainer.Resolve<IHomePage>() : null;
        private IPetOwnerDetailsPage? PetOwnerDetailsPage => _objectContainer.IsRegistered<IPetOwnerDetailsPage>() ? _objectContainer.Resolve<IPetOwnerDetailsPage>() : null;

        public ManageAccountSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I click on Manage your account")]
        public void ThenIClickOnManageYourAccount()
        {
            ManageAccountPage?.ClickOnManageYourAccountLink();
        }

        [Then(@"I click on Update Details link")]
        public void ThenIClickOnUpdateDetails()
        {
            ManageAccountPage?.ClickOnUpdatedetailsLink();
        }

        [Then(@"I click on Change Personal Information link")]
        public void ThenIClickOnChangePersonalInformationLink()
        {
            ManageAccountPage?.ClickOnChangePersonalInformationLink();
        }

        [Then(@"I click on Change Personal Address link")]
        public void ThenIClickOnChangePersonalAddressLink()
        {
            ManageAccountPage?.ClickOnChangePersonalAddressLink();
        }

        [Then(@"I enter updated Phone number")]
        public void ThenIEnterUpdatedPhoneNumber()
        {
            var updatedPhoneNumber = Utils.GenerateRandomUKPhonenumber();
            ManageAccountPage?.EnterPhoneNumber(updatedPhoneNumber);
            _scenarioContext.Add("PhoneNumber", updatedPhoneNumber);
        }

        [Then(@"I click Continue")]
        public void ThenIClickContinue()
        {
            ManageAccountPage?.ClickContinue();
            _driver?.Wait(15); //wait is applied for the personal details updates to be reflected in pets application
        }

        [Then(@"I click on Back button in Pets Application")]
        [Then(@"I click on Back button")]
        public void ThenIClickOnBackButton()
        {
            ManageAccountPage?.ClickBackButton();
        }

        [Then(@"I go back to Pets application")]
        public void ThenIGoBackToPetsApplication()
        {
            ManageAccountPage?.ClickPetsLink();
        }

        [Then(@"I enter updated First Name")]
        public void ThenIEnterUpdatedFirstName()
        {
            var firstName = "Updated";
            _scenarioContext.Add("OriginalFirstName", ManageAccountPage?.EnterFirstName(firstName));

            _scenarioContext.Add("FirstName", firstName);
        }

        [Then(@"I enter updated Last Name")]
        public void ThenIEnterUpdatedLastName()
        {
            var lastName = "User";
            _scenarioContext.Add("LastName", lastName);
            _scenarioContext.Add("OriginalLastName", ManageAccountPage?.EnterLastName(lastName));
        }

        [Then(@"I revert the Pet Owner Name to the Original Name")]
        public void ThenIRevertThePetOwnerNameToTheOriginalName()
        {
            ManageAccountPage?.EnterFirstName(_scenarioContext.Get<string>("OriginalFirstName"));
            ManageAccountPage?.EnterLastName(_scenarioContext.Get<string>("OriginalLastName"));
            ThenIClickContinue();
            ThenIClickOnBackButton();
            ThenIGoBackToPetsApplication();
            homePage?.ClickApplyForPetTravelDocument();
            string petOwnerName = _scenarioContext.Get<string>("OriginalFirstName") + " " + _scenarioContext.Get<string>("OriginalLastName");
            Assert.IsTrue(PetOwnerDetailsPage?.VerifyUpdatedName(petOwnerName));

        }

        [Then(@"I click on Search for my address by UK Postcode link")]
        public void ThenIClickOnSearchForMyAddressByUKPostcodeLink()
        {
            _scenarioContext.Add("ExistingPostcode", ManageAccountPage?.ClickOnSearchUKPostcodeLink());
        }

        [Then(@"I enter the valid ([^']*) Postcode")]
        public void ThenIEnterTheValidPostcode(string postcode)
        {
            string[] PostCode = postcode.Split(',');
            if (!PostCode[0].Equals(_scenarioContext.Get<string>("ExistingPostcode")))
            {
                ManageAccountPage?.EnterTheValidPostcode(PostCode[0]);
            }
            else
            {
                ManageAccountPage?.EnterTheValidPostcode(PostCode[1]);
            }
        }

        [Then(@"I click find address button")]
        public void ThenIClickFindAddressButton()
        {
            ManageAccountPage?.ClickFindAddressButton();
        }

        [Then(@"I select the address")]
        public void ThenISelectTheAddress()
        {
            _scenarioContext.Add("SelectedAddress", ManageAccountPage?.SelectTheAddress());
        }

    }
}
