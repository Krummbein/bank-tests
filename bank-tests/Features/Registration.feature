Feature: Registration

# change nickname manually before running this case
Scenario: Registration check
	Given I have navigated to main bank page
	And I click register link
	When I enter the following information
	| field    | input       |
	| fname    | paul        |
	| lname    | mikj        |
	| address  | somestreet  |
	| city     | somecity    |
	| state    | somestate   |
	| zip      | somezip     |
	| phone    | 651641615   |
	| ssn      | 615651      |
	| username | avlevovuzzz |
	| password | 123123      |
	| confirm  | 123123      |
	And I click register button
	Then I should see a registration confirmation message



@checkEmptyAddress
Scenario: Negative reg check - empty address

	Given I have navigated to main bank page
	And I click register link
	When I enter the following information
	| field    | input      |
	| fname    | paul       |
	| lname    | mikj       |
	| address  |            |
	| city     | somecity   |
	| state    | somestate  |
	| zip      | somezip    |
	| phone    | 651641615  |
	| ssn      | 615651     |
	| username | avlevovuzz |
	| password | 123123     |
	| confirm  | 123123     |
	And I click register button
	Then I should see an addressErr message


@checkEmptyLastName
Scenario: Negative reg check - empty last name

	Given I have navigated to main bank page
	And I click register link
	When I enter the following information
	| field    | input       |
	| fname    | paul        |
	| lname    |             |
	| address  | someaddress |
	| city     | somecity    |
	| state    | somestate   |
	| zip      | somezip     |
	| phone    | 651641615   |
	| ssn      | 615651      |
	| username | avlevovuzz  |
	| password | 123123      |
	| confirm  | 123123      |
	And I click register button
	Then I should see an lnameErr message


 @checkEmptyCity
Scenario: Negative reg check - empty city

	Given I have navigated to main bank page
	And I click register link
	When I enter the following information
	| field    | input       |
	| fname    | paul        |
	| lname    | mikj        |
	| address  | someaddress |
	| city     |             |
	| state    | somestate   |
	| zip      | somezip     |
	| phone    | 651641615   |
	| ssn      | 615651      |
	| username | avlevovuzz  |
	| password | 123123      |
	| confirm  | 123123      |
	And I click register button
	Then I should see an cityErr message

	# It is not safe to rely on empty strings. It has to be a way to specify such cases by "null" or smth.