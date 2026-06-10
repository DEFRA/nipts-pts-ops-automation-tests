@WelshPETS
Feature: Update Microchip Information Welsh

Modify the Microchiped details before submitting the application in Welsh

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

Scenario Outline: Modify PETS Microchip number By Registered User with details correct in Welsh
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	When provided microchip number as <MicrochipNumber> in Welsh
	And I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped in Welsh
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as '<Pet>' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What breed is your '<Pet>'? page in Welsh
	And I have selected 1 as breed index from breed dropdownlist in Welsh
	When I click on continue button from What is your pet's breed page in Welsh
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
	And I have clicked the change option for the 'Microchip number' from Microchip information section
	And I have modified the microchip number with the value of '<UpdatedMicrochipNumber>' in Welsh
	When I click Continue button from microchipped page in Welsh
	Then I have verified microchip details in declaration page in Welsh
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

Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | UpdatedMicrochipNumber | Pet  | PetName | Gender | Color | IsSignificantFeatures |
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 |        132456789123451 | Ci   | Dog     | Benyw  | Du    | Oes                   |
	| PetCat's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 |        132456789123451 | Cath | Cat     | Benyw  | Du    | Oes                   |

Scenario Outline: Modify PETS Microchip scanned date By Registered User with details correct in Welsh
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	When provided microchip number as <MicrochipNumber> in Welsh
	And I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped in Welsh
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as '<Pet>' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What breed is your '<Pet>'? page in Welsh
	And I have selected 1 as breed index from breed dropdownlist in Welsh
	When I click on continue button from What is your pet's breed page in Welsh
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
	And I have clicked the change option for the 'Implant or scan date' from Microchip information section
	And I have modified the microchip scanned date by adding '-5' days in Welsh
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I have verified microchip details in declaration page in Welsh
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

Examples:
	| FullName  | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet  | PetName | Gender | Color | IsSignificantFeatures |
	| PetCats's | Yes                      | CV1 4PY  | 02012345671 | Yes             | 123456789123452 | Cath | Cat     | Benyw  | Du    | Oes                   |
	| PetDog's  | Yes                      | CV1 4PY  | 02012345671 | Yes             | 123456789123452 | Ci   | Dog     | Benyw  | Coch  | Oes                   |

Scenario Outline: Modify PETS Microchip scanned date By Registered User with details correct in Welsh - Ferret
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	When provided microchip number as <MicrochipNumber> in Welsh
	And I click Continue button from microchipped page in Welsh
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
	And I have clicked the change option for the 'Implant or scan date' from Microchip information section
	And I have modified the microchip scanned date by adding '-5' days in Welsh
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I have verified microchip details in declaration page in Welsh
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

Examples:
	| FullName  | IsRegisteredUser                | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color   | IsSignificantFeatures |
	| PetFerret | Yes, I am the registered keeper | Yes                      | CV1 4PY  | 02012345671 | Yes             | 123456789123452 | Ffured | Ffured  | Benyw  | Sinamon | Oes                   |

Scenario Outline: Modify PETS Microchip number By Registered User with details correct in Welsh - Ferret
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	When provided microchip number as <MicrochipNumber> in Welsh
	And I click Continue button from microchipped page in Welsh
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
	And I have clicked the change option for the 'Microchip number' from Microchip information section
	And I have modified the microchip number with the value of '<UpdatedMicrochipNumber>' in Welsh
	When I click Continue button from microchipped page in Welsh
	Then I have verified microchip details in declaration page in Welsh
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

Examples:
	| FullName  | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | UpdatedMicrochipNumber | Pet    | PetName | Gender | Color | IsSignificantFeatures |
	| PetFerret | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 |        132456789123451 | Ffured | Ffured  | Benyw  | Sabl  | Oes                   |

Scenario Outline: Modify PETS Microchip scanned date before to date of birth and verify the error message in Welsh
	Then I have selected '<Are your details correct>' option
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
	Then I should redirected to the What breed is your '<Pet>'? page in Welsh
	And I have selected 1 as breed index from breed dropdownlist in Welsh
	When I click on continue button from What is your pet's breed page in Welsh
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
	And I have clicked the change option for the 'Implant or scan date' from Microchip information section
	And I have modified the microchip scanned date before to the date of birth in Welsh
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should see an error message "Rhowch ddyddiad sydd ar ôl dyddiad geni'r anifail anwes" in pets microchipped or last scanned page

Examples:
	| Are your details correct | MicrochipOption | MicrochipNumber | Pet  | PetName | Gender | Color | IsSignificantFeatures |
	| Yes                      | Yes             | 123456789123452 | Cath | Cath    | Female | Du    | Oes                   |
	| Yes                      | Yes             | 123456789123452 | Ci   | Ci      | Female | Coch  | Oes                   |

Scenario Outline: Modify PETS Microchip scanned date before to date of birth and verify the error message - Ferret
	Then I have selected '<Are your details correct>' option
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
	And I have clicked the change option for the 'Implant or scan date' from Microchip information section
	And I have modified the microchip scanned date before to the date of birth in Welsh
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should see an error message "Rhowch ddyddiad sydd ar ôl dyddiad geni'r anifail anwes" in pets microchipped or last scanned page

Examples:
	| Are your details correct | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color   | IsSignificantFeatures |
	| Yes                      | Yes             | 123456789123452 | Ffured | Ffured  | Benyw  | Siocled | Oes                   |