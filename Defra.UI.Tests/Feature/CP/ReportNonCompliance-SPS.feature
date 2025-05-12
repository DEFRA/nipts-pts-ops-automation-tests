@CPRegression
Feature: Report Non Compliance - SPS

SPS Port checker Checks application and Route Details

Background:
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the CP Sign in using Government Gateway page
	When I have provided the CP SPS credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checker page

Scenario: Verify Reasons heading with hint in Report non compliance page as SPS Checker - Approved status
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '02:10'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '4574B2' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I should see the 'Reasons' heading with hint 'Select all that apply.'
	And I verify any relavant comments section

Scenario: Verify Reasons and Any Relavant comments heading with hint in Report non compliance page as SPS Checker
	Then I have selected '<Transportation>' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time '12:10'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '<PTDNumber>' of the application
	When I click search button
	And I should see the application status in '<Status>'
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I should see the 'Reasons' heading with hint 'Select all that apply.'
	And I verify any relavant comments section
Examples:
	| Transportation | FerryRoute                    | PTDNumber | Status       |
	| Ferry          | Birkenhead to Belfast (Stena) | 9EFC9F    | Unsuccessful |
	| Ferry          | Birkenhead to Belfast (Stena) | A6AD63    | Cancelled    |
	| Ferry          | Loch Ryan to Belfast (Stena)  | 8E375B    | Pending      |

Scenario Outline: Verify SPS Outcome in Report non compliance page for Approved application as SPS Checker
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '12:40'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '4574B2' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I verify the SPS Outcome 'Allowed to travel under Windsor Framework|Not allowed to travel under Windsor Framework' options under 'Record outcome'
	And I verify the Details of Outcome label
	And I Verify the SPS Outcomes are not selected

Scenario Outline: Verify SPS Outcome in Report non compliance page for unsuccessful applications as SPS Checker
	Then I have selected 'Ferry' radio option
	And I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time '11:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '<ApplicationNumber>' of the application
	When I click search button
	And I should see the application status in '<Status>'
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I verify the SPS Outcome 'Allowed to travel under Windsor Framework|Not allowed to travel under Windsor Framework' options under 'Record outcome'
	And I verify the Details of Outcome label
	And I Verify the SPS Outcomes are not selected
Examples:
	| ApplicationNumber | FerryRoute                   | Status       |
	| 9EFC9F            | Cairnryan to Larne (P&O)     | Unsuccessful |
	| A6AD63            | Loch Ryan to Belfast (Stena) | Cancelled    |
	| 8E375B            | Loch Ryan to Belfast (Stena) | Pending      |

Scenario: Verify the error message for no selection in reason section in Report non-compliance page as SPS Checker
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	And I have provided Scheduled departure time '12:30'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I click search by 'Search by PTD number' radio button
	And I provided the '4574B2' of the application
	When I click search button
	And I should see the application status in 'Approved'
	And I select Fail radio button
	And I click save and continue button from application status page
	Then I should navigate to Report non-compliance page
	And I should see no checkboxes are selected in microchip section
	Then I should see a checkbox 'Pet does not match the PTD' is not selected
	And I should see no checkboxes are selected in other issues section
	When I click Report non-compliance button from Report non-compliance page
	Then I should see an error message "Select at least one reason for non-compliance" in Report non-compliance page