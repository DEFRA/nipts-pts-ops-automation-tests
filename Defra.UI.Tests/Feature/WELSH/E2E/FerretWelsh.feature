@E2EWelsh
Feature: E2E Ferret Welsh

Create a PETS travel document for the travel from Great Britain to Northern Ireland in Welsh

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
	When I click apply for a document button in Welsh
	Then I should redirected to the Are your details correct page in Welsh

Scenario Outline: Create PETS Travel Document By Registered User with details correct in Welsh - Ferret - Authorised in Dynamics
	Then I have selected '<Are your details correct>' option in Welsh
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber> in Welsh
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped in Welsh
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as '<Pet>' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What is your pet's name page in Welsh
	And I provided the Pets name as '<PetName>' in Welsh
	When I click on continue button from What is your pet's name page in Welsh
	Then I should redirected to the What sex is your pet page in Welsh
	And I have selected the option as '<Gender>' for sex in Welsh
	When I click on continue button from What sex is your pet page in Welsh
	Then I should redirected to the Do you know your pet's date of birth page in Welsh
	And I have provided date of birth in Welsh
	When I click on continue button from Do you know your pet's date of birth? page in Welsh
	Then I should redirected to the What is the main colour of your '<Pet>' page in Welsh
	And I have selected the option as '<Color>' for color in Welsh
	When I click on continue button from What is the main colour of your pet page in Welsh
	Then I should redirected to the Does your pet have any significant features page in Welsh
	And I have selected an option as '<IsSignificantFeatures>' for significant features in Welsh
	When I click on continue button from Does your pet have any significant features page in Welsh
	Then I should redirected to the Check your answers and sign the declaration page in Welsh
	And I have verified microchip details in declaration page in Welsh
	And I have verified pet details in declaration page in Welsh
	And I have verified pet owner details in declaration page in Welsh
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page in Welsh
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link in Welsh
	Then I should see the heading of dashboard page changed to Welsh
	And I should see the application in 'Yn aros' status in Welsh
	When I have clicked the View hyperlink from home page in Welsh
	Then The submitted application should be displayed in summary view in Welsh
	And I have verified microchip details in summary page in Welsh
	And I have verified pet details in summary page in Welsh
	And I have verified pet owner details in summary page in Welsh
	When I Login to Dynamics application
	And I opens the application
	Then I get the PTD Reference Number and Store it
	When I assign the application to myself
	And I 'Pass' the Microchip check
	And I go back
	And I 'Pass' the Evidence check
	And I go back
	And I 'Authorise' the application
	Then the status is changed to 'Authorised'
	And I click on Back button in Welsh
	And I should see the application in 'Wedi’u cymeradwyo' status in Welsh
Examples:
	| FullName    | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color | IsSignificantFeatures |
	| PetFerret's | Yes                      | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ffured | Ffured  | Benyw  | Sabl  | Nac oes               |

Scenario Outline: Create PETS Travel Document By Registered User with details not correct in Welsh - Ferret - Rejected in Dynamics
	Then I have selected '<Are your details correct>' option in Welsh
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the What is your full name page in Welsh
	And I provided the full name of the pet keeper as '<FullName>' in Welsh
	When I click Continue button from What is your full name page in Welsh
	Then I should redirected to What is your postcode page in Welsh
	And I provided the postcode '<PostCode>'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 1 from address list in Welsh
	When I click Continue button from What is your postcode page in Welsh
	Then I should redirected to What is your phone number page in Welsh
	And I provided the phone number '<PhoneNumber>' in Welsh
	When I click Continue button from What is your phone number page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber> in Welsh
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped in Welsh
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as '<Pet>' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What is your pet's name page in Welsh
	And I provided the Pets name as '<PetName>' in Welsh
	When I click on continue button from What is your pet's name page in Welsh
	Then I should redirected to the What sex is your pet page in Welsh
	And I have selected the option as '<Gender>' for sex in Welsh
	When I click on continue button from What sex is your pet page in Welsh
	Then I should redirected to the Do you know your pet's date of birth page in Welsh
	And I have provided date of birth in Welsh
	When I click on continue button from Do you know your pet's date of birth? page in Welsh
	Then I should redirected to the What is the main colour of your '<Pet>' page in Welsh
	And I have selected the option as '<Color>' for color in Welsh
	When I click on continue button from What is the main colour of your pet page in Welsh
	Then I should redirected to the Does your pet have any significant features page in Welsh
	And I have selected an option as '<IsSignificantFeatures>' for significant features in Welsh
	When I click on continue button from Does your pet have any significant features page in Welsh
	Then I should redirected to the Check your answers and sign the declaration page in Welsh
	And I have verified microchip details in declaration page in Welsh
	And I have verified pet details in declaration page in Welsh
	And I have verified pet owner details in declaration page in Welsh
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page in Welsh
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link in Welsh
	Then I should see the heading of dashboard page changed to Welsh
	And I should see the application in 'Yn aros' status in Welsh
	When I have clicked the View hyperlink from home page in Welsh
	Then The submitted application should be displayed in summary view in Welsh
	And I have verified microchip details in summary page in Welsh
	And I have verified pet details in summary page in Welsh
	And I have verified pet owner details in summary page in Welsh
	When I Login to Dynamics application
	And I opens the application
	Then I get the PTD Reference Number and Store it
	When I assign the application to myself
	And I 'Fail' the Microchip check
	And I go back
	And I 'Reject' the application with reason 'Invalid MC number'
	Then the status is changed to 'Rejected'
	And I click on Back button in Welsh
	And I should not see the application in the Dashboard in Welsh

Examples:
	| FullName    | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color | IsSignificantFeatures |
	| PetFerret's | No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ffured | Ffured  | Benyw  | Sabl  | Nac oes               |

Scenario Outline: Create PETS Travel Document By Registered User with pet is not microchipped in Welsh
	Then I have selected '<Are your details correct>' option in Welsh
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to the Get your pet microchipped before applying page in Welsh

Examples:
	| IsRegisteredUser                | Are your details correct | MicrochipOption |
	| Yes, I am the registered keeper | Yes                      | No              |

Scenario Outline: Create PETS Travel Document By Registered User with enter address manually in Welsh - Revoke in Dynamics
	Then I have selected '<Are your details correct>' option in Welsh
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the What is your full name page in Welsh
	And I provided the full name of the pet keeper as '<FullName>' in Welsh
	When I click Continue button from What is your full name page in Welsh
	Then I should redirected to What is your postcode page in Welsh
	When I click the link Enter the address manually in Welsh
	And I provided address details with postcode '<PostCode>' in Welsh
	And I click Continue button from What is your postcode page in Welsh
	Then I should redirected to What is your phone number page in Welsh
	And I provided the phone number '<PhoneNumber>' in Welsh
	When I click Continue button from What is your phone number page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber> in Welsh
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped in Welsh
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as '<Pet>' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What is your pet's name page in Welsh
	And I provided the Pets name as '<PetName>' in Welsh
	When I click on continue button from What is your pet's name page in Welsh
	Then I should redirected to the What sex is your pet page in Welsh
	And I have selected the option as '<Gender>' for sex in Welsh
	When I click on continue button from What sex is your pet page in Welsh
	Then I should redirected to the Do you know your pet's date of birth page in Welsh
	And I have provided date of birth in Welsh
	When I click on continue button from Do you know your pet's date of birth? page in Welsh
	Then I should redirected to the What is the main colour of your '<Pet>' page in Welsh
	And I have selected the option as '<Color>' for color in Welsh
	When I click on continue button from What is the main colour of your pet page in Welsh
	Then I should redirected to the Does your pet have any significant features page in Welsh
	And I have selected an option as '<IsSignificantFeatures>' for significant features in Welsh
	When I click on continue button from Does your pet have any significant features page in Welsh
	Then I should redirected to the Check your answers and sign the declaration page in Welsh
	And I have verified microchip details in declaration page in Welsh
	And I have verified pet details in declaration page in Welsh
	And I have verified pet owner details in declaration page in Welsh
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page in Welsh
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link in Welsh
	Then I should see the heading of dashboard page changed to Welsh
	And I should see the application in 'Yn aros' status in Welsh
	When I have clicked the View hyperlink from home page in Welsh
	Then The submitted application should be displayed in summary view in Welsh
	And I have verified microchip details in summary page in Welsh
	And I have verified pet details in summary page in Welsh
	And I have verified pet owner details in summary page in Welsh
	When I Login to Dynamics application
	And I opens the application
	Then I get the PTD Reference Number and Store it
	When I assign the application to myself
	And I 'Pass' the Microchip check
	And I go back
	And I 'Authorise' the application
	Then the status is changed to 'Authorised'
	When I assign the application to myself
	And I 'Revoke' the application with reason 'Pet Deceased'
	Then the status is changed to 'Revoked'
	And I click on Back button in Welsh
	And I should not see the application in the Dashboard in Welsh

Examples:
	| FullName | IsRegisteredUser                | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color | IsSignificantFeatures |
	| Ferret's | Yes, I am the registered keeper | No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ffured | Ffured  | Benyw  | Sabl  | Nac oes               |

Scenario Outline: Verify the breed row for ferret not appears in summary and declaration page in Welsh
	Then I have selected '<Are your details correct>' option in Welsh
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber> in Welsh
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped in Welsh
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as '<Pet>' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What is your pet's name page in Welsh
	And I provided the Pets name as '<PetName>' in Welsh
	When I click on continue button from What is your pet's name page in Welsh
	Then I should redirected to the What sex is your pet page in Welsh
	And I have selected the option as '<Gender>' for sex in Welsh
	When I click on continue button from What sex is your pet page in Welsh
	Then I should redirected to the Do you know your pet's date of birth page in Welsh
	And I have provided date of birth in Welsh
	When I click on continue button from Do you know your pet's date of birth? page in Welsh
	Then I should redirected to the What is the main colour of your '<Pet>' page in Welsh
	And I have selected the option as '<Color>' for color in Welsh
	When I click on continue button from What is the main colour of your pet page in Welsh
	Then I should redirected to the Does your pet have any significant features page in Welsh
	And I have selected an option as '<IsSignificantFeatures>' for significant features in Welsh
	When I click on continue button from Does your pet have any significant features page in Welsh
	Then I should redirected to the Check your answers and sign the declaration page in Welsh
	And I have verified microchip details in declaration page in Welsh
	And I have verified pet details in declaration page in Welsh
	And I have verified pet owner details in declaration page in Welsh
	And I have verified breed row for ferret is not displayed
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page in Welsh
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link in Welsh
	Then I should see the heading of dashboard page changed to Welsh
	And I should see the application in 'Yn aros' status in Welsh
	When I have clicked the View hyperlink from home page in Welsh
	Then The submitted application should be displayed in summary view in Welsh
	And I have verified microchip details in summary page in Welsh
	And I have verified pet details in summary page in Welsh
	And I have verified breed row for ferret is not displayed
	And I have verified pet owner details in summary page in Welsh
	When I Login to Dynamics application
	And I opens the application
	Then I get the PTD Reference Number and Store it
	When I assign the application to myself
	And I 'Pass' the Microchip check
	And I go back
	And I 'Pass' the Evidence check
	And I go back
	And I 'Authorise' the application
	Then the status is changed to 'Authorised'
	And I click on Back button in Welsh
	And I should see the application in 'Wedi’u cymeradwyo' status in Welsh
	When I have clicked the View hyperlink from home page in Welsh
	Then I verify all the details in the declaration page for approved PTD 'Wedi’u cymeradwyo' in Welsh
	And I have verified breed row for ferret is not displayed in Welsh

Examples:
	| Are your details correct | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color | IsSignificantFeatures |
	| Yes                      | Yes             | 123456789654321 | Ffured | Ffured  | Benyw  | Sabl  | Nac oes               |

Scenario Outline: Download PETS Travel Document Ferret in Welsh - Approved
	Then I have selected '<Are your details correct>' option in Welsh
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber> in Welsh
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped in Welsh
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as '<Pet>' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What is your pet's name page in Welsh
	And I provided the Pets name as '<PetName>' in Welsh
	When I click on continue button from What is your pet's name page in Welsh
	Then I should redirected to the What sex is your pet page in Welsh
	And I have selected the option as '<Gender>' for sex in Welsh
	When I click on continue button from What sex is your pet page in Welsh
	Then I should redirected to the Do you know your pet's date of birth page in Welsh
	And I have provided date of birth in Welsh
	When I click on continue button from Do you know your pet's date of birth? page in Welsh
	Then I should redirected to the What is the main colour of your '<Pet>' page in Welsh
	And I have selected the option as '<Color>' for color in Welsh
	When I click on continue button from What is the main colour of your pet page in Welsh
	Then I should redirected to the Does your pet have any significant features page in Welsh
	And I have selected an option as '<IsSignificantFeatures>' for significant features in Welsh
	When I click on continue button from Does your pet have any significant features page in Welsh
	Then I should redirected to the Check your answers and sign the declaration page in Welsh
	And I have verified microchip details in declaration page in Welsh
	And I have verified pet details in declaration page in Welsh
	And I have verified pet owner details in declaration page in Welsh
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page in Welsh
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link in Welsh
	Then I should see the heading of dashboard page changed to Welsh
	And I should see the application in 'Yn aros' status in Welsh
	When I have clicked the View hyperlink from home page in Welsh
	Then The submitted application should be displayed in summary view in Welsh
	And I have verified microchip details in summary page in Welsh
	And I have verified pet details in summary page in Welsh
	And I have verified pet owner details in summary page in Welsh
	When I Login to Dynamics application
	And I opens the application
	Then I get the PTD Reference Number and Store it
	When I assign the application to myself
	And I 'Pass' the Microchip check
	And I go back
	And I 'Authorise' the application
	Then the status is changed to 'Authorised'
	And I click on Back button in Welsh
	And I should see the application in 'Wedi’u cymeradwyo' status in Welsh
	When I have clicked the View hyperlink from home page in Welsh
	Then I click download link in summary page in Welsh
	
Examples:
	| FullName    | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color | IsSignificantFeatures |
	| PetFerret's | Yes                      | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ffured | Ffured  | Gwryw  | Sabl  | Nac oes               |

Scenario Outline: Print PETS Travel Document Ferret in Welsh - Approved
	Then I have selected '<Are your details correct>' option in Welsh
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber> in Welsh
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped in Welsh
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as '<Pet>' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What is your pet's name page in Welsh
	And I provided the Pets name as '<PetName>' in Welsh
	When I click on continue button from What is your pet's name page in Welsh
	Then I should redirected to the What sex is your pet page in Welsh
	And I have selected the option as '<Gender>' for sex in Welsh
	When I click on continue button from What sex is your pet page in Welsh
	Then I should redirected to the Do you know your pet's date of birth page in Welsh
	And I have provided date of birth in Welsh
	When I click on continue button from Do you know your pet's date of birth? page in Welsh
	Then I should redirected to the What is the main colour of your '<Pet>' page in Welsh
	And I have selected the option as '<Color>' for color in Welsh
	When I click on continue button from What is the main colour of your pet page in Welsh
	Then I should redirected to the Does your pet have any significant features page in Welsh
	And I have selected an option as '<IsSignificantFeatures>' for significant features in Welsh
	When I click on continue button from Does your pet have any significant features page in Welsh
	Then I should redirected to the Check your answers and sign the declaration page in Welsh
	And I have verified microchip details in declaration page in Welsh
	And I have verified pet details in declaration page in Welsh
	And I have verified pet owner details in declaration page in Welsh
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page in Welsh
	And I can see the unique application reference number
	When I have clicked the View all your lifelong pet travel documents link in Welsh
	Then I should see the heading of dashboard page changed to Welsh
	And I should see the application in 'Yn aros' status in Welsh
	When I have clicked the View hyperlink from home page in Welsh
	Then The submitted application should be displayed in summary view in Welsh
	And I have verified microchip details in summary page in Welsh
	And I have verified pet details in summary page in Welsh
	And I have verified pet owner details in summary page in Welsh
	When I Login to Dynamics application
	And I opens the application
	Then I get the PTD Reference Number and Store it
	When I assign the application to myself
	And I 'Pass' the Microchip check
	And I go back
	And I 'Authorise' the application
	Then the status is changed to 'Authorised'
	And I click on Back button in Welsh
	And I should see the application in 'Wedi’u cymeradwyo' status in Welsh
	When I have clicked the View hyperlink from home page in Welsh
	Then I click print link in summary page in Welsh
	
Examples:
	| FullName    | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color   | IsSignificantFeatures |
	| PetFerret's | Yes                      | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ffured | Ffured  | Gwryw  | Siocled | Nac oes               |