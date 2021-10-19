Feature: Transaction

Scenario: Positive find transaction
	Given I have navigated to bank's login page
	And I have loged in as p with password 123
	When I click Find Transactions link
	And I enter <input> into <field>
	And I click <button> button
	Then I should see transaction results
	Then I should see <input> in transaction's <attribute>

	Examples: 
	| input      | field       | button       | attribute       |
	| 10-19-2021 | dateField   | dateButton   | dateAttribute   |
	| 100.00     | amountField | amountButton | amountAttribute |


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