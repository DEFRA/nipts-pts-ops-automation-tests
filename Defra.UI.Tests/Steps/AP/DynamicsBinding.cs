using Reqnroll.BoDi;
using Capgemini.PowerApps.SpecFlowBindings.Steps;
using Defra.Trade.Plants.SpecFlowBindings.Steps;
using FluentAssertions;
using Defra.UI.Tests.Tools;
using Microsoft.Dynamics365.UIAutomation.Browser;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using GridSteps = Capgemini.PowerApps.SpecFlowBindings.Steps.GridSteps;
using Capgemini.PowerApps.SpecFlowBindings.Configuration;
using static Microsoft.Dynamics365.UIAutomation.Api.Pages.ActivityFeed;
using FluentAssertions.Execution;
using System.ServiceModel.Channels;

namespace Defra.UI.Tests.Steps.AP
{
    [Binding]
    public class DynamicsBinding
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public object SpecFlowBindingsSteps { get; private set; }

        public DynamicsBinding(IObjectContainer container, ScenarioContext scenarioContext)
        {
            _objectContainer = container;
            _scenarioContext = scenarioContext;
        }

        [When("I opens the application")]
        public void WhenIOpensTheApplication()
        {
            _driver.WaitForPageToLoad();

            GridSteps.WhenISwitchToTheViewInTheGrid("All PTD Applications");
            var referenceNumber = _scenarioContext.Get<string>("ReferenceNumber");
            if (referenceNumber != null)
                GridSteps.WhenISearchForInTheGrid(referenceNumber);
            GridSteps.WhenIOpenTheRecordAtPositionInTheGrid(0);
            _driver.WaitForPageToLoad();
            _scenarioContext.Add("PTDReferenceNumber", FormSteps.GetValueOfField("nipts_documentreference"));

        }

        [When("I assign the application to myself")]
        public void WhenIAssignTheApplicationToHimself()
        {
            var formContext = _driver.WaitUntilAvailable(By.Id("mainContent"));
            CommandSteps.ClickCommand("Refresh");
            _driver.WaitForPageToLoad();
            CommandSteps.ClickCommand("Assign");
            Trade.Plants.SpecFlowBindings.Steps.DialogSteps.WhenIAssignToMeOnTheAssignDialog();
        }

        [When("I {string} the Microchip check")]
        public void WhenIPassOrFailTheMicrochipCheck(string MicrochipStatus)
        {
            EntitySteps.ISelectTab("Verification Checks");
            SharedSteps.WaitForScriptProcessing();
            GridSteps.WhenIOpenTheRecordAtPositionInTheGrid(0);
            SharedSteps.WaitForScriptProcessing();
            if (MicrochipStatus == "Fail")
            {
                EntitySteps.WhenIEnterInTheField("Nil Return", "nipts_failreason", "optionset", "field", 1);
            }
            CommandSteps.ClickCommand(MicrochipStatus);
            SharedSteps.WaitForScriptProcessing();
            PopupSteps.WhenIClickTheButtonOnThePopupDialog("Confirm");
            SharedSteps.WaitForScriptProcessing();
            FormSteps.ICanSeeAHeaderField("readonly", MicrochipStatus);
        }

        [When("I {string} the Evidence check")]
        public void WhenIPassOrFailTheEvidenceCheck(string Status)
        {
            EntitySteps.ISelectTab("Verification Checks");
            SharedSteps.WaitForScriptProcessing();
            GridSteps.WhenIOpenTheRecordAtPositionInTheGrid(1);
            SharedSteps.WaitForScriptProcessing();
            if (Status == "Fail")
            {
                EntitySteps.WhenIEnterInTheField("Nil Return", "nipts_failreason", "optionset", "field", 1);
            }
            CommandSteps.ClickCommand(Status);
            SharedSteps.WaitForScriptProcessing();
            PopupSteps.WhenIClickTheButtonOnThePopupDialog("Confirm");
            SharedSteps.WaitForScriptProcessing();
            FormSteps.ICanSeeAHeaderField("readonly", Status);
        }

        [When("I Fail the Microchip check with '(.*)' reason")]
        public void WhenIFailTheMicrochipCheckWithOtherReason(string reason)
        {
            EntitySteps.ISelectTab("Verification Checks");
            SharedSteps.WaitForScriptProcessing();
            GridSteps.WhenIOpenTheRecordAtPositionInTheGrid(0);
            SharedSteps.WaitForScriptProcessing();
            EntitySteps.WhenIEnterInTheField(reason, "nipts_failreason", "optionset", "field");
            EntitySteps.WhenIEnterInTheField("Other", "nipts_otherreason", "text", "field");
            CommandSteps.ClickCommand("Fail");
            SharedSteps.WaitForScriptProcessing();
            PopupSteps.WhenIClickTheButtonOnThePopupDialog("Confirm");
            SharedSteps.WaitForScriptProcessing();
        }

        [Then("I verify Other Fail reason is not populated")]
        public void ThenIVerifyOtherFailReasonIsNotPopulated()
        {
            EntitySteps.ISelectTab("Verification Checks");
            SharedSteps.WaitForScriptProcessing();
            GridSteps.WhenIOpenTheRecordAtPositionInTheGrid(0);
            SharedSteps.WaitForScriptProcessing();
            EntitySteps.ThenICanNotSeeTheField("nipts_otherreason");
        }

        [Then("I verify Other Reason is not populated")]
        public void ThenIVerifyOtherReasonIsNotPopulated()
        {
            CommandSteps.ClickCommand("Refresh");
            _driver.WaitForPageToLoad();
            CommandSteps.ClickCommand("Revoke");
            SharedSteps.WaitForScriptProcessing();
            PopupSteps.WhenIClickTheButtonOnThePopupDialog("Confirm");
            SharedSteps.WaitForScriptProcessing();
            ThenTheStatusIsChangedTo("Revoke Pending");
            CommandSteps.ClickCommand("Refresh");
            _driver.WaitForPageToLoad();
            EntitySteps.WhenIEnterInTheField("Other", "nipts_reasonforrevocation", "optionset", "field");
            EntitySteps.WhenIEnterInTheField("Other Reason", "nipts_otherrevocationreason", "text", "field");
            EntitySteps.WhenIEnterInTheField("Owner Left GB", "nipts_reasonforrevocation", "optionset", "field");
            _driver.WaitForPageToLoad();
            EntitySteps.ThenICanNotSeeTheField("nipts_otherrevocationreason");
        }

        [Then("I verify the '(.*)' Fail reason")]
        public void ThenIVerifyTheFailReason(string reason)
        {
            ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(reason, "nipts_failreason", "optionset", "field", "");
        }

        [When("I go back")]
        public void WhenIGoBack()
        {
            CommandSteps.WhenIgoBack();
            _driver.WaitForPageToLoad();
            _driver.WaitForTransaction();
        }

        [When("I mark the application to '(.*)'")]
        [When("I '(.*)' the application")]
        public void WhenIAuthoriseTheApplication(string status)
        {
            CommandSteps.ClickCommand(status);
            SharedSteps.WaitForScriptProcessing();
            PopupSteps.WhenIClickTheButtonOnThePopupDialog("Confirm");
            SharedSteps.WaitForScriptProcessing();
        }

        [When("I '(.*)' the application with reason '(.*)'")]
        public void WhenITheApplication(string status, string reason)
        {
            if (status.ToUpper().Equals("REJECT"))
            {
                RejectApplication(status, reason);
            }
            else if (status.ToUpper().Equals("REVOKE"))
            {
                RevokeApplication(status, reason);
            }
        }

        private void RejectApplication(string status, string reason)
        {
            EntitySteps.ISelectTab("General");
            EntitySteps.WhenIEnterInTheField(reason, "nipts_reasonforrejection", "text", "field", 1);
            CommandSteps.ClickCommand(status);
            SharedSteps.WaitForScriptProcessing();
            PopupSteps.WhenIClickTheButtonOnThePopupDialog("Confirm");
            SharedSteps.WaitForScriptProcessing();
            SharedSteps.WaitForScriptProcessing();
            ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(reason, "nipts_reasonforrejection", "text", "field", "");
            ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(Utils.GetCurrentTime().ToString("dd/MM/yyyy"), "nipts_daterejected", "datetime", "field", "");
        }

        [Then("the status is '(.*)'")]
        [Then("the status is changed to '(.*)'")]
        public void ThenTheStatusIsChangedTo(string status)
        {
            CommandSteps.ClickCommand("Refresh");
            _driver.WaitForPageToLoad();
            FormSteps.ICanSeeAHeaderField("readonly", status);
        }

        public void RevokeApplication(string status, string reason)
        {
            CommandSteps.ClickCommand("Refresh");
            _driver.WaitForPageToLoad();
            CommandSteps.ClickCommand(status);
            SharedSteps.WaitForScriptProcessing();
            PopupSteps.WhenIClickTheButtonOnThePopupDialog("Confirm");
            SharedSteps.WaitForScriptProcessing();
            ThenTheStatusIsChangedTo("Revoke Pending");
            CommandSteps.ClickCommand("Refresh");
            _driver.WaitForPageToLoad();
            ThenICannotSeeButton("Authorise");
            ThenICannotSeeButton("Reject");
            if (reason.ToUpper().StartsWith("OTHER"))
            {
                string[] OtherReason = reason.Split(':');
                EntitySteps.WhenIEnterInTheField(OtherReason[0], "nipts_reasonforrevocation", "optionset", "field");
                EntitySteps.WhenIEnterInTheField(OtherReason[1], "nipts_otherrevocationreason", "text", "field");
                RevokeandVerifyTheRevocationFields(OtherReason[0]);
                ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(OtherReason[1], "nipts_otherrevocationreason", "text", "field", "");
            }
            else
            {
                EntitySteps.WhenIEnterInTheField(reason, "nipts_reasonforrevocation", "optionset", "field", 1);
                EntitySteps.ThenICanNotSeeTheField("nipts_otherrevocationreason");
                RevokeandVerifyTheRevocationFields(reason);
            }
        }

        private void RevokeandVerifyTheRevocationFields(string reason)
        {
            CommandSteps.ClickCommand("Revoke");
            SharedSteps.WaitForScriptProcessing();
            PopupSteps.WhenIClickTheButtonOnThePopupDialog("Confirm");
            SharedSteps.WaitForScriptProcessing();
            EntitySteps.WhenIEnterInTheField("Owner Left GB", "nipts_reasonforrevocation", "optionset", "field", 2);

            ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(reason, "nipts_reasonforrevocation", "optionset", "field", "");
            ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(Utils.GetCurrentTime().ToString("dd/MM/yyyy"), "nipts_daterevoked", "datetime", "field", "");
        }

        [Then("I (do|dont) see Duplicate Microchip Notification")]
        public void ThenISeeDuplicateMicroChipNotification(string doOrDont)
        {
            if (doOrDont.ToUpper().Equals("DO"))
                EntitySteps.ThenICanSeeAnInfoFormNotificationStating("Duplicate Microchip Number Identified.");
            else if (doOrDont.ToUpper().Equals("DONT"))
                EntitySteps.ThenICannotSeeAnInfoFormNotificationStating("Duplicate Microchip Number Identified.");
        }

        [When("I assign the application to '(.*)' another user")]
        public void WhenIAssignTheApplicationToAnotherUser(string user)
        {
            var formContext = _driver.WaitUntilAvailable(By.Id("mainContent"));
            CommandSteps.ClickCommand("Refresh");
            _driver.WaitForPageToLoad();
            CommandSteps.ClickCommand("Assign");
            Capgemini.PowerApps.SpecFlowBindings.Steps.DialogSteps.WhenIAssignToANamedOnTheAssignDialog(Microsoft.Dynamics365.UIAutomation.Api.UCI.Dialogs.AssignTo.User, user);
            _driver.WaitForPageToLoad();
            FormSteps.RecordIsOwnedBy(user);
        }

        [Then("the Record Owner By '(.*)'")]
        public void WhenTheRecordOwnerBy(string user)
        {
            if (user.ToUpper().Equals("CURRENT USER"))
            {
                FormSteps.RecordIsOwnedBy(TestConfiguration.CurrentUsers.FirstOrDefault().Value.Alias);
            }
        }

        [When("I add notes as '(.*)' and '(.*)'")]
        public void WhenIAddNotesAsAnd(string title, string body)
        {
            TimelineSteps.WhenIAddANoteToTheTimeline(title, body);
        }

        [Then("I cannot see '(.*)' button")]
        public void ThenICannotSeeButton(string commandName)
        {
            CommandBarSteps.ThenICanNotSeeTheCommand(commandName);
        }

        [Then("I cannot edit the field '(.*)'")]
        public void ThenICannotEditTheField(string fieldNames)
        {
            string[] fieldName = fieldNames.Split(':');
            foreach (string field in fieldName)
                switch (field.ToUpper())
                {
                    case "TOWN":
                        FormSteps.ThenICanNotEditTheField("nipts_ownertown");
                        break;
                    case "PET NAME":
                        FormSteps.ThenICanNotEditTheField("nipts_petname");
                        break;
                    //case "SPECIES":
                    //    FormSteps.ThenICanNotEditTheField("nipts_pettype");
                    //    break;
                    //case "BREED":
                    //    FormSteps.ThenICanNotEditTheField("nipts_petbreed");
                    //    break;
                    case "ADDITIONAL BREED DETAILS":
                        FormSteps.ThenICanNotEditTheField("nipts_petbreeddetails");
                        break;
                    case "SEX":
                        FormSteps.ThenICanNotEditTheField("nipts_petsex");
                        break;
                    case "ANIMALSEX":
                        FormSteps.ThenICanNotEditTheField("nipts_animalsex");
                        break;
                    case "DATE OF BIRTH":
                        FormSteps.ThenICanNotEditTheField("nipts_petdob");
                        break;
                    case "APPROX AGE":
                        FormSteps.ThenICanNotEditTheField("nipts_petapproxage");
                        break;
                    case "COLOUR":
                        FormSteps.ThenICanNotEditTheField("nipts_petcolour");
                        break;
                    case "COLOURID":
                        FormSteps.ThenICanNotEditTheField("nipts_petcolourid");
                        break;
                    case "OTHER COLOUR":
                        FormSteps.ThenICanNotEditTheField("nipts_petothercolour");
                        break;
                    case "UNIQUE FEATURES":
                        FormSteps.ThenICanNotEditTheField("nipts_petuniquefeatures");
                        break;
                    case "MICROCHIP NUMBER":
                        FormSteps.ThenICanNotEditTheField("nipts_microchipnum");
                        break;
                    case "MICROCHIPPED DATE":
                        FormSteps.ThenICanNotEditTheField("nipts_microchippeddate");
                        break;
                    case "OWNER TYPE":
                        FormSteps.ThenICanNotEditTheField("nipts_ownertype");
                        break;
                    case "CHARITY NAME":
                        FormSteps.ThenICanNotEditTheField("nipts_charityname");
                        break;
                    case "ADDRESS LINE 1":
                        FormSteps.ThenICanNotEditTheField("nipts_owneraddressline1");
                        break;
                    case "ADDRESS LINE 2":
                        FormSteps.ThenICanNotEditTheField("nipts_owneraddressline2");
                        break;
                    case "ADDRESS LINE 3":
                        FormSteps.ThenICanNotEditTheField("nipts_owneraddressline3");
                        break;
                    case "POSTCODE":
                        FormSteps.ThenICanNotEditTheField("nipts_ownerpostcode");
                        break;
                    case "NAME":
                        FormSteps.ThenICanNotEditTheField("nipts_ownername");
                        break;
                    case "EMAIL":
                        FormSteps.ThenICanNotEditTheField("nipts_owneremail");
                        break;
                    case "COUNTY":
                        FormSteps.ThenICanNotEditTheField("nipts_ownercounty");
                        break;
                    case "PHONE":
                        FormSteps.ThenICanNotEditTheField("nipts_ownerphone");
                        break;
                    case "APPLICANT NAME":
                        FormSteps.ThenICanNotEditTheField("nipts_ownername"); //nipts_offlineapplicantname
                        break;
                    case "APPLICANT EMAIL":
                        FormSteps.ThenICanNotEditTheField("nipts_owneremail"); //nipts_offlineemail
                        break;
                    case "APPLICANT ADDRESS LINE 1":
                        FormSteps.ThenICanNotEditTheField("nipts_owneraddressline1"); //nipts_offlineaddressline1
                        break;
                    case "APPLICANT ADDRESS LINE 2":
                        FormSteps.ThenICanNotEditTheField("nipts_owneraddressline2"); //nipts_offlineaddressline2
                        break;
                    case "APPLICANT ADDRESS LINE 3":
                        FormSteps.ThenICanNotEditTheField("nipts_owneraddressline3");//nipts_offlineaddressline3
                        break;
                    case "APPLICANT TOWN":
                        FormSteps.ThenICanNotEditTheField("nipts_ownertown");//nipts_offlinetown
                        break;
                    case "APPLICANT POSTCODE":
                        FormSteps.ThenICanNotEditTheField("nipts_ownerpostcode"); //nipts_offlinepostcode
                        break;
                    case "APPLICANT COUNTY":
                        FormSteps.ThenICanNotEditTheField("nipts_ownercounty"); //nipts_offlinecounty
                        break;
                    case "APPLICANT PHONE":
                        FormSteps.ThenICanNotEditTheField("nipts_ownerphone"); //nipts_offlinephone
                        break;
                    default:
                        break;
                }
        }

        [When("I Switch to '([^']*)'")]
        public void WhenISwitchTheGridView(string gridView)
        {
            GridSteps.WhenISwitchToTheViewInTheGrid(gridView);
        }

        [Then("I verify the system view for the application '(.*)'")]
        public void IVerifyTheSystemViewForTheApplication(string applicationName)
        {
            EntitySteps.IVerifyTheSystemViewForTheApplication(applicationName);
        }

        [When("I open the first application")]
        public void WhenIOpenTheFirstRecord()
        {
            GridSteps.WhenIOpenTheRecordAtPositionInTheGrid(0);
        }

        [When(@"I filter with '(.*)' is '(.*)' to '(.*)' in PTS Application")]
        public void WhenISearchWithFilters(string filterName, string Operator, string Value)
        {
            GridSteps.WhenISearchByAdvancedFilterInTheGrid(filterName, Operator, Value);
        }

        [When("I go to the tab '(.*)'")]
        public void WhenIGoToTheTab(string tabName)
        {
            EntitySteps.ISelectTab(tabName);
        }

        [When("I open the '(.*)' application")]
        [When("I open the '([^']*)' application")]
        public void WhenIOpenTheGivenApplication(string applicationNumber)
        {
            GridSteps.WhenISearchForInTheGrid(applicationNumber);
            GridSteps.WhenIOpenTheRecordAtPositionInTheGrid(0);
        }

        [Then("I Verify if '(.*)' coloumn is available in Duplicate subgrid")]
        public void ThenIVerifyIfColoumnIsAvailable(string columnName)
        {
            Trade.Plants.SpecFlowBindings.Steps.GridSteps.CheckColumnExists(columnName, "Duplicates_subgrid");
        }

        [Then("I Verify the '(.*)' Failed Verification Check Error Message")]
        public void ThenIVerifyTheFailedVerificationCheckErrorMessage(string Checks)
        {
            EntitySteps.ISelectTab("Verification Checks");
            SharedSteps.WaitForScriptProcessing();
            if (Checks.ToUpper().Equals("MICROCHIP"))
                GridSteps.WhenIOpenTheRecordAtPositionInTheGrid(0);
            else if (Checks.ToUpper().Equals("EVIDENCE"))
                GridSteps.WhenIOpenTheRecordAtPositionInTheGrid(1);
            SharedSteps.WaitForScriptProcessing();
            CommandSteps.ClickCommand("Fail");
            SharedSteps.WaitForScriptProcessing();
            PopupSteps.WhenIClickTheButtonOnThePopupDialog("Confirm");
            SharedSteps.WaitForScriptProcessing();
            Trade.Plants.SpecFlowBindings.Steps.DialogSteps.ThenADialogIsDisplayedWithMessageInTheDialogField("Verification Check can't be failed. Couldn't find a reason to fail this check. Please add a fail reason and try again.", "dialogMessageText");
        }

        [Then("I verify the copy of the '([^']*)' Email in Timeline")]
        public void ThenIVerifyTheCopyOfEmail(string timelineCopy)
        {
            CommandSteps.ClickCommand("Refresh");

            if (timelineCopy.ToUpper().Equals("CONFIRMATION"))
                Assert.IsTrue(TimelineSteps.GetTimelineRecordTitle("Lifelong Pet Travel Document Application Received"));
            else if (timelineCopy.ToUpper().Equals("APPROVED"))
            {
                CommandSteps.ClickCommand("Refresh");
                Assert.IsTrue(TimelineSteps.GetTimelineRecordTitle("Lifelong Pet Travel Document Application Decision"));
                Assert.IsTrue(TimelineSteps.GetTimelineRecordBody("approved"));
            }
            else if (timelineCopy.ToUpper().Equals("REJECTION"))
            {
                Assert.IsTrue(TimelineSteps.GetTimelineRecordTitle("Lifelong Pet Travel Document Application Decision"));
                Assert.IsTrue(TimelineSteps.GetTimelineRecordBody("rejected"));
            }
            else if (timelineCopy.ToUpper().Equals("REVOCATION"))
            {
                Assert.IsTrue(TimelineSteps.GetTimelineRecordTitle("Lifelong Pet Travel Document Application Decision"));
                Assert.IsTrue(TimelineSteps.GetTimelineRecordBody("revoked"));
            }
        }

        [Then("I verify the revocation error message")]
        public void ThenIVerifyTheRevocationErrorMessage()
        {
            CommandSteps.ClickCommand("Revoke");
            SharedSteps.WaitForScriptProcessing();
            Trade.Plants.SpecFlowBindings.Steps.DialogSteps.ThenADialogIsDisplayedWithMessageInTheDialogField("You are about to revoke the application record. Do you want to continue with this action? This action cannot be undone.", "dialogMessageText");
            PopupSteps.WhenIClickTheButtonOnThePopupDialog("Confirm");
            SharedSteps.WaitForScriptProcessing();
            Trade.Plants.SpecFlowBindings.Steps.DialogSteps.ThenADialogIsDisplayedWithMessageInTheDialogField("Application can't be revoked. Couldn't find a reason to revoke this PTD application. Please add a reason for revocation and try again.", "dialogMessageText");
            SharedSteps.WaitForScriptProcessing();
        }

        [Then("I Verify the Rejection messages")]
        public void ThenIVerifyTheRejectionMessages()
        {
            CommandSteps.ClickCommand("Reject");
            SharedSteps.WaitForScriptProcessing();
            Trade.Plants.SpecFlowBindings.Steps.DialogSteps.ThenADialogIsDisplayedWithMessageInTheDialogField("You are about to reject the application record. Do you want to continue with this action?", "dialogMessageText");
            PopupSteps.WhenIClickTheButtonOnThePopupDialog("Confirm");
            SharedSteps.WaitForScriptProcessing();

            Trade.Plants.SpecFlowBindings.Steps.DialogSteps.ThenADialogIsDisplayedWithMessageInTheDialogField("Application can't be rejected. Couldn't find a reason to reject this PTD application. Please add a reason for rejection and try again.", "dialogMessageText");
        }

        [Then("I verify revoke date and reason is not populated")]
        public void ThenIVerifyRevokeDateAndReasonIsNotPopulated()
        {
            EntitySteps.ThenICanNotSeeTheField("nipts_reasonforrevocation");
            EntitySteps.ThenICanNotSeeTheField("nipts_daterevoked");
        }

        [Then("I cannot edit '(.*)' Details")]
        public void ThenICannotEditDetails(string field)
        {
            CommandSteps.ClickCommand("Refresh");
            _driver.WaitForPageToLoad();
            if (field.ToUpper().Equals("PET"))
            {
                ThenICannotEditTheField("Pet Name:Species:Breed:AnimalSex:Date of Birth:Approx Age:Colourid:Unique Features:Microchip Number:Microchipped Date");

            }
            else if (field.ToUpper().Equals("PET OWNER"))
            {
                ThenICannotEditTheField("Owner Type:Name:Email:Charity Name:Address Line 1:Address Line 2:Address Line 3:Town:Postcode:County:Phone");

            }
            else if (field.ToUpper().Equals("APPLICANT DETAILS"))
            {
                ThenICannotEditTheField("Applicant Name:Applicant Email:Applicant address line 1:Applicant address line 2:Applicant address line 3:Applicant Town:Applicant Postcode:Applicant County:Applicant Country:Applicant Phone");
            }
        }

        [Then("I cannot edit '(.*)' Details for Pending Application")]
        public void ThenICannotEditDetailsForPendingApplication(string field)
        {
            CommandSteps.ClickCommand("Refresh");
            _driver.WaitForPageToLoad();
            if (field.ToUpper().Equals("PET"))
            {
                ThenICannotEditTheField("Pet Name:Species:Breed:Sex:Date of Birth:Approx Age:Colour:Unique Features:Microchip Number:Microchipped Date");

            }
            else if (field.ToUpper().Equals("PET OWNER"))
            {
                ThenICannotEditTheField("Owner Type:Name:Email:Charity Name:Address Line 1:Address Line 2:Address Line 3:Town:Postcode:County:Phone");

            }
            else if (field.ToUpper().Equals("APPLICANT DETAILS"))
            {
                ThenICannotEditTheField("Applicant Name:Applicant Email:Applicant address line 1:Applicant address line 2:Applicant address line 3:Applicant Town:Applicant Postcode:Applicant County:Applicant Country:Applicant Phone");
            }
        }

        [When("I sort the coloumn '(.*)' by '(.*)'")]
        public void WhenISortTheColumn(string ColumnName, string SortBy)
        {
            if (ColumnName.ToUpper().Equals("SUBMISSION DATE"))
                GridSteps.WhenISortByInTheGrid("nipts_submissiondate", SortBy);
        }

        [When(@"I click Open Record from the timeline")]
        public static void WhenIClickOpenRecordFromTheTimeline()
        {
            TimelineSteps.WhenIClickOpenRecordFromTheTimeline();
        }

        [Then(@"the subject of email should reads '(.*)'")]
        public void ThenTheSubjectOfEmailShouldReads(string emailSubject)
        {
            var latestEmailSubject = TimelineSteps.ThenTheSubjectOfEmailShouldReads(emailSubject);
            latestEmailSubject.Should().Be(emailSubject);
        }

        [When(@"I marked the case as Pending")]
        public void WhenIMarkedTheCaseAsPending()
        {
            CommandSteps.ClickCommand("Pending");
            _driver.WaitForPageToLoad();
            SharedSteps.WaitForScriptProcessing();
            PopupSteps.WhenIClickTheButtonOnThePopupDialog("Confirm");
            SharedSteps.WaitForScriptProcessing();
        }

        [When(@"I switched to PETS Application")]
        public void WhenISwitchedToPetsApplication()
        {
            var windowHandle = _scenarioContext.Get<string>("WindowHandle");
            _driver.SwitchTo().Window(windowHandle);
        }

        [Then("the value of '(.*)' is '(.*)' in the PTD application")]
        public void ThenTheValueOfIsInThePTDApplication(string field, string value)
        {
            if (field.ToUpper().Equals("MICROCHIP NUMBER"))
                ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(value, "nipts_microchipnum", "text", "field", "");
            else if (field.ToUpper().Equals("NAME"))
                ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(value, "nipts_ownername", "text", "field", "");
        }

        [When(@"I Click on New to create an offline application")]
        public void WhenICreateAnOfflineApplication()
        {
            CommandSteps.ClickCommand("New");
            _driver.WaitForPageToLoad();
            SharedSteps.WaitForScriptProcessing();
        }

        [When(@"I enter '(.*)' as '(.*)'")]
        public void WhenIEnterOfflineApplicatinNameAs(string field, string value)
        {
            switch (field.ToUpper())
            {
                case "APPLICANT NAME":
                    EntitySteps.WhenIEnterInTheField(value, "nipts_applicantid", "lookup", "field", 1);
                    ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(value, "nipts_applicantid", "lookup", "field", "");
                    break;
                case "EMAIL":
                    EntitySteps.WhenIEnterInTheField(value, "nipts_offlineemail", "text", "field", 1);
                    break;
                case "ADDRESS LINE 1":
                    EntitySteps.WhenIEnterInTheField(value, "nipts_offlineaddressline1", "text", "field", 1);
                    ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(value, "nipts_offlineaddressline1", "text", "field", "");
                    break;
                case "ADDRESS LINE 2":
                    EntitySteps.WhenIEnterInTheField(value, "nipts_offlineaddressline2", "text", "field", 1);
                    ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(value, "nipts_offlineaddressline2", "text", "field", "");
                    break;
                case "ADDRESS LINE 3":
                    EntitySteps.WhenIEnterInTheField(value, "nipts_offlineaddressline3", "text", "field", 1);
                    ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(value, "nipts_offlineaddressline3", "text", "field", "");
                    break;
                case "TOWN":
                    EntitySteps.WhenIEnterInTheField(value, "nipts_offlinetown", "text", "field", 1);
                    ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(value, "nipts_offlinetown", "text", "field", "");
                    break;
                case "POSTCODE":
                    EntitySteps.WhenIEnterInTheField(value, "nipts_offlinepostcode", "text", "field", 1);
                    ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(value, "nipts_offlinepostcode", "text", "field", "");
                    break;
                case "COUNTY":
                    EntitySteps.WhenIEnterInTheField(value, "nipts_offlinecounty", "text", "field", 1);
                    ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(value, "nipts_offlinecounty", "text", "field", "");
                    break;
                case "COUNTRY":
                    EntitySteps.WhenIEnterInTheField(value, "nipts_offlinecountry", "text", "field", 1);
                    ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(value, "nipts_offlinecountry", "text", "field", "");
                    break;
                case "PHONE":
                    EntitySteps.WhenIEnterInTheField(value, "nipts_offlinephone", "text", "field", 1);
                    break;
                case "OWNER TYPE":
                    EntitySteps.WhenIEnterInTheField(value, "nipts_ownertype", "optionset", "field", 1);
                    ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(value, "nipts_ownertype", "optionset", "field", "");
                    break;
                case "PET NAME":
                    EntitySteps.WhenIEnterInTheField(value, "nipts_petname", "text", "field", 1);
                    ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(value, "nipts_petname", "text", "field", "");
                    break;
                case "SPECIES":
                    EntitySteps.WhenIEnterInTheField(value, "nipts_pettype", "optionset", "field", 1);
                    ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(value, "nipts_pettype", "optionset", "field", "");
                    break;
                case "BREED":
                    EntitySteps.WhenIEnterInTheField(value, "nipts_petbreedid", "lookup", "field", 1);
                    ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(value, "nipts_petbreedid", "lookup", "field", "");
                    break;
                case "ADDITIONAL BREED":
                    EntitySteps.WhenIEnterInTheField(value, "nipts_petbreeddetails", "text", "field", 1);
                    ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(value, "nipts_petbreeddetails", "text", "field", "");
                    break;
                case "SEX":
                    EntitySteps.WhenIEnterInTheField(value, "nipts_animalsex", "optionset", "field", 1);
                    ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(value, "nipts_animalsex", "optionset", "field", "");
                    break;
                case "AGE":
                    EntitySteps.WhenIEnterInTheField(value, "nipts_petapproxage", "text", "field", 1);
                    ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(value, "nipts_petapproxage", "text", "field", "");
                    break;
                case "COLOUR":
                    EntitySteps.WhenIEnterInTheField(value, "nipts_petcolourid", "lookup", "field", 1);
                    ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(value, "nipts_petcolourid", "lookup", "field", "");
                    break;
                case "OTHER COLOUR":
                    EntitySteps.WhenIEnterInTheField(value, "nipts_petothercolour", "text", "field", 1);
                    ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(value, "nipts_petothercolour", "text", "field", "");
                    break;
                case "UNIQUE FEATURE":
                    EntitySteps.WhenIEnterInTheField(value, "nipts_petuniquefeatures", "text", "field", 1);
                    ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(value, "nipts_petuniquefeatures", "text", "field", "");
                    break;
                case "MICROCHIP NUMBER":
                    if (value.ToUpper().Equals("AUTO"))
                    {
                        var microchiNumber = Utils.GenerateMicrochipNumber();
                        EntitySteps.WhenIEnterInTheField(microchiNumber, "nipts_microchipnum", "text", "field", 1);
                        ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(microchiNumber, "nipts_microchipnum", "text", "field", "");
                    }
                    else
                    {
                        EntitySteps.WhenIEnterInTheField(value, "nipts_microchipnum", "text", "field", 1);
                        ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(value, "nipts_microchipnum", "text", "field", "");
                    }
                    break;
                case "MICROCHIPPED DATE":
                    EntitySteps.WhenIEnterInTheField(value, "nipts_microchippeddate", "text", "field", 1);
                    break;
                case "DATE OF BIRTH":
                    EntitySteps.WhenIEnterInTheField(value, "nipts_petdob", "text", "field", 1);
                    break;
            }
        }

        [When(@"I Click on Save")]
        public void WhenIClickOnSave()
        {
            Thread.Sleep(1000);
            CommandSteps.ClickCommand("Save");
            _driver.WaitForPageToLoad();
            CommandSteps.ClickCommand("Refresh");
            _driver.WaitForPageToLoad();
            SharedSteps.WaitForScriptProcessing();
            CommandSteps.ClickCommand("Refresh");
            _driver.WaitForPageToLoad();
            SharedSteps.WaitForScriptProcessing();
            Thread.Sleep(5000);
        }

        [Then(@"I see the Application Reference number generated")]
        public void ThenISeeTheApplicationReferenceNumber()
        {
            CommandSteps.ClickCommand("Refresh");
            _driver.WaitForPageToLoad();
            string PTD_Reference = EntitySteps.ThenIGetTheHeaderTitle();
            ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(PTD_Reference, "nipts_applicationreference", "text", "field", "");
            ModalFormSteps.ThenICanSeeAValueOfInTheFieldWithinTheModalForm(PTD_Reference, "nipts_documentreference", "text", "field", "");
        }

        [Then(@"I can see the submission date and time")]
        public void ThenICanSeeTheSubmissionDateTime()
        {
            ModalFormSteps.ThenICanSeeAValueTheModalForm("nipts_submissiondate", "text", "field", "");
        }

        [Then(@"I dont see the Email in timeline")]
        public void ThenIDontSeeTheEmailInTimeline()
        {
            Assert.IsTrue(TimelineSteps.TimelineRecordNotPresent());
        }

        [Then(@"I cannot see '(.*)' command")]
        public void ThenICannotSeePending(string command)
        {
            ModalFormSteps modalFormSteps = new ModalFormSteps(_scenarioContext);
            modalFormSteps.ThenICanSeeTheCommandWithinTheModalForm("cannot", command, "");
        }

        [Then(@"I See the error '(.*)' notification")]
        public void ThenISeeTheErrorNotification(string errorMessage)
        {
            EntitySteps.ThenICanSeeAnErrorFormNotificationStating(errorMessage);
        }

        [Then(@"I See an error '(.*)' when Authorising the application")]
        public void ThenISeeAnError(string errorMessage)
        {
            CommandSteps.ClickCommand("Authorise");
            SharedSteps.WaitForScriptProcessing();
            PopupSteps.WhenIClickTheButtonOnThePopupDialog("Confirm");
            SharedSteps.WaitForScriptProcessing();
            Trade.Plants.SpecFlowBindings.Steps.DialogSteps.ThenADialogIsDisplayedWithMessageInTheDialogField(errorMessage, "dialogMessageText");
            SharedSteps.WaitForScriptProcessing();
        }

        [Then(@"I move the application to Revoke Pending status")]
        public void ThenIMoveTeApplicationToRevokePending()
        {
            CommandSteps.ClickCommand("Refresh");
            _driver.WaitForPageToLoad();
            CommandSteps.ClickCommand("Revoke");
            SharedSteps.WaitForScriptProcessing();
            PopupSteps.WhenIClickTheButtonOnThePopupDialog("Confirm");
            SharedSteps.WaitForScriptProcessing();
            ThenTheStatusIsChangedTo("Revoke Pending");
        }
    }
}
