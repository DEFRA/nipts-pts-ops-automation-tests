@CPRegression
Feature: GB Checks Referral pages validation - SPS

SPS Port checker Checks Referred to SPS and GB check report page

Background:
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the CP Sign in using Government Gateway page
	When I have provided the CP SPS credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checker page

Scenario: Verify for no duplicate referrals and latest details updated in GB check report page - SPS Checker
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '23:59'
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
	When I Select the 'Microchip number does not match the PTD' Microchip Checkbox
	And I enter the Microchip number in '123456789012345' in Report non-compliance page
	And I click 'Not Allowed' in SPS Outcome
	Then I click 'Vehicle on ferry' in Passenger details
	And I enter details 'Outcome Details' in Details of outcome
	When I click Save outcome button from non-compliance page
	Then I should see a message 'Information has been successfully submitted' in Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by application number' radio button
	And I provided the Reference number '0CI5N6V6' of the application
	When I click search button
	And I should see the application status in 'Unsuccessful'
	And I continue button from application status page
	Then I should navigate to Report non-compliance page
	When I Select the 'Cannot find microchip' Microchip Checkbox
	And I select 'Authorised person but no confirmation' as visual check reason
	And I click 'Allowed' in SPS Outcome
	Then I click 'Ferry foot passenger' in Passenger details
	And I enter comments 'Comments' in Any relevant comments
	When I click Save outcome button from non-compliance page
	Then I should see a message 'Information has been successfully submitted' in Checks page
	When I click View link in Fail Referred to SPS row with departure time '23:59'
	Then I should navigate to Checks page
	And I verify the PTDOrRefNum '0CI5N6V6' is not repeated in the table
	When I click the View button from Checks page
 	Then I should navigate to Referred to SPS page
	When I click the reference number '0CI5N6V6' link
	Then I should navigate to GB check report page
	And I should see 'Outcome' and 'Check details' subheadings
	Then I should see 'Passenger says they will not travel' as Check outcome
	And I should see 'None' as Details of outcome
	And I should see 'Cannot find microchip' as Reason for referral
	And I should see 'None' as Additional comments
	Then I should see 'PREPROD Automation' as GB checker name
	And I should see 'Birkenhead to Belfast (Stena)' as Route
	Then I should see current date as Scheduled departure date
	And I should see '23:59' as Scheduled departure time

Scenario Outline: Verify the Checks home page filter and display only the selected ferry route - SPS
	Then I have selected 'Ferry' radio option
	Then I select the '<Route>' radio option
	And I have provided Scheduled departure time '<DepatureTime>'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	And I should see route displayed in all the tables of Checks page should be '<Route>'
Examples:
	| Route                         | DepatureTime |
	| Birkenhead to Belfast (Stena) | 09:30        |
	| Cairnryan to Larne (P&O)      | 09:30        |
	| Loch Ryan to Belfast (Stena)  | 09:30        |