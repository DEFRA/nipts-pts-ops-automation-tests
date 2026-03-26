@WelshPETS
Feature: View pet travel document Validations Welsh

Background:
	Given I navigate to PETS a travel document URL
	When I have provided the password for Landing page
	Then I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the AP Sign in using Government Gateway page
	When I have provided the credentials and signin
	Then I should redirected to Apply for a pet travel document page
	When I click 'Cymraeg' link to change the language
	Then I should see the heading of dashboard page changed to Welsh

Scenario: Verify name address and signature details in Issuing authority table of approved document in Welsh
	When I click apply for a document button in Welsh
	Then I should redirected to the Are your details correct page in Welsh
	And I have selected 'Yes' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the 'Yes' option
	And provided microchip number through auto-generated
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as 'Ci' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What breed is your 'Ci'? page in Welsh
	And I have selected 1 as breed index from breed dropdownlist in Welsh
	When I click on continue button from What is your pet's breed page in Welsh
	Then I should redirected to the What is your pet's name page in Welsh
	And I provided the Pets name as 'Ci' in Welsh
	When I click on continue button from What is your pet's name page in Welsh
	Then I should redirected to the What sex is your pet page in Welsh
	And I have selected the option as 'Gwryw' for sex in Welsh
	When I click on continue button from What sex is your pet page in Welsh
	Then I should redirected to the Do you know your pet's date of birth page in Welsh
	And I have provided date of birth in Welsh
	When I click on continue button from Do you know your pet's date of birth? page in Welsh
	Then I should redirected to the What is the main colour of your 'Ci' page in Welsh
	And I have selected the option as 'Aur neu felyn' for color in Welsh
	When I click on continue button from What is the main colour of your pet page in Welsh
	Then I should redirected to the Does your pet have any significant features page in Welsh
	And I have selected an option as 'Nac oes' for significant features in Welsh
	When I click on continue button from Does your pet have any significant features page in Welsh
	Then I navigate to the Check your answers and sign the declaration page in Welsh
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page in Welsh
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link in Welsh
	Then I should see the heading of dashboard page changed to Welsh
	And I should see the application in 'Yn aros' status in Welsh
	When I have clicked the View hyperlink from home page in Welsh
	Then The submitted application should be displayed in summary view in Welsh
	And I have verified pet details in summary page in Welsh
	When I Login to Dynamics application
	And I opens the application
	Then I get the PTD Reference Number and Store it
	When I assign the application to myself
	And I 'Pass' the Microchip check
	And I go back
	And I 'Authorise' the application
	Then the status is changed to 'Authorised'
	And I click on Back button on the Pets Application in Welsh
	And I should see the application in 'Wedi’u cymeradwyo' status in Welsh
	When I have clicked the View hyperlink from home page in Welsh
	Then I should see a table named 'Awdurdod dyroddi' with a column 'Enw a chyfeiriad yr awdurdod cymwys' in approved document in Welsh
	And the address of authority should be 'Asiantaeth Iechyd Anifeiliaid a Phlanhigion' 'Woodham Lane, New Haw, Addlestone, Surrey KT15 3NB' in Welsh
	And I should see 'Wedi'i llofnodi ar ran yr awdurdod cymwys (APHA)' column with signed person name and designation in Welsh

Scenario: Verify back button functionality from are your details correct page and from declaration page in Welsh
	When I click apply for a document button in Welsh
	Then I should redirected to the Are your details correct page in Welsh
	And I click on Back button on the Pets Application in Welsh
	And I should see the heading of dashboard page changed to Welsh
	When I click apply for a document button in Welsh
	Then I should redirected to the Are your details correct page in Welsh
	And I have selected 'Yes' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the 'Yes' option
	And provided microchip number through auto-generated
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as 'Ci' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What breed is your 'Ci'? page in Welsh
	And I have selected 1 as breed index from breed dropdownlist in Welsh
	When I click on continue button from What is your pet's breed page in Welsh
	Then I should redirected to the What is your pet's name page in Welsh
	And I provided the Pets name as 'Ci' in Welsh
	When I click on continue button from What is your pet's name page in Welsh
	Then I should redirected to the What sex is your pet page in Welsh
	And I have selected the option as 'Gwryw' for sex in Welsh
	When I click on continue button from What sex is your pet page in Welsh
	Then I should redirected to the Do you know your pet's date of birth page in Welsh
	And I have provided date of birth in Welsh
	When I click on continue button from Do you know your pet's date of birth? page in Welsh
	Then I should redirected to the What is the main colour of your 'Ci' page in Welsh
	And I have selected the option as 'Du' for color in Welsh
	When I click on continue button from What is the main colour of your pet page in Welsh
	Then I should redirected to the Does your pet have any significant features page in Welsh
	And I have selected an option as 'Nac oes' for significant features in Welsh
	When I click on continue button from Does your pet have any significant features page in Welsh
	Then I should redirected to the Check your answers and sign the declaration page in Welsh
	And I click on Back button on the Pets Application in Welsh
	And I should redirected to the Does your pet have any significant features page in Welsh
	And I click on Back button on the Pets Application in Welsh
	And I should redirected to the What is the main colour of your 'Ci' page in Welsh

Scenario: Verify invalid documents link and table in Welsh
	When I click apply for a document button in Welsh
	Then I should redirected to the Are your details correct page in Welsh
	And I have selected 'Yes' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the 'Yes' option
	And provided microchip number through auto-generated
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as 'Ci' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What breed is your 'Ci'? page in Welsh
	And I have selected 1 as breed index from breed dropdownlist in Welsh
	When I click on continue button from What is your pet's breed page in Welsh
	Then I should redirected to the What is your pet's name page in Welsh
	And I provided the Pets name as 'Dog_InvalidLink' in Welsh
	When I click on continue button from What is your pet's name page in Welsh
	Then I should redirected to the What sex is your pet page in Welsh
	And I have selected the option as 'Gwryw' for sex in Welsh
	When I click on continue button from What sex is your pet page in Welsh
	Then I should redirected to the Do you know your pet's date of birth page in Welsh
	And I have provided date of birth in Welsh
	When I click on continue button from Do you know your pet's date of birth? page in Welsh
	Then I should redirected to the What is the main colour of your 'Ci' page in Welsh
	And I have selected the option as 'Du' for color in Welsh
	When I click on continue button from What is the main colour of your pet page in Welsh
	Then I should redirected to the Does your pet have any significant features page in Welsh
	And I have selected an option as 'Nac oes' for significant features in Welsh
	When I click on continue button from Does your pet have any significant features page in Welsh
	Then I should redirected to the Check your answers and sign the declaration page in Welsh
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page in Welsh
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link in Welsh
	Then I should see the heading of dashboard page changed to Welsh
	And I should see the application in 'Yn aros' status in Welsh
	When I have clicked the View hyperlink from home page in Welsh
	Then The submitted application should be displayed in summary view in Welsh
	And I have verified pet details in summary page in Welsh
	When I Login to Dynamics application
	And I opens the application
	Then I get the PTD Reference Number and Store it
	When I assign the application to myself
	And I 'Fail' the Microchip check
	And I go back
	And I 'Reject' the application with reason 'Invalid Application'
	Then the status is changed to 'Rejected'
	And I click on Back button on the Pets Application in Welsh
	And I should see the heading of dashboard page changed to Welsh
	And I should see invalid documents link in Welsh
	When I click invalid documents link in Welsh
	Then I should be navigated to invalid documents page in Welsh
	And invalid documents table column names should be 'Enw’r anifail anwes' 'Statws' in Welsh
	And the status column should display only unsuccessful and cancelled records in Welsh
	And I can see the view link in all records of the table in Welsh
	And I click on Back button on the Pets Application in Welsh
	And I should see the heading of dashboard page changed to Welsh

Scenario: Verify the accept additional cookies in cookies banner and hide cookie message in Welsh
	Then I should see cookies banner at the top of the page in Welsh
	And I should see accept and reject additional cookies button in the cookies banner in Welsh
	When I click Accept additional cookies button in the cookies banner in Welsh
	Then I should see additional cookies accepted confirmation message in Welsh
	And I click Hide cookie message should hide the 'Accepted' cookie banner in Welsh

Scenario: Verify the reject additional cookies in cookies banner and hide cookie message in Welsh
	Then I should see cookies banner at the top of the page in Welsh
	And I should see accept and reject additional cookies button in the cookies banner in Welsh
	When I click Reject additional cookies button in the cookies banner in Welsh
	Then I should see additional cookies rejected confirmation message in Welsh
	And I click Hide cookie message should hide the 'Rejected' cookie banner in Welsh

Scenario: Verify Cookies page radio buttons and default option selection in Welsh
	And I click the Cookies Link
	Then I should navigate to the Cookies details correct page opens in same tab in Welsh
	When I see two radio buttons are visible at the end of the page in Welsh
	Then I should see the No option is selected as default option

Scenario: Verify the applicant can change the cookie preference and save it in cookies page in Welsh
	And I click the Cookies Link
	Then I should navigate to the Cookies details correct page opens in same tab in Welsh
	And I should see the No option is selected as default option
	And I select the Yes option
	When I click the save cookies settings button
	Then I should see success message at the top of the page in Welsh

Scenario: Verify clicking change your cookie settings link in cookies banner opens cookies page in same tab - accept cookies in Welsh
	Then I should see cookies banner at the top of the page in Welsh
	And I should see accept and reject additional cookies button in the cookies banner in Welsh
	When I click Accept additional cookies button in the cookies banner in Welsh
	Then I should see additional cookies accepted confirmation message in Welsh
	When I click change your cookie settings link in the 'Accepted' confirmation message
	Then I should navigate to the Cookies details correct page opens in same tab in Welsh

Scenario: Verify clicking change your cookie settings link in cookies banner opens cookies page in same tab - reject cookies in Welsh
	Then I should see cookies banner at the top of the page in Welsh
	And I should see accept and reject additional cookies button in the cookies banner in Welsh
	When I click Reject additional cookies button in the cookies banner in Welsh
	Then I should see additional cookies rejected confirmation message in Welsh
	When I click change your cookie settings link in the 'Rejected' confirmation message
	Then I should navigate to the Cookies details correct page opens in same tab in Welsh

Scenario: Verify the cookies banner is not visible on any page of the application after saving cookie preference in Welsh
	Then I should see cookies banner at the top of the page in Welsh
	And I should see accept and reject additional cookies button in the cookies banner in Welsh
	When I click Reject additional cookies button in the cookies banner in Welsh
	Then I should see additional cookies rejected confirmation message in Welsh
	And I click Hide cookie message should hide the 'Rejected' cookie banner in Welsh
	And I should not see cookies banner at the top of the page
	When I click apply for a document button in Welsh
	Then I should redirected to the Are your details correct page in Welsh
	And I should not see cookies banner at the top of the page
	And I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I should not see cookies banner at the top of the page
	And I selected the '<MicrochipOption>' option
	And provided microchip number through auto-generated
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I should not see cookies banner at the top of the page
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I should not see cookies banner at the top of the page
	And I have selected an option as '<Pet>' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What breed is your '<Pet>'? page in Welsh
	And I should not see cookies banner at the top of the page
	And I have selected 1 as breed index from breed dropdownlist in Welsh
	When I click on continue button from What is your pet's breed page in Welsh
	Then I should redirected to the What is your pet's name page in Welsh
	And I should not see cookies banner at the top of the page
	And I provided the Pets name as '<PetName>' in Welsh
	When I click on continue button from What is your pet's name page in Welsh
	Then I should redirected to the What sex is your pet page in Welsh
	And I should not see cookies banner at the top of the page
	And I have selected the option as '<Gender>' for sex in Welsh
	When I click on continue button from What sex is your pet page in Welsh
	Then I should redirected to the Do you know your pet's date of birth page in Welsh
	And I should not see cookies banner at the top of the page
	And I have provided date of birth in Welsh
	When I click on continue button from Do you know your pet's date of birth? page in Welsh
	Then I should redirected to the What is the main colour of your '<Pet>' page in Welsh
	And I should not see cookies banner at the top of the page
	And I have selected the option as '<Color>' for color in Welsh
	When I click on continue button from What is the main colour of your pet page in Welsh
	Then I should redirected to the Does your pet have any significant features page in Welsh
	And I should not see cookies banner at the top of the page
	And I have selected an option as '<IsSignificantFeatures>' for significant features in Welsh
	When I click on continue button from Does your pet have any significant features page in Welsh
	Then I should redirected to the Check your answers and sign the declaration page in Welsh
	And I should not see cookies banner at the top of the page
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page in Welsh
	And I should not see cookies banner at the top of the page
	When I have clicked the View all your lifelong pet travel documents link in Welsh
	Then I should see the heading of dashboard page changed to Welsh
	And I should see the application in 'Yn aros' status in Welsh
	When I have clicked the View hyperlink from home page in Welsh
	Then The submitted application should be displayed in summary view in Welsh
	And I should not see cookies banner at the top of the page

Examples:
	| Are your details correct | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures |
	| Yes                      | Yes             | 123456789123456 | Ci  | Ci      | Gwryw  | Du    | Oes                   |

Scenario: Verify the back and forward navigation after navigating upto significant feature page in Welsh
	When I click apply for a document button in Welsh
	Then I should redirected to the Are your details correct page in Welsh
	And I have selected 'Yes' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the 'Yes' option
	And provided microchip number through auto-generated
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as 'Ci' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What breed is your 'Ci'? page in Welsh
	And I have selected 1 as breed index from breed dropdownlist in Welsh
	When I click on continue button from What is your pet's breed page in Welsh
	Then I should redirected to the What is your pet's name page in Welsh
	And I provided the Pets name as 'Ci' in Welsh
	When I click on continue button from What is your pet's name page in Welsh
	Then I should redirected to the What sex is your pet page in Welsh
	And I have selected the option as 'Gwryw' for sex in Welsh
	When I click on continue button from What sex is your pet page in Welsh
	Then I should redirected to the Do you know your pet's date of birth page in Welsh
	And I have provided date of birth in Welsh
	When I click on continue button from Do you know your pet's date of birth? page in Welsh
	Then I should redirected to the What is the main colour of your 'Ci' page in Welsh
	And I have selected the option as 'Du' for color in Welsh
	When I click on continue button from What is the main colour of your pet page in Welsh
	Then I should redirected to the Does your pet have any significant features page in Welsh
	And I click on Back button on the Pets Application in Welsh
	And I should redirected to the What is the main colour of your 'Ci' page in Welsh
	And I click on Back button on the Pets Application in Welsh
	And I should redirected to the Do you know your pet's date of birth page in Welsh
	And I click on Back button on the Pets Application in Welsh
	And I should redirected to the What sex is your pet page in Welsh
	And I click on Back button on the Pets Application in Welsh
	And I should redirected to the What is your pet's name page in Welsh
	When I click on continue button from What is your pet's name page in Welsh
	Then I should redirected to the What sex is your pet page in Welsh

Scenario: Verify GOV.UK and the title Taking a pet from Great Britain to Northern Ireland in the header of all pages in Welsh
	Then I should see 'GOV.UK' 'Mynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon' links in the header
	When I click apply for a document button in Welsh
	Then I should redirected to the Are your details correct page in Welsh
	And I should see 'GOV.UK' 'Mynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon' links in the header
	And I have selected 'No' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the What is your full name page in Welsh
	And I should see 'GOV.UK' 'Mynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon' links in the header
	And I provided the full name of the pet keeper as 'PetOwner Welsh' in Welsh
	When I click Continue button from What is your full name page in Welsh
	Then I should redirected to What is your postcode page in Welsh
	And I should see 'GOV.UK' 'Mynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon' links in the header
	And I provided the postcode 'CV1 4PY'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 1 from address list
	When I click Continue button from What is your postcode page in Welsh
	Then I should redirected to What is your phone number page in Welsh
	And I should see 'GOV.UK' 'Mynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon' links in the header
	And I provided the phone number '02012345678'
	When I click Continue button from What is your phone number page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I should see 'GOV.UK' 'Mynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon' links in the header
	And I selected the 'No' option
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to the Get your pet microchipped before applying page in Welsh
	And I should see 'GOV.UK' 'Mynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon' links in the header
	And I click on Back button on the Pets Application in Welsh
	And I should redirected to the Is your pet microchipped page in Welsh
	And I selected the 'Yes' option
	And provided microchip number through auto-generated
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I should see 'GOV.UK' 'Mynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon' links in the header
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I should see 'GOV.UK' 'Mynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon' links in the header
	And I have selected an option as 'Ci' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What breed is your 'Ci'? page in Welsh
	And I should see 'GOV.UK' 'Mynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon' links in the header
	And I have selected 1 as breed index from breed dropdownlist in Welsh
	When I click on continue button from What is your pet's breed page in Welsh
	Then I should redirected to the What is your pet's name page in Welsh
	And I should see 'GOV.UK' 'Mynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon' links in the header
	And I provided the Pets name as 'Ci' in Welsh
	When I click on continue button from What is your pet's name page in Welsh
	Then I should redirected to the What sex is your pet page in Welsh
	And I should see 'GOV.UK' 'Mynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon' links in the header
	And I have selected the option as 'Gwryw' for sex in Welsh
	When I click on continue button from What sex is your pet page in Welsh
	Then I should redirected to the Do you know your pet's date of birth page in Welsh
	And I should see 'GOV.UK' 'Mynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon' links in the header
	And I have provided date of birth in Welsh
	When I click on continue button from Do you know your pet's date of birth? page in Welsh
	Then I should redirected to the What is the main colour of your 'Ci' page in Welsh
	And I should see 'GOV.UK' 'Mynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon' links in the header
	And I have selected the option as 'Du' for color in Welsh
	When I click on continue button from What is the main colour of your pet page in Welsh
	Then I should redirected to the Does your pet have any significant features page in Welsh
	And I should see 'GOV.UK' 'Mynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon' links in the header
	And I have selected an option as 'Nac oes' for significant features in Welsh
	When I click on continue button from Does your pet have any significant features page in Welsh
	Then I should see 'GOV.UK' 'Mynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon' links in the header
	And I should redirected to the Check your answers and sign the declaration page in Welsh
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page in Welsh
	And I should see 'GOV.UK' 'Mynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon' links in the header
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link in Welsh
	Then I should see the heading of dashboard page changed to Welsh
	And I should see the application in 'Yn aros' status in Welsh
	When I have clicked the View hyperlink from home page in Welsh
	Then The submitted application should be displayed in summary view in Welsh
	And I should see 'GOV.UK' 'Mynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon' links in the header

Scenario: Verify the user not able to enter the previous session after PTD submission and sign out in Welsh
	When I click apply for a document button in Welsh
	Then I should redirected to the Are your details correct page in Welsh
	And I have selected 'Yes' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the 'Yes' option
	And provided microchip number through auto-generated
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as 'Ffured' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What is your pet's name page in Welsh
	And I provided the Pets name as 'Ffured' in Welsh
	When I click on continue button from What is your pet's name page in Welsh
	Then I should redirected to the What sex is your pet page in Welsh
	And I have selected the option as 'Benyw' for sex in Welsh
	When I click on continue button from What sex is your pet page in Welsh
	Then I should redirected to the Do you know your pet's date of birth page in Welsh
	And I have provided date of birth
	When I click on continue button from Do you know your pet's date of birth? page in Welsh
	Then I should redirected to the What is the main colour of your 'Ffured' page in Welsh
	And I have selected the option as 'Sinamon' for color in Welsh
	When I click on continue button from What is the main colour of your pet page in Welsh
	Then I should redirected to the Does your pet have any significant features page in Welsh
	And I have selected an option as 'Nac oes' for significant features in Welsh
	When I click on continue button from Does your pet have any significant features page in Welsh
	Then I should redirected to the Check your answers and sign the declaration page in Welsh
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page in Welsh
	When I have clicked the View all your lifelong pet travel documents link in Welsh
	Then I should see the heading of dashboard page changed to Welsh
	And click on signout button and verify the signout message
	When I click browser back button
	Then I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the AP Sign in using Government Gateway page
	And I click sign in button
	And I should see an error message "Enter Government Gateway user ID&Enter your password" in Government Gateway page
