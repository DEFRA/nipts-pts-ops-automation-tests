@WelshPETS
Feature: Suspension related Validations in Welsh


Background:
	Given I navigate to PETS a travel document URL
	When I have provided the password for Landing page
	Then I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the AP Sign in using Government Gateway page
	When I have provided the suspension credentials and signin
	Then I should redirected to Apply for a pet travel document page
	When I click 'Cymraeg' link to change the language
	Then I should see the heading of dashboard page changed to Welsh

Scenario: Verify the status and warning message and apply for a document button in suspended account in Welsh
	Then I should see a suspension warning message in Welsh
	And I should not see apply for a document green button in Welsh
	And I should verify the status of all records in the dashboard as 'Suspended' in Welsh

Scenario: Verify the view document and print download option in Welsh - Suspended
	Then I should see a suspension warning message in Welsh
	When I have clicked the first ptd view hyperlink from dashboard
	Then I verify the status of the application 'Wedi’i atal' in Welsh
	And I should not see issuing authority table
	And I should not see print and download your application options