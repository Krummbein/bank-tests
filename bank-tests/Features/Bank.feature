Feature: Bank
	Simple bank resgistration check

Scenario: Registration check
	Given I have navigated to main bank page
	And I click register link
	When I enter <fname> in fname field
	And I enter <lname> in lname field
	And I enter <address> in address field
	And I enter <city> in city field
	And I enter <state> in state field
	And I enter <zip> in zip field
	And I enter <phone> in phone field
	And I enter <ssn> in ssn field
	And I enter <username> in username field
	And I enter <password> in password and confirm fields
	And I click register button
	Then I should see a confirmation message


	Examples:
	| fname | lname | address    | city     | state     | zip     | phone     | ssn    | username		| password |
	| paul  | mikj  | somestreet | somecity | somestate | somezip | 651641615 | 615651 | avlevovussssssss | 123123   |
