@CPRegression
Feature: Report Non Compliance

Port checker Checks application and Route Details

Background:
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the CP Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checker page

Scenario: Verify PTD details drop down link in Report non compliance page - Approved status
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '02:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '4574B2' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Refer to SPS radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click Pet Travel Document details link dropdown
	And I should see a table name for approved and revoked status as 'Pet Travel Document details'
	And I Verify the PTD number with label 'PTD number' and value '457 4B2'
	And I verify the date of issuance with label 'Date' and value '24/12/2024'
	And I Verify status with label 'Status' and value 'Approved' on Report non-compliance page

Scenario: Verify the error message for no selection of type of passenger in Report non-compliance page
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '12:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '4574B2' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Refer to SPS radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I should see 'Type of passenger' subheading under 'Passenger details' section
	When I should see 'Ferry foot passenger' 'Vehicle on ferry' radio buttons not selected by default
	And I click Report non-compliance button from Report non-compliance page
	Then I should see an error message "Select the type of passenger" in Report non-compliance page

Scenario: Verify Pet Travel Document section in Report non compliance page - Approved status
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '16:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '4574B2' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Refer to SPS radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click Pet Travel Document details link dropdown
	Then I Verify status with label 'Status' and value 'Approved' on Report non-compliance page
	And I should not see the Pet Travel Document section for 'Approved' status

Scenario: Verify Reasons heading with hint in Report non compliance page
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '02:10'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '4574B2' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Refer to SPS radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I should see the 'Reasons' heading with hint 'Select all that apply.'

Scenario Outline: Verify the Record Outcome and Any Relevant comments section in Report non compliance page
	Then I have selected 'Ferry' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time '12:40'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '<ApplicationNumber>' of the application
	When I click search button
	And I should see the application status in '<Status>'
	And I select Refer to SPS radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I should not see any relevant comments section
	Then I verify the Record Outcome 'Passenger referred to DAERA/SPS at NI port|Passenger advised not to travel|Passenger says they will not travel' checkboxes under 'Record outcome'
	And I verify the Details of Outcome label
	And I Verify the Record Outcome check boxes are not selected
Examples:
	| ApplicationNumber | FerryRoute                    | Status   |
	| 4574B2            | Birkenhead to Belfast (Stena) | Approved |
	
Scenario: Verify the navigation by clicking search and home icon from Report non compliance page
	And I have selected 'Ferry' radio option
	And I select the 'Cairnryan to Larne (P&O)' radio option
	And I have provided Scheduled departure time '16:20'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '987659898798764' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Refer to SPS radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '987659898798764' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Refer to SPS radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	When I click footer home icon
	Then I should navigate to Checks page

Scenario: Verify the Details of outcome textarea accepts only 500 characters
	Then I have selected 'Ferry' radio option
	And I select the 'Cairnryan to Larne (P&O)' radio option
	And I have provided Scheduled departure time '14:00'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '4574B2' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Refer to SPS radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	When I Select the 'Cannot find microchip' Microchip Checkbox
	Then I click 'Vehicle on ferry' in Passenger details
	And I enter details 'This could be more information about the checks or any risks you have identified  Do not include personal or sensitive information  This could be more information about the checks or any risks you have identified  Do not include personal or sensitive information  This could be more information about the checks or any risks you have identified  Do not include personal or sensitive information  This could be more information about the checks or any risks you have identified  Do not include personal' in Details of outcome
	When I click Report non-compliance button from Report non-compliance page
	Then I should see an error message "Outcome summary must be 500 characters or less" in Report non-compliance page

Scenario: Verify Other issues check boxes in Report non compliance page
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '16:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '4574B2' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Refer to SPS radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I should see the 'Other issues' subheading in visual check section
	And I verify the other issues 'Authorised person but no confirmation|Refused to sign declaration' checkboxes
	And I should see no checkboxes are selected in other issues section
	Then I should not see visual check heading and pet does not match the ptd checkbox

Scenario: Verify Pet owner details section in Report non compliance page
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '16:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '4574B2' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Refer to SPS radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I should see the 'Passenger details' subheading
	And I should see a table 'Pet owner details'
	And I should see Name 'Watson Kate' and Email 'Vinotha.Thiyagarajan+5@cognizant.com' of Pet owner
	And I should see Address '4 JACK FLETCHER CLOSE,LINCOLN,LN4 1FF' and Phone number '07897897895' of Pet owner

Scenario: Verify the Microchip section in Report non compliance page
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '16:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the 'D6BE7C' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Refer to SPS radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I Verify the Microchip section
	Then I expand and verify Microchip details '240125100121131|24/01/2022' from PTD table
	And I should not see Microchip number does not match the PTD checkbox

@CPCrossBrowser
Scenario Outline: Verify the success message after submitting the Report non compliance
	Then I have selected 'Ferry' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time '02:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '<ApplicationNumber>' of the application
	When I click search button
	And I should see the application status in '<Status>'
	And I select Refer to SPS radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click Pet Travel Document details link dropdown
	And I Verify status with label 'Status' and value '<Status>' on Report non-compliance page
	When I Select the 'Cannot find microchip' Microchip Checkbox
	Then I verify the Record Outcome 'Passenger referred to DAERA/SPS at NI port|Passenger advised not to travel|Passenger says they will not travel' checkboxes under 'Record outcome'
	And I verify the Details of Outcome label
	When I click 'Passenger says they will not travel' Record Outcome
	Then I click '<TypeOfPassenger>' in Passenger details
	When I click Save outcome button from non-compliance page
	Then I should see a message 'Information has been successfully submitted' in Checks page
Examples:
	| ApplicationNumber | FerryRoute                   | Status   | TypeOfPassenger      |
	| D6BE7C            | Cairnryan to Larne (P&O)     | Approved | Ferry foot passenger |
	| 4574B2            | Loch Ryan to Belfast (Stena) | Approved | Vehicle on ferry     |

@CPCrossBrowser
Scenario Outline: Verify passenger details section radio buttons in Report non-compliance page
	Then I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time '14:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '<PTDNumber>' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Refer to SPS radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	When I Click on Back button
	And I should see the application status in 'Approved'
	And I select Refer to SPS radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I should see 'Type of passenger' subheading under 'Passenger details' section
	And I click '<TypeOfPassenger>' in Passenger details
	When I click 'Passenger says they will not travel' Record Outcome
	And I Select the 'Cannot find microchip' Microchip Checkbox
	And I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Checks page
Examples:
	| Transportation | FerryRoute                    | PTDNumber | TypeOfPassenger      |
	| Ferry          | Birkenhead to Belfast (Stena) | 4574B2    | Ferry foot passenger |
	| Ferry          | Birkenhead to Belfast (Stena) | 4574B2    | Vehicle on ferry     |

Scenario: Verify the error message for no selection in reason section in Report non-compliance page
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '12:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '4574B2' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Refer to SPS radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I should see no checkboxes are selected in microchip section
	And I should see no checkboxes are selected in other issues section
	When I click Report non-compliance button from Report non-compliance page
	Then I should see an error message "Select at least one reason for non-compliance" in Report non-compliance page

Scenario: Verify the Report non compliance page content for flight route selection
	Then I have selected 'Flight' radio option
	Then I provide the 'RK 29Q' in the box
	And I have provided Scheduled departure time '18:49'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '4574B2' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Refer to SPS radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I should see no checkboxes are selected in microchip section
	And I should see no checkboxes are selected in other issues section
	And I should not see Type of Passenger section in Report non compliance page
	When I click 'Passenger says they will not travel' Record Outcome
	And I Select the 'Cannot find microchip' Microchip Checkbox
	And I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Checks page