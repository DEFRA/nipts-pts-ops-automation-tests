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

Scenario: Verify the Checks home page tables display sailing route departure date and time
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '09:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	And I should see route displayed in all the tables of Checks page should be 'Birkenhead to Belfast (Stena)'
	Then I should see departure date and time displayed in all tables of Checks page

Scenario: Verify the existing login and sailing details are saved in new tab of same browser
	Then I have selected 'Ferry' radio option
	Then I select the 'Cairnryan to Larne (P&O)' radio option
	And I have provided Scheduled departure time '15:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	And I should see the header of the page with route 'Cairnryan to Larne (P&O)' current date time '15:30' and change link
	When I open a new tab in the same browser window
	And I navigate to the port checker application
	And I click signin button on port checker application
	Then I should navigate to Checks page
	And I should see the header of the page with route 'Cairnryan to Larne (P&O)' current date time '15:30' and change link