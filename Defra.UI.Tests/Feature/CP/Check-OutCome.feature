﻿@CPRegression
Feature: Check Outcome

Port checker validates the check outcome for pass or fail

Background:
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the CP Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checker page

Scenario: Validate pass outcome for approved application found by PTD number
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '10:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '4574B2' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Pass radio button
	And I click save and continue button from application status page
	Then I should navigate to Checks page
	Then The Confirmation box is displayed in Checks page

Scenario: Validate fail outcome for Pending status application found by PTD number
	Then I have selected 'Ferry' radio option
	And I select the 'Cairnryan to Larne (P&O)' radio option
	And I have provided Scheduled departure time '10:20'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '39AC94' of the application
	When I click search button
	And I should see the application status in 'Pending'
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page

Scenario: Validate pass outcome for approved application found by application number
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '11:15'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by application number' radio button
	And I provided the Reference number '6TYJHUI6' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Pass radio button
	And I click save and continue button from application status page
	Then I should navigate to Checks page

Scenario: Validate fail outcome for Pending status with color banner application found by application number
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '11:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by application number' radio button
	And I provided the Reference number '1R4QRIL3' of the application
	When I click search button
	And I should see the application status in 'Pending'
	Then I see the 'Amber' color banner
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page

Scenario: Validate pass outcome and color banner for approved application found by microchip number
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '11:45'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '561365613656136' of the application
	When I click search button
	And I should see the application status in 'Approved'
	Then I see the 'Green' color banner
	When I select Pass radio button
	And I click save and continue button from application status page
	Then I should navigate to Checks page

Scenario: Validate fail outcome for Pending status application found by microchip number
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '12:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '236782367823678' of the application
	When I click search button
	And I should see the application status in 'Pending'
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page

Scenario: Verify the error message for no selection of radio button in application status page
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '14:00'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '561365613656136' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I click save and continue button from application status page
	Then I should see an error message "Select an option" in application status page

Scenario: Verify the application status and color banner
	Then I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time '14:00'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '<PTDNumber>' of the application
	When I click search button
	And I should see the application status in '<Status>'
	Then I see the 'Red' color banner
Examples:
	| Transportation | FerryRoute                    | PTDNumber | Status       |
	| Ferry          | Birkenhead to Belfast (Stena) | 9EFC9F    | Unsuccessful |
	| Ferry          | Birkenhead to Belfast (Stena) | A6AD63    | Cancelled    |

Scenario: Verify the Reference number table
	Then I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time '14:00'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '<PTDNumber>' of the application
	When I click search button
	And I should see the application status in '<Status>'
	Then I verify the Reference number table for '<Status>' application
Examples:
	| Transportation | FerryRoute                    | PTDNumber | Status       |
	| Ferry          | Birkenhead to Belfast (Stena) | 9EFC9F    | Unsuccessful |
	| Ferry          | Birkenhead to Belfast (Stena) | C196CD    | Pending      |
	| Ferry          | Birkenhead to Belfast (Stena) | 457380    | Cancelled    |
	| Ferry          | Birkenhead to Belfast (Stena) | 586B06    | Approved     |

Scenario: Verify the Checks section and radio buttons in application summary page
	Then I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time '14:00'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '<PTDNumber>' of the application
	When I click search button
	And I should see the application status in '<Status>'
	Then I verify 'Checks' section with 'Check' subheading and 'PTD presented and valid|visual check of pet matches PTD|microchip number matches PTD|no risks identified' check points
	And I should not see any radio button options in Checks section
Examples:
	| Transportation | FerryRoute                    | PTDNumber | Status       |
	| Ferry          | Birkenhead to Belfast (Stena) | 9EFC9F    | Unsuccessful |
	| Ferry          | Birkenhead to Belfast (Stena) | A6AD63    | Cancelled    |
	| Ferry          | Birkenhead to Belfast (Stena) | 39AC94    | Pending      |

Scenario: Verify the radio buttons label and hint in application summary page
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '14:00'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '586B06' of the application
	When I click search button
	And I should see the application status in 'Approved'
	Then I verify Checks section with radio buttons 'Pass|Fail or referred to SPS' and hint 'Passes all checks.|Fails at least one check.'
