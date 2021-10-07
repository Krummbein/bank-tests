Feature: Bank
	Simple bank resgistration check

@mytag
Scenario: Registration check
	Given I have navigated to main bank page
	When I click register link
	Then I can see registration button
	