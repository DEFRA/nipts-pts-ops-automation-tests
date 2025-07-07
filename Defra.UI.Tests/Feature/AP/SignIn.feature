@Regression @SmokeTest @Common @PETS
Feature: LoginLogout

As a Defra customer, I am able to sign in and sign out with valid credentials

Background: 
	Given that I navigate to the DEFRA application
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the AP Sign in using Government Gateway page

Scenario: Sign in button click validation
	Then sign in with valid credentials with logininfo

Scenario: Sign out button click validation
	Then sign in with valid credentials with logininfo
	And  click on signout button and verify the signout message
	
Scenario: Sign Up
	Then I click on Create Sign In Details
	When I enter an email address with reference 'opspetsauto' to receive a confirmation code and continue
	And I enter the Confirmation code
	And I Click on Contine Button
	And I Click on Contine Button
	And I enter full name 'OpsAP Automation'
	And I Click on Contine Button
	And I enter the Password 'G0vernmen+'
	And I Click on Contine Button
	Then I Save the GGID
	When I Click on Contine Button
	And I Click on Contine Button
	And I Click on Contine Button
	And I Click on Contine Button
	And I select a Individual User
	And I Click on Contine Button
	And I enter the First name 'OpsPets' and Last name 'Automation'
	And I Click on Contine Button
	And I enter the telephone number '07689837745'
	And I Click on Contine Button
	And I enter the Postcode 'OX1 1AF'
	And I Click on Contine Button
	And I select the address from the dropdown 
	And I Click on Contine Button
	And I enter the memorable word 'Opstesting' and hint 'Opstesting'
	And I Click on Contine Button
	And I click on Confirm and complete registeration
	Then I should navigate to Lifelong pet travel documents page


