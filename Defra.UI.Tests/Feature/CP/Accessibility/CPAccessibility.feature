@CPAccessibility
Feature: Compliance Portal Accessibility Automation

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
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
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
	When I click save and continue button from application status page
	Then I should navigate to Checks page

Scenario: Validate fail outcome for Awaiting verification status application found by PTD number
	Then I have selected 'Ferry' radio option
	Then I select the 'Cairnryan to Larne (P&O)' radio option
	And I have provided Scheduled departure time '10:20'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '39AC94' of the application
	When I click search button
	And I should see the application status in 'Awaiting verification'
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page

Scenario: Verify the application status and color banner
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
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
	| Ferry          | Birkenhead to Belfast (Stena) | A6AD63    | Revoked      |
