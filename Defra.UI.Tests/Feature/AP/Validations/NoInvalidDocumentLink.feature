@Validations
Feature: No Invalid Document Link


Background:
	Given I navigate to PETS a travel document URL
	When I have provided the password for Landing page
	Then I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the AP Sign in using Government Gateway page
	When I have provided the user credentials without any Invalid document and signin
	Then I should redirected to Apply for a pet travel document page

@PipelineFailure
Scenario: Verify the No Invalid link is not present
	Then I Should not see the invalid documents link