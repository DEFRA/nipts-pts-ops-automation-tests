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

Scenario: Verify name address and signature details in Issuing authority table of approved document
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
	Then I should see 'Signed on behalf of the competent authority(APHA)' column with signed person name and designation

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

Scenario: Verify the accept additional cookies in cookies banner and hide cookie message
	Then I should see cookies banner at the top of the page
	And I should see accept and reject additional cookies button in the cookies banner
	When I click Accept additional cookies button in the cookies banner
	Then  I should see additional cookies accepted confirmation message
	And I click Hide cookie message should hide the 'Accepted' cookie banner

Scenario: Verify the reject additional cookies in cookies banner and hide cookie message
	Then I should see cookies banner at the top of the page
	And I should see accept and reject additional cookies button in the cookies banner
	When I click Reject additional cookies button in the cookies banner
	Then  I should see additional cookies rejected confirmation message
	And I click Hide cookie message should hide the 'Rejected' cookie banner

Scenario: Verify Cookies page radio buttons and default option selection 
	And  I click the Cookies Link
	Then I should navigate to the Cookies details correct page opens in same tab
	When I see two radio buttons are visible at the end of the page
	Then I should see the No option is selected as default option

Scenario: Verify the applicant can change the cookie preference and save it in cookies page
	And  I click the Cookies Link
	Then I should navigate to the Cookies details correct page opens in same tab
	And I should see the No option is selected as default option
	Then I select the Yes option 
	When I click the save cookies settings button
	Then I should see success message at the top of the page

Scenario: Verify clicking change your cookie settings link in cookies banner opens cookies page in same tab - accept cookies
	Then I should see cookies banner at the top of the page
	And I should see accept and reject additional cookies button in the cookies banner
	When I click Accept additional cookies button in the cookies banner
	Then  I should see additional cookies accepted confirmation message
	When I click change your cookie settings link in the 'Accepted' confirmation message
	Then I should navigate to the Cookies details correct page opens in same tab 

Scenario: Verify clicking change your cookie settings link in cookies banner opens cookies page in same tab - reject cookies
	Then I should see cookies banner at the top of the page
	And I should see accept and reject additional cookies button in the cookies banner
	When I click Reject additional cookies button in the cookies banner
	Then  I should see additional cookies rejected confirmation message
	When I click change your cookie settings link in the 'Rejected' confirmation message
	Then I should navigate to the Cookies details correct page opens in same tab

Scenario: Verify the cookies banner is not visible on any page of the application after saving cookie preference
	Then I should see cookies banner at the top of the page
	And I should see accept and reject additional cookies button in the cookies banner
	When I click Reject additional cookies button in the cookies banner
	Then  I should see additional cookies rejected confirmation message
	And I click Hide cookie message should hide the 'Rejected' cookie banner
	Then I should not see cookies banner at the top of the page
	When I click Create a new pet travel document button
	Then I should redirected to the Are your details correct page
	And I should not see cookies banner at the top of the page
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	And I should not see cookies banner at the top of the page
	Then I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber>
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned? page
	And I should not see cookies banner at the top of the page
	Then I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page
	Then I should redirected to the Is your pet a cat, dog or ferret page
	And I should not see cookies banner at the top of the page
	Then I have selected an option as '<Pet>' for pet
	When I click on continue button from Is your pet a cat, dog or ferret page
	Then I should redirected to the What breed is your '<Pet>'? page
	And I should not see cookies banner at the top of the page
	Then I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page
	Then I should redirected to the What is your pet's name page
	And I should not see cookies banner at the top of the page
	Then I provided the Pets name as '<PetName>'
	When I click on continue button from What is your pet's name page
	Then I should redirected to the What sex is your pet page
	And I should not see cookies banner at the top of the page
	Then I have selected the option as '<Gender>' for sex
	When I click on continue button from What sex is your pet page
	Then I should redirected to the Do you know your pet's date of birth page
	And I should not see cookies banner at the top of the page
	Then I have provided date of birth
	When I click on continue button from Do you know your pet's date of birth? page
	Then I should redirected to the What is the main colour of your '<Pet>' page
	And I should not see cookies banner at the top of the page
	Then I have selected the option as '<Color>' for color
	When I click on continue button from What is the main colour of your pet page
	Then I should redirected to the Does your pet have any significant features page
	And I should not see cookies banner at the top of the page
	Then I have selected an option as '<IsSignificantFeatures>' for significant features
	When I click on continue button from Does your pet have any significant features page
	Then I should redirected to the Check your answers and sign the declaration page
	And I should not see cookies banner at the top of the page
	Then I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I should not see cookies banner at the top of the page
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application in 'Pending' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	And I should not see cookies banner at the top of the page

Examples:
	| Are your details correct | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color         | IsSignificantFeatures |
	| Yes                      | Yes             | 123456789123456 | Dog | Dog     | Male   | Black         | Yes                   |

Scenario: Verify the back and forward navigation after navigating upto significant feature page
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
	And I click on Back button
	Then I should redirected to the What is the main colour of your 'Dog' page
	And I click on Back button
	Then I should redirected to the Do you know your pet's date of birth page
	And I click on Back button
	Then I should redirected to the What sex is your pet page
	And I click on Back button
	Then I should redirected to the What is your pet's name page
	When I click on continue button from What is your pet's name page
	Then I should redirected to the What sex is your pet page

Scenario: Verify GOV.UK and the title Taking a pet from Great Britain to Northern Ireland in the header of all pages
	Then I should see 'GOV.UK' 'Taking a pet from Great Britain to Northern Ireland' links in the header
	When I click Create a new pet travel document button
	Then I should redirected to the Are your details correct page
	And I should see 'GOV.UK' 'Taking a pet from Great Britain to Northern Ireland' links in the header
	Then I have selected 'No' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the What is your full name page
	And I should see 'GOV.UK' 'Taking a pet from Great Britain to Northern Ireland' links in the header
	Then I provided the full name of the pet keeper as 'PetDog's'
	When I click Continue button from What is your full name page
	Then I should redirected to What is your postcode page
	And I should see 'GOV.UK' 'Taking a pet from Great Britain to Northern Ireland' links in the header
	Then I provided the postcode 'CV1 4PY'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 1 from address list
	When I click Continue button from What is your postcode page
	Then I should redirected to What is your phone number page
	And I should see 'GOV.UK' 'Taking a pet from Great Britain to Northern Ireland' links in the header
	Then I provided the phone number '02012345678'
	When I click Continue button from What is your phone number page
	Then I should redirected to the Is your pet microchipped page
	And I should see 'GOV.UK' 'Taking a pet from Great Britain to Northern Ireland' links in the header
	Then I selected the 'No' option
	When I click Continue button from microchipped page
	Then I should redirected to the Get your pet microchipped before applying page
	And I should see 'GOV.UK' 'Taking a pet from Great Britain to Northern Ireland' links in the header
	And I click on Back button
	Then I should redirected to the Is your pet microchipped page
	Then I selected the 'Yes' option
	And provided microchip number through auto-generated
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned? page
	And I should see 'GOV.UK' 'Taking a pet from Great Britain to Northern Ireland' links in the header
	Then I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page
	Then I should redirected to the Is your pet a cat, dog or ferret page
	And I should see 'GOV.UK' 'Taking a pet from Great Britain to Northern Ireland' links in the header
	Then I have selected an option as 'Dog' for pet
	When I click on continue button from Is your pet a cat, dog or ferret page
	Then I should redirected to the What breed is your 'Dog'? page
	And I should see 'GOV.UK' 'Taking a pet from Great Britain to Northern Ireland' links in the header
	Then I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page
	Then I should redirected to the What is your pet's name page
	And I should see 'GOV.UK' 'Taking a pet from Great Britain to Northern Ireland' links in the header
	Then I provided the Pets name as 'Dog'
	When I click on continue button from What is your pet's name page
	Then I should redirected to the What sex is your pet page
	And I should see 'GOV.UK' 'Taking a pet from Great Britain to Northern Ireland' links in the header
	Then I have selected the option as 'Male' for sex
	When I click on continue button from What sex is your pet page
	Then I should redirected to the Do you know your pet's date of birth page
	And I should see 'GOV.UK' 'Taking a pet from Great Britain to Northern Ireland' links in the header
	Then I have provided date of birth
	When I click on continue button from Do you know your pet's date of birth? page
	Then I should redirected to the What is the main colour of your 'Dog' page
	And I should see 'GOV.UK' 'Taking a pet from Great Britain to Northern Ireland' links in the header
	Then I have selected the option as 'Gold or yellow' for color
	When I click on continue button from What is the main colour of your pet page
	Then I should redirected to the Does your pet have any significant features page
	And I should see 'GOV.UK' 'Taking a pet from Great Britain to Northern Ireland' links in the header
	Then I have selected an option as 'No' for significant features
	When I click on continue button from Does your pet have any significant features page
	Then I should see 'GOV.UK' 'Taking a pet from Great Britain to Northern Ireland' links in the header
	And I should redirected to the Check your answers and sign the declaration page
	Then I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	And I should see 'GOV.UK' 'Taking a pet from Great Britain to Northern Ireland' links in the header
	Then I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And I should see the application in 'Pending' status
	When I have clicked the View hyperlink from home page
	Then The submitted application should be displayed in summary view
	And I should see 'GOV.UK' 'Taking a pet from Great Britain to Northern Ireland' links in the header

Scenario: Verify the user not able to enter the previous session after PTD submission and sign out
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
	And I have selected an option as 'Ferret' for pet
	When I click on continue button from Is your pet a cat, dog or ferret page
	Then I should redirected to the What is your pet's name page
	And I provided the Pets name as 'Ferret'
	When I click on continue button from What is your pet's name page
	Then I should redirected to the What sex is your pet page
	And I have selected the option as 'Male' for sex
	When I click on continue button from What sex is your pet page
	Then I should redirected to the Do you know your pet's date of birth page
	And I have provided date of birth
	When I click on continue button from Do you know your pet's date of birth? page
	Then I should redirected to the What is the main colour of your 'Ferret' page
	And I have selected the option as 'Cinnamon' for color
	When I click on continue button from What is the main colour of your pet page
	Then I should redirected to the Does your pet have any significant features page
	And I have selected an option as 'No' for significant features
	When I click on continue button from Does your pet have any significant features page
	Then I should redirected to the Check your answers and sign the declaration page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page
	When I have clicked the View all your lifelong pet travel documents link
	Then I should redirected to Apply for a pet travel document page
	And  click on signout button and verify the signout message
	When I click browser back button
	Then I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the AP Sign in using Government Gateway page
	And I click sign in button
	And I should see an error message "Enter Government Gateway user ID&Enter your password" in Government Gateway page
