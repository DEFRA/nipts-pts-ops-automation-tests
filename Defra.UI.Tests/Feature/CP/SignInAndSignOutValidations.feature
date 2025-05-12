@CPRegression
Feature: SignIn And SignOut Validations

Port checker login and logout from Checker Portal Application

Background: 
	Given that I navigate to the port checker application
	Then I Verify the Access Start Page Content
	When I click signin button on port checker application
	Then I should redirected to the CP Sign in using Government Gateway page

Scenario: Validate Sign in feature
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checker page

Scenario: Validate Sign out feature
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then click on signout button on CP and verify the signout message