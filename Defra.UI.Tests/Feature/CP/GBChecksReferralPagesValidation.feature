@CPRegression @CPCrossBrowser
Feature: GB Checks Referral pages validation

Referred to SPS and GB check report page validation

Background: 
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the CP Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checker page

Scenario: Verify GB check report page title
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '16:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click View link in Fail Referred to SPS row with count more than 0
	Then I should navigate to Referred to SPS page
	When I click first link in PTD or Reference number
	Then I should navigate to GB check report page

