@CPRegression
Feature: GB Checks Referral pages validation - SPS

SPS Port checker Checks Referred to SPS and GB check report page

Background:
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the CP Sign in using Government Gateway page
	When I have provided the CP SPS credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checker page

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

Scenario: Verify the table details in Referred to SPS page as SPS Checker
	Then I have selected 'Ferry' radio option
	And I select the 'Loch Ryan to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '10:00'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by application number' radio button
	And I provided the Reference number 'RHE7FYYD' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	When I Select the 'Cannot find microchip' Microchip Checkbox
	Then I click 'Vehicle on ferry' in Passenger details
	When I click Save outcome button from non-compliance page
	Then I should see a message 'Information has been successfully submitted' in Checks page
	When I click View link in Fail Referred to SPS row with departure time '10:00'
	Then I should navigate to Referred to SPS page
	And I verify the Referred to SPS page table column names as 'PTD or Reference number' 'Pet' 'Microchip' 'Travel by' 'SPS outcome'
	And I verify the Referred to SPS page table column values as 'GB826 8C5 FA2' 'Cat and Tortoiseshell' '291025122748541' 'Vehicle' 'Check needed'
	And I should not see Additional Comments