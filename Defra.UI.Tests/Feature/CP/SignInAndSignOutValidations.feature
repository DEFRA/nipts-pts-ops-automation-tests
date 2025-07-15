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

Scenario: Verify unauthouried signin in compliance portal
	When I have provided invalid CP credentials and signin
	Then I should navigate to 'You cannot access this page or perform this action' error page
	And I should see 'Contact your team leader with any queries.' text under the main heading of error page
	And I should not see the footer of the page
	Then I should not see the header of the page
	And I should not see account and signout icons