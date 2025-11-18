@Validations
Feature: Microchip Information Validations Welsh

Validating the negative scenarios for Microchip Information in Welsh

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

Scenario Outline: Verify microchipped date should not allows future date
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber>
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided future date of PETS microchipped
	When I click Continue button from When was your pet microchipped page
	Then I should see an error message "Rhowch ddyddiad sydd yn y gorffennol" in pets microchipped or last scanned page
	And I should not be redirected to Is your pet a dog, cat or ferret? page in Welsh

Examples:
	| FullName | Are your details correct | MicrochipOption | MicrochipNumber |
	| PetCat's | Yes                      | Yes             | 123456789123485 |

Scenario Outline: Verify microchipped date should not allows older than 34 years
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber>
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided older than expected date of PETS microchipped
	When I click Continue button from When was your pet microchipped page
	Then I should not be redirected to Is your pet a dog, cat or ferret? page in Welsh
	And I should see an error message "Nodwch ddyddiad sy’n llai na 34 mlynedd yn ôl" in pets microchipped or last scanned page
Examples:
	| FullName | Are your details correct | MicrochipOption | MicrochipNumber |
	| PetCat's | Yes                      | Yes             | 123456789123485 |

Scenario Outline: Verify microchipped date text boxes should not allow invalid date
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber>
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided microchipped date as '<MicrochippedDay>' '<MicrochippedMonth>' '<MicrochippedYear>'
	When I click Continue button from When was your pet microchipped page
	Then I should not be redirected to Is your pet a dog, cat or ferret? page in Welsh
	And I should see an error message "Rhowch y dyddiad pan gafodd eich anifail anwes y microsglodyn neu’r dyddiad y cafodd ei sganio ddiwethaf. Er enghraifft, 11 4 2021" in pets microchipped or last scanned page
Examples:
	| Are your details correct | MicrochipOption | MicrochipNumber | MicrochippedDay | MicrochippedMonth | MicrochippedYear |
	| Yes                      | Yes             | 123456789123485 | 34              | 12                | 2002             |
	| Yes                      | Yes             | 123456789123485 | 21              | 14                | 2002             |
	| Yes                      | Yes             | 123456789123485 | £$              | %^                | 200$             |
	| Yes                      | Yes             | 123456789123485 | dd              | mm                | 20yy             |

Scenario Outline: Verify microchipped page validations without selection and should not moves to next page
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	When I click Continue button from microchipped page
	Then I should see an error message '<ErrorMessage>' in microchipped page
	And I should not be redirected to When was your pet microchipped or last scanned? page in Welsh
Examples:
	| FullName | Are your details correct | MicrochipOption | ErrorMessage                                      |
	| Pet Dog  | Yes                      |                 | Dwedwch a oes gan eich anifail anwes ficrosglodyn |

Scenario Outline: Verify microchipped page validations and should not moves to next page
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	And enter microchip number as <MicrochipNumber>
	When I click Continue button from microchipped page
	Then I should see an error message '<ErrorMessage>' in microchipped page
	And I should not be redirected to When was your pet microchipped or last scanned? page in Welsh
Examples:
	| FullName | Are your details correct | MicrochipOption | MicrochipNumber | ErrorMessage                                                       |
	| Pet Dog  | Yes                      | Yes             |                 | Rhaid i rif microsglodyn eich anifail anwes fod yn 15 digid o hyd. |
	| Pet Dog  | Yes                      | Yes             | abc123def456fgh | Rhaid i rif microsglodyn eich anifail anwes fod yn 15 digid o hyd. |

Scenario Outline: Verify microchip number should not allows less or more than 15 digits
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	And enter microchip number as <MicrochipNumber>
	When I click Continue button from microchipped page
	Then I should not be redirected to When was your pet microchipped or last scanned? page in Welsh
	And I should see an error message "Rhaid i rif microsglodyn eich anifail anwes fod yn 15 digid o hyd." in Is your pet microchipped page

Examples:
	| FullName | Are your details correct | MicrochipOption | MicrochipNumber  |
	| PetDog's | Yes                      | Yes             | 1234567891       |
	| PetDog's | Yes                      | Yes             | 1234567891234567 |

Scenario Outline: The date on the microchip should be a future date relative to the pets date of birth
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber>
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as '<Pet>' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I should redirected to the What breed is your '<Pet>'? page in Welsh
	And I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page
	Then I should redirected to the What is your pet's name page in Welsh
	And I provided the Pets name as '<PetName>'
	When I click on continue button from What is your pet's name page
	Then I should redirected to the What sex is your pet page in Welsh
	And I have selected the option as '<Gender>' for sex
	When I click on continue button from What sex is your pet page
	Then I should redirected to the Do you know your pet's date of birth page in Welsh
	And I have provided future date of birth from microchip scanned date
	When I click on continue button from Do you know your pet's date of birth? page
	Then I should not be redirected to the What is the main colour of your '<Pet>' page in Welsh
	And I should see an error message "Rhowch ddyddiad sydd cyn rhif microsglodyn yr anifail anwes" in pets date of birth page

Examples:
	| FullName | Are your details correct | PhoneNumber | MicrochipOption | MicrochipNumber | Pet  | PetName | Gender | Color         |
	| PetDog's | Yes                      | 02012345671 | Yes             | 123456789123458 | Ci   | Dog     | Male   | Black         |
	| PetCat's | Yes                      | 07440345672 | Yes             | 123456789654322 | Cath | Cat     | Female | Tortoiseshell |

Scenario Outline: Verify declaration page validation and should not moves to application completion
	Then I have selected 'Yes' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the 'Yes' option
	And provided microchip number through auto-generated
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as 'Ci' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page
	Then I should redirected to the What breed is your 'Ci'? page in Welsh
	And I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page
	Then I should redirected to the What is your pet's name page in Welsh
	And I provided the Pets name as 'Dog'
	When I click on continue button from What is your pet's name page
	Then I should redirected to the What sex is your pet page in Welsh
	And I have selected the option as 'Male' for sex
	When I click on continue button from What sex is your pet page
	Then I should redirected to the Do you know your pet's date of birth page in Welsh
	And I have provided past date of birth from microchip scanned date
	When I click on continue button from Do you know your pet's date of birth? page
	Then I should navigate to the What is the main colour of your 'Ci' page in Welsh
	When I have selected the radio button as 'Aur neu felyn' for pet's and continue in Welsh
	Then I should navigate to the Does your pet have any significant features page in Welsh
	When I have selected 'Nac oes' for significant features and continue in Welsh
	Then I navigate to the Check your answers and sign the declaration page in Welsh
	When I click Send Application button in Declaration page
	Then I should see an error message "Cytuno â'r datganiad" in declaration page in Welsh

Scenario Outline: Verify the survey link in get your pet microchipped before applying page
	Then I have selected 'Yes' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the 'No' option
	When I click Continue button from microchipped page
	Then I should redirected to the Get your pet microchipped before applying page in Welsh
	When I click the survey link "Rhowch eich barn (mae'n cymryd 30 eiliad)" in Welsh
	Then I should navigate to the feedback page in new tab

Scenario Outline: Verify the survey link in application submitted page
	Then I have selected 'Yes' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the 'Yes' option
	And provided microchip number through auto-generated
	When I click Continue button from microchipped page
	Then I should redirected to When was your pet microchipped or last scanned? page in Welsh
	And I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page
	Then I should redirected to the Is your pet a cat, dog or ferret page in Welsh
	And I have selected an option as 'Ci' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page
	Then I should redirected to the What breed is your 'Ci'? page in Welsh
	And I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page
	Then I should redirected to the What is your pet's name page in Welsh
	And I provided the Pets name as 'Dog'
	When I click on continue button from What is your pet's name page
	Then I should redirected to the What sex is your pet page in Welsh
	And I have selected the option as 'Male' for sex
	When I click on continue button from What sex is your pet page
	Then I should redirected to the Do you know your pet's date of birth page in Welsh
	And I have provided past date of birth from microchip scanned date
	When I click on continue button from Do you know your pet's date of birth? page
	Then I should navigate to the What is the main colour of your 'Ci' page in Welsh
	When I have selected the radio button as 'Aur neu felyn' for pet's and continue in Welsh
	Then I should navigate to the Does your pet have any significant features page in Welsh
	When I have selected 'Nac oes' for significant features and continue in Welsh
	Then I navigate to the Check your answers and sign the declaration page in Welsh
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page in Welsh
	And I can see the unique application reference number
	When I click the survey link "Rhowch eich barn (mae'n cymryd 30 eiliad)" in Welsh
	Then I should navigate to the feedback page in new tab

Scenario: Verify the input hyphen only to microchip number text box navigates to 403 error page and validate the back button
	Then I have selected 'Yes' option
	When I click on continue button from Are your details correct page
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the 'Yes' option
	And I provided microchip number as hyphen '-'
	When I click Continue button from microchipped page
	Then I should navigate to 'You cannot access this page or perform this action' error page
	When I click browser back button
	Then I should see the already entered hyphen '-' in the microchip number text box
	When I click Continue button from microchipped page
	Then I should navigate to 'You cannot access this page or perform this action' error page
	And I click go back to the previous page link
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I should see the already entered hyphen '-' in the microchip number text box