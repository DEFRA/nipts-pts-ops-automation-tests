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