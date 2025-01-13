@CPRegression
Feature: Report Non Compliance

Port checker Checks application and Route Details

Background:
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checker page

Scenario: Verify PTD details drop down link in Report non compliance page - Approved status
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
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
	Then I should see a table name as 'Pet Travel Document (PTD)'
	And I Verify status 'Approved' on Report non-compliance page

Scenario: Verify PTD details drop down link in Report non compliance page - Awaiting verification status
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '236782367823678' of the application
	When I click search button
	And I should see the application status in 'Awaiting verification'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click Pet Travel Document details link dropdown
	And I Verify status 'Awaiting verification' on Report non-compliance page

Scenario: Verify PTD details drop down link in Report non compliance page - Revoked status
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the 'A6AD63' of the application
	When I click search button
	And I should see the application status in 'Revoked'
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click Pet Travel Document details link dropdown
	Then I should see a table name as 'Pet Travel Document (PTD)'
	And I Verify status 'Revoked' on Report non-compliance page
	
Scenario: Verify PTD details drop down link in Report non compliance page - Unsuccessful status
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '9EFC9F' of the application
	When I click search button
	And I should see the application status in 'Unsuccessful'
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click Pet Travel Document details link dropdown
	And I Verify status 'Unsuccessful' on Report non-compliance page

Scenario: Verify the error message for no selection of type of passenger in Report non-compliance page
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
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
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
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
	And I click '<TypeOfPassenger>' in Passenger details
	When I click Report non-compliance button from Report non-compliance page
	Then I should navigate to Checks page
	
Examples:
	| Transportation | FerryRoute                    | PTDNumber | TypeOfPassenger |
	| Ferry          | Birkenhead to Belfast (Stena) | 4574B2    | Foot passenger  |
	| Ferry          | Birkenhead to Belfast (Stena) | 4574B2    | Vehicle         |

Scenario: Verify Pet Travel Document section in Report non compliance page - Approved status
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
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
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '39AC94' of the application
	When I click search button
	And I should see the application status in 'Awaiting verification'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click Pet Travel Document details link dropdown
	And I Verify status 'Awaiting verification' on Report non-compliance page
	And I should see the Pet Travel Document section with status 'PTD awaiting verification'

Scenario: Verify Pet Travel Document section in Report non compliance page
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
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
	And I have provided Scheduled departure time
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '39AC94' of the application
	When I click search button
	And I should see the application status in 'Awaiting verification'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I should see the 'Reasons' heading with hint 'Select all that apply.'

Scenario: Verify Reasons heading with hint in Report non compliance page
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
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

Examples:
	| Transportation | FerryRoute                    | PTDNumber | Status       |
	| Ferry          | Birkenhead to Belfast (Stena) | 9EFC9F    | Unsuccessful |
	| Ferry          | Birkenhead to Belfast (Stena) | A6AD63    | Revoked      |


Scenario Outline: Verify GB and SPS Outcome in Report non compliance page - Awaiting Verification and Approved
	Then I have selected 'Ferry' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
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
	And I verify the Details of Outcome textarea maximum length is '500'
Examples:
	| ApplicationNumber | FerryRoute                    | Status                |
	| 4574B2            | Birkenhead to Belfast (Stena) | Approved              |
	| 8E375B            | Loch Ryan to Belfast (Stena)  | Awaiting verification |

Scenario Outline: Verify GB and SPS Outcome in Report non compliance page - Unsuccessful and Revoked
	Then I have selected 'Ferry' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time
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
	| ApplicationNumber | FerryRoute                   | Status       |
	| 9EFC9F            | Cairnryan to Larne (P&O)     | Unsuccessful |
	| A6AD63            | Loch Ryan to Belfast (Stena) | Revoked      |