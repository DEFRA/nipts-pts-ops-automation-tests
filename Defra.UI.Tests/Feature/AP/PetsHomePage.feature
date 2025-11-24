@PETS @Regression
Feature: PetsHomePageFooterLinks

Checking the header, footer and Feedback Hyperlinks

Background: 
	Given that I navigate to the DEFRA application
	When I have provided the password for Landing page
	Then I should see type of Gateway login page
	And I have selected "Sign in with Government Gateway" as login type
	When I click Continue button from How do you want to sign in page
	Then I should redirected to the AP Sign in using Government Gateway page
	And sign in with valid credentials with logininfo

Scenario: Checking the Feedback Hyperlink opens in new tab
	Then I should navigate to Lifelong pet travel documents page
	And  I click the Feedback Link
	Then I should navigate to the Feedback details correct page opens in new tab

Scenario: Checking the AccessibilityStatement Hyperlink opens in same tab and back navigation
	Then I should navigate to Lifelong pet travel documents page
	And  I click the AccessibilityStatement Link
	Then I should navigate to the AccessibilityStatement details correct page opens in same tab
	And I click on Back button
	Then I should navigate to Lifelong pet travel documents page

Scenario: Checking the Cookies Hyperlink opens in same tab and back navigation
	Then I should navigate to Lifelong pet travel documents page
	And  I click the Cookies Link
	Then I should navigate to the Cookies details correct page opens in same tab
	And I click on Back button
	Then I should navigate to Lifelong pet travel documents page 

Scenario: Checking the PrivacyNotice Hyperlink opens in new tab
	Then I should navigate to Lifelong pet travel documents page
	And  I click the PrivacyNotice Link
	Then I should navigate to the PrivacyNotice details correct page opens in new tab

Scenario: Checking the TermsAndConditions Hyperlink opens in same tab and back navigation
	Then I should navigate to Lifelong pet travel documents page
	And  I click the TermsAndConditions Link
	Then I should navigate to the TermsAndConditions details correct page opens in same tab
	And I click on Back button
	Then I should navigate to Lifelong pet travel documents page 

Scenario: Checking the CrownCopyright Hyperlink
	Then I should navigate to Lifelong pet travel documents page
	And  I click the CrownCopyright Link
	Then I should navigate to the CrownCopyright details correct page