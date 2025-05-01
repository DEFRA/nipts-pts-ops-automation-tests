@CPRegression @CPCrossBrowser
Feature: GB Checks Referral pages validation

Referred to SPS and GB check report page validation

Background: 
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the CP Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checker page

Scenario: Verify GB check report page headings and back link navigation
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '16:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by application number' radio button
	And I provided the Reference number '0CI5N6V6' of the application
	When I click search button
	And I should see the application status in 'Unsuccessful'
	And I continue button from application status page
	Then I should navigate to Report non-compliance page
	When I Select the 'Cannot find microchip' Microchip Checkbox
	And I click 'Passenger says they will not travel' GB Outcome
	Then I click 'Vehicle on ferry' in Passenger details
	When I click Save outcome button from non-compliance page
	Then I should see a message 'Information has been successfully submitted' in Checks page
	When I click View link in Fail Referred to SPS row with count more than 0
	Then I should navigate to Referred to SPS page
	When I click first link in PTD or Reference number
	Then I should navigate to GB check report page
	And I should see 'Outcome' and 'Check details' subheadings
	When I Click on Back button
	Then I should navigate to Referred to SPS page

Scenario: Verify Outcome table in GB check report page
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '23:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by application number' radio button
	And I provided the Reference number 'DKVUZHQ9' of the application
	When I click search button
	And I should see the application status in 'Unsuccessful'
	And I continue button from application status page
	Then I should navigate to Report non-compliance page
	When I Select the 'Microchip number does not match the PTD' Microchip Checkbox
	And I enter the Microchip number in '123456789012345' in Report non-compliance page
	And I click 'Passenger says they will not travel' GB Outcome
	Then I click 'Vehicle on ferry' in Passenger details
	When I click Save outcome button from non-compliance page
	Then I should see a message 'Information has been successfully submitted' in Checks page
	When I click View link in Fail Referred to SPS row with count more than 0
	Then I should navigate to Referred to SPS page
	When I click first link in PTD or Reference number
	Then I should navigate to GB check report page
	And I should see 'Outcome' and 'Check details' subheadings
	Then I should see 'Passenger says they will not travel' as Check outcome
	And I should see 'Microchip number does not match the PTD' as Reason for referral
	And I should see '123498012398051' as Microchip number found in scan
	And I should see 'None' as Additional comments

Scenario: Verify Check details table in GB check report page
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '23:58'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by application number' radio button
	And I provided the Reference number 'VRNB3GAF' of the application
	When I click search button
	And I should see the application status in 'Cancelled'
	And I continue button from application status page
	Then I should navigate to Report non-compliance page
	When I Select the 'Microchip number does not match the PTD' Microchip Checkbox
	And I enter the Microchip number in '123456789012345' in Report non-compliance page
	And I click 'Passenger says they will not travel' GB Outcome
	Then I click 'Vehicle on ferry' in Passenger details
	When I click Save outcome button from non-compliance page
	Then I should see a message 'Information has been successfully submitted' in Checks page
	When I click View link in Fail Referred to SPS row with count more than 0
	Then I should navigate to Referred to SPS page
	When I click first link in PTD or Reference number
	Then I should navigate to GB check report page
	And I should see 'Outcome' and 'Check details' subheadings
	Then I should see 'PREPROD Automation' as GB checker name
	And I should see 'Birkenhead to Belfast (Stena)' as Route
	Then I should see current date as Scheduled departure date
	And I should see '23:58' as Scheduled departure time

Scenario: Verify PTD Number format in Referred to SPS page
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '23:58'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click View link in Fail Referred to SPS row with count more than 0
	Then I should navigate to Referred to SPS page
	And I should see all the PTD numbers should be in correct format and starts with 'GB826'

Scenario Outline: Verify if the SPS Checker can allow the passenger to travel
	Then I have selected 'Ferry' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time '23:58'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page

	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the CP Sign in using Government Gateway page
	When I have provided the CP SPS credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checker page
	Then I have selected 'Ferry' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time '02:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click View link in Fail Referred to SPS row with count more than 0
	Then I should navigate to Referred to SPS page
	When I click on the application that is in checks Needed SPS Outcome
	And I click Conduct a SPS check button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I verify the SPS Outcome 'Allowed to travel under Windsor Framework|Not allowed to travel under Windsor Framework' options under 'Record outcome'
	When I click 'Allowed' in SPS Outcome
	When I click Save outcome button from non-compliance page
	And I click View link in Fail Referred to SPS row with count more than 0
	Then I should navigate to Referred to SPS page

Examples:
	| ApplicationNumber | FerryRoute                   | Status       | TypeOfPassenger      | MCOutcome                               |
	| 9EFC9F            | Birkenhead to Belfast (Stena)| Unsuccessful | Ferry foot passenger | Cannot find microchip                   |
