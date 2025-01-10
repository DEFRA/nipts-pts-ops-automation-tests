﻿@E2E
Feature: E2E Ferret

Create a PETS travel document for the travel from Great Britain to Northern Ireland

Background:
	Given I navigate to PETS a travel document URL
	And I have provided the password for Landing page
	When I click Continue button from Landing page
	Then I should redirected to the Sign in using Government Gateway page
	When I have provided the credentials and signin
	Then I should redirected to Apply for a pet travel document page
	When I click Create a new pet travel document button
	Then I should redirected to the Are your details correct page

@Test
Scenario Outline: Create PETS Travel Document By Registered User with details correct - Ferret - Authorised in Dynamics
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	And I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber>
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned? page
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page
	Then I should redirected to the Is your pet a cat, dog or ferret page
	And I have selected an option as '<Pet>' for pet
	When I click on continue button from Is your pet a cat, dog or ferret page
	Then I should redirected to the What is your pet's name page
	And I provided the Pets name as '<PetName>'
	When I click on continue button from What is your pet's name page
	Then I should redirected to the What sex is your pet page
	And I have selected the option as '<Gender>' for sex
	When I click on continue button from What sex is your pet page
	Then I should redirected to the Do you know your pet's date of birth page
	And I have provided date of birth
	When I click on continue button from Do you know your pet's date of birth? page
	Then I should redirected to the What is the main colour of your '<Pet>' page
	And I have selected the option as '<Color>' for color
	When I click on continue button from What is the main colour of your pet page
	Then I should redirected to the Does your pet have any significant features page
	And I have selected an option as '<IsSignificantFeatures>' for significant features
	When I click on continue button from Does your pet have any significant features page
	Then I should redirected to the Check your answers and sign the declaration page
	And I have verified microchip details in declaration page
	And I have verified pet details in declaration page
	And I have verified pet owner details in declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application in 'Pending' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	And I have verified microchip details in summary page
	And I have verified pet details in summary page
	And I have verified pet owner details in summary page
	When I Login to Dynamics application
	When I opens the application
	And I assign the application to myself
	And I 'Pass' the Microchip check
	And I go back
	And I 'Pass' the Evidence check
	And I go back
	And I 'Authorise' the application
	Then the status is changed to 'Authorised'
	And I click on Back button in Pets Application
	And I should see the application in 'APPROVED' status
Examples:
	| FullName    |  Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color     | IsSignificantFeatures |
	| PetFerret's |  Yes                      | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ferret | Ferret  | Female | Chocolate | No                    |

Scenario Outline: Create PETS Travel Document By Registered User with details not correct - Ferret - Rejected in Dynamics
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	And I provided the postcode '<PostCode>'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 1 from address list
	When I click Continue button from What is your postcode page
	Then I should redirected to What is your phone number page
	And I provided the phone number '<PhoneNumber>'
	When I click Continue button from What is your phone number page
	Then I should redirected to the Is your pet microchipped page
	And I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber>
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned? page
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page
	Then I should redirected to the Is your pet a cat, dog or ferret page
	And I have selected an option as '<Pet>' for pet
	When I click on continue button from Is your pet a cat, dog or ferret page
	Then I should redirected to the What is your pet's name page
	And I provided the Pets name as '<PetName>'
	When I click on continue button from What is your pet's name page
	Then I should redirected to the What sex is your pet page
	And I have selected the option as '<Gender>' for sex
	When I click on continue button from What sex is your pet page
	Then I should redirected to the Do you know your pet's date of birth page
	And I have provided date of birth
	When I click on continue button from Do you know your pet's date of birth? page
	Then I should redirected to the What is the main colour of your '<Pet>' page
	And I have selected the option as '<Color>' for color
	When I click on continue button from What is the main colour of your pet page
	Then I should redirected to the Does your pet have any significant features page
	And I have selected an option as '<IsSignificantFeatures>' for significant features
	When I click on continue button from Does your pet have any significant features page
	Then I should redirected to the Check your answers and sign the declaration page
	And I have verified microchip details in declaration page
	And I have verified pet details in declaration page
	And I have verified pet owner details in declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application in 'Pending' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	And I have verified microchip details in summary page
	And I have verified pet details in summary page
	And I have verified pet owner details in summary page	
	When I Login to Dynamics application
	And I opens the application
	And I assign the application to myself
	And I 'Fail' the Microchip check
	And I go back
	And I 'Reject' the application with reason 'Invalid MC number'
	Then the status is changed to 'Rejected'
	And I click on Back button in Pets Application
	And I should not see the application in the Dashboard

Examples:
	| FullName    |  Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color | IsSignificantFeatures |
	| PetFerret's |  No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ferret | Ferret  | Female | Sable | No                    |

Scenario Outline: Create PETS Travel Document By Registered User with pet is not microchipped
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	And I selected the '<MicrochipOption>' option
	When I click Continue button from microchipped page
	Then I should redirected to the Get your pet microchipped before applying page

Examples:
	| IsRegisteredUser                | Are your details correct | MicrochipOption |
	| Yes, I am the registered keeper | Yes                      | No              |

Scenario Outline: Create PETS Travel Document By Registered User with enter address manually - Revoke in Dynamics
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	When I click the link Enter the address manually
	And I provided address details with postcode '<PostCode>'
	When I click Continue button from What is your postcode page
	Then I should redirected to What is your phone number page
	And I provided the phone number '<PhoneNumber>'
	When I click Continue button from What is your phone number page
	Then I should redirected to the Is your pet microchipped page
	And I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber>
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned? page
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page
	Then I should redirected to the Is your pet a cat, dog or ferret page
	And I have selected an option as '<Pet>' for pet
	When I click on continue button from Is your pet a cat, dog or ferret page
	Then I should redirected to the What is your pet's name page
	And I provided the Pets name as '<PetName>'
	When I click on continue button from What is your pet's name page
	Then I should redirected to the What sex is your pet page
	And I have selected the option as '<Gender>' for sex
	When I click on continue button from What sex is your pet page
	Then I should redirected to the Do you know your pet's date of birth page
	And I have provided date of birth
	When I click on continue button from Do you know your pet's date of birth? page
	Then I should redirected to the What is the main colour of your '<Pet>' page
	And I have selected the option as '<Color>' for color
	When I click on continue button from What is the main colour of your pet page
	Then I should redirected to the Does your pet have any significant features page
	And I have selected an option as '<IsSignificantFeatures>' for significant features
	When I click on continue button from Does your pet have any significant features page
	Then I should redirected to the Check your answers and sign the declaration page
	And I have verified microchip details in declaration page
	And I have verified pet details in declaration page
	And I have verified pet owner details in declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application in 'Pending' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	And I have verified microchip details in summary page
	And I have verified pet details in summary page
	And I have verified pet owner details in summary page
	When I Login to Dynamics application
	And I opens the application
	And I assign the application to myself
	And I 'Pass' the Microchip check
	And I go back
	And I 'Authorise' the application
	Then the status is changed to 'Authorised'
	When I assign the application to myself
	And I 'Revoke' the application with reason 'Pet Deceased'
	Then the status is changed to 'Revoked'
	And I click on Back button in Pets Application
	And I should not see the application in the Dashboard

Examples:
	| FullName | IsRegisteredUser                | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color | IsSignificantFeatures |
	| Ferret's | Yes, I am the registered keeper | No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ferret | Ferret  | Female | Sable | No                    |
