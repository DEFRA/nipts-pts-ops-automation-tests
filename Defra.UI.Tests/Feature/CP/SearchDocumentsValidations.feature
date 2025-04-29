@CPRegression @CPCrossBrowser
Feature: Search Documents Validations

Port checker validates Search documents and Change Route details

Background: 
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the CP Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checker page

Scenario: Verify the error message for search button click after clearing the given PTD number
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
	Then I click search by 'Search by PTD number' radio button
	When I click search button
	Then I should see an error message "Enter a PTD number" in Find a document page

Scenario: Verify the error message for search button click after clearing the given application number
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '14:45'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by application number' radio button
	And I provided the Application Number 'QRWD9DZ' of the application
	When I click clear search button
	Then I click search by 'Search by application number' radio button
	When I click search button
	Then I should see an error message "Enter an application number" in Find a document page

Scenario: Verify the error message for search button click after clearing the given microchip number
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '12:45'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '123456089012340' of the application
	When I click clear search button
	Then I click search by 'Search by microchip number' radio button
	When I click search button
	Then I should see an error message "Enter a microchip number" in Find a document page

Scenario: Verify invalid PTD number navigates to Document not found page
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '11:45'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '613465' of the application
	When I click search button
	Then I should see "Document not found" an error message in Find a document page

Scenario: Verify invalid application number navigates to Document not found page 
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '05:45'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by application number' radio button
	And I provided the Application Number 'AD6789QE' of the application
	When I click search button
	Then I should navigate to Document not found page
	And I Verify the message for 'AD6789QE' in Document Not Found Page
	And I click on go back to search link
	And I navigate to Find a document page
	And I see the values are deleted

Scenario: Verify invalid microchip number navigates to Document not found page 
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '07:45'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '666661111134343' of the application
	When I click search button
	Then I should navigate to Document not found page
	And I Verify the message for '666661111134343' in Document Not Found Page
	And I click on go back to search link
	And I navigate to Find a document page
	And I see the values are deleted


Scenario: Verify the navigation for change link click in header from Checks page
	And I have selected 'Ferry' radio option
	And I select the 'Cairnryan to Larne (P&O)' radio option
	And I have provided Scheduled departure time '09:45'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	And I click change link from headers
	And I should redirected to port route checker page

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

Scenario: Verify the navigation for change link click in header from search results page verification
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
	Then I click change link from headers
	And I should redirected to port route checker page

Scenario: Verify the navigation for change link click in header from report non-compliance page verification
	And I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '15:40'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '561365613656136' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	Then I click change link from headers
	And I should redirected to port route checker page

Scenario: Verify the footer display from all pages
	And I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '12:20'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	And I should see the footer of the page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '987659898798764' of the application
	Then I should see the footer of the page
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	Then I should see the footer of the page
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I should see the footer of the page

Scenario: Verify the header display from all pages
	And I have selected 'Ferry' radio option
	And I select the 'Cairnryan to Larne (P&O)' radio option
	Then I have selected current date '-1' Date option
	And I have provided Scheduled departure time '15:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	And I should see the header of the page with route 'Cairnryan to Larne (P&O)' date current date '-1' time '15:30' and change link
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '987659898798764' of the application
	Then I should see the header of the page with route 'Cairnryan to Larne (P&O)' date current date '-1' time '15:30' and change link
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	Then I should see the header of the page with route 'Cairnryan to Larne (P&O)' date current date '-1' time '15:30' and change link
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I should see the header of the page with route 'Cairnryan to Larne (P&O)' date current date '-1' time '15:30' and change link

Scenario: Verify home page navigation by clicking home icon in the footer from all pages
	And I have selected 'Ferry' radio option
	And I select the 'Cairnryan to Larne (P&O)' radio option
	And I have provided Scheduled departure time '11:20'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click footer home icon
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	When I click footer home icon
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '987659898798764' of the application
	When I click search button
	And I should see the application status in 'Approved'
	When I click footer home icon
	Then I should navigate to Checks page

Scenario: Verify search page navigation by clicking search icon in the footer from all pages
	And I have selected 'Ferry' radio option
	And I select the 'Cairnryan to Larne (P&O)' radio option
	And I have provided Scheduled departure time '11:20'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '987659898798764' of the application
	When I click search button
	And I should see the application status in 'Approved'
	When I click search button from footer
	Then I navigate to Find a document page

Scenario: Verify the error message if no PTD number detail given
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '14:50'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '' of the application
	When I click search button
	Then I should see an error message "Enter a PTD number" in Find a document page

Scenario: Verify the error message if entering less than 6 characters PTD Number format
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '12:50'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the 'AD763' of the application
	When I click search button
	Then I should see an error message "Enter 6 characters after 'GB826'" in Find a document page

Scenario: Verify the error message if entering more than 6 characters PTD Number format
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '14:50'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the 'AD387641' of the application
	When I click search button
	Then I should see an error message "Enter 6 characters after 'GB826'" in Find a document page

Scenario: Verify the error message if PTD number text box have 6 characters other than 0-9 and A-F (not including the hyphen)
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '11:50'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '*%£$&@' of the application
	When I click search button
	Then I should see an error message "Enter 6 characters after 'GB826', using only letters A to F and numbers" in Find a document page

Scenario: Verify the error message if no text provided in application number text box
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '14:50'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by application number' radio button
	And I provided the Application Number '' of the application
	When I click search button
	Then I should see an error message "Enter an application number" in Find a document page

Scenario: Verify the error message if entering more or less than 8 characters application number format
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '12:00'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by application number' radio button
	And I provided the Application Number 'AD128E' of the application
	When I click search button
	Then I should see an error message "Enter 8 characters" in Find a document page

Scenario: Verify the error message if application number provided with special character
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '14:00'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by application number' radio button
	And I provided the Application Number '£$&^@{}' of the application
	When I click search button
	Then I should see an error message "Enter 8 characters, using only letters and numbers" in Find a document page

Scenario: Verify the error message if no text provided in microchip number text box
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '11:10'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '' of the application
	When I click search button
	Then I should see an error message "Enter a microchip number" in Find a document page

Scenario: Verify the error message if special character provided in microchip number text box
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '12:10'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '£$&^@{}' of the application
	When I click search button
	Then I should see an error message "Enter a 15-digit number, using only numbers" in Find a document page

Scenario: Verify the error message if entering more than 15 microchip number format
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '22:50'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '89765897651234567' of the application
	When I click search button
	Then I should see an error message "Enter a 15-digit number" in Find a document page
	
Scenario: Verify the error message if entering less than 15 microchip number format
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '23:50'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by microchip number' radio button
	And I provided the Microchip number '98761234' of the application
	When I click search button
	Then I should see an error message "Enter a 15-digit number" in Find a document page

Scenario: Verify the data entered remains in the text box of Find a document page
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

Scenario: Verify change link click in header from Checks page and back button from homepage
	And I have selected 'Ferry' radio option
	And I select the 'Cairnryan to Larne (P&O)' radio option
	Then I have selected current date '-1' Date option
	And I have provided Scheduled departure time '09:45'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	And I click change link from headers
	And I should redirected to port route checker page
	Then I should see no route options selected by default
	And I should see no departure time is populated by default
	Then I should see date subsection 'Scheduled departure date' with the current date pre-population
	And I click back link
	Then I should navigate to Checks page
	And I should see the header of the page with route 'Cairnryan to Larne (P&O)' date current date '-1' time '09:45' and change link

Scenario: Verify the input hyphen only to application number text box navigates to 403 error page
	Then I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '05:45'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by application number' radio button
	And I provided the Application Number ''-'' of the application
	When I click search button
	Then I should navigate to 'You cannot access this page or perform this action' error page
	When I click go back to the previous page link
	Then I navigate to Find a document page
	When I select Search by PTD number radio button and then selected the Search by application number radio button
	Then I should see the already entered application number ''-'' in the text box	 

Scenario: Verify the Clear search functionality in Find a Document page
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