@WelshChangeDetails
Feature: ManageAccount Welsh

Background: 
	Given that I navigate to the DEFRA application
	When I have provided the password for Landing page
	Then I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the AP Sign in using Government Gateway page
	And sign in with valid credentials with logininfo
	When I click 'Cymraeg' link to change the language
	Then I should see the heading of dashboard page changed to Welsh

Scenario: Change Phone Number in Manage account in Welsh
	Then I should navigate to Manage account in Welsh	
	And I verify the Manage your account page content in Welsh
	And I click on Manage your account in Welsh
	And I click on Update Details link
	And I click on Change Personal Information link
	And I clicked Change link for Telephone number
	And I enter updated Phone number
	And I click Continue
	And I click on Back button
	And I click on Back button
	And I go back to Pets application
	When  click on signout button and verify the signout message	
	Then I click on Taking a pet from Great Britain to Northern Ireland link
	And I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the AP Sign in using Government Gateway page
	And sign in with valid credentials with logininfo
	Then I should see the heading of dashboard page changed to Welsh
	When I click apply for a document button in Welsh
	Then I should redirected to the Are your details correct page in Welsh
	And I verify the updated Phone number in Welsh

Scenario: Change Name in Manage account in Welsh
	Then I should navigate to Manage account in Welsh
	And I verify the Manage your account page content in Welsh
	And I click on Manage your account in Welsh
	And I click on Update Details link
	And I click on Change Personal Information link
	And I clicked Change link for Name
	And I enter updated First Name
	And I enter updated Last Name
	And I click Continue
	And I click on Back button
	And I click on Back button
	And I go back to Pets application
	When  click on signout button and verify the signout message	
	Then I click on Taking a pet from Great Britain to Northern Ireland link
	And I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the AP Sign in using Government Gateway page
	And sign in with valid credentials with logininfo
	Then I should see the heading of dashboard page changed to Welsh
	When I click apply for a document button in Welsh
	Then I should redirected to the Are your details correct page in Welsh
	And I verify the updated Pet Owner Name in Welsh
	Then I should navigate to Manage account in Welsh
	And I click on Manage your account in Welsh
	And I click on Update Details link
	And I click on Change Personal Information link
	And I clicked Change link for Name
	And I revert the Pet Owner Name to the Original Name

Scenario Outline: Change Address in Manage account in Welsh
	Then I should navigate to Manage account in Welsh
	And I click on Manage your account in Welsh
	And I click on Update Details link
	And I click on Change Personal Information link
	And I clicked Change link for Address
	And I click on Search for my address by UK Postcode link
	And I enter the valid <postcode> Postcode
	And I click find address button
	And I select the address
	And I click Continue
	And I click on Back button
	And I click on Back button
	And I go back to Pets application
	When  click on signout button and verify the signout message	
	Then I click on Taking a pet from Great Britain to Northern Ireland link
	And I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the AP Sign in using Government Gateway page
	And sign in with valid credentials with logininfo
	Then I should see the heading of dashboard page changed to Welsh
	When I click apply for a document button in Welsh
	Then I should redirected to the Are your details correct page in Welsh
	And I verify the updated Pet Owner Address in Welsh
	
Examples:
	| postcode         |
	| CV1 4PY,RG1 3JN  |
