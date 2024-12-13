Feature: Compliance Portal Accessibility

As a PTS port checker I want to verify details from all pages

Background: 
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page

Scenario: Port checker Change Route Checking Details from Search results page
	And I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Welcome page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '123456789012345' of the application
	When I click search button
	Then I should see the application status in 'Pending'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page