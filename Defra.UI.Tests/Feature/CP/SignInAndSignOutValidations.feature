@CPRegression
Feature: SignIn And SignOut Validations

Port checker login and logout from Checker Portal Application

Background: 
	Given that I navigate to the port checker application
	Then I Verify the Access Start Page Content

Scenario: Validate Sign in feature
	When I click signin button on port checker application
	Then I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the CP Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checker page

Scenario: Validate Sign out feature
	When I click signin button on port checker application
	Then I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the CP Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then click on signout button on CP and verify the signout message

Scenario: Verify unauthouried signin in compliance portal
	When I click signin button on port checker application
	Then I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the CP Sign in using Government Gateway page
	When I have provided invalid CP credentials and signin
	Then I should navigate to 'You cannot access this page or perform this action' error page
	And I should see 'Contact your team leader with any queries.' text under the main heading of error page
	And I should not see the footer of the page
	Then I should not see the header of the page
	And I should not see account and signout icons

Scenario: Verify accessibility statement link and content headings of the page
	And I verify 'Accessibility statement' link below the header
	When I click accessibility statement link
	And I have provided the password for prototype research page
	Then I should redirected to accessibility page with 'Check a pet travelling from GB to NI' header
	And I verify the main heading of the page as 'Accessibility statement for Check a pet travelling from GB to NI'
	Then I verify the sub headings of the accessibility statement page

Scenario: Verify accessibility statement page links and navigation
	When I click accessibility statement link
	And I have provided the password for prototype research page
	Then I should redirected to accessibility page with 'Check a pet travelling from GB to NI' header
	And I verify the main heading of the page as 'Accessibility statement for Check a pet travelling from GB to NI'
	Then I verify all the links in the accessibility statement page
	And I click back link
	Then I Verify the Access Start Page Content
