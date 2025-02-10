@CPRegression @CPCrossBrowser
Feature: Report Non Compliance

Port checker Checks application and Route Details

Background:
	Given that I navigate to the port checker application
	And I click signin button on port checker application
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
	And I provided the '4574B2' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click Pet Travel Document details link dropdown
	Then I should see a table name for approved and revoked status as 'Pet Travel Document (PTD)'
	And I Verify the PTD number '457 4B2'
	Then I verify the date of issuance '24/12/2024'
	And I Verify status 'Approved' on Report non-compliance page

Scenario: Verify PTD details drop down link in Report non compliance page - Awaiting verification status
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '08:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '236782367823678' of the application
	When I click search button
	And I should see the application status in 'Awaiting verification'
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click Pet Travel Document details link dropdown
	Then I should see a table name as 'Application Details'
	And I Verify the reference number 'XC7I93AF'
	Then I verify the date of issuance '13/12/2024'
	And I Verify status 'Awaiting verification' on Report non-compliance page

Scenario: Verify PTD details drop down link in Report non compliance page - Revoked status
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '02:50'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '398934673434237' of the application
	When I click search button
	And I should see the application status in 'Revoked'
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click Pet Travel Document details link dropdown
	Then I should see a table name for approved and revoked status as 'Pet Travel Document (PTD)'
	And I Verify the PTD number 'AB5 17A'
	Then I verify the date of issuance '25/10/2024'
	And I Verify status 'Revoked' on Report non-compliance page
	
Scenario: Verify PTD details drop down link in Report non compliance page - Unsuccessful status
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '02:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '987659871298713' of the application
	When I click search button
	And I should see the application status in 'Unsuccessful'
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click Pet Travel Document details link dropdown
	Then I should see a table name as 'Application details'
	And I Verify the reference number '0CI5N6V6'
	Then I verify the date of issuance '14/11/2024'
	And I Verify status 'Unsuccessful' on Report non-compliance page

Scenario: Verify the error message for no selection of type of passenger in Report non-compliance page
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '12:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '4574B2' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	When I click Report non-compliance button from Report non-compliance page
	Then I should see an error message "Select a type of passenger" in Report non-compliance page

Scenario Outline: Verify passenger details section radio buttons in Report non-compliance page
	Then I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time '14:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '<PTDNumber>' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	When I Click on Back button
	And I should see the application status in 'Approved'
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	Then I should see 'Type of passenger' subheading under 'Passenger details' section
	And I click '<TypeOfPassenger>' in Passenger details
	When I click 'Passenger says they will not travel' GB Outcome
	And I Select the 'Cannot find microchip' Microchip Checkbox
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Checks page
	
Examples:
	| Transportation | FerryRoute                    | PTDNumber | TypeOfPassenger |
	| Ferry          | Birkenhead to Belfast (Stena) | 4574B2    | Foot passenger  |
	| Ferry          | Birkenhead to Belfast (Stena) | 4574B2    | Vehicle         |

Scenario: Verify Pet Travel Document section in Report non compliance page - Approved status
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '16:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '4574B2' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click Pet Travel Document details link dropdown
	And I Verify status 'Approved' on Report non-compliance page
	And I should not see the Pet Travel Document section for 'Approved' status

Scenario: Verify Pet Travel Document section in Report non compliance page - Awaiting verification status
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '13:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '39AC94' of the application
	When I click search button
	And I should see the application status in 'Awaiting verification'
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click Pet Travel Document details link dropdown
	And I Verify status 'Awaiting verification' on Report non-compliance page
	And I should see the Pet Travel Document section with status 'PTD awaiting verification'

Scenario: Verify Pet Travel Document section in Report non compliance page
	Then I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time '02:20'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '<PTDNumber>' of the application
	When I click search button
	And I should see the application status in '<Status>'
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click Pet Travel Document details link dropdown
	And I Verify status '<Status>' on Report non-compliance page
	And I should see the Pet Travel Document section with status '<PTD Status>'

Examples:
	| Transportation | FerryRoute                    | PTDNumber | Status       | PTD Status       |
	| Ferry          | Birkenhead to Belfast (Stena) | 9EFC9F    | Unsuccessful | PTD unsuccessful |
	| Ferry          | Birkenhead to Belfast (Stena) | A6AD63    | Revoked      | PTD revoked      |

Scenario: Verify Reasons heading with hint in Report non compliance page - Awaiting verification status
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '02:10'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '39AC94' of the application
	When I click search button
	And I should see the application status in 'Awaiting verification'
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I should see the 'Reasons' heading with hint 'Select all that apply.'

Scenario: Verify Reasons and Any Relavant comments heading with hint in Report non compliance page
	Then I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time '12:10'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '<PTDNumber>' of the application
	When I click search button
	And I should see the application status in '<Status>'
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I should see the 'Reasons' heading with hint 'Select all that apply.'
	And I verify any relavant comments section

Examples:
	| Transportation | FerryRoute                    | PTDNumber | Status       |
	| Ferry          | Birkenhead to Belfast (Stena) | 9EFC9F    | Unsuccessful |
	| Ferry          | Birkenhead to Belfast (Stena) | A6AD63    | Revoked      |


Scenario Outline: Verify GB and SPS Outcome in Report non compliance page
	Then I have selected 'Ferry' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time '12:40'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '<ApplicationNumber>' of the application
	When I click search button
	And I should see the application status in '<Status>'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I verify the GB Outcome 'Passenger referred to DAERA/SPS at NI port|Passenger advised not to travel|Passenger says they will not travel' checkboxes
	And I verify the SPS Outcome 'Allowed to travel under Windsor Framework|Not allowed to travel under Windsor Framework' options
	And I verify the Details of Outcome label
	And I Verify the GB and SPS Outcomes are not selected
	And I verify the Details of Outcome textarea maximum length is '500'
Examples:
	| ApplicationNumber | FerryRoute                    | Status   |
	| 4574B2            | Birkenhead to Belfast (Stena) | Approved |
	
Scenario Outline: Verify GB and SPS Outcome in Report non compliance page for unsuccessful applications
	Then I have selected 'Ferry' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time '11:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '<ApplicationNumber>' of the application
	When I click search button
	And I should see the application status in '<Status>'
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I verify the GB Outcome 'Passenger referred to DAERA/SPS at NI port|Passenger advised not to travel|Passenger says they will not travel' checkboxes
	And I verify the SPS Outcome 'Allowed to travel under Windsor Framework|Not allowed to travel under Windsor Framework' options
	And I verify the Details of Outcome label
	And I verify the Details of Outcome textarea maximum length is '500'
Examples:
	| ApplicationNumber | FerryRoute                   | Status                |
	| 9EFC9F            | Cairnryan to Larne (P&O)     | Unsuccessful          |
	| A6AD63            | Loch Ryan to Belfast (Stena) | Revoked               |
	| 8E375B            | Loch Ryan to Belfast (Stena) | Awaiting verification |


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
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '987659898798764' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
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
	And I provided the '9EFC9F' of the application
	When I click search button
	And I should see the application status in 'Unsuccessful'
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I verify the Details of Outcome textarea maximum length is '500'

Scenario: Verify Visual check subheading and pet details from PTD dropdown in Report non compliance page
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '16:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '4574B2' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	Then I should see the 'Visual check' subheading
	And I should click 'Pet details from PTD' link next to the subheading

Scenario: Verify the check box in Visual check section of Report non compliance page
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '16:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '4574B2' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I should see the 'Visual check' subheading
	Then I should see a checkbox 'Pet does not match the PTD' is not selected

Scenario: Verify Other issues check boxes in Visual check section of Report non compliance page
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '16:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '4574B2' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I should see the 'Visual check' subheading
	Then I should see the 'Other issues' subheading in visual check section
	And I verify the other issues 'Potential commercial movement|Authorised traveller but no confirmation|Other reason' checkboxes
	Then I should see a hint 'This could be about the PTD and any risks identified.' next to Other reason option
	And I should see no checkboxes are selected in other issues section

Scenario: Verify Visual check Pet details from PTD dropdown table in Report non compliance page
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '16:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '4574B2' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I should see the 'Visual check' subheading
	Then I should click 'Pet details from PTD' link next to the subheading
	And I should see a table 'Pet details from PTD or application'
	Then I should see Species 'Dog' Breed 'Afghan Hound' Sex 'Male' Date of birth '07/10/2018' Colour 'Brown, tan or chocolate' and Significant features 'No' in the table

Scenario: Verify Pet owner details section in Report non compliance page
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '16:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '4574B2' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I should see the 'Pet owner details' subheading
	Then I should see a table 'Pet owner details'
	And I should see Name 'Watson Kate' and Email 'Vinotha.Thiyagarajan+5@cognizant.com' of Pet owner
	Then I should see Address '4 JACK FLETCHER CLOSE,LINCOLN,LN4 1FF' and Phone number '07897897895' of Pet owner

Scenario: Verify the Microchip section in Report non compliance page
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '16:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the 'D6BE7C' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I Verify the Microchip section
	And I expand and verify Microchip details '240125100121131|24/01/2022' from PTD table

Scenario Outline: Verify the error message for Microchip number textbox in Report non compliance page
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '16:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the 'D6BE7C' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click 'Vehicle' in Passenger details
	When I click 'Passenger says they will not travel' GB Outcome
	When I Select the 'Microchip number does not match the PTD' Microchip Checkbox
	And I enter the Microchip number in '<MicrochipNumber>' in Report non-compliance page
	And I click Report non-compliance button from Report non-compliance page
	Then I should see an error message '<ErrorMessage>' in Report non-compliance page
Examples:
	| ErrorMessage                                            | MicrochipNumber   |
	| Enter the 15-digit microchip number                     |                   |
	| Enter the 15-digit microchip number, using only numbers | 19890989834567823 |
	| Enter the 15-digit microchip number, using only numbers | 1233356           |
	| Enter the 15-digit microchip number, using only numbers | TestingMC         |
	| Enter the 15-digit microchip number, using only numbers | "£%$^&<>          |
	

Scenario: Verify the success message after submitting the Report non compliance
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '02:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '9EFC9F' of the application
	When I click search button
	And I should see the application status in 'Unsuccessful'
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I should see 'Type of passenger' subheading under 'Passenger details' section
	Then I click 'Vehicle' in Passenger details
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Checks page
	And I should see a message 'Information has been successfully submitted' in Checks page