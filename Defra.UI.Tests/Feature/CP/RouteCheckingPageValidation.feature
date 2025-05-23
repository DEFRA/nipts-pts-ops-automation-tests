﻿@CPRegression
Feature: Route Checking Page Validation

Validating the negative scenarios for Route Checking Information

Background:
	Given that I navigate to the port checker application
	When I click signin button on port checker application
	Then I should redirected to the CP Sign in using Government Gateway page
	When I have provided the CP credentials and signin
	And I have provided the password for prototype research page
	Then I should redirected to port route checker page

Scenario: Verify the error message if no selection of ferry or flight route
	Then I have selected '' radio option
	And I have provided Scheduled departure time '10:30'
	When I click save and continue button from route checker page
	Then I should see an error 'Select if you are checking a ferry or a flight' in route checking page

Scenario: Verify the error message if no selection of ferry route
	Then I have selected 'Ferry' radio option
	Then I select the '' radio option
	And I have provided Scheduled departure time '09:30'
	When I click save and continue button from route checker page
	Then I should see an error message "Select the ferry you are checking" in route checking page

Scenario: Verify the error message if no flight number provided in the flight route
	Then I have selected 'Flight' radio option
	Then I provide the '' in the box
	And I have provided Scheduled departure time '10:40'
	When I click save and continue button from route checker page
	Then I should see an error message "Enter the flight number. For example, RK 103" in route checking page

Scenario Outline: Verify home page for flight Number text box with special character or more than 8 characters
	Then I have selected 'Flight' radio option
	When I see the subheading 'Flight number' with a text box
	Then I provide the '<FlightNumber>' in the box
	And I have provided Scheduled departure time '10:50'
	When I click save and continue button from route checker page
	Then I should see an error message "Enter the flight number using up to 8 letters and numbers (for example, RK 103)" in route checking page
	Examples:
	| FlightNumber |
	| a-z$&*       |
	| 1234 5678    |

Scenario: Verify error message for no scheduled departure date details provided
	Then I have selected 'Flight' radio option
	Then I provide the 'AF296Q' in the box
	Then I have selected ''''''Date option
	And I have provided Scheduled departure time '11:30'
	When I click save and continue button from route checker page
	Then I should see an error message "Enter the scheduled departure date, for example 27 3 2024" in route checking page

Scenario: Verify error message for scheduled departure date with special character
	Then I have selected 'Flight' radio option
	Then I provide the 'AF296Q' in the box
	Then I have selected '£$''*&''%^'Date option
	And I have provided Scheduled departure time '12:30'
	When I click save and continue button from route checker page
	Then I should see an error message "Enter the date in the correct format, for example 27 3 2024" in route checking page

Scenario: Verify error message for any one empty box in scheduled departure date
	Then I have selected 'Flight' radio option
	Then I provide the 'AF296Q' in the box
	Then I have selected '07''''19992'Date option
	And I have provided Scheduled departure time '15:30'
	When I click save and continue button from route checker page
	Then I should see an error message "Enter the date in the correct format, for example 27 3 2024" in route checking page

Scenario: Verify the error message if no selection of scheduled departure time details
	Then I have selected 'Flight' radio option
	Then I provide the 'AF296Q' in the box
	Then I have selected '27''02''2025'Date option
	When I click save and continue button from route checker page
	Then I should see an error message "Enter the scheduled departure time, for example 15:30" in route checking page

Scenario: Verify the error message if only hour details provided in the scheduled departure time
	Then I have selected 'Flight' radio option
	Then I provide the 'AF296Q' in the box
	And I have provided Scheduled departure hour '11' in hours field only
	When I click save and continue button from route checker page
	Then I should see an error message "Enter the scheduled departure time, for example 15:30" in route checking page

Scenario: Verify sailing or flight option and no route options selected under that subheading by default
	Then I should see the subheading 'Are you checking a ferry or flight?' along with 2 route options
	And I should see no route options selected by default

Scenario: Verify the Ferry route subheading and no route options selected under Ferry by default
	Then I have selected 'Ferry' radio option
	And I should see the subheading 'Route' along with 3 route options
	And I should see no ferry route options selected by default

Scenario: Verify footer and back link in route checking page
	Then I should not see the footer of the page
	Then I should see back link in the top left of route checking page
	And I click back link
	And I should navigate to test environment prototype page

Scenario: Verify selected departure time displays in home page
	Then I have selected 'Flight' radio option
	Then I provide the 'AF296Q' in the box
	Then I have selected current date '-1' Date option
	And I have provided Scheduled departure time '18:30'
	When I click save and continue button from route checker page
	Then I should see departure date current date '-1' and time '18:30' on top of the home page

Scenario: Verify the scheduled departure date, date hint and current date pre-population
	Then I should see date subsection 'Scheduled departure date' with the current date pre-population
	And I should see hint 'For example, 27 3 2024' under the date subheading

Scenario: Verify the scheduled departure time and time hint
	Then I should see time subsection 'Scheduled departure time'
	And I should see hint 'Use the 24-hour clock - for example, 15:30.' under the time subheading

Scenario: Verify the error message if scheduled departure date and time is more than 48 hours ago
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	Then I have selected departure date as current date '-2' and departure time as current time to check '48HoursAgo'
	When I click save and continue button from route checker page
	Then I should see an error message "The flight or ferry must have departed in the past 48 hours or departs within the next 24 hours" in route checking page

Scenario: Verify the error message if scheduled departure date and time is after 24 hours from now
	Then I have selected 'Ferry' radio option
	And I select the 'Birkenhead to Belfast (Stena)' radio option
	Then I have selected departure date as current date '1' and departure time as current time to check 'After24Hours'
	When I click save and continue button from route checker page
	Then I should see an error message "The flight or ferry must have departed in the past 48 hours or departs within the next 24 hours" in route checking page
