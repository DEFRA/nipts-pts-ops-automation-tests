﻿namespace Defra.UI.Tests.Pages.CP.Interfaces
{
    public interface IReportNonCompliancePage
    {
        bool IsPageLoaded();
        void SelectReportNonComplianceButton();
        void ClickPetTravelDocumentDetailsLnk();
        bool VerifyTheExpectedStatus(string status);
        void SelectTypeOfPassenger(string radioButtonValue);
        bool IsError(string errorMessage);
        bool CheckPetTravelDocumentDetailsSection(string status);
        bool VerifyTheTableNameInPTDLink(string tableName);
        bool VerifyReasonsHeadingWithHint(string reasons, string hint);
        bool VerifyGBOutcomeCheckboxes(string checkboxValues, string subHeading);
        bool VerifySPSOutcomeCheckboxes(string checkboxValues, string subHeading);
        bool VerifyDetailsOfOutcome();
        bool VerifyMaxLengthOfDetailsOfOutcomeTextarea(string maxLength);
        bool VerifyThePTDNumber(string ptdNumber);
        bool VerifyTheDateOfIssuance(string dateOfIssuance);
        bool VerifyTheReferenceNumber(string refereneNumber);
        bool VerifyTableNameForApprovedAndRevokedInPTDLink(string tableName);
        bool VerifyGBCheckboxesAreNotChecked();
        bool VerifySPSCheckboxesAreNotChecked();
        bool VerifyAnyRelavantCommentsTextarea(string heading, string hint, string maxLength);
        bool VerifyTypeOfPassengerSubheading(string subHeading, string sectionName);
        bool VerifyVCAndPetOwnerDetailSubheading(string subHeading);
        bool VerifyPetDetailsFromPTDLink(string linkName);
        bool VerifyPetDoesNotMatchThePTDCheckBox(string checkboxValue);
        bool VerifyVCAndPetOwnerDetailTableName(string tableName);
        bool VerifyVisualCheckTableFields(string species, string breed, string sex, string dob, string colour, string significantFeature);
        bool VerifyOtherIssuesSubheading(string subHeading);
        bool VerifyOtherIssuesCheckboxes(string checkboxOptions);
        bool VerifyOtherReasonOptionHint(string hint);
        bool VerifyOtherIssuesCheckboxesAreNotChecked();
        bool VerifyMicrochipSection();
        bool VerifyMCDetailsPTDTableWithValues(string MCDetails);
        void ClickOnMCCheckbox(string MCCheckbox);
        void EnterMCNumber(string mCNumber);
        void ClickGBOutcomeCheckbox(string gBOutcome);
        bool VerifyNameAndEmailOfPetOwner(string name, string email);
        bool VerifyAddressAndPhoneNumberOfPetOwner(string address, string phoneNumber);
        bool VerifyInfoSubmittedMessage(string submittedMessage);
        void ClickSaveOutComeButton();
        bool VerifyTypeOfPassengerRadioButtons(string ferryFootPassenger, string vehicleOnFerry, string airline);
        void ClickSPSOutcomeCheckbox(string sPSOutcome);
        bool VerifyMicrochipCheckboxesAreChecked();
    }
}