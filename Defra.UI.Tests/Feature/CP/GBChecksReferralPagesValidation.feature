@CPRegression
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
	And I have provided Scheduled departure time '12:30'
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
	When I click View link in Fail Referred to SPS row with departure time '12:30'
	Then I should navigate to Referred to SPS page
	When I click first link in PTD or Reference number
	Then I should navigate to GB check report page
	And I should see 'Outcome' and 'Check details' subheadings
	When I Click on Back button
	Then I should navigate to Referred to SPS page

Scenario: Verify Outcome table in GB check report page - SPS User
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '23:59'
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
	And I select 'Authorised person but no confirmation' as visual check reason
	And I click 'Passenger says they will not travel' GB Outcome
	Then I click 'Vehicle on ferry' in Passenger details
	And I enter comments '<AdditionalCommentsInReportNonCompPage>' in Any relevant comments
	And I enter details '<DetailsOFOutcomeInReportNonCompPage>' in Details of outcome
	When I click Save outcome button from non-compliance page
	Then I should see a message 'Information has been successfully submitted' in Checks page
	And click on signout button on CP and verify the signout message
	When I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the CP Sign in using Government Gateway page
	When I have provided the CP SPS credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checker page
	And I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '20:20'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click View link in Fail Referred to SPS row with departure time '23:59'
	Then I should navigate to Referred to SPS page
	When I click the reference number 'DKVUZHQ9' link
	Then I should navigate to GB check report page
	And I should see 'Outcome' and 'Check details' subheadings
	Then I should see 'Passenger says they will not travel' as Check outcome
	And I should see '<DetailsOFOutcomeInGBCheckReport>' as Details of outcome
	And I should see 'Microchip number does not match the PTD, Authorised person but no confirmation' as Reason for referral
	And I should see '123456789012345' as Microchip number found in scan
	And I should see '<AdditionalCommentsInInGBCheckReport>' as Additional comments
Examples:
	| DetailsOFOutcomeInReportNonCompPage | AdditionalCommentsInReportNonCompPage | DetailsOFOutcomeInGBCheckReport | AdditionalCommentsInInGBCheckReport |
	| Outcome Details                     | Comments                              | Outcome Details                 | Comments                            |
	|                                     |                                       | None                            | None                                |

Scenario: Verify Check details table in GB check report page - SPS User
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '23:50'
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
	And click on signout button on CP and verify the signout message
	When I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the CP Sign in using Government Gateway page
	When I have provided the CP SPS credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checker page
	And I have selected 'Ferry' radio option
	Then I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '20:20'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click View link in Fail Referred to SPS row with departure time '23:50'
	Then I should navigate to Referred to SPS page
	When I click first link in PTD or Reference number
	Then I should navigate to GB check report page
	And I should see 'Outcome' and 'Check details' subheadings
	Then I should see 'PREPROD Automation' as GB checker name
	And I should see 'Birkenhead to Belfast (Stena)' as Route
	Then I should see current date as Scheduled departure date
	And I should see '23:50' as Scheduled departure time
	Then I should see current date and current time as Date and time checked

Scenario: Verify the route details and PTD Number format in Referred to SPS page
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '23:59'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by application number' radio button
	And I provided the Reference number 'H71XF4NH' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	When I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	When I Select the 'Cannot find microchip' Microchip Checkbox
	And I click 'Passenger says they will not travel' GB Outcome
	Then I click 'Vehicle on ferry' in Passenger details
	When I click Save outcome button from non-compliance page
	Then I should see a message 'Information has been successfully submitted' in Checks page
	When I click View link in Fail Referred to SPS row with departure time '23:59'
	Then I should navigate to Referred to SPS page
	And I should see route details 'Birkenhead to Belfast (Stena)' date and time '23:59' below the title of the page
	And I should see all the PTD numbers should be in correct format and starts with 'GB826'

Scenario: Verify the back link navigation for search result through home referral page route
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
	When I click View link in Fail Referred to SPS row with departure time '16:30'
	Then I should navigate to Referred to SPS page
	When I click first link in PTD or Reference number
	Then I should navigate to GB check report page
	When I click Conduct a SPS check button
	And I should see the application status in 'Unsuccessful'
	Then I click back link
	And I should navigate to GB check report page
	When I click footer home icon
	And I click View link in Fail Referred to SPS row with departure time '16:30'
	Then I should navigate to Referred to SPS page
	When I click first link in PTD or Reference number
	Then I should navigate to GB check report page
	When I click Conduct a SPS check button
	And I should see the application status in 'Unsuccessful'
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I click back link
	When I should see the application status in 'Unsuccessful'
	Then I click back link
	And I should navigate to GB check report page

Scenario: Verify the table details in Referred to SPS page
	Then I have selected 'Ferry' radio option
	And I select the 'Loch Ryan to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '10:00'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by application number' radio button
	And I provided the Reference number '8CLR4IZ7' of the application
	When I click search button
	And I should see the application status in 'Cancelled'
	And I continue button from application status page
	Then I should navigate to Report non-compliance page
	When I Select the 'Cannot find microchip' Microchip Checkbox
	And I click 'Passenger says they will not travel' GB Outcome
	Then I click 'Vehicle on ferry' in Passenger details
	When I click Save outcome button from non-compliance page
	Then I should see a message 'Information has been successfully submitted' in Checks page
	When I click View link in Fail Referred to SPS row with departure time '10:00'
	Then I should navigate to Referred to SPS page
	And I verify the Referred to SPS page table column names as 'PTD or Reference number' 'Pet' 'Microchip' 'Travel by' 'SPS outcome'
	And I verify the Referred to SPS page table column values as 'GB826 CBA 461' 'Dog and Other' '398931864434234' 'Vehicle' 'Check needed'

Scenario: Verify for no duplicate referrals and latest details updated in GB check report page
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '23:59'
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
	And I enter details 'Outcome Details' in Details of outcome
	When I click Save outcome button from non-compliance page
	Then I should see a message 'Information has been successfully submitted' in Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by application number' radio button
	And I provided the Reference number 'DKVUZHQ9' of the application
	When I click search button
	And I should see the application status in 'Unsuccessful'
	And I continue button from application status page
	Then I should navigate to Report non-compliance page
	When I Select the 'Cannot find microchip' Microchip Checkbox
	And I select 'Authorised person but no confirmation' as visual check reason
	And I click 'Passenger advised not to travel' GB Outcome
	Then I click 'Ferry foot passenger' in Passenger details
	And I enter comments 'Comments' in Any relevant comments
	When I click Save outcome button from non-compliance page
	Then I should see a message 'Information has been successfully submitted' in Checks page
	When I click View link in Fail Referred to SPS row with departure time '23:59'
	Then I should navigate to Referred to SPS page
	And I verify the PTDOrRefNum 'DKVUZHQ9' is not repeated in the table
	And I verify the Referred to SPS page table column values as 'DKVUZHQ9' 'Ferret and Chocolate' '123498012398051' 'Foot' 'Check needed'
	When I click the reference number 'DKVUZHQ9' link
	Then I should navigate to GB check report page
	And I should see 'Outcome' and 'Check details' subheadings
	Then I should see 'Passenger advised not to travel' as Check outcome
	And I should see 'None' as Details of outcome
	And I should see 'Cannot find microchip, Authorised person but no confirmation' as Reason for referral
	And I should see 'Comments' as Additional comments
	Then I should see 'PREPROD Automation' as GB checker name
	And I should see 'Birkenhead to Belfast (Stena)' as Route
	Then I should see current date as Scheduled departure date
	And I should see '23:59' as Scheduled departure time
	Then I should see current date and current time as Date and time checked

Scenario: Verify referral count on updating approved document pass to fail check outcome
	Then I have selected 'Ferry' radio option
	And I select the 'Cairnryan to Larne (P&O)' radio option
	And I have provided Scheduled departure time '02:45'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '87FDFA' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Pass radio button
	And I click save and continue button from application status page
	Then I should navigate to Checks page
	And I should see a message 'Information has been successfully submitted' in Checks page
	Then I should see the count next to Pass as '1' in the table contains departure time '02:45'
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '87FDFA' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	When I Select the 'Cannot find microchip' Microchip Checkbox
	And I select 'Authorised person but no confirmation' as visual check reason
	And I click 'Passenger advised not to travel' GB Outcome
	Then I click 'Ferry foot passenger' in Passenger details
	And I enter comments 'Comments' in Any relevant comments
	When I click Save outcome button from non-compliance page
	Then I should see a message 'Information has been successfully submitted' in Checks page
	Then I should see the count next to Pass as '0' in the table contains departure time '02:45'
	And I should see the count next to Fail Referred to SPS as '1' in the table contains departure time '02:45'
	When I click View link in Fail Referred to SPS row with departure time '02:45'
	Then I should navigate to Referred to SPS page
	And I verify the PTDOrRefNum 'GB826 87F DFA' is not repeated in the table
	When I click the reference number 'GB82687FDFA' link
	Then I should navigate to GB check report page
	And I should see 'Outcome' and 'Check details' subheadings
	Then I should see 'Passenger advised not to travel' as Check outcome
	And I should see 'None' as Details of outcome
	And I should see 'Cannot find microchip, Authorised person but no confirmation' as Reason for referral
	And I should see 'Comments' as Additional comments
	Then I should see 'PREPROD Automation' as GB checker name
	And I should see 'Cairnryan to Larne (P&O)' as Route
	Then I should see current date as Scheduled departure date
	And I should see '02:45' as Scheduled departure time
	Then I should see current date and current time as Date and time checked

Scenario: Verify referral count on updating approved document fail to fail check outcome
	Then I have selected 'Ferry' radio option
	And I select the 'Loch Ryan to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '02:45'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '86FD9E' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	When I Select the 'Cannot find microchip' Microchip Checkbox
	And I click 'Passenger advised not to travel' GB Outcome
	Then I click 'Ferry foot passenger' in Passenger details
	And I enter comments 'Comments' in Any relevant comments
	When I click Save outcome button from non-compliance page
	Then I should see a message 'Information has been successfully submitted' in Checks page
	And I should see the count next to Fail Referred to SPS as '1' in the table contains departure time '02:45'
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '86FD9E' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	When I select 'Pet does not match the PTD' as visual check reason
	And I click 'Passenger says they will not travel' GB Outcome
	Then I click 'Vehicle on ferry' in Passenger details
	When I click Save outcome button from non-compliance page
	Then I should see a message 'Information has been successfully submitted' in Checks page
	Then I should see the count next to Pass as '0' in the table contains departure time '02:45'
	And I should see the count next to Fail Referred to SPS as '1' in the table contains departure time '02:45'
	When I click View link in Fail Referred to SPS row with departure time '02:45'
	Then I should navigate to Referred to SPS page
	And I verify the PTDOrRefNum 'GB826 86F D9E' is not repeated in the table
	When I click the reference number 'GB82686FD9E' link
	Then I should navigate to GB check report page
	And I should see 'Outcome' and 'Check details' subheadings
	Then I should see 'Passenger says they will not travel' as Check outcome
	And I should see 'None' as Details of outcome
	And I should see 'Pet does not match the PTD' as Reason for referral
	And I should see 'None' as Additional comments
	Then I should see 'PREPROD Automation' as GB checker name
	And I should see 'Loch Ryan to Belfast (Stena)' as Route
	Then I should see current date as Scheduled departure date
	And I should see '02:45' as Scheduled departure time
	Then I should see current date and current time as Date and time checked

Scenario: Verify the pagination of referrals details list in Referred to SPS page
	Then I add records in referrals list in Referred to SPS page 'Ferry' 'Cairnryan to Larne (P&O)' '15:10' 'Cannot find microchip' 'Passenger says they will not travel' 'Vehicle on ferry' 'Information has been successfully submitted'
	And I click View link in Fail row with departure time '15:10' and check for pagination

Scenario: Verify if the View link should be hidden for GB referral count is 0
	Then I have selected 'Ferry' radio option
	And I select the 'Cairnryan to Larne (P&O)' radio option
	And I have provided Scheduled departure time '17:45'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '87FDFA' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Pass radio button
	And I click save and continue button from application status page
	Then I should navigate to Checks page
	And I should see a message 'Information has been successfully submitted' in Checks page
	Then I should see the count next to Pass as '1' in the table contains departure time '17:45'
	And I should see the count next to Fail Referred to SPS as '0' in the table contains departure time '17:45'
	And I Should not see the View link in the table contains departure time '17.45'
