@CPRegression
Feature: Change Route Checking Details

As a PTS port checker I want ot Change Route Checking Details from all pages

Background: 
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page

Scenario: Change Route Checking Details from Home page verification
	And I have selected 'Ferry' radio option
	And I select the 'Cairnryan to Larne (P&O)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Checks page
	And I click change link from headers
	And I should redirected to port route checke page

Scenario: Change Route Checking Details from search page verification
	And I have selected 'Ferry' radio option
	And I select the 'Cairnryan to Larne (P&O)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click change link from headers
	And I should redirected to port route checke page

Scenario: Change Route Checking Details from search results page verification
	And I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '561365613656136' of the application
	When I click search button
	Then I click change link from headers
	And I should redirected to port route checke page

Scenario: Validate home page navigation by clicking home icon in the footer
	And I have selected 'Ferry' radio option
	And I select the 'Cairnryan to Larne (P&O)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	And I click search button from footer
	Then I navigate to Find a document page
	When I click footer home icon
	Then I should navigate to Checks page
