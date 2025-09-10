@Idcoms
Feature: Idcoms Regression

IDCOMS System Regression for NIPTS

Scenario: Verify if a Caseworker can assign an already assigned case to themselves
	When I Login to Dynamics application
	And I Switch to 'All PTD Applications'
	And I open the first application
	And I assign the application to 'Shukla Vishal' another user
	And I assign the application to myself

Scenario: Verify if the Pet owner details are not editable
	When I Login to Dynamics application
	And I filter with 'Status Reason' is 'Equals' to 'Pending' in PTS Application
	And I open the first application
	Then I cannot edit 'Pet Owner' Details

Scenario: Verify if the Pet details are not editable and no pending button visible
	When I Login to Dynamics application
	And I filter with 'Status Reason' is 'Equals' to 'Pending' in PTS Application
	And I open the first application
	Then I cannot edit 'Pet' Details for Pending Application
	And I cannot see 'Pending' command

Scenario: Verify Revoke Pending System View	
	When I Login to Dynamics application
	And I Switch to 'Revoke Pending PTD Applications'
	And I open the first application
	Then the status is 'Revoke Pending'

Scenario: Verify Status transitions for Authorised application
	When I Login to Dynamics application
	And I Switch to 'Authorised PTD Applications'
	And I open the first application
	Then the status is 'Authorised'
	And I cannot see 'Activate' button

Scenario: Verify Status transitions for Revoked application
	When I Login to Dynamics application
	And I Switch to 'Revoked PTD Applications'
	And I open the first application
	Then the status is 'Revoked'
	And I cannot see 'Activate' button

Scenario: Verify Status transitions for Rejected application
	When I Login to Dynamics application
	And I Switch to 'Rejected PTD Applications'
	And I open the first application
	Then the status is 'Rejected'
	And I cannot see 'Activate' button


Scenario: Verify the duplicate subgrid - Rejected Application
	When I Login to Dynamics application
	And I Switch to 'All PTD Applications'
	And I open the 'ZIA73KAF' application
	And I go to the tab 'Duplicates'
	Then I Verify if 'Application Reference' coloumn is available in Duplicate subgrid
	And I Verify if 'PTD Reference' coloumn is available in Duplicate subgrid


Scenario: Verify the duplicate subgrid - Revoked Application
	When I Login to Dynamics application
	And I Switch to 'All PTD Applications'
	And I open the 'JUBBQB3A' application
	And I go to the tab 'Duplicates'
	Then I Verify if 'Application Reference' coloumn is available in Duplicate subgrid
	And I Verify if 'PTD Reference' coloumn is available in Duplicate subgrid


Scenario: Verify the duplicate subgrid - Authorised Application
	When I Login to Dynamics application
	And I Switch to 'All PTD Applications'
	And I open the 'JUBBQB3A' application
	And I go to the tab 'Duplicates'
	Then I Verify if 'Application Reference' coloumn is available in Duplicate subgrid
	And I Verify if 'PTD Reference' coloumn is available in Duplicate subgrid


Scenario: Verify the duplicate subgrid - Open Application
	When I Login to Dynamics application
	And I Switch to 'All PTD Applications'
	And I open the 'BSSOBCSA' application
	And I go to the tab 'Duplicates'
	Then I Verify if 'Application Reference' coloumn is available in Duplicate subgrid
	And I Verify if 'PTD Reference' coloumn is available in Duplicate subgrid


Scenario: Verify the duplicate subgrid - Pending Application
	When I Login to Dynamics application
	And I Switch to 'All PTD Applications'
	And I open the '6TVXHBPB' application
	And I go to the tab 'Duplicates'
	Then I Verify if 'Application Reference' coloumn is available in Duplicate subgrid
	And I Verify if 'PTD Reference' coloumn is available in Duplicate subgrid


Scenario: Verify the duplicate subgrid - Revoke pending Application
	When I Login to Dynamics application
	And I Switch to 'All PTD Applications'
	And I open the 'YUOMQ0Z7' application
	And I go to the tab 'Duplicates'
	Then I Verify if 'Application Reference' coloumn is available in Duplicate subgrid
	And I Verify if 'PTD Reference' coloumn is available in Duplicate subgrid

Scenario: Verify Microchip - Failed Verification Check Error Message
	When I Login to Dynamics application
	And I Switch to 'Open - Unassigned PTD Applications'
	And I open the first application
	And I assign the application to myself
	Then I Verify the 'Microchip' Failed Verification Check Error Message

Scenario: Verify Revoke application messages
	When I Login to Dynamics application	
	And I Switch to 'Authorised PTD Applications'
	And I open the first application
	And I assign the application to myself
	And I 'Revoke' the application
	Then I verify the revocation error message
	
Scenario: Verify Reject application messages
	When I Login to Dynamics application	
	And I Switch to 'All PTD Applications'
	And I filter with 'Status Reason' is 'Equals' to 'Pending' in PTS Application
	And I open the first application
	And I assign the application to myself
	Then I Verify the Rejection messages

Scenario: Verify the Other Revocation Reason is mandatory
	When I Login to Dynamics application	
	And I Switch to 'Authorised PTD Applications'
	And I open the first application
	And I assign the application to myself
	And I 'Revoke' the application with reason 'Other:Other Reason'

Scenario: Verify Revoke reason: Clear and hide Other Reason field when not used
	When I Login to Dynamics application
	And I Switch to 'Authorised PTD Applications'
	And I open the first application
	And I assign the application to myself
	Then I verify Other Reason is not populated

Scenario: Verify Microchip Check: Clear and hide Other Reason field when not used
	When I Login to Dynamics application
	And I Switch to 'All PTD Applications'
	And I open the first application
	And I assign the application to myself
	Then I verify Other Fail reason is not populated

Scenario Outline: Revoke date & Reason is not available
	When I Login to Dynamics application	
	And I Switch to '<Application Type>'
	And I open the first application
	Then I verify revoke date and reason is not populated

Examples:
| Application Type                   |
| Open - Unassigned PTD Applications |
| Pending PTD Applications           |
| Authorised PTD Applications        |
| Rejected PTD Applications          |

Scenario: Verify the Microchip Check ‘Other Reason’ field mandatory
	When I Login to Dynamics application
	And I Switch to 'Open - Unassigned PTD Applications'
	And I open the first application
	And I assign the application to myself
	And I 'Fail' the Microchip check with 'Other' reason
	Then I verify the 'Other' Fail reason

Scenario: Verify if a Caseworker can filter the cases with pending status
	When I Login to Dynamics application
	And I filter with 'Status Reason' is 'Equals' to 'Pending' in PTS Application
	And I open the first application
	Then the status is 'Pending'
	
Scenario: Verify if Caseworker filters for cases assigned to them
	When I Login to Dynamics application
	And I Switch to 'All PTD Applications'
	And I filter with 'Owner' is 'Equals current user' to '' in PTS Application
	And I open the first application
	Then the Record Owner By 'current user'

Scenario: Verify if a Caseworker can search by microchip number
	When I Login to Dynamics application
	And I filter with 'Microchip Number' is 'Equals' to '123456789012345' in PTS Application
	And I open the first application
	Then the value of 'Microchip Number' is '123456789012345' in the PTD application

Scenario: Verify the caseworker can search by pet owner
	When I Login to Dynamics application
	And I filter with 'Name' is 'Equals' to 'Brinda CTS' in PTS Application
	And I open the first application
	Then the value of 'Name' is 'Brinda CTS' in the PTD application	

Scenario: Verify if Caseworker  clears caseworker filter - Dog
	When I Login to Dynamics application
	And I filter with 'Species' is 'Equals' to 'Dog' in PTS Application
	And I open the first application
	Then the value of 'Species' is 'Dog' in the PTD application	

Scenario: Verify if Caseworker  clears caseworker filter - Cat
	When I Login to Dynamics application
	And I filter with 'Species' is 'Equals' to 'Cat' in PTS Application
	And I open the first application
	Then the value of 'Species' is 'Cat' in the PTD application

Scenario: Verify if Caseworker  clears caseworker filter - Ferret
	When I Login to Dynamics application
	And I filter with 'Species' is 'Equals' to 'Ferret' in PTS Application
	And I open the first application
	Then the value of 'Species' is 'Ferret' in the PTD application	

Scenario: Verify the Assisted Digital PTD Applications System Views
	When I Login to Dynamics application
	And I Switch to 'All Offline PTD Applications'
	And I Switch to 'All Offline PTD Applications (DEARA)'
	Then I verify the system view for the application 'All Offline PTD Applications (DEARA)'

Scenario: Verify if the caseworker can create a new offline PTD application and Authorise it.
	When I Login to Dynamics application
	And I Click on New to create an offline application
	And I enter 'Applicant Name' as 'Automation user'
	And I enter 'Owner Type' as 'Self'
	And I enter 'Pet Name' as 'Aurora'
	And I enter 'Species' as 'Dog'
	And I enter 'Breed' as 'Beagle'
	And I enter 'Sex' as 'Male'
	And I enter 'Date of Birth' as '09/08/2022'
	And I enter 'Age' as '12'
	And I enter 'Colour' as 'Brown, tan or chocolate'
	And I enter 'Unique feature' as 'As fast as Cheetah'
	And I enter 'Microchip Number' as 'auto'
	And I enter 'Microchipped Date' as '09/08/2023'
	And I Click on Save
	Then the status is 'Open'
	And the Record Owner By 'current user'
	And I see the Application Reference number generated
	And I can see the submission date and time
	When I 'Pass' the Microchip check
	And I go back
	And I 'Authorise' the application
	Then the status is changed to 'Authorised'
	And I dont see the Email in timeline
	And I cannot see 'Pending' command
		
Scenario: Verify if the caseworker can create a new offline PTD application, Authorise and Revoke it and no pending button visible
	When I Login to Dynamics application
	And I Click on New to create an offline application
	And I enter 'Applicant Name' as 'Automation user'
	And I enter 'Owner Type' as 'Self'
	And I enter 'Pet Name' as 'Aurora'
	And I enter 'Species' as 'Dog'
	And I enter 'Breed' as 'Beagle'
	And I enter 'Sex' as 'Male'
	And I enter 'Date of Birth' as '09/08/2022'
	And I enter 'Age' as '12'
	And I enter 'Colour' as 'Brown, tan or chocolate'
	And I enter 'Unique feature' as 'As fast as Cheetah'
	And I enter 'Microchip Number' as 'auto'
	And I enter 'Microchipped Date' as '09/08/2023'
	And I Click on Save
	Then the status is 'Open'
	And the Record Owner By 'current user'
	And I see the Application Reference number generated
	And I can see the submission date and time
	When I 'Pass' the Microchip check
	And I go back
	And I 'Authorise' the application
	Then the status is changed to 'Authorised'	
	And I cannot see 'Pending' command
	When I assign the application to myself
	And I 'Revoke' the application with reason 'Pet Deceased'
	Then the status is changed to 'Revoked'
	And I cannot see 'Pending' command
	And I dont see the Email in timeline


Scenario: Verify the Duplicate Microchip Notification for offline PTD application submitted with only mandatory fields and reject it
	When I Login to Dynamics application
	And I Click on New to create an offline application
	And I enter 'Applicant Name' as 'Automation user'
	And I enter 'Owner Type' as 'Self'
	And I enter 'Pet Name' as 'Aurora'
	And I enter 'Species' as 'Dog'
	And I enter 'Breed' as 'Beagle'
	And I enter 'Sex' as 'Male'
	And I enter 'Date of Birth' as '09/08/2022'
	And I enter 'Age' as '12'
	And I enter 'Colour' as 'Brown, tan or chocolate'
	And I enter 'Unique feature' as 'As fast as Cheetah'
	And I enter 'Microchip Number' as '564789098987654'
	And I enter 'Microchipped Date' as '09/08/2023'
	And I Click on Save
	Then the status is 'Open'
	And I 'do' see Duplicate Microchip Notification
	When I 'Fail' the Microchip check
	And I go back
	And I 'Reject' the application with reason 'Invalid MC number'
	Then the status is changed to 'Rejected'
	And I cannot see 'Pending' command

Scenario: Verify if the caseworker can update the offline PTD application multiple time when the application status is Open
	When I Login to Dynamics application
	And I Click on New to create an offline application
	And I enter 'Microchip Number' as 'auto'
	And I Click on Save
	Then the status is 'Open'
	And I see the Application Reference number generated
	And I can see the submission date and time
	When I enter 'Applicant Name' as 'Automation user'
	And I enter 'Owner Type' as 'Self'
	And I enter 'Pet Name' as 'Aurora'
	And I enter 'Species' as 'Dog'
	And I enter 'Breed' as 'Beagle'
	And I enter 'Sex' as 'Male'
	And I enter 'Date of Birth' as '09/08/2022'
	And I enter 'Age' as '12'
	And I enter 'Colour' as 'Brown, tan or chocolate'
	And I enter 'Unique feature' as 'As fast as Cheetah'
	And I enter 'Microchipped Date' as '09/08/2023'
	And I Click on Save
	
Scenario: Verify if the caseworker can update the offline PTD application multiple time when the application status is Pending
	When I Login to Dynamics application
	And I Click on New to create an offline application
	And I enter 'Microchip Number' as 'auto'
	And I Click on Save
	Then the status is 'Open'
	And I see the Application Reference number generated
	And I can see the submission date and time
	When I mark the application to 'Pending'
	Then the status is 'Pending'
	When I enter 'Applicant Name' as 'Automation user'
	And I enter 'Owner Type' as 'Self'
	And I enter 'Pet Name' as 'Aurora'
	And I enter 'Species' as 'Dog'
	And I enter 'Breed' as 'Beagle'
	And I enter 'Sex' as 'Male'
	And I enter 'Date of Birth' as '09/08/2022'
	And I enter 'Age' as '12'
	And I enter 'Colour' as 'Brown, tan or chocolate'
	And I enter 'Unique feature' as 'As fast as Cheetah'
	And I enter 'Microchip Number' as 'auto'
	And I enter 'Microchipped Date' as '09/08/2023'
	And I Click on Save

Scenario: Offline PTD Application should not be editable in Revoke Pending Status and should remain assigned with the case worker
	When I Login to Dynamics application
	And I Click on New to create an offline application
	And I enter 'Applicant Name' as 'Pets Automation'
	And I enter 'Owner Type' as 'Self'
	And I enter 'Pet Name' as 'Aurora'
	And I enter 'Species' as 'Dog'
	And I enter 'Breed' as 'Beagle'
	And I enter 'Sex' as 'Male'
	And I enter 'Date of Birth' as '09/08/2022'
	And I enter 'Age' as '12'
	And I enter 'Colour' as 'Brown, tan or chocolate'
	And I enter 'Unique feature' as 'As fast as Cheetah'
	And I enter 'Microchipped Date' as '09/08/2023'
	And I enter 'Microchip Number' as 'auto'
	And I Click on Save
	Then the status is 'Open'
	And the Record Owner By 'current user'
	And I see the Application Reference number generated
	And I can see the submission date and time
	When I 'Pass' the Microchip check
	And I go back
	And I 'Authorise' the application
	Then the status is changed to 'Authorised'
	When I assign the application to myself
	Then I move the application to Revoke Pending status
	And I cannot edit 'Pet Owner' Details
	And I cannot edit 'Pet' Details
	And I cannot edit 'Applicant details' Details

Scenario: Verify the Unique features field is empty in offline PTD application and authorise it and verify the status in CP
	When I Login to Dynamics application
	And I Click on New to create an offline application
	And I enter 'Applicant Name' as 'Pets Automation'
	And I enter 'Owner Type' as 'Self'
	And I enter 'Pet Name' as 'Aurora'
	And I enter 'Species' as 'Dog'
	And I enter 'Breed' as 'Beagle'
	And I enter 'Sex' as 'Male'
	And I enter 'Date of Birth' as '09/08/2022'
	And I enter 'Age' as '12'
	And I enter 'Colour' as 'Brown, tan or chocolate'
	And I enter 'Unique feature' as ''
	And I enter 'Microchip Number' as 'auto'
	And I enter 'Microchipped Date' as '09/08/2023'
	And I Click on Save
	Then the status is 'Open'
	And the Record Owner By 'current user'
	And I see the Application Reference number generated
	And I get the PTD Reference Number and Store it
	And I can see the submission date and time
	When I Verify the Microchip Number in Microchip Verification Check
	And I go back
	And I 'Pass' the Microchip check
	And I go back
	And I 'Authorise' the application
	Then the status is changed to 'Authorised'
	When I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the CP Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checker page
	And I have selected 'Ferry' radio option
	And I select the 'Cairnryan to Larne (P&O)' radio option
	And I have provided Scheduled departure time '11:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the PTD number of the application
	When I click search button
	And I should see the application status in 'Approved'

Scenario: Verify the Unique features field is empty in offline PTD application and reject it
	When I Login to Dynamics application
	And I Click on New to create an offline application
	And I enter 'Applicant Name' as 'Pets Automation'
	And I enter 'Owner Type' as 'Self'
	And I enter 'Pet Name' as 'Aurora'
	And I enter 'Species' as 'Dog'
	And I enter 'Breed' as 'Beagle'
	And I enter 'Sex' as 'Male'
	And I enter 'Date of Birth' as '09/08/2022'
	And I enter 'Age' as '12'
	And I enter 'Colour' as 'Brown, tan or chocolate'
	And I enter 'Unique feature' as ''
	And I enter 'Microchip Number' as '564789098982222'
	And I enter 'Microchipped Date' as '09/08/2023'
	And I Click on Save
	Then the status is 'Open'
	And I 'do' see Duplicate Microchip Notification
	When I 'Fail' the Microchip check
	And I go back
	And I 'Reject' the application with reason 'Invalid MC number'
	Then the status is changed to 'Rejected'

Scenario: Verify the error message when the future date is entered in Microchip date field
	When I Login to Dynamics application
	And I Click on New to create an offline application
	And I enter 'Microchipped Date' as 'CurrentDate+4'
	And I enter 'Pet Name' as 'Aurora'
	Then I See the error 'The date for Microchipped Date must be in the past.' notification

Scenario: Verify the error message when the future date is entered in Date of birth field
	When I Login to Dynamics application
	And I Click on New to create an offline application
	And I enter 'Date of Birth' as 'CurrentDate+4'
	And I enter 'Pet Name' as 'Aurora'
	Then I See the error 'The date for Date of Birth must be in the past.' notification

Scenario: Create a New applicant Contact is and create a offline application and authorise it
	When I Login to Dynamics application
	And I Click on New to create an offline application
	And I create a new applicant in IDCOMS
	And I enter 'Owner Type' as 'Self'
	And I enter 'Pet Name' as 'Aurora'
	And I enter 'Species' as 'Dog'
	And I enter 'Breed' as 'Beagle'
	And I enter 'Sex' as 'Male'
	And I enter 'Date of Birth' as '09/08/2022'
	And I enter 'Age' as '12'
	And I enter 'Colour' as 'Brown, tan or chocolate'
	And I enter 'Unique feature' as 'As fast as Cheetah'
	And I enter 'Microchipped Date' as '09/08/2023'
	And I enter 'Microchip Number' as 'auto'
	And I Click on Save
	Then the status is 'Open'
	And the Record Owner By 'current user'
	And I see the Application Reference number generated
	And I can see the submission date and time
	When I 'Pass' the Microchip check
	And I go back
	And I 'Authorise' the application
	Then the status is changed to 'Authorised'