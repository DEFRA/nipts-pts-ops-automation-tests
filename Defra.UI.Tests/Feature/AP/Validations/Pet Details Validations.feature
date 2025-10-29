@Validations
Feature: Pet Details Validations

Validating the negative scenarios for Pet Details

Background:
	Given I navigate to PETS a travel document URL
	When I have provided the password for Landing page
	Then I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the AP Sign in using Government Gateway page
	When I have provided the credentials and signin
	Then I should redirected to Apply for a pet travel document page
	When I click Create a new pet travel document button
	Then I should redirected to the Are your details correct page

Scenario Outline: Verify pets date of birth should not allows older than 34
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
	Then I should redirected to the What breed is your '<Pet>'? page
	And I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page
	Then I should redirected to the What is your pet's name page
	And I provided the Pets name as '<PetName>'
	When I click on continue button from What is your pet's name page
	Then I should redirected to the What sex is your pet page
	And I have selected the option as '<Gender>' for sex
	When I click on continue button from What sex is your pet page
	Then I should redirected to the Do you know your pet's date of birth page
	And I have provided older than expected date of PETS date of birth
	When I click on continue button from Do you know your pet's date of birth? page
	Then I should not be redirected to What is the main colour of your '<Pet>' page
	And I should see an error message "The date you entered is too far in the past, check your pet's date of birth is correct" in pets date of birth page

Examples:
	| FullName | Are your details correct | MicrochipOption | MicrochipNumber | Pet | PetName | Gender |
	| PetDog's | Yes                      | Yes             | 123456789123456 | Dog | Dog     | Male   |

Scenario Outline: Verify pets date of birth should not allows future date
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
	Then I should redirected to the What breed is your '<Pet>'? page
	And I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page
	Then I should redirected to the What is your pet's name page
	And I provided the Pets name as '<PetName>'
	When I click on continue button from What is your pet's name page
	Then I should redirected to the What sex is your pet page
	And I have selected the option as '<Gender>' for sex
	When I click on continue button from What sex is your pet page
	Then I should redirected to the Do you know your pet's date of birth page
	And I have provided future date of PETS date of birth
	When I click on continue button from Do you know your pet's date of birth? page
	Then I should not be redirected to What is the main colour of your '<Pet>' page
	And I should see an error message "Enter a date that is in the past" in pets date of birth page

Examples:
	| FullName | Are your details correct | MicrochipOption | MicrochipNumber | Pet | PetName | Gender |
	| PetCat's | Yes                      | Yes             | 123456789654321 | Cat | Cat     | Female |

Scenario Outline: Verify pets date of birth text boxes should not allow invalid date
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
	And I have provided date of birth as '40''13''2024'
	When I click on continue button from Do you know your pet's date of birth? page
	Then I should not be redirected to What is the main colour of your 'Dog' page
	And I should see an error message "Enter your pet’s date of birth in the correct format, for example, 11 04 2021" in pets date of birth page

Scenario Outline: Verify the error message for no pets date of birth provided
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
	And I have provided date of birth as ''''''
	When I click on continue button from Do you know your pet's date of birth? page
	Then I should not be redirected to What is the main colour of your 'Dog' page
	And I should see an error message "Enter your pet’s date of birth in the correct format, for example, 11 04 2021" in pets date of birth page

Scenario Outline: Verify if the pet type is not selected then should not move to next page
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
	When I click on continue button from Is your pet a cat, dog or ferret page
	Then I should see an error message "Select if your pet is a cat, dog or ferret" in Is your pet a dog, cat or ferret page
	And I should not be redirected to What breed is your '<Pet>' page

Examples:
	| FullName | Are your details correct | MicrochipOption | MicrochipNumber |
	| Pet Dog  | Yes                      | Yes             | 123456789123456 |

Scenario Outline: Verify pet name for validations and should not move to next page
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
	Then I should redirected to the What breed is your '<Pet>'? page
	And I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page
	Then I should redirected to the What is your pet's name page
	And I provided the invalid Pets name as '<PetName>'
	When I click on continue button from What is your pet's name page
	Then I should see an error message '<ErrorMessage>' in What is your pets name page
	And I should not be redirected to What sex is your pet page

Examples:
	| FullName | Are your details correct | MicrochipOption | MicrochipNumber | Pet | Gender | ErrorMessage                                        | PetName                                                                                                                                                                                                                                                                                                                  |
	| Pet Dog  | Yes                      | Yes             | 123456789123456 | Dog | Male   | Enter your pet's name                               |                                                                                                                                                                                                                                                                                                                          |
	| Pet Cat  | Yes                      | Yes             | 123456789123456 | Cat | Female | Enter your pet's name, using 300 characters or less | ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ |

Scenario Outline: Verify if the pets sex is not selected then should not move to next page
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
	Then I should redirected to the What breed is your '<Pet>'? page
	And I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page
	Then I should redirected to the What is your pet's name page
	And I provided the Pets name as '<PetName>'
	When I click on continue button from What is your pet's name page
	Then I should redirected to the What sex is your pet page
	When I click on continue button from What sex is your pet page
	Then I should see an error message "Select if your pet is male or female" in What sex is your pet page
	And I should not redirected to the Do you know your pet's date of birth page

Examples:
	| FullName | Are your details correct | MicrochipOption | MicrochipNumber | Pet | PetName |
	| Pet Dog  | Yes                      | Yes             | 123456789654321 | Cat | Cat     |

Scenario Outline: Verify pet colour page validations by not selecting any color
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
	Then I should redirected to the What breed is your '<Pet>'? page
	And I have selected 2 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page
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
	Then I should see an error message '<ErrorMessage>' in What is the main colour of your pet page
	And I should not be redirected to the Does your pet have any significant features page

Examples:
	| FullName    | Are your details correct | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color | ErrorMessage                          |
	| PetCat's    | Yes                      | Yes             | 123456789654321 | Cat    | Cat     | Female |       | Select the main colour of your cat    |
	| PetDog's    | Yes                      | Yes             | 123456789654322 | Dog    | Dog     | Female |       | Select the main colour of your dog    |

Scenario Outline: Verify pet colour page validations by not selecting any color - Ferret
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
	Then I should see an error message '<ErrorMessage>' in What is the main colour of your pet page
	And I should not be redirected to the Does your pet have any significant features page

Examples:
	| FullName    | Are your details correct | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color | ErrorMessage                          |
	| PetFerret's | Yes                      | Yes             | 123456789654323 | Ferret | Ferret  | Female |       | Select the main colour of your ferret |


Scenario Outline: Verify pet colour page validations and should not moves to next page
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
	Then I should redirected to the What breed is your '<Pet>'? page
	And I have selected 2 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page
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
	And I have provided other colour value as '<OtherColor>'
	When I click on continue button from What is the main colour of your pet page
	Then I should see an error message '<ErrorMessage>' in What is the main colour of your pet page
	And I should not be redirected to the Does your pet have any significant features page

Examples:
	| FullName | Are your details correct | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | ErrorMessage                                                       | OtherColor                                                                                                                                                   |
	| PetDog's | Yes                      | Yes             | 123456789123456 | Dog | Dog     | Male   | Other | Describe the main colour of your dog                               |                                                                                                                                                              |
	| PetDog's | Yes                      | Yes             | 123456789123452 | Dog | Dog     | Female | Other | Describe the main colour of your dog, using 150 characters or less | ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ |

Scenario Outline: Verify pet's significant features page validations by no selection and should not moves to next page
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
	Then I should redirected to the What breed is your '<Pet>'? page
	And I have selected 2 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page
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
	When I click on continue button from Does your pet have any significant features page
	Then I should see an error message '<ErrorMessage>' in Does your pet have any significant features page
	And I should not be redirected to the Check your answers and sign the declaration page

Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | ErrorMessage                                    |
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Black |                       | Select if your pet has any significant features |

Scenario Outline: Verify pet's significant features page validations and should not moves to next page
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
	Then I should redirected to the What breed is your '<Pet>'? page
	And I have selected 2 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page
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
	When I click on continue button from Does your pet have any significant features page
	Then I have selected an option as '<IsSignificantFeatures>' for significant features
	And I have provided significant features as '<SignificantFeatures>'
	When I click on continue button from Does your pet have any significant features page
	Then I should see an error message '<ErrorMessage>' in Does your pet have any significant features page
	And I should not be redirected to the Check your answers and sign the declaration page

Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color | IsSignificantFeatures | SignificantFeatures                                                                                                                                                                                                                                                                                                      | ErrorMessage                                                          |
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Black | Yes                   |                                                                                                                                                                                                                                                                                                                          | Describe your pet's significant feature                               |
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Black | Yes                   | ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ | Describe your pet's significant feature, using 300 characters or less |

Scenario Outline: Verify pet's breed maximum characters limit validations and should not moves to next page
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
	Then I should redirected to the What breed is your '<Pet>'? page
	And I have provided breed value as '<Breed>' in breed dropdownlist
	When I click on continue button from What is your pet's breed page
	Then I should see an error message '<ErrorMessage>' in What breed is your pet page
	And I should not be redirected to the What is your pet's name page

Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Breed                                                                                                                                                      | ErrorMessage                               |
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | VerifyPetsBreedMaximumCharactersLimitValidationsAndShouldNotMovesToNextPageVerifyPetsBreedMaximumCharactersLimitValidationsAndShouldNotMovesToNextPagePage | Enter a breed using 150 characters or less |

Scenario Outline: Verify pet's breed not selected validations and should not moves to next page
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
	Then I should redirected to the What breed is your '<Pet>'? page
	When I click on continue button from What is your pet's breed page
	Then I should see an error message '<ErrorMessage>' in What breed is your pet page
	And I should not be redirected to the What is your pet's name page

Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | ErrorMessage                          |
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Select or enter the breed of your pet |

Scenario: Verify the pet name accepts alphanumeric and special characters
	Then I have selected 'Yes' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page
	And I selected the 'Yes' option
	And provided microchip number as 123456789123456
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned? page
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page
	Then I should redirected to the Is your pet a cat, dog or ferret page
	And I have selected an option as 'Cat' for pet
	When I click on continue button from Is your pet a cat, dog or ferret page
	Then I should redirected to the What breed is your 'Cat'? page
	And I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page
	Then I should redirected to the What is your pet's name page
	And I provided the Pets name as 'Pet!"£$%^&123'
	When I click on continue button from What is your pet's name page
	Then I should redirected to the What sex is your pet page