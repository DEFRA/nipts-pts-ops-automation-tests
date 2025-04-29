@CPRegression @CPCrossBrowser
Feature: Check Outcome - SPS

SPS Port checker validates the check outcome for pass or fail

Background:
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the CP Sign in using Government Gateway page
	When I have provided the CP SPS credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checker page

Scenario: Verify the Checks section and radio buttons in application summary page as SPS Checker
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
	| Ferry          | Birkenhead to Belfast (Stena) | C196CD    | Pending      |

Scenario: Verify the radio buttons label, hint and Pass outcome with in application summary page for Approved document as SPS Checker
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
	When I select Pass radio button
	And I click save and continue button from application status page
	Then I should navigate to Checks page
	Then The Confirmation box is displayed in Checks page

Scenario: Verify the error message for no selection of radio button in application status page as SPS Checker
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

Scenario: Validate fail outcome for Pending status application found by PTD number as SPS Checker
	Then I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time '10:20'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '<PTDNumber>' of the application
	When I click search button
	And I should see the application status in '<Status>'
	And I continue button from application status page
	Then I should navigate to Report non-compliance page
Examples:
	| Transportation | FerryRoute                    | PTDNumber | Status       |
	| Ferry          | Birkenhead to Belfast (Stena) | 9EFC9F    | Unsuccessful |
	| Ferry          | Birkenhead to Belfast (Stena) | A6AD63    | Cancelled    |
	| Ferry          | Birkenhead to Belfast (Stena) | 39AC94    | Pending      |