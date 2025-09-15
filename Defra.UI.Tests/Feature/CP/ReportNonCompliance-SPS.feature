@CPRegression
Feature: Report Non Compliance - SPS

SPS Port checker Checks application and Route Details

Background:
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the CP Sign in using Government Gateway page
	When I have provided the CP SPS credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checker page

Scenario: Verify Reasons heading with hint in Report non compliance page as SPS Checker - Approved status
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
	And I select Fail radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I should see the 'Reasons' heading with hint 'Select all that apply.'

Scenario Outline: Verify Details of Outcome label in Report non compliance page for Approved application as SPS Checker
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '12:40'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '4574B2' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I verify the Details of Outcome label

Scenario: Verify the error message for no selection in reason section in Report non-compliance page as SPS Checker
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
	And I select Fail radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I should see no checkboxes are selected in microchip section
	And I should see no checkboxes are selected in other issues section
	When I click Report non-compliance button from Report non-compliance page
	Then I should see an error message "Select at least one reason for non-compliance" in Report non-compliance page