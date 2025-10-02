@CPRegression
Feature: Check Outcome - SPS

SPS Port checker validates the check outcome for pass or fail

Background:
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the AP Sign in using Government Gateway page
	When I have provided the CP SPS credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checker page

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
	Then I verify Checks section with radio buttons 'Pass|Issue SUPTD|Fail' and hint ''
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