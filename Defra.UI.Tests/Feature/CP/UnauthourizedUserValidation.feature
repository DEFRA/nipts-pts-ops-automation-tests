@CPRegression
Feature: Unauthourized User Validation

Unauthourized User - AP User logging in Compliance Portal

Background:
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the CP Sign in using Government Gateway page

Scenario: Verify unauthouried signin in compliance portal
	When I have provided invalid credentials and signin
	Then I should navigate to 'You cannot access this page or perform this action' error page
	And I should see 'Contact your team leader with any queries.' text under the main heading of error page
	And I should not see the footer of the page
	Then I should not see the header of the page
	And I should not see account and signout icons
