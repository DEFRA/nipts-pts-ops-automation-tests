@CPRegression
Feature: Search Result Validation

Background: 
	Given that I navigate to the port checker application
	And I click signin button on port checker application
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checker page

Scenario Outline: Verify the application summary tables in search result page 
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time '14:00'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '<PTDNumber>' of the application
	When I click search button
	And I should see the application status in '<Status>'
	Then I verify the Reference number table for '<Status>' application
	And I verify the Issuing Authority table for '<Status>' application
	And I verify the Microchip Information table in Search result page
	And I verify the Pet Details table for '<Species>' in Search result page
	And I verify the Pet Owner Details table in Search result page

Examples:
	| Transportation | FerryRoute                    | PTDNumber | Status                | Species |
	| Ferry          | Birkenhead to Belfast (Stena) | 9EFC9F    | Unsuccessful          | Ferret  |
	| Ferry          | Birkenhead to Belfast (Stena) | C196CD    | Awaiting verification | Dog     |
	| Ferry          | Birkenhead to Belfast (Stena) | 457380    | Revoked               | Dog     |
	| Ferry          | Birkenhead to Belfast (Stena) | D6BE7C    | Approved              | Cat     |

Scenario Outline: Verify the application summary tables values in search result page 
	Then I have selected '<Transportation>' radio option
	Then I select the '<FerryRoute>' radio option
	And I have provided Scheduled departure time '14:00'
	When I click save and continue button from route checker page
	Then I should navigate to Checks page
	When I click search button from footer
	Then I navigate to Find a document page
	And I provided the '<PTDNumber>' of the application
	When I click search button
	And I should see the application status in '<Status>'
	Then I verify the Reference number table values '<RefNumberTableValues>' for '<Status>' application
	And I verify the Microchip table values '<MCTableValues>' for '<Status>' application
	And I verify the Pet Details table values '<PetDetailsTableValues>' for the species '<Species>'
	And I verify the Pet Owner Details table values '<PetOwnerDetailsTableValues>' for the application
	

Examples:
	| Transportation | FerryRoute                    | PTDNumber | Status                | Species | RefNumberTableValues | MCTableValues              | PetDetailsTableValues                                                                                 | PetOwnerDetailsTableValues                                                                                           |
	| Ferry          | Birkenhead to Belfast (Stena) | CA7BED    | Unsuccessful          | Ferret  | MHZCLZYG^13/01/2025  | 123231234123210^30/12/2022 | Pet user^Ferret^Male^11/02/2003^Champagne^No                                                          | Brinda ipad^brindha.mathanaguru@cognizant.com^20 ORTS ROAD\\r\nREADING\\r\nRG1 3JN^07688833333                       |
	| Ferry          | Birkenhead to Belfast (Stena) | C196CD    | Awaiting verification | Dog     | 1PROD005^14/01/2025  | 140125171525917^14/01/2022 | Dog dfAXqmTYIWJUMJfkjxtWlnGNp^Dog^Mixed breed or unknown^Male^14/01/2017^Black^Black Mark on Shoulder | Nagarajan Subbiah^PETS.TestAutomation008@nagarajansubbiah.33mail.com^4 ORTS ROAD\\r\nREADING\\r\nRG1 3JN^07590087678 |
	