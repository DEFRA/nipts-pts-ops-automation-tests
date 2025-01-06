@CPRegression
Feature: CP Route Checking Validation

Validating the negative scenarios for Route Checking Information

Background: 
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checke page
	

Scenario: Error message validation for no selection of ferry or flight route
	Then I have selected '' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should see an error 'Select if you are checking a ferry or a flight' in route checking page

Scenario: Error message validation for no selection of ferry route
	Then I have selected 'Ferry' radio option
	Then I select the '' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should see an error message "Select the ferry you are checking" in route checking page

Scenario: Error message validation for no flight number provided in the flight route
	Then I have selected 'Flight' radio option
	Then I provide the '' in the box
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should see an error message "Enter the flight number you are checking" in route checking page	  

Scenario: Home page validation for flight Number text box with special character
	Then I have selected 'Flight' radio option
	Then I provide the '$$£@lk' in the box
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Checks page

Scenario: Error message validation for no scheduled departure date details
	Then I have selected 'Flight' radio option
	Then I provide the '1234' in the box
	Then I have selected ''''''Date option
	And  I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should see an error message "Enter the scheduled departure date, for example 27 3 2024" in route checking page

Scenario: Error message validation for scheduled departure date with special character
	Then I have selected 'Flight' radio option
	Then I provide the '1234' in the box
	Then I have selected '@@''@@''@@'Date option
	And  I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should see an error message "Enter the date in the correct format, for example 27 3 2024" in route checking page

Scenario: Error message validation for any one empty box in scheduled departure date
	Then I have selected 'Flight' radio option
	Then I provide the '1234' in the box
	Then I have selected '''01''29876987'Date option
	And  I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should see an error message "Enter the date in the correct format, for example 27 3 2024" in route checking page

Scenario: Error message validation for no scheduled departure time details
	Then I have selected 'Flight' radio option
	Then I provide the '1234' in the box
	Then I have selected '19''10''2024'Date option
	When I click save and continue button from route checke page
	Then I should see an error message "Enter the scheduled departure time, for example 15:30" in route checking page

Scenario: Error message validation for only hour details provided in the scheduled departure time
	Then I have selected 'Flight' radio option
	Then I provide the '1234' in the box
	And  I have provided Scheduled departure time in hours field only
	When I click save and continue button from route checke page
	Then I should see an error message "Enter the scheduled departure time, for example 15:30" in route checking page

Scenario: Error message validation for no PTD number detail
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '' of the application
	When I click search button
	Then I should see an error message "Enter a PTD number" in Find a document page

Scenario: Error message validation for entering less than 6 characters PTD Number format
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '12345' of the application
	When I click search button
	Then I should see an error message "Enter 6 characters after 'GB826'" in Find a document page

Scenario: Error message validation for entering more than 6 characters PTD Number format
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '1234567' of the application
	When I click search button
	Then I should see an error message "Enter 6 characters after 'GB826'" in Find a document page

Scenario: Document not found page validation for invalid PTD number 
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '123456' of the application
	When I click search button
	Then I should navigate to Document not found page

Scenario: Error message validation for application number text box with characters other than 0-9 and A-F (not including the hyphen)
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '@@@@@$$&' of the application
	When I click search button
	Then I should see an error message "Enter 6 characters after 'GB826', using only the letters A to F and numbers" in Find a document page

Scenario: Error message validation for no text in application number text box
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by application number' radio button
	And I provided the Application Number '' of the application
	When I click search button
	Then I should see an error message "Enter an application number" in Find a document page

Scenario: Error message validation for entering more or less than 8 characters application number format
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by application number' radio button
	And I provided the Application Number 'QRWD9DZ' of the application
	When I click search button
	Then I should see an error message "Enter 8 characters" in Find a document page

Scenario: Error message validation for application number with special character
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by application number' radio button
	And I provided the Application Number '@@@@@$$&' of the application
	When I click search button
	Then I should see an error message "Enter 8 characters, using only letters and numbers" in Find a document page

Scenario: Document not found page validation for invalid application number
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by application number' radio button
	And I provided the Application Number 'QRWD9DZQ' of the application
	When I click search button
	Then I should navigate to Document not found page

Scenario: Error message validation for no text in microchip number text box
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '' of the application
	When I click search button
	Then I should see an error message "Enter a microchip number" in Find a document page

Scenario: Error message validation for microchip number with special character
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '@@@@@$$&' of the application
	When I click search button
	Then I should see an error message "Enter a 15-digit number, using only numbers" in Find a document page

Scenario: Error message validation for providing more than 15 microchip number format
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '1234560890123405' of the application
	When I click search button
	Then I should see an error message "Enter a 15-digit number, using only numbers" in Find a document page
	
Scenario: Error message validation for providing less than 15 microchip number format
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '12345608901234' of the application
	When I click search button
	Then I should see an error message "Enter a 15-digit number, using only numbers" in Find a document page
	
Scenario: Document not found page validation for invalid microchip number  
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '123456089012340' of the application
	When I click search button
	Then I should navigate to Document not found page

Scenario: Error message validation for no selection of radio button in application status page
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '123456789012345' of the application
	When I click search button
	And I should see the application status in 'Approved'
	When I click save and continue button from application status page
	Then I should see an error message "Select an option" in application status page

Scenario: Error message validation for no selection of type of passenger on report non-compliance page
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time
	When I click save and continue button from route checke page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '4574B2' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	When I click Report non-compliance button from Report non-compliance page
	Then I should see an error message "Select a type of passenger" in Report non-compliance page