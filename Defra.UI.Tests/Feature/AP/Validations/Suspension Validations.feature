@Validations @Regression
Feature: Suspension related Validations


Background:
	Given I navigate to PETS a travel document URL
	When I have provided the password for Landing page
	Then I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the AP Sign in using Government Gateway page
	When I have provided the suspension credentials and signin
	Then I should redirected to Apply for a pet travel document page

Scenario: Verify the status and warning message and apply for a document button in suspended account
	Then I should see a suspension warning message
	And I should not see apply for a document green button
	Then I should verify the status of all records in the dashboard as 'Suspended'

Scenario: Verify the view document and print download option - Suspended
	Then I should see a suspension warning message
	When I have clicked the first ptd view hyperlink from dashboard
	Then I verify the status of the application 'Suspended'
	And I should not see issuing authority table
	Then I should not see print and download your application options