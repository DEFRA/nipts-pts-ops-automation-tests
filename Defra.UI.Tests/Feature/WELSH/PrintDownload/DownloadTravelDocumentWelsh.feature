@WelshPETS
Feature: Download Travel Document Welsh

Create a PETS travel document from Great Britain to Northern Ireland and Download the travel document in Welsh

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

Scenario Outline: Download PETS Travel Document Dog and Cat in Welsh - Pending
	Then I have selected '<Are your details correct>' option in Welsh
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
	And I click download link in summary page in Welsh

Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet  | PetName | Gender | Color | IsSignificantFeatures |
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Ci   | Ci      | Benyw  | Du    | Oes                   |
	| PetCat's | Yes                      | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Cath | Cath    | Gwryw  | Coch  | Nac oes               |

	
Scenario Outline: Download PETS Travel Document Ferret in Welsh - Pending
	Then I have selected '<Are your details correct>' option in Welsh
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
	And I click download link in summary page in Welsh
	
Examples:
	| FullName    | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet    | PetName | Gender | Color   | IsSignificantFeatures |
	| PetFerret's | Yes                      | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Ffured | Ffured  | Benyw  | Siocled | Nac oes               |