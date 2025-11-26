@WelshPETS
Feature: PTSignificantFeatures Welsh

Create a PETS travel document providing PETS Significante Features to travel from Great Britain to Northern Ireland

Background:
	Given I navigate to PETS a travel document URL
	When I have provided the password for Landing page
	Then I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the AP Sign in using Government Gateway page
	When I have provided the credentials and signin
	
Scenario Outline: Create PTD for PETS with or without Significant Features and verify the hint for yes option in Welsh
	Then I should redirected to Apply for a pet travel document page
	When I click 'Cymraeg' link to change the language
	Then I should see the heading of dashboard page changed to Welsh
	When I click apply for a document button in Welsh
	Then I should redirected to the Are your details correct page in Welsh
	And I have selected '<PetsOwnerDetails>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the Is your pet microchipped page in Welsh
	And I selected the '<MicroChipNumberOn>' option
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
	And I have provided past date of birth from microchip scanned date
	When I click on continue button from Do you know your pet's date of birth? page in Welsh
	Then I should navigate to the What is the main colour of your '<Pet>' page in Welsh
	When I have selected the radio button as '<PetColor>' for pet's and continue in Welsh
	Then I should navigate to the Does your pet have any significant features page in Welsh
	When I have selected '<IsSignificanteFeatures>' for significant features and continue in Welsh
	Then I navigate to the Check your answers and sign the declaration page in Welsh
	And I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I should redirected to the Application submitted page in Welsh
	And I can see the unique application reference number

Examples:
	| PetsOwnerDetails | MicroChipNumberOn | Pet  | PetName | Gender | PetColor      | IsSignificanteFeatures |
	| Yes              | Yes               | Ci   | The Dog | Male   | Aur neu felyn | Oes                    |
	| Yes              | Yes               | Cath | The Cat | Female | Twcsido       | Nac oes                |