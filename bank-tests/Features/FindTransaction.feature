Feature: FindTransaction

# CHANGE THE DATE MANUALLY

Scenario: Positive find transaction - manual
	Given I have navigated to bank's login page
	And I have loged in as p with password 123
	When I click Find Transactions link
	And I enter <input> into <field>
	And I click Find Transaction button for <field> field
	Then the page with results should open
	And I should see transactions with <input> from the <field>

	Examples: 
	| input      | field        |
	| 100        | FindByAmount |
	| 10-26-2021 | FindByDate   |

Scenario: Positive find transaction - auto new user
	Given I have a registered user trans_pos_new_user_2 with password 123
	And I have transfered <input> funds
	When I click Find Transactions link
	And I enter <input> into <field>
	And I click Find Transaction button for <field> field
	Then the page with results should open
	And I should see transactions with <input> from the <field>

	Examples: 
	| input | field        |
	| 100   | FindByAmount |
	


Scenario: Negative find transaction
	Given I have navigated to bank's login page
	And I have loged in as p with password 123
	When I click Find Transactions link
	And I enter <input> into <field>
	And I click Find Transaction button for <field> field
	Then I should see error message

	Examples: 
	| input  | field        |
	| asdasd | FindByAmount |
	| фыв    | FindByAmount |
	| *-_/   | FindByAmount |