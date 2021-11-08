Feature: Overview
	
Scenario: Positive Overview
	Given I have a registered user ov_pos_21 with password 123
	And I have created second account on this user
	And I have navigated to Transfer Page
	When I transfer 100 from the first account to the second
	And I navigate to Overview Page
	Then I should see $100.00 on the second account
	When I navigate to Find Transaction Page
	And I enter 100 into FindByAmount field
	And I click Find Transaction button for FindByAmount field
	Then the page with results should open
	And I should see transactions with 100 from the FindByAmount

# 18-19 replace 4-8
Scenario: Positive Overview 2
	Given I have navigated to bank's login page
	And I have loged in as p with password 123
	Then I should see $100.00 on the second account
	When I navigate to Find Transaction Page
	And I enter 100 into FindByAmount field
	And I click Find Transaction button for FindByAmount field
	Then the page with results should open
	And I should see transactions with 100 from the FindByAmount