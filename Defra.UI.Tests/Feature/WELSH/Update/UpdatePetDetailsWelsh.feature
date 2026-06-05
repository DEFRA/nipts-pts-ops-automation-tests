@WelshPETS
Feature: Update Pet Details Welsh

Modify the Pet details before submitting the application in Welsh

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

Scenario Outline: Modify PETS Name By Registered User with details correct in Welsh - Ferret
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the What is your full name page in Welsh
	And I provided the full name of the pet keeper as '<FullName>' in Welsh
	When I click Continue button from What is your full name page in Welsh
	Then I should redirected to What is your postcode page in Welsh
	And I provided the postcode '<PostCode>'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 1 from address list
	When I click Continue button from What is your postcode page in Welsh
	Then I should redirected to What is your phone number page in Welsh
	And I provided the phone number '<PhoneNumber>'
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
	And I have clicked the change option for Ferret 'Name' from Pet details section
	And I have modified the pet name as '<UpdatedName>' in Welsh
	When I click on continue button from What is your pet's name page in Welsh
	Then I have verified pet details in declaration page in Welsh
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

Examples:
	| FullName       | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | UpdatedName | Gender | Color   | IsSignificantFeatures |
	| PET-Owner-Name | No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ffured | Ffured  | NewFerret   | Benyw  | Sinamon | Nac oes               |

Scenario Outline: Modify Species of the pet By Registered User with details correct in Welsh
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
	And I have clicked the change option for the 'Species' from Pet details section
	And I have modified the species type as '<UpdatedSpecies>' in Welsh
	When I click continue button from Is your pet a dog, cat or ferret page till reaching declaration page along with modification of color '<UpdatedColor>' and breed <UpdatedBreedIndex> in Welsh
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
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet  | PetName | Gender | Color | IsSignificantFeatures | UpdatedSpecies | UpdatedColor | UpdatedBreedIndex |
	| PetDog   | Yes                      | CV1 4PY  | 02012345671 | Yes             | 123456789123452 | Cath | Cath    | Benyw  | Du    | Oes                   | Ci             | Aurneufelyn  |                 3 |
	| PetCat   | Yes                      | CV1 4PY  | 02012345671 | Yes             | 123456789123452 | Ci   | Ci      | Benyw  | Coch  | Oes                   | Cath           | Du           |                 3 |

Scenario Outline: Modify breed of the pet By Registered User with details correct in Welsh
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
	And I have clicked the change option for the 'Breed' from Pet details section
	And I have modified the pets breed with the index value of '<UpdatedBreedIndex>' in Welsh
	When I click on continue button from What is your pet's breed page in Welsh
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
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet  | PetName | Gender | Color | IsSignificantFeatures | UpdatedBreedIndex |
	| PetCat   | Yes                      | CV1 4PY  | 02012345671 | Yes             | 123456789123452 | Cath | Cath    | Benyw  | Du    | Oes                   |                 3 |
	| PetDog   | Yes                      | CV1 4PY  | 02012345671 | Yes             | 123456789123452 | Ci   | Ci      | Benyw  | Coch  | Oes                   |                 3 |

Scenario Outline: Modify PETS Sex By Registered User with details correct in Welsh - Ferret
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the What is your full name page in Welsh
	And I provided the full name of the pet keeper as '<FullName>' in Welsh
	When I click Continue button from What is your full name page in Welsh
	Then I should redirected to What is your postcode page in Welsh
	And I provided the postcode '<PostCode>'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 1 from address list
	When I click Continue button from What is your postcode page in Welsh
	Then I should redirected to What is your phone number page in Welsh
	And I provided the phone number '<PhoneNumber>'
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
	And I have clicked the change option for Ferret 'Sex' from Pet details section
	And I have modified the pets sex as '<UpdatedSex>' in Welsh
	When I click on continue button from What sex is your pet page in Welsh
	Then I have verified pet details in declaration page in Welsh
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

Examples:
	| FullName       | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | UpdatedSex | Color   | IsSignificantFeatures |
	| PET-Owner-Name | No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ffured | Ffured  | Benyw  | Gwryw      | Sinamon | Nac oes               |

Scenario Outline: Modify PETS date of birth By Registered User with details correct in Welsh - Ferret
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the What is your full name page in Welsh
	And I provided the full name of the pet keeper as '<FullName>' in Welsh
	When I click Continue button from What is your full name page in Welsh
	Then I should redirected to What is your postcode page in Welsh
	And I provided the postcode '<PostCode>'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 1 from address list
	When I click Continue button from What is your postcode page in Welsh
	Then I should redirected to What is your phone number page in Welsh
	And I provided the phone number '<PhoneNumber>'
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
	And I have clicked the change option for Ferret 'Date of birth' from Pet details section
	And I have modified the pets date of birth by adding '-5' days in Welsh
	When I click on continue button from Do you know your pet's date of birth? page in Welsh
	Then I have verified pet details in declaration page in Welsh
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

Examples:
	| FullName       | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color   | IsSignificantFeatures |
	| PET-Owner-Name | No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ffured | Ffured  | Benyw  | Sinamon | Nac oes               |

Scenario Outline: Modify PETS colour By Registered User with details correct in Welsh - Ferret
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the What is your full name page in Welsh
	And I provided the full name of the pet keeper as '<FullName>' in Welsh
	When I click Continue button from What is your full name page in Welsh
	Then I should redirected to What is your postcode page in Welsh
	And I provided the postcode '<PostCode>'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 1 from address list
	When I click Continue button from What is your postcode page in Welsh
	Then I should redirected to What is your phone number page in Welsh
	And I provided the phone number '<PhoneNumber>'
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
	And I have clicked the change option for Ferret 'Colour' from Pet details section
	And I have modified the pets colour as '<UpdatedColor>' in Welsh
	When I click on continue button from What is the main colour of your pet page in Welsh
	Then I have verified pet details in declaration page in Welsh
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

Examples:
	| FullName       | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color | UpdatedColor | IsSignificantFeatures |
	| PET-Owner-Name | No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ffured | Ffured  | Benyw  | Sabl  | Sinamon      | Nac oes               |

Scenario Outline: Modify PETS significant features By Registered User with details correct in Welsh - Ferret
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the What is your full name page in Welsh
	And I provided the full name of the pet keeper as '<FullName>' in Welsh
	When I click Continue button from What is your full name page in Welsh
	Then I should redirected to What is your postcode page in Welsh
	And I provided the postcode '<PostCode>'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 1 from address list
	When I click Continue button from What is your postcode page in Welsh
	Then I should redirected to What is your phone number page in Welsh
	And I provided the phone number '<PhoneNumber>'
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
	And I have clicked the change option for Ferret 'Significant features' from Pet details section
	And I have modified the pets significant feature as '<UpdatedSignificantFeatures>' in Welsh
	When I click on continue button from Does your pet have any significant features page in Welsh
	Then I should redirected to the Check your answers and sign the declaration page in Welsh
	And I have verified pet details in declaration page in Welsh
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

Examples:
	| FullName       | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color | IsSignificantFeatures | UpdatedSignificantFeatures |
	| PET-Owner-Name | No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ffured | Ffured  | Benyw  | Du    | Nac oes               | Oes                        |

Scenario Outline: Modify PETS colour By Registered User with details correct in Welsh
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the What is your full name page in Welsh
	And I provided the full name of the pet keeper as '<FullName>' in Welsh
	When I click Continue button from What is your full name page in Welsh
	Then I should redirected to What is your postcode page in Welsh
	And I provided the postcode '<PostCode>'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 1 from address list
	When I click Continue button from What is your postcode page in Welsh
	Then I should redirected to What is your phone number page in Welsh
	And I provided the phone number '<PhoneNumber>'
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
	And I have clicked the change option for the 'Colour' from Pet details section
	And I have modified the pets colour as '<UpdatedColor>' in Welsh
	When I click on continue button from What is the main colour of your pet page in Welsh
	Then I have verified pet details in declaration page in Welsh
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

Examples:
	| FullName       | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet  | PetName | Gender | Color | UpdatedColor | IsSignificantFeatures |
	| PET-Owner-Name | No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ci   | Ci      | Benyw  | Du    | Coch         | Nac oes               |
	| PET-Owner-Name | No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Cath | Cath    | Benyw  | Du    | Coch         | Nac oes               |
	
Scenario Outline: Modify PETS date of birth By Registered User with details correct in Welsh
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the What is your full name page in Welsh
	And I provided the full name of the pet keeper as '<FullName>' in Welsh
	When I click Continue button from What is your full name page in Welsh
	Then I should redirected to What is your postcode page in Welsh
	And I provided the postcode '<PostCode>'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 1 from address list
	When I click Continue button from What is your postcode page in Welsh
	Then I should redirected to What is your phone number page in Welsh
	And I provided the phone number '<PhoneNumber>'
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
	And I have clicked the change option for the 'Date of birth' from Pet details section
	And I have modified the pets date of birth by adding '-5' days in Welsh
	When I click on continue button from Do you know your pet's date of birth? page in Welsh
	Then I have verified pet details in declaration page in Welsh
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

Examples:
	| FullName       | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet  | PetName | Gender | UpdatedSex | Color | IsSignificantFeatures |
	| PET-Owner-Name | No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ci   | Ci      | Benyw  | Gwryw      | Du    | Nac oes               |
	| PET-Owner-Name | No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Cath | Cath    | Gwryw  | Benyw      | Du    | Nac oes               |

Scenario Outline: Modify PETS Sex By Registered User with details correct in Welsh
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the What is your full name page in Welsh
	And I provided the full name of the pet keeper as '<FullName>' in Welsh
	When I click Continue button from What is your full name page in Welsh
	Then I should redirected to What is your postcode page in Welsh
	And I provided the postcode '<PostCode>'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 1 from address list
	When I click Continue button from What is your postcode page in Welsh
	Then I should redirected to What is your phone number page in Welsh
	And I provided the phone number '<PhoneNumber>'
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
	And I have clicked the change option for the 'Sex' from Pet details section
	And I have modified the pets sex as '<UpdatedSex>' in Welsh
	When I click on continue button from What sex is your pet page in Welsh
	Then I have verified pet details in declaration page in Welsh
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

Examples:
	| FullName       | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet  | PetName | Gender | UpdatedSex | Color | IsSignificantFeatures |
	| PET-Owner-Name | No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ci   | Ci      | Benyw  | Gwryw      | Du    | Nac oes               |
	| PET-Owner-Name | No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Cath | Cath    | Gwryw  | Benyw      | Du    | Nac oes               |

Scenario Outline: Modify PETS Name By Registered User with details correct in Welsh
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the What is your full name page in Welsh
	And I provided the full name of the pet keeper as '<FullName>' in Welsh
	When I click Continue button from What is your full name page in Welsh
	Then I should redirected to What is your postcode page in Welsh
	And I provided the postcode '<PostCode>'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 1 from address list
	When I click Continue button from What is your postcode page in Welsh
	Then I should redirected to What is your phone number page in Welsh
	And I provided the phone number '<PhoneNumber>'
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
	And I have clicked the change option for the 'Name' from Pet details section
	And I have modified the pet name as '<UpdatedName>' in Welsh
	When I click on continue button from What is your pet's name page in Welsh
	Then I have verified pet details in declaration page in Welsh
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

Examples:
	| FullName       | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet  | PetName | UpdatedName | Gender | Color | IsSignificantFeatures |
	| PET-Owner-Name | No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ci   | Ci      | NewDog      | Gwryw  | Coch  | Nac oes               |
	| PET-Owner-Name | No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Cath | Cath    | NewCat      | Gwryw  | Du    | Nac oes               |

Scenario Outline: Modify PETS significant features By Registered User with details correct in Welsh
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the What is your full name page in Welsh
	And I provided the full name of the pet keeper as '<FullName>' in Welsh
	When I click Continue button from What is your full name page in Welsh
	Then I should redirected to What is your postcode page in Welsh
	And I provided the postcode '<PostCode>'
	When I click Search button
	Then I should see a list of address in dropdownlist
	And I select the index 1 from address list
	When I click Continue button from What is your postcode page in Welsh
	Then I should redirected to What is your phone number page in Welsh
	And I provided the phone number '<PhoneNumber>'
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
	And I have clicked the change option for the 'Significant features' from Pet details section
	And I have modified the pets significant feature as '<UpdatedSignificantFeatures>' in Welsh
	When I click on continue button from Does your pet have any significant features page in Welsh
	Then I should redirected to the Check your answers and sign the declaration page in Welsh
	And I have verified pet details in declaration page in Welsh
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

Examples:
	| FullName       | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet  | PetName | Gender | Color | IsSignificantFeatures | UpdatedSignificantFeatures |
	| PET-Owner-Name | No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ci   | Ci      | Gwryw  | Du    | Nac oes               | Oes                        |
	| PET-Owner-Name | No                       | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Cath | Cath    | Gwryw  | Du    | Oes                   | Nac oes                    |

Scenario Outline: Modify Species of the pet By Registered User with details correct in Welsh - Ferret
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
	And I have clicked the change option for Ferret 'Species' from Pet details section
	And I have modified the species type as '<UpdatedSpecies>' in Welsh
	When I click continue button from Is your pet a dog, cat or ferret page till reaching declaration page along with modification of color '<UpdatedColor>' and breed <UpdatedBreedIndex> in Welsh
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
	| FullName  | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color   | IsSignificantFeatures | UpdatedSpecies | UpdatedColor | UpdatedBreedIndex |
	| PetFerret | Yes                      | CV1 4PY  | 02012345671 | Yes             | 123456789123452 | Ffured | Ffured  | Gwryw  | Sinamon | Oes                   | Ci             | Du           |                 3 |
