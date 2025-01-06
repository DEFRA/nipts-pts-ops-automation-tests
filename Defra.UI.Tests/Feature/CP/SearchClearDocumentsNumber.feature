@CPRegression
Feature: Search Clear Documents Number

As a PTS port checker I want ot Clear documents number from Find a document search box


Background: 
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page

	
Scenario: Error message validation for search button click after clearing the given PTD number
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '12345' of the application
	When I click clear search button
	And I click search button
	Then I should see an error message "Enter a PTD number" in Find a document page

Scenario: Error message validation for search button click after clearing the given application number
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by application number' radio button
	And I provided the Application Number 'QRWD9DZ' of the application
	When I click clear search button
	Then I click search by 'Search by application number' radio button
	When I click search button
	Then I should see an error message "Enter an application number" in Find a document page

Scenario: Error message validation for search button click after clearing the given microchip number
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '123456089012340' of the application
	When I click clear search button
	Then I click search by 'Search by microchip number' radio button
	When I click search button
	Then I should see an error message "Enter a microchip number" in Find a document page