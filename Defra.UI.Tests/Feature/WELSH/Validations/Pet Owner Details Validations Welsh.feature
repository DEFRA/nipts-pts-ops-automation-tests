@WelshPETS
Feature: Pet Owner Details Validations Welsh

Validating the negative scenarios for Pet Owner Details

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

Scenario: Verify pet owner details page validations in Welsh and should not moves to next page
	When I click on continue button from Are your details correct page in Welsh
	Then I should see an error message 'Dewiswch a ydych chi’n cytuno â’r datganiad' in pet owner details page

Scenario Outline: Verify full name should not be invalid in Welsh
	When I selected the radio button '<Are your details correct>' option and continue in Welsh
	Then I should navigate to Pets Owner full name page in Welsh
	When I provided '<FullName>' and continue in Welsh
	Then I should not be redirected to What is your postcode page in Welsh
	And I should see an error message '<ErrorMessage>' in What is your full name page

Examples:
	| FullName                                                                                                                                                                                                                                                                                                                 | Are your details correct | ErrorMessage                                                   |
	| ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ | Nac ydyn                 | Rhowch eich enw llawn, gan ddefnyddio 300 o gymeriadau neu lai |
	|                                                                                                                                                                                                                                                                                                                          | Nac ydyn                 | Rhowch eich enw llawn                                          |

Scenario Outline: Verify pet owner phone number page validations in Welsh and should not moves to next page
	When I selected the radio button '<Are your details correct>' option and continue in Welsh
	Then I should navigate to Pets Owner full name page in Welsh
	And I provided the full name of the pet keeper as '<FullName>'
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
	Then I should see an error message '<ErrorMessage>' in What is your phone number page
	And I should not be redirected to the Is your pet microchipped page in Welsh
Examples:

	| FullName | Are your details correct | PostCode | PhoneNumber                                                        | ErrorMessage                                         |
	| PetCat's | Nac ydyn                 | CV2 4NZ  |                                                                    | Rhowch rif ffôn, fel 01632 960 001 neu 07700 900 982 |
	| PetDog's | Nac ydyn                 | CV1 4PY  | ABCDEFGHAD                                                         | Rhowch rif ffôn, fel 01632 960 001 neu 07700 900 982 |
	| PetDog's | Nac ydyn                 | CV1 4PY  | 075515528680755155286807551552868075515528680755155286807551552868 | Rhowch rif ffôn, fel 01632 960 001 neu 07700 900 982 |
	| PetDog's | Nac ydyn                 | CV1 4PY  | **************                                                     | Rhowch rif ffôn, fel 01632 960 001 neu 07700 900 982 |

Scenario Outline: Verify postcode search page validations in Welsh and should not moves to next page in Welsh
	When I selected the radio button '<Are your details correct>' option and continue in Welsh
	Then I should navigate to Pets Owner full name page in Welsh
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page in Welsh
	Then I should redirected to What is your postcode page in Welsh
	And I provided the postcode '<PostCode>'
	When I click Search button
	Then I should see an error message '<ErrorMessage>' in What is your postcode page
Examples:

	| FullName | Are your details correct | PostCode                           | ErrorMessage                                                               |
	| PetCat's | Nac ydyn                 |                                    | Rhowch eich cod post                                                       |
	| PetCat's | Nac ydyn                 | ABC121C                            | Rhowch god post llawn yn y fformat cywir, er enghraifft TF7 5AY neu TF75AY |
	| PetDog's | Nac ydyn                 | &&ABC1$$                           | Rhowch god post llawn yn y fformat cywir, er enghraifft TF7 5AY neu TF75AY |
	| PetDog's | Nac ydyn                 | ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGH | Rhowch god post llawn yn y fformat cywir, er enghraifft TF7 5AY neu TF75AY |
	| PetDog's | Nac ydyn                 | IM1 1AX                            | Rhowch god post llawn yn y fformat cywir, er enghraifft TF7 5AY neu TF75AY |

Scenario Outline: Verify postcode search page by not selecting an address from dropdownlist and should not moves to next page in Welsh
	When I selected the radio button '<Are your details correct>' option and continue in Welsh
	Then I should navigate to Pets Owner full name page in Welsh
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page in Welsh
	Then I should redirected to What is your postcode page in Welsh
	And I provided the postcode '<PostCode>'
	When I click Search button
	And I click Continue button from What is your postcode page in Welsh
	Then I should see an error message '<ErrorMessage>' in What is your postcode page

Examples:

	| FullName | Are your details correct | PostCode | ErrorMessage                             |
	| PetCat's | Nac ydyn                 | CV2 4NY  | Dewiswch eich cyfeiriad o blith y rhestr |

Scenario Outline: Verify enter address manually validations with all fields blank in Welsh
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the What is your full name page in Welsh
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page in Welsh
	Then I should redirected to What is your postcode page in Welsh
	When I click on Enter the address manually link from postcode page in Welsh
	Then I should navigate to Pets Owner manually address page in Welsh
	When I click Continue button from What is your address page in Welsh
	Then I should see an error message '<ErrorMessages>' in What is your address page
Examples:

	| FullName | Are your details correct | Address | ErrorMessages                                                                   |
	| PetDog's | Nac ydyn                 |         | Rhowch linell 1 eich cyfeiriad$Rhowch eich tref neu ddinas$Rhowch eich cod post |
	
Scenario Outline: Verify enter address manually validations with maximum limit characters for each fields in Welsh
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the What is your full name page in Welsh
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page in Welsh
	Then I should redirected to What is your postcode page in Welsh
	When I click the link Enter the address manually in Welsh
	Then I have provided address details as '<Address>' for each field
	When I click Continue button from What is your address page in Welsh
	Then I should see an error message '<ErrorMessages>' in What is your address page
Examples:

	| FullName | Are your details correct | Address                                                                                                                                                                                                                                                            | ErrorMessages                                                                                                                                                                                                                                                                                                                              |
	| PetDog's | Nac ydyn                 | ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWX | Rhowch linell 1 eich cyfeiriad gan ddefnyddio 250 o gymeriadau neu lai$Rhowch linell 2 eich cyfeiriad gan ddefnyddio 250 o gymeriadau neu lai$Rhowch dref neu ddinas gan ddefnyddio 250 o gymeriadau neu lai$Rhowch sir gan ddefnyddio 100 o gymeriadau neu lai$Rhowch god post llawn yn y fformat cywir, er enghraifft TF7 5AY neu TF75AY |

Scenario Outline: Verify enter address manually validations with invalid postcode, special characters and exceed limits in Welsh
	Then I have selected '<Are your details correct>' option
	When I click on continue button from Are your details correct page in Welsh
	Then I should redirected to the What is your full name page in Welsh
	And I provided the full name of the pet keeper as '<FullName>'
	When I click Continue button from What is your full name page in Welsh
	Then I should redirected to What is your postcode page in Welsh
	When I click the link Enter the address manually in Welsh
	Then I provided the postcode '<PostCode>'
	When I click Continue button from What is your address page in Welsh
	Then I should see an error message '<ErrorMessages>' in What is your postcode page
Examples:

	| FullName | Are your details correct | PostCode                           | ErrorMessages                                                              |
	| PetCat's | Nac ydyn                 |                                    | Rhowch eich cod post                                                       |
	| PetCat's | Nac ydyn                 | @ABC121C                           | Rhowch god post llawn yn y fformat cywir, er enghraifft TF7 5AY neu TF75AY |
	| PetDog's | Nac ydyn                 | ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGH | Rhowch god post llawn yn y fformat cywir, er enghraifft TF7 5AY neu TF75AY |
	| PetDog's | Nac ydyn                 | BT9 7EP                            | Rhowch god post llawn yn y fformat cywir, er enghraifft TF7 5AY neu TF75AY |