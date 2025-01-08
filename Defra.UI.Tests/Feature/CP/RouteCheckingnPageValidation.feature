@CPRegression
Feature: Route Checking Page Validation

Validating the negative scenarios for Route Checking Information

Background: 
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checker page	

Scenario: Verify the error message if no selection of ferry or flight route
	Then I have selected '' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checker page
	Then I should see an error 'Select if you are checking a ferry or a flight' in route checking page

Scenario: Verify the error message if no selection of ferry route
	Then I have selected 'Ferry' radio option
	Then I select the '' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checker page
	Then I should see an error message "Select the ferry you are checking" in route checking page

Scenario: Verify the error message if no flight number provided in the flight route
	Then I have selected 'Flight' radio option
	Then I provide the '' in the box
	And I have provided Scheduled departure time
	When I click save and continue button from route checker page
	Then I should see an error message "Enter the flight number you are checking" in route checking page	  

Scenario: Verify home page for flight Number text box with special character
	Then I have selected 'Flight' radio option
	Then I provide the 'a-z$&*' in the box
	And I have provided Scheduled departure time
	When I click save and continue button from route checker page
	Then I should navigate to Checks page

Scenario: Verify error message for no scheduled departure date details provided
	Then I have selected 'Flight' radio option
	Then I provide the 'AF296Q' in the box
	Then I have selected ''''''Date option
	And  I have provided Scheduled departure time
	When I click save and continue button from route checker page
	Then I should see an error message "Enter the scheduled departure date, for example 27 3 2024" in route checking page

Scenario: Verify error message for scheduled departure date with special character
	Then I have selected 'Flight' radio option
	Then I provide the 'AF296Q' in the box
	Then I have selected '£$''*&''%^'Date option
	And  I have provided Scheduled departure time
	When I click save and continue button from route checker page
	Then I should see an error message "Enter the date in the correct format, for example 27 3 2024" in route checking page

Scenario: Verify error message for any one empty box in scheduled departure date
	Then I have selected 'Flight' radio option
	Then I provide the 'AF296Q' in the box
	Then I have selected '07''''19992'Date option
	And  I have provided Scheduled departure time
	When I click save and continue button from route checker page
	Then I should see an error message "Enter the date in the correct format, for example 27 3 2024" in route checking page

Scenario: Verify the error message if no selection of scheduled departure time details 
	Then I have selected 'Flight' radio option
	Then I provide the 'AF296Q' in the box
	Then I have selected '27''02''2025'Date option
	When I click save and continue button from route checker page
	Then I should see an error message "Enter the scheduled departure time, for example 15:30" in route checking page

Scenario: Verify the error message if only hour details provided in the scheduled departure time
	Then I have selected 'Flight' radio option
	Then I provide the 'AF296Q' in the box
	And  I have provided Scheduled departure time in hours field only
	When I click save and continue button from route checker page
	Then I should see an error message "Enter the scheduled departure time, for example 15:30" in route checking page