@Idcoms
Feature: Idcoms Suspension Testdata

IDCOMS System Regression for NIPTS

Scenario: Offline English PTD and SNC
	When I Login to Dynamics application
	And I Click on New to create an offline application
	And I create a new applicant in IDCOMS
	And I enter 'Owner Type' as 'Self'
	And I enter 'Pet Name' as 'Teddy'
	And I enter 'Species' as 'Dog'
	And I enter 'Breed' as 'Beagle'
	And I enter 'Sex' as 'Male'
	And I enter 'Date of Birth' as '09/08/2022'
	And I enter 'Age' as '12'
	And I enter 'Colour' as 'Brown, tan or chocolate'
	And I enter 'Unique feature' as 'As fast as Cheetah'
	And I enter 'Microchipped Date' as '09/08/2023'
	And I enter 'Microchip Number' as 'auto'
	And I Click on Save
	Then the status is 'Open'
	And I see the Application Reference number generated
	When I 'Pass' the Microchip check
	And I go back
	And I 'Authorise' the application
	Then the status is changed to 'Authorised'
	When I switch to 'SNCs' tab
	And I create a New Suspect Non Compliance
	And I Log decision in SNC as '12 Months'
	Then The 'Decision date' is set to Current date
	And the status is changed to 'Intent to Suspend'

Scenario: Offline Welsh PTD and SNC
	When I Login to Dynamics application
	And I Click on New to create an offline application
	And I create a new applicant in IDCOMS
	And I enter 'Owner Type' as 'Self'
	And I enter 'Pet Name' as 'Teddy'
	And I enter 'Species' as 'Dog'
	And I enter 'Breed' as 'Beagle'
	And I enter 'Sex' as 'Male'
	And I enter 'Date of Birth' as '09/08/2022'
	And I enter 'Age' as '12'
	And I enter 'Colour' as 'Brown, tan or chocolate'
	And I enter 'Unique feature' as 'As fast as Cheetah'
	And I enter 'Microchipped Date' as '09/08/2023'
	And I enter 'Microchip Number' as 'auto'
	And I enter 'APPLICATION TYPE' as 'CY'
	And I Click on Save
	Then the status is 'Open'
	And I see the Application Reference number generated
	When I 'Pass' the Microchip check
	And I go back
	And I 'Authorise' the application
	Then the status is changed to 'Authorised'
	When I switch to 'SNCs' tab
	And I create a New Suspect Non Compliance
	And I Log decision in SNC as '12 Months'
	Then The 'Decision date' is set to Current date
	And the status is changed to 'Intent to Suspend'

Scenario: Online English PTD and SNC
	Given that I navigate to the DEFRA application
	When I have provided the password for Landing page
	Then I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the AP Sign in using Government Gateway page
	When I have provided the credentials and signin
	When I click Create a new pet travel document button
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page
	Then I selected the '<MicrochipOption>' option
	And provided microchip number as <MicrochipNumber>
	When I click Continue button from microchipped page
	Then I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page
	Then I have selected an option as '<Pet>' for pet
	When I click on continue button from Is your pet a cat, dog or ferret page
	Then I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page
	Then I provided the Pets name as '<PetName>'
	When I click on continue button from What is your pet's name page
	Then I have selected the option as '<Gender>' for sex
	When I click on continue button from What sex is your pet page
	Then I have provided date of birth
	When I click on continue button from Do you know your pet's date of birth? page
	Then I have selected the option as '<Color>' for color
	When I click on continue button from What is the main colour of your pet page
	Then I have selected an option as '<IsSignificantFeatures>' for significant features
	When I click on continue button from Does your pet have any significant features page
	Then I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I can see the unique application reference number
	When I Login to Dynamics application
	And I opens the application
	Then I get the PTD Reference Number and Store it
	When I assign the application to myself
	And I 'Pass' the Microchip check
	And I go back
	And I 'Authorise' the application
	Then the status is changed to 'Authorised'
	When I switch to 'SNCs' tab
	And I create a New Suspect Non Compliance
	And I Log decision in SNC as '12 Months'
	Then The 'Decision date' is set to Current date
	And the status is changed to 'Intent to Suspend'

Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet | PetName | Gender | Color         | IsSignificantFeatures |
	| PetDog1's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Black         | No                    |
	| PetCat1's | Yes                      | CV2 4NZ  | 07440345678 | Yes             | 123456789654323 | Cat | Cat     | Female | Tortoiseshell | No                    |
	| PetDog2's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Red           | No                    |
	| PetCat2's | Yes                      | CV2 4NZ  | 07440345678 | Yes             | 123456789654323 | Cat | Cat     | Female | Ginger        | No                    |
	| PetDog3's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Red           | No                    |
	| PetCat3's | Yes                      | CV2 4NZ  | 07440345678 | Yes             | 123456789654323 | Cat | Cat     | Female | White         | No                    |
	| PetDog4's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Black         | No                    |
	| PetCat4's | Yes                      | CV2 4NZ  | 07440345678 | Yes             | 123456789654323 | Cat | Cat     | Female | Tortoiseshell | No                    |
	| PetDog5's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Red           | No                    |
	| PetCat5's | Yes                      | CV2 4NZ  | 07440345678 | Yes             | 123456789654323 | Cat | Cat     | Female | Ginger        | No                    |
	| PetDog6's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Dog | Dog     | Male   | Red           | No                    |
	| PetCat6's | Yes                      | CV2 4NZ  | 07440345678 | Yes             | 123456789654323 | Cat | Cat     | Female | White         | No                    |


Scenario: Online Welsh PTD and SNC
	Given that I navigate to the DEFRA application
	When I have provided the password for Landing page
	Then I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the AP Sign in using Government Gateway page
	When I have provided the credentials and signin
	When I click 'Cymraeg' link to change the language
	Then I should see the heading of dashboard page changed to Welsh
	When I click apply for a document button in Welsh
	Then I have selected '<Are your details correct>' option in Welsh
	When I click on continue button from Are your details correct page in Welsh
	Then I selected the '<MicrochipOption>' option
	When provided microchip number as <MicrochipNumber> in Welsh
	And I click Continue button from microchipped page in Welsh
	Then I have provided date of PETS microchipped in Welsh
	When I click Continue button from When was your pet microchipped page in Welsh
	Then I have selected an option as '<Pet>' for pet in Welsh
	When I click on continue button from Is your pet a cat, dog or ferret page in Welsh
	Then I have selected 1 as breed index from breed dropdownlist in Welsh
	When I click on continue button from What is your pet's breed page in Welsh
	Then I provided the Pets name as '<PetName>' in Welsh
	When I click on continue button from What is your pet's name page in Welsh
	Then I have selected the option as '<Gender>' for sex in Welsh
	When I click on continue button from What sex is your pet page in Welsh
	Then I have provided date of birth in Welsh
	When I click on continue button from Do you know your pet's date of birth? page in Welsh
	Then I have selected the option as '<Color>' for color in Welsh
	When I click on continue button from What is the main colour of your pet page in Welsh
	Then I have selected an option as '<IsSignificantFeatures>' for significant features in Welsh
	When I click on continue button from Does your pet have any significant features page in Welsh
	Then I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I can see the unique application reference number
	When I Login to Dynamics application
	And I opens the application
	Then I get the PTD Reference Number and Store it
	When I assign the application to myself
	And I 'Pass' the Microchip check
	And I go back
	And I 'Authorise' the application
	Then the status is changed to 'Authorised'
	When I switch to 'SNCs' tab
	And I create a New Suspect Non Compliance
	And I Log decision in SNC as '12 Months'
	Then The 'Decision date' is set to Current date
	And the status is changed to 'Intent to Suspend'

Examples:
	| FullName | Are your details correct | PostCode | PhoneNumber | MicrochipOption | MicrochipNumber | Pet  | PetName | Gender | Color | IsSignificantFeatures |
	| PetDog's | Yes                      | CV1 4PY  | 02012345678 | Yes             | 123456789123456 | Ci   | Ci      | Benyw  | Du    | Nac oes               |
	| PetCat's | Yes                      | CV2 4NZ  | 07440345678 | Yes             | 123456789654321 | Cath | Cath    | Gwryw  | Coch  | Nac oes               |

Scenario: Multiple Online English PTDs,1-Open,2-Authorised,3-Rejected,4-Revoked and 5-SNC
	Given that I navigate to the DEFRA application
	When I have provided the password for Landing page
	Then I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the AP Sign in using Government Gateway page
	When I have provided the credentials and signin
	                     #1.Open PTD
	When I click Create a new pet travel document button
	Then I have selected 'Yes' option
	When I click on continue button from Are your details correct page
	Then I selected the 'Yes' option
	And provided microchip number as 123456789123423
	When I click Continue button from microchipped page
	Then I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page
	Then I have selected an option as 'Dog' for pet
	When I click on continue button from Is your pet a cat, dog or ferret page
	Then I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page
	Then I provided the Pets name as 'Dog'
	When I click on continue button from What is your pet's name page
	Then I have selected the option as 'Male' for sex
	When I click on continue button from What sex is your pet page
	Then I have provided date of birth
	When I click on continue button from Do you know your pet's date of birth? page
	Then I have selected the option as 'Black' for color
	When I click on continue button from What is the main colour of your pet page
	Then I have selected an option as 'No' for significant features
	When I click on continue button from Does your pet have any significant features page
	Then I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I can see the unique application reference number
	When the user deletes all the stored values
	And I have clicked the View all your lifelong pet travel documents link
	                   #2.Authorised PTD
	When I click Create a new pet travel document button
	Then I have selected 'Yes' option
	When I click on continue button from Are your details correct page
	Then I selected the 'Yes' option
	And provided microchip number as 123456789654323
	When I click Continue button from microchipped page
	Then I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page
	Then I have selected an option as 'Cat' for pet
	When I click on continue button from Is your pet a cat, dog or ferret page
	Then I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page
	Then I provided the Pets name as 'Cat'
	When I click on continue button from What is your pet's name page
	Then I have selected the option as 'Female' for sex
	When I click on continue button from What sex is your pet page
	Then I have provided date of birth
	When I click on continue button from Do you know your pet's date of birth? page
	Then I have selected the option as 'Tortoiseshell' for color
	When I click on continue button from What is the main colour of your pet page
	Then I have selected an option as 'No' for significant features
	When I click on continue button from Does your pet have any significant features page
	Then I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I can see the unique application reference number
	When I Login to Dynamics application
	And I opens the application
	Then I get the PTD Reference Number and Store it
	When I assign the application to myself
	And I 'Pass' the Microchip check
	And I go back
	And I 'Authorise' the application
	Then the status is changed to 'Authorised'
	When the user deletes all the stored values
	                   #3.Rejected PTD
	When I click Apply for another lifelong pet travel document link
	Then I have selected 'Yes' option
	When I click on continue button from Are your details correct page
	Then I selected the 'Yes' option
	And provided microchip number as 123456789654323
	When I click Continue button from microchipped page
	Then I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page
	Then I have selected an option as 'Dog' for pet
	When I click on continue button from Is your pet a cat, dog or ferret page
	Then I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page
	Then I provided the Pets name as 'Dog'
	When I click on continue button from What is your pet's name page
	Then I have selected the option as 'Male' for sex
	When I click on continue button from What sex is your pet page
	Then I have provided date of birth
	When I click on continue button from Do you know your pet's date of birth? page
	Then I have selected the option as 'Black' for color
	When I click on continue button from What is the main colour of your pet page
	Then I have selected an option as 'No' for significant features
	When I click on continue button from Does your pet have any significant features page
	Then I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I can see the unique application reference number
	When I Login to Dynamics application
	And I opens the application
	Then I get the PTD Reference Number and Store it
	When I assign the application to myself
	And I 'Fail' the Microchip check
	And I go back
	And I 'Reject' the application with reason 'Invalid MC number'
	Then the status is changed to 'Rejected'
	When the user deletes all the stored values
	            #4Revoked PTD
	When I click Apply for another lifelong pet travel document link
	Then I have selected 'Yes' option
	When I click on continue button from Are your details correct page
	Then I selected the 'Yes' option
	And provided microchip number as 123456789654323
	When I click Continue button from microchipped page
	Then I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page
	Then I have selected an option as 'Ferret' for pet
	When I click on continue button from Is your pet a cat, dog or ferret page
	Then I provided the Pets name as 'Ferret'
	When I click on continue button from What is your pet's name page
	Then I have selected the option as 'Female' for sex
	When I click on continue button from What sex is your pet page
	Then I have provided date of birth
	When I click on continue button from Do you know your pet's date of birth? page
	Then I have selected the option as 'Sable' for color
	When I click on continue button from What is the main colour of your pet page
	Then I have selected an option as 'No' for significant features
	When I click on continue button from Does your pet have any significant features page
	Then I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I can see the unique application reference number
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
	When the user deletes all the stored values
	                #5.Authorised and created SNC
	When I click Apply for another lifelong pet travel document link
	Then I have selected 'Yes' option
	When I click on continue button from Are your details correct page
	Then I selected the 'Yes' option
	And provided microchip number as 123456789654323
	When I click Continue button from microchipped page
	Then I have provided date of PETS microchipped
	When I click Continue button from When was your pet microchipped page
	Then I have selected an option as 'Cat' for pet
	When I click on continue button from Is your pet a cat, dog or ferret page
	Then I have selected 1 as breed index from breed dropdownlist
	When I click on continue button from What is your pet's breed page
	Then I provided the Pets name as 'Cat'
	When I click on continue button from What is your pet's name page
	Then I have selected the option as 'Female' for sex
	When I click on continue button from What sex is your pet page
	Then I have provided date of birth
	When I click on continue button from Do you know your pet's date of birth? page
	Then I have selected the option as 'Tortoiseshell' for color
	When I click on continue button from What is the main colour of your pet page
	Then I have selected an option as 'No' for significant features
	When I click on continue button from Does your pet have any significant features page
	Then I have ticked the I agree to the declaration checkbox
	When I click Accept and Send button from Declaration page
	Then I can see the unique application reference number
	When I Login to Dynamics application
	And I opens the application
	Then I get the PTD Reference Number and Store it
	When I assign the application to myself
	And I 'Pass' the Microchip check
	And I go back
	And I 'Authorise' the application
	Then the status is changed to 'Authorised'
	When I switch to 'SNCs' tab
	And I create a New Suspect Non Compliance
	And I Log decision in SNC as '12 Months'
	Then The 'Decision date' is set to Current date
	And the status is changed to 'Intent to Suspend'
	When the user deletes all the stored values
	