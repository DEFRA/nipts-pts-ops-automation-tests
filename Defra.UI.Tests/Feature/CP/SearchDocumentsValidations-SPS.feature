@CPRegression
Feature: Search Documents Validations - SPS

SPS Port checker validates Search documents and Change Route details

Background: 
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the CP Sign in using Government Gateway page
	When I have provided the CP SPS credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checker page

Scenario: Verify the navigation for change link click in header from search page
	And I have selected 'Ferry' radio option
	And I select the 'Cairnryan to Larne (P&O)' radio option
	And I have provided Scheduled departure time '14:20'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click change link from headers
	And I should redirected to port route checker page

Scenario: Verify the data entered remains in the text box of Find a document page - SPS Checker
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '23:50'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '4574B2' of the application
	Then I click search by 'Search by application number' radio button
	And I provided the Application Number 'ZRWD8KG6' of the application
	Then I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '987659898798764' of the application
	Then I click search by 'Search by PTD number' radio button
	And I should see the already entered PTD number '4574B2' in the text box
	Then I click search by 'Search by application number' radio button
	And I should see the already entered application number 'ZRWD8KG6' in the text box
	Then I click search by 'Search by microchip number' radio button
	And I should see the already entered microchip number '987659898798764' in the text box

Scenario: Verify the Clear search functionality in Find a Document page - SPS Checker
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '08:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '12345' of the application
	When I click clear search button
	Then I see the values are deleted

Scenario Outline: Verify the SPS User is able to search by PTD Number
	Then I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time '14:00'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '<PTDNumber>' of the application
	When I click search button
	And I should see the application status in '<Status>'
Examples:
	| Transportation | FerryRoute                    | PTDNumber | Status       | Species |
	| Ferry          | Birkenhead to Belfast (Stena) | 9EFC9F    | Unsuccessful | Ferret  |
	| Ferry          | Birkenhead to Belfast (Stena) | D6BE7C    | Approved     | Cat     |

Scenario: Verify the SPS User is able to search by Microchip Number
	And I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '12:20'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '561365613656136' of the application
	When I click search button
	And I should see the application status in 'Approved'

Scenario: Verify the SPS User is able to search by Application Reference Number
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '14:45'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by application number' radio button
	And I provided the Application Number 'HATAIMZE' of the application
	When I click search button
	And I should see the application status in 'Pending'