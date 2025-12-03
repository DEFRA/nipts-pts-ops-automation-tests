@WelshValidations
Feature: Pet Details Validations Welsh

Validating the negative scenarios for Pet Details in Welsh

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

Scenario Outline: Verify pets date of birth should not allows older than 34 in Welsh
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber>
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as '<Pet>' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What breed is your '<Pet>'? page in Welsh
	And I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page in Welsh
	Then I should redirected to the What is your pet's name page in Welsh
	And I provided the Pets name as '<PetName>'
	When I click on continue button from What is your pet's name page in Welsh
	Then I should redirected to the What sex is your pet page in Welsh
	And I have selected the option as '<Gender>' for sex
	When I click on continue button from What sex is your pet page in Welsh
	Then I should redirected to the Do you know your pet's date of birth page in Welsh
	And I have provided older than expected date of PETS date of birth
	When I click on continue button from Do you know your pet's date of birth? page in Welsh
	Then I should not be redirected to the What is the main colour of your '<Pet>' page in Welsh
	And I should see an error message "Mae’r dyddiad rydych chi wedi’i roi yn rhy bell yn y gorffennol, gwnewch yn siŵr bod dyddiad geni eich anifail anwes yn gywir" in pets date of birth page

Examples:
	| FullName | Are your details correct | MicrochipOption | MicrochipNumber | Pet | PetName | Gender |
	| PetDog's | Yes                      | Yes             | 123456789123456 | Ci  | Dog     | Male   |

Scenario Outline: Verify pets date of birth should not allows future date in Welsh
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber>
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as '<Pet>' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What breed is your '<Pet>'? page in Welsh
	And I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page in Welsh
	Then I should redirected to the What is your pet's name page in Welsh
	And I provided the Pets name as '<PetName>'
	When I click on continue button from What is your pet's name page in Welsh
	Then I should redirected to the What sex is your pet page in Welsh
	And I have selected the option as '<Gender>' for sex
	When I click on continue button from What sex is your pet page in Welsh
	Then I should redirected to the Do you know your pet's date of birth page in Welsh
	And I have provided future date of PETS date of birth
	When I click on continue button from Do you know your pet's date of birth? page in Welsh
	Then I should not be redirected to the What is the main colour of your '<Pet>' page in Welsh
	And I should see an error message "Rhowch ddyddiad sydd yn y gorffennol" in pets date of birth page

Examples:
	| FullName | Are your details correct | MicrochipOption | MicrochipNumber | Pet  | PetName | Gender |
	| PetCat's | Yes                      | Yes             | 123456789654321 | Cath | Cat     | Female |

Scenario: Verify pets date of birth text boxes should not allow invalid date in Welsh
	Then I have selected 'Yes' option
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
	And I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page in Welsh
	Then I should redirected to the What is your pet's name page in Welsh
	And I provided the Pets name as 'Dog'
	When I click on continue button from What is your pet's name page in Welsh
	Then I should redirected to the What sex is your pet page in Welsh
	And I have selected the option as 'Male' for sex
	When I click on continue button from What sex is your pet page in Welsh
	Then I should redirected to the Do you know your pet's date of birth page in Welsh
	And I have provided date of birth as '40''13''2024'
	When I click on continue button from Do you know your pet's date of birth? page in Welsh
	Then I should not be redirected to the What is the main colour of your 'Ci' page in Welsh
	And I should see an error message "Rhowch ddyddiad geni eich anifail anwes yn y fformat cywir, er enghraifft, 11 04 2021" in pets date of birth page

Scenario: Verify the error message for no pets date of birth provided in Welsh
	Then I have selected 'Yes' option
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
	And I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page in Welsh
	Then I should redirected to the What is your pet's name page in Welsh
	And I provided the Pets name as 'Dog'
	When I click on continue button from What is your pet's name page in Welsh
	Then I should redirected to the What sex is your pet page in Welsh
	And I have selected the option as 'Male' for sex
	When I click on continue button from What sex is your pet page in Welsh
	Then I should redirected to the Do you know your pet's date of birth page in Welsh
	And I have provided date of birth as ''''''
	When I click on continue button from Do you know your pet's date of birth? page in Welsh
	Then I should not be redirected to the What is the main colour of your 'Dog' page in Welsh
	And I should see an error message "Rhowch ddyddiad geni eich anifail anwes yn y fformat cywir, er enghraifft, 11 04 2021" in pets date of birth page

Scenario: Verify if the pet type is not selected then should not move to next page in Welsh
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber>
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should see an error message "Dwedwch a ydych chi'n mynd â chi anwes, cath anwes neu ffured anwes" in Is your pet a dog, cat or ferret page
	And I should not be redirected to What breed is your '<Pet>' page in Welsh

Examples:
	| FullName | Are your details correct | MicrochipOption | MicrochipNumber |
	| Pet Dog  | Yes                      | Yes             | 123456789123456 |

Scenario Outline: Verify pet name for validations and should not move to next page in Welsh
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber>
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as '<Pet>' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What breed is your '<Pet>'? page in Welsh
	And I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page in Welsh
	Then I should redirected to the What is your pet's name page in Welsh
	And I provided the invalid Pets name as '<PetName>'
	When I click on continue button from What is your pet's name page in Welsh
	Then I should see an error message '<ErrorMessage>' in What is your pets name page
	And I should not be redirected to What sex is your pet page in Welsh

Examples:
	| FullName | Are your details correct | MicrochipOption | MicrochipNumber | Pet  | Gender | ErrorMessage                                                     | PetName                                                                                                                                                                                                                                                                                                                  |
	| Pet Dog  | Yes                      | Yes             | 123456789123456 | Ci   | Male   | Rhowch enw eich anifail anwes                                    |                                                                                                                                                                                                                                                                                                                          |
	| Pet Cat  | Yes                      | Yes             | 123456789123456 | Cath | Female | Rhowch enw anifail anwes gan ddefnyddio 300 o gymeriadau neu lai | ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ |

Scenario Outline: Verify if the pets sex is not selected then should not move to next page in Welsh
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber>
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as '<Pet>' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What breed is your '<Pet>'? page in Welsh
	And I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page in Welsh
	Then I should redirected to the What is your pet's name page in Welsh
	And I provided the Pets name as '<PetName>'
	When I click on continue button from What is your pet's name page in Welsh
	Then I should redirected to the What sex is your pet page in Welsh
	When I click on continue button from What sex is your pet page in Welsh
	Then I should see an error message "Dwedwch a yw'ch anifail anwes yn wryw ynteu'n fenyw" in What sex is your pet page
	And I should not redirected to the Do you know your pet's date of birth page in Welsh

Examples:
	| FullName | Are your details correct | MicrochipOption | MicrochipNumber | Pet  | PetName |
	| Pet Dog  | Yes                      | Yes             | 123456789654321 | Cath | Cat     |

Scenario Outline: Verify pet colour page validations by not selecting any color in Welsh
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber>
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as '<Pet>' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What breed is your '<Pet>'? page in Welsh
	And I have selected 2 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page in Welsh
	Then I should redirected to the What is your pet's name page in Welsh
	And I provided the Pets name as '<PetName>'
	When I click on continue button from What is your pet's name page in Welsh
	Then I should redirected to the What sex is your pet page in Welsh
	And I have selected the option as '<Gender>' for sex
	When I click on continue button from What sex is your pet page in Welsh
	Then I should redirected to the Do you know your pet's date of birth page in Welsh
	And I have provided date of birth
	When I click on continue button from Do you know your pet's date of birth? page in Welsh
	Then I should redirected to the What is the main colour of your '<Pet>' page in Welsh
	And I have selected the option as '<Color>' for color in Welsh
	When I click on continue button from What is the main colour of your pet page in Welsh
	Then I should see an error message '<ErrorMessage>' in What is the main colour of your pet page
	And I should not be redirected to the Does your pet have any significant features page in Welsh

Examples:
	| FullName | Are your details correct | MicrochipOption | MicrochipNumber | Pet  | PetName | Gender | Color | ErrorMessage                |
	| PetCat's | Yes                      | Yes             | 123456789654321 | Cath | Cat     | Female |       | Dewiswch brif liw eich cath |
	| PetDog's | Yes                      | Yes             | 123456789654322 | Ci   | Dog     | Female |       | Dewiswch brif liw eich ci   |

Scenario Outline: Verify pet colour page validations by not selecting any color in Welsh - Ferret
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber>
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as '<Pet>' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What is your pet's name page in Welsh
	And I provided the Pets name as '<PetName>'
	When I click on continue button from What is your pet's name page in Welsh
	Then I should redirected to the What sex is your pet page in Welsh
	And I have selected the option as '<Gender>' for sex
	When I click on continue button from What sex is your pet page in Welsh
	Then I should redirected to the Do you know your pet's date of birth page in Welsh
	And I have provided date of birth
	When I click on continue button from Do you know your pet's date of birth? page in Welsh
	Then I should redirected to the What is the main colour of your '<Pet>' page in Welsh
	And I have selected the option as '<Color>' for color in Welsh
	When I click on continue button from What is the main colour of your pet page in Welsh
	Then I should see an error message '<ErrorMessage>' in What is the main colour of your pet page
	And I should not be redirected to the Does your pet have any significant features page in Welsh

Examples:
	| FullName    | Are your details correct | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color | ErrorMessage                  |
	| PetFerret's | Yes                      | Yes             | 123456789654323 | Ffured | Ferret  | Female |       | Dewiswch brif liw eich ffured |


Scenario Outline: Verify pet colour page validations and should not moves to next page in Welsh
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber>
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as '<Pet>' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What breed is your '<Pet>'? page in Welsh
	And I have selected 2 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page in Welsh
	Then I should redirected to the What is your pet's name page in Welsh
	And I provided the Pets name as '<PetName>'
	When I click on continue button from What is your pet's name page in Welsh
	Then I should redirected to the What sex is your pet page in Welsh
	And I have selected the option as '<Gender>' for sex
	When I click on continue button from What sex is your pet page in Welsh
	Then I should redirected to the Do you know your pet's date of birth page in Welsh
	And I have provided date of birth
	When I click on continue button from Do you know your pet's date of birth? page in Welsh
	Then I should redirected to the What is the main colour of your '<Pet>' page in Welsh
	And I have selected the option as '<Color>' for color in Welsh
	And I have provided other colour value as '<OtherColor>'
	When I click on continue button from What is the main colour of your pet page in Welsh
	Then I should see an error message '<ErrorMessage>' in What is the main colour of your pet page
	And I should not be redirected to the Does your pet have any significant features page in Welsh

Examples:
	| FullName | Are your details correct | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | ErrorMessage                                                          | OtherColor                                                                                                                                                   |
	| PetDog's | Yes                      | Yes             | 123456789123456 | Ci  | Dog     | Male   | Arall | Disgrifiwch liw eich ci                                               |                                                                                                                                                              |
	| PetDog's | Yes                      | Yes             | 123456789123452 | Ci  | Dog     | Female | Arall | Disgrifiwch brif liw eich ci, gan ddefnyddio 150 o gymeriadau neu lai | ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ |

Scenario Outline: Verify pet's significant features page validations by no selection and should not moves to next page in Welsh
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber>
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as '<Pet>' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What breed is your '<Pet>'? page in Welsh
	And I have selected 2 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page in Welsh
	Then I should redirected to the What is your pet's name page in Welsh
	And I provided the Pets name as '<PetName>'
	When I click on continue button from What is your pet's name page in Welsh
	Then I should redirected to the What sex is your pet page in Welsh
	And I have selected the option as '<Gender>' for sex
	When I click on continue button from What sex is your pet page in Welsh
	Then I should redirected to the Do you know your pet's date of birth page in Welsh
	And I have provided date of birth
	When I click on continue button from Do you know your pet's date of birth? page in Welsh
	Then I should redirected to the What is the main colour of your '<Pet>' page in Welsh
	And I have selected the option as '<Color>' for color
	When I click on continue button from What is the main colour of your pet page in Welsh
	Then I should redirected to the Does your pet have any significant features page in Welsh
	When I click on continue button from Does your pet have any significant features page in Welsh
	Then I should see an error message '<ErrorMessage>' in Does your pet have any significant features page
	And I should not be redirected to the Check your answers and sign the declaration page in Welsh

Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color         | IsSignificantFeatures | ErrorMessage                                                        |
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Ci  | Dog     | Male   | Aur neu felyn |                       | Dewiswch a oes gan eich anifail anwes unrhyw nodweddion arwyddocaol |

Scenario Outline: Verify pet's significant features page validations and should not moves to next page in Welsh
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber>
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as '<Pet>' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What breed is your '<Pet>'? page in Welsh
	And I have selected 2 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page in Welsh
	Then I should redirected to the What is your pet's name page in Welsh
	And I provided the Pets name as '<PetName>'
	When I click on continue button from What is your pet's name page in Welsh
	Then I should redirected to the What sex is your pet page in Welsh
	And I have selected the option as '<Gender>' for sex
	When I click on continue button from What sex is your pet page in Welsh
	Then I should redirected to the Do you know your pet's date of birth page in Welsh
	And I have provided date of birth
	When I click on continue button from Do you know your pet's date of birth? page in Welsh
	Then I should redirected to the What is the main colour of your '<Pet>' page in Welsh
	And I have selected the option as '<Color>' for color
	When I click on continue button from What is the main colour of your pet page in Welsh
	Then I should redirected to the Does your pet have any significant features page in Welsh
	When I click on continue button from Does your pet have any significant features page in Welsh
	Then I have selected an option as '<IsSignificantFeatures>' for significant features
	And I have provided significant features as '<SignificantFeatures>'
	When I click on continue button from Does your pet have any significant features page in Welsh
	Then I should see an error message '<ErrorMessage>' in Does your pet have any significant features page
	And I should not be redirected to the Check your answers and sign the declaration page in Welsh

Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color         | IsSignificantFeatures | SignificantFeatures                                                                                                                                                                                                                                                                                                      | ErrorMessage                                                                                |
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Ci  | Dog     | Male   | Aur neu felyn | Yes                   |                                                                                                                                                                                                                                                                                                                          | Disgrifiwch nodwedd arwyddocaol eich anifail anwes                                          |
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Ci  | Dog     | Male   | Aur neu felyn | Yes                   | ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ | Disgrifiwch nodwedd arwyddocaol eich anifail anwes, gan ddefnyddio 300 o gymeriadau neu lai |

Scenario Outline: Verify pet's breed maximum characters limit validations and should not moves to next page in Welsh
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber>
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as '<Pet>' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What breed is your '<Pet>'? page in Welsh
	And I have provided breed value as '<Breed>' in breed dropdownlist
	When I click on continue button from What is your pet's breed page in Welsh
	Then I should see an error message '<ErrorMessage>' in What breed is your pet page
	And I should not be redirected to the What is your pet's name page in Welsh

Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Breed                                                                                                                                                      | ErrorMessage                                        |
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Ci  | Dog     | Male   | VerifyPetsBreedMaximumCharactersLimitValidationsAndShouldNotMovesToNextPageVerifyPetsBreedMaximumCharactersLimitValidationsAndShouldNotMovesToNextPagePage | Rhowch frid gan ddefnyddio 150 o gymeriadau neu lai |

Scenario Outline: Verify pet's breed not selected validations and should not moves to next page in Welsh
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber>
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as '<Pet>' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What breed is your '<Pet>'? page in Welsh
	When I click on continue button from What is your pet's breed page in Welsh
	Then I should see an error message '<ErrorMessage>' in What breed is your pet page
	And I should not be redirected to the What is your pet's name page in Welsh

Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | ErrorMessage                             |
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Ci  | Dog     | Male   | Dewiswch neu roi frîd eich anifail anwes |

Scenario: Verify the pet name accepts alphanumeric and special characters in Welsh
	Then I have selected 'Yes' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the 'Yes' option
	And provided microchip number as 123456789123456
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as 'Cath' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What breed is your 'Cath'? page in Welsh
	And I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page in Welsh
	Then I should redirected to the What is your pet's name page in Welsh
	And I provided the Pets name as 'Pet!"£$%^&123'
	When I click on continue button from What is your pet's name page in Welsh
	Then I should redirected to the What sex is your pet page in Welsh

Scenario Outline: Verify pet's breed are displayed in dropdown based on the selected species in Welsh
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber>
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as '<Pet>' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What breed is your '<Pet>'? page in Welsh
	And I verify the breeds displayed in the breed dropdownlist for '<Pet>' species in Welsh
	Then I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page in Welsh
	Then I should redirected to the What is your pet's name page in Welsh

Examples:
	| Are your details correct | MicrochipOption | MicrochipNumber | Pet  |
	| Yes                      | Yes             | 123456789123456 | Ci   |
	| Yes                      | Yes             | 123456789123456 | Cath |

Scenario Outline: Verify pet's breed accept free text and moves to next page in Welsh
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber>
	When I click Continue button from microchipped page in Welsh
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as '<Pet>' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What breed is your '<Pet>'? page in Welsh
	And I have provided breed value as '<Breed>' in breed dropdownlist
	When I click on continue button from What is your pet's breed page in Welsh
	Then I should redirected to the What is your pet's name page in Welsh

Examples:
	| Are your details correct | MicrochipOption | MicrochipNumber | Pet  | Breed    |
	| Yes                      | Yes             | 123456789123456 | Ci   | DogBreed |
	| Yes                      | Yes             | 123456789123456 | Cath | CatBreed |