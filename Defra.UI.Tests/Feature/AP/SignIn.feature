@Regression @SmokeTest @Common @PETS
Feature: LoginLogout

As a Defra customer, I am able to sign in and sign out with valid credentials

Background: 
	Given that I navigate to the DEFRA application
	When I have provided the password for Landing page
	Then I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the AP Sign in using Government Gateway page
	When I have provided the credentials and signin
	Then I should redirected to Apply for a pet travel document page

Scenario: Sign in button click validation
	Then sign in with valid credentials with logininfo

Scenario: Sign out button click validation
	Then sign in with valid credentials with logininfo
	And  click on signout button and verify the signout message

Scenario: Verify the footer links access before signing in to the pets application
	Then  I click the TermsAndConditions Link
	And I should navigate to the TermsAndConditions details page
	Then I should not see manage account and sign out links
	And I close the current tab and switch back to government gateway page
	Then I click the AccessibilityStatement Link
	And I should navigate to the AccessibilityStatement details page
	Then I should not see manage account and sign out links
	And I close the current tab and switch back to government gateway page
	Then  I click the Cookies Link
	And I should navigate to the Cookies details page
	Then I should not see manage account and sign out links

Scenario: Verify the user not able to enter the previous session after signing out
	Then sign in with valid credentials with logininfo
	And  click on signout button and verify the signout message
	When I click browser back button
	Then I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the AP Sign in using Government Gateway page
	And I click sign in button
	And I should see an error message "Enter Government Gateway user ID&Enter your password" in Government Gateway page

Scenario: Verify the user not able to enter the previous session after signing out from manage account page
	Then sign in with valid credentials with logininfo
	Then I should navigate to Manage account
	And I click on Manage your account
	And I click on signout button from your defra account page and verify the signout message
	Given that I navigate to the DEFRA application
	Then I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the AP Sign in using Government Gateway page
	And I click sign in button
	And I should see an error message "Enter Government Gateway user ID&Enter your password" in Government Gateway page
