@Validations
Feature: View pet travel document Validations


Background:
	Given I navigate to PETS a travel document URL
	When I have provided the password for Landing page
	Then I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the AP Sign in using Government Gateway page
	When I have provided the credentials and signin
	Then I should redirected to Apply for a pet travel document page

Scenario: Verify name and address in Issuing authority table of approved document
	When I click Create a new pet travel document button
	Then I should redirected to the Are your details correct page
	And I have selected 'Yes' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	And I selected the 'Yes' option
	And provided microchip number through auto-generated
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned? page
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page
	Then I should redirected to the Is your pet a cat, dog or ferret page
	And I have selected an option as 'Dog' for pet
	When I click on continue button from Is your pet a cat, dog or ferret page
	Then I should redirected to the What breed is your 'Dog'? page
	And I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page
	Then I should redirected to the What is your pet's name page
	And I provided the Pets name as 'Dog'
	When I click on continue button from What is your pet's name page
	Then I should redirected to the What sex is your pet page
	And I have selected the option as 'Male' for sex
	When I click on continue button from What sex is your pet page
	Then I should redirected to the Do you know your pet's date of birth page
	And I have provided date of birth
	When I click on continue button from Do you know your pet's date of birth? page
	Then I should redirected to the What is the main colour of your 'Dog' page
	And I have selected the option as 'Gold or yellow' for color
	When I click on continue button from What is the main colour of your pet page
	Then I should redirected to the Does your pet have any significant features page
	And I have selected an option as 'No' for significant features
	When I click on continue button from Does your pet have any significant features page
	Then I should redirected to the Check your answers and sign the declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application in 'Pending' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	And I have verified pet details in summary page
	When I Login to Dynamics application
	And I opens the application
	Then I get the PTD Reference Number and Store it
	When I assign the application to myself
	And I 'Pass' the Microchip check
	And I go back
	And I 'Authorise' the application
	Then the status is changed to 'Authorised'
	And I click on Back button in Pets Application
	And I should see the application in 'Approved' status
	When I have clicked the View hyperlink from home page
	Then I should see a table named 'Issuing authority' with a column 'Name and address of competent authority' in approved document
	And the address of authority should be 'Animal and Plant Health Agency' 'Woodham Lane, New Haw, Addlestone, Surrey KT15 3NB'

Scenario: Verify back button functionality from are your details correct page and from declaration page
	When I click Create a new pet travel document button
	Then I should redirected to the Are your details correct page
	And I click on Back button
	And I should redirected to Apply for a pet travel document page
	When I click Create a new pet travel document button
	Then I should redirected to the Are your details correct page
	Then I have selected 'Yes' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	And I selected the 'Yes' option
	And provided microchip number through auto-generated
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned? page
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page
	Then I should redirected to the Is your pet a cat, dog or ferret page
	And I have selected an option as 'Dog' for pet
	When I click on continue button from Is your pet a cat, dog or ferret page
	Then I should redirected to the What breed is your 'Dog'? page
	And I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page
	Then I should redirected to the What is your pet's name page
	And I provided the Pets name as 'Dog'
	When I click on continue button from What is your pet's name page
	Then I should redirected to the What sex is your pet page
	And I have selected the option as 'Male' for sex
	When I click on continue button from What sex is your pet page
	Then I should redirected to the Do you know your pet's date of birth page
	And I have provided date of birth
	When I click on continue button from Do you know your pet's date of birth? page
	Then I should redirected to the What is the main colour of your 'Dog' page
	And I have selected the option as 'Gold or yellow' for color
	When I click on continue button from What is the main colour of your pet page
	Then I should redirected to the Does your pet have any significant features page
	And I have selected an option as 'No' for significant features
	When I click on continue button from Does your pet have any significant features page
	Then I should redirected to the Check your answers and sign the declaration page
	And I click on Back button
	Then I should redirected to the Does your pet have any significant features page
	And I click on Back button
	Then I should redirected to the What is the main colour of your 'Dog' page

Scenario: Verify invalid documents link and table
	When I click Create a new pet travel document button
	Then I should redirected to the Are your details correct page
	And I have selected 'Yes' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	And I selected the 'Yes' option
	And provided microchip number through auto-generated
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned? page
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page
	Then I should redirected to the Is your pet a cat, dog or ferret page
	And I have selected an option as 'Dog' for pet
	When I click on continue button from Is your pet a cat, dog or ferret page
	Then I should redirected to the What breed is your 'Dog'? page
	And I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page
	Then I should redirected to the What is your pet's name page
	And I provided the Pets name as 'Dog_InvalidLink'
	When I click on continue button from What is your pet's name page
	Then I should redirected to the What sex is your pet page
	And I have selected the option as 'Male' for sex
	When I click on continue button from What sex is your pet page
	Then I should redirected to the Do you know your pet's date of birth page
	And I have provided date of birth
	When I click on continue button from Do you know your pet's date of birth? page
	Then I should redirected to the What is the main colour of your 'Dog' page
	And I have selected the option as 'Gold or yellow' for color
	When I click on continue button from What is the main colour of your pet page
	Then I should redirected to the Does your pet have any significant features page
	And I have selected an option as 'No' for significant features
	When I click on continue button from Does your pet have any significant features page
	Then I should redirected to the Check your answers and sign the declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application in 'Pending' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	And I have verified pet details in summary page
	When I Login to Dynamics application
	And I opens the application
	Then I get the PTD Reference Number and Store it
	When I assign the application to myself
	And I 'Fail' the Microchip check
	And I go back
	And I 'Reject' the application with reason 'Invalid Application'
	Then the status is changed to 'Rejected'
	And I click on Back button in Pets Application
	And I should not see the application in the Dashboard
	Then I should see invalid documents link
	When I click invalid documents link
	Then I should be navigated to invalid documents page
	And invalid documents table column names should be 'Pet name' 'Status'
	Then the status column should display only unsuccessful and cancelled records
	And I can see the view link in all records of the table
	Then I click on Back button
	And I should redirected to Apply for a pet travel document page

