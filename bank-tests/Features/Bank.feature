﻿Feature: Bank
	Simple bank resgistration check

# cookie needed
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
	Then I should see a registration confirmation message

	Examples:
	| fname | lname | address    | city     | state     | zip     | phone     | ssn    | username           | password |
	| paul  | mikj  | somestreet | somecity | somestate | somezip | 651641615 | 615651 | avlevovusssssssssss | 123123   |


Scenario: Negative registration check
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
	Then I should see an <error> message

	Examples:
	| fname | lname | address    | city     | state     | zip     | phone     | ssn    | username         | password | error      |
	| paul  | mikj  |            | somecity | somestate | somezip | 651641615 | 615651 | avlevovussssssss | 123123   | addressErr |
	| paul  |       | somestreet | somecity | somestate | somezip | 651641615 | 615651 | avlevovussssssss | 123123   | lnameErr   |
	
	# It is not safe to rely on empty strings. It has to be a way to specify such cases by "null" or smth.



# cookie needed
Scenario: Profile update check
	Given I have navigated to main bank page
	And I have loged in as <user> with <password>
	When I click Update contact info link
	And  I clear <field> and fill it with <new input>
	And I click Update profile button
	Then I should see the update confirmation message
	

	| user       | password | field | new input      |
	| paulisimus | 123      |       | newPhoneNumber |