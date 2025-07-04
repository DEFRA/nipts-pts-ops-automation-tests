@CPRegression
Feature: Checks Page Validations

Port checker validates Checks home page tables and details in it

Background: 
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the CP Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checker page

Scenario: Verify selected departure time displays in home page
	Then I have selected 'Flight' radio option
	Then I provide the 'AF296Q' in the box
	Then I have selected current date '-1' Date option
	And I have provided Scheduled departure time '18:30'
	When I click save and continue button from route checker page
	Then I should see departure date current date '-1' and time '18:30' on top of the home page

Scenario: Verify the home page content for flight route selection
	Then I have selected 'Flight' radio option
	Then I provide the 'AF296Q' in the box
	And I have provided Scheduled departure time '10:40'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	And I should see content 'You can scan or search for:' with list 'PTD number' 'application number' 'microchip number'

Scenario: Verify the Checks home page filter and display only the selected ferry route
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '09:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	And I should see route displayed in all the tables of Checks page should be 'Birkenhead to Belfast (Stena)'