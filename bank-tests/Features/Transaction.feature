Feature: Transaction

Scenario: Positive find transaction
	Given I have navigated to bank's login page
	And I have loged in as pavleus with password 123
	When I click Find Transactions link
	And I enter <input> into <field>
	And I click <button> button
	Then I should see transaction results

	Examples: 
	| input      | field       | button       |
	| 10-13-2021 | dateField   | dateButton   |
	| 100        | amountField | amountButton |


Scenario: Negative find transaction
	Given I have navigated to bank's login page
	And I have loged in as pavleus with password 123
	When I click Find Transactions link
	And I enter <input> into <field>
	And I click <button> button
	Then I should see error message

	Examples: 
	| input  | field       | button       |
	| asdasd | amountField | amountButton |
	| фыв    | amountField | amountButton |
	| *-_/   | amountField | amountButton |