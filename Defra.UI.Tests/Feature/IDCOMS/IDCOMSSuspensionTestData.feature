@Idcoms
Feature: Idcoms Suspension Testdata

IDCOMS System Regression for NIPTS

Scenario: test
	When I Login to Dynamics application
	And I Click on New to create an offline application
	And I create a new applicant in IDCOMS
	And I enter 'Owner Type' as 'Self'
	And I enter 'Pet Name' as 'Teddy'
	And I enter 'Species' as 'Dog'
	And I enter 'Breed' as 'Beagle'
	And I enter 'Sex' as 'Male'
	And I enter 'Date of Birth' as '09/08/2022'
	And I enter 'Age' as '12'
	And I enter 'Colour' as 'Brown, tan or chocolate'
	And I enter 'Unique feature' as 'As fast as Cheetah'
	And I enter 'Microchipped Date' as '09/08/2023'
	And I enter 'Microchip Number' as 'auto'
	And I enter 'APPLICATION TYPE' as 'CY'
	And I Click on Save
	Then the status is 'Open'
	And I see the Application Reference number generated
	When I 'Pass' the Microchip check
	And I go back
	And I 'Authorise' the application
	Then the status is changed to 'Authorised'
	When I switch to 'SNCs' tab
	And I create a New Suspect Non Compliance
	And I Log decision in SNC as '12 Months'
	Then The 'Decision date' is set to Current date
	And the status is changed to 'Intent to Suspend'
