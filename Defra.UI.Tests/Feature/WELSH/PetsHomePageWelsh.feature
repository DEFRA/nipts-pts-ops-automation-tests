@WelshPETS
Feature: PetsHomePageFooterLinksWelsh

Checking the header, footer and Feedback Hyperlinks in Welsh

Background:
	Given that I navigate to the DEFRA application
	When I have provided the password for Landing page
	Then I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the AP Sign in using Government Gateway page
	And sign in with valid credentials with logininfo

Scenario: Checking the Welsh Feedback Hyperlink opens in new tab
	Then I should navigate to Lifelong pet travel documents page
	When I click 'Cymraeg' link to change the language
	Then I should see the heading of dashboard page changed to Welsh
	And I click the welsh feedback link
	And I should navigate to the Feedback details correct page opens in new tab

Scenario: Checking the Welsh PrivacyNotice Hyperlink opens in new tab
	Then I should navigate to Lifelong pet travel documents page
	When I click 'Cymraeg' link to change the language
	Then I should see the heading of dashboard page changed to Welsh
	And I click the welsh PrivacyNotice link
	And I should navigate to the PrivacyNotice details correct page opens in new tab

Scenario: Checking the Welsh Cookies Hyperlink opens in same tab and back navigation
	Then I should navigate to Lifelong pet travel documents page
	When I click 'Cymraeg' link to change the language
	Then I should see the heading of dashboard page changed to Welsh
	And I click the welsh cookies link
	And I should navigate to the welsh cookies details correct page opens in same tab
	And I click on welsh Back button
	And I should navigate to Lifelong pet travel documents page in Welsh

Scenario: Checking the Welsh AccessibilityStatement Hyperlink opens in same tab and back navigation
	Then I should navigate to Lifelong pet travel documents page
	When I click 'Cymraeg' link to change the language
	Then I should see the heading of dashboard page changed to Welsh
	And I click the welsh AccessibilityStatement Link
	And I should navigate to the welsh AccessibilityStatement details correct page opens in same tab
	And I click on welsh Back button
	And I should navigate to Lifelong pet travel documents page in Welsh

Scenario: Checking the Welsh TermsAndConditions Hyperlink opens in same tab and back navigation
	Then I should navigate to Lifelong pet travel documents page
	When I click 'Cymraeg' link to change the language
	Then I should see the heading of dashboard page changed to Welsh
	And I click the welsh TermsAndConditions Link
	And I should navigate to the welsh TermsAndConditions details correct page opens in same tab
	And I click on welsh Back button
	And I should navigate to Lifelong pet travel documents page in Welsh
