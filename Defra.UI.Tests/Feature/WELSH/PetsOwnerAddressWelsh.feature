@PETS @Welsh
Feature: Pets Owner Address Welsh

Create a PETS travel document to provide address when PETS Owner details are incorrect

Background:
	Given that I navigate to the DEFRA application
	When I have provided the password for Landing page
	Then I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the AP Sign in using Government Gateway page
	And sign in with valid credentials with logininfo

@APCrossBrowser
Scenario Outline: Create PETS Travel Document By PostCode Address User in Welsh
	Then I should navigate to Lifelong pet travel documents page
	When I click 'Cymraeg' link to change the language
	Then I should see the heading of dashboard page changed to Welsh
	When I click apply for a document button in Welsh
	Then I should redirected to the Are your details correct page in Welsh
	When I selected the radio button '<PetsOwnerDetails>' option and continue in Welsh
	Then I should navigate to Pets Owner full name page in Welsh
	When I provided '<PetsOwnerName>' and continue in Welsh
	Then I should navigate to Pets Owner address postcode page in Welsh
	When I provide Pets Owner '<PostCode>' and click find address in Welsh
	And I select Pets Owner Address from dropdown and continue in Welsh
	Then I should navigate to Pets Owner phone number page in Welsh
	When I provide Pets Owner '<PhoneNumber>' and continue in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the radio button '<MicroChipNumberOn>' option
	And provided microchip number through auto-generated
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
	When I have provided date of birth for pet and continue in Welsh
	And I have selected the radio button as '<PetColor>' for pet's and continue in Welsh
	Then I should navigate to the Does your pet have any significant features page in Welsh
	When I have selected '<IsSignificanteFeatures>' for significant features and continue in Welsh
	Then I navigate to the Check your answers and sign the declaration page in Welsh
	And I have ticked the checkbox I agree to the declaration
	When I click Send Application button in Declaration page
	Then I should redirect to the Application submitted page in Welsh
	And I can see the application reference number

Examples:
	| PetsOwnerDetails | PetsOwnerName     | PostCode | PhoneNumber | MicroChipNumberOn | MicroChipNumber | Pet | PetName | Gender | PetColor      | IsSignificanteFeatures |
	| Nac ydyn         | DEFRA PTS Service | RM10 8DP | 07401659856 | Yes               | 123456789123456 | Ci  | The Ci  | Male   | Aur neu felyn | Oes                    |

Scenario Outline: Create PETS Travel Document By Manually Address User in Welsh
	Then I should navigate to Lifelong pet travel documents page
	When I click 'Cymraeg' link to change the language
	Then I should see the heading of dashboard page changed to Welsh
	When I click apply for a document button in Welsh
	Then I should redirected to the Are your details correct page in Welsh
	When I selected the radio button '<PetsOwnerDetails>' option and continue in Welsh
	Then I should navigate to Pets Owner full name page in Welsh
	When I provided '<PetsOwnerName>' and continue in Welsh
	Then I should navigate to Pets Owner address postcode page in Welsh
	When I click on Enter the address manually link from postcode page in Welsh
	Then I should navigate to Pets Owner manually address page in Welsh
	When I fill in '<AddressLineOne>', '<AddressLineTwo>', '<TownOrCity>', '<County>', '<PostCode>'and continue in Welsh
	Then I should navigate to Pets Owner phone number page in Welsh
	When I provide Pets Owner '<PhoneNumber>' and continue in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the radio button '<MicroChipNumberOn>' option
	And provided microchip number through auto-generated
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
	When I have provided date of birth for pet and continue in Welsh
	And I have selected the radio button as '<PetColor>' for pet's and continue in Welsh
	Then I should navigate to the Does your pet have any significant features page in Welsh
	When I have selected '<IsSignificanteFeatures>' for significant features and continue in Welsh
	Then I navigate to the Check your answers and sign the declaration page in Welsh
	And I have ticked the checkbox I agree to the declaration
	When I click Send Application button in Declaration page
	Then I should redirect to the Application submitted page in Welsh
	And I can see the application reference number

Examples:
	| PetsOwnerDetails | PetsOwnerName     | AddressLineOne | AddressLineTwo | TownOrCity | County | PostCode | PhoneNumber | MicroChipNumberOn | MicroChipNumber | Pet | PetName | Gender | PetColor      | IsSignificanteFeatures |
	| Nac ydyn         | DEFRA PTS Service | Flat-1         | 12 Reed Road   | Dagenham   | Essex  | RM10 8DP | 07401659856 | Yes               | 123456789123456 | Ci  | The Ci  | Male   | Aur neu felyn | Oes                    |