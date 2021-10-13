Feature: Registration

# change nickname manually before running this case
 @registrationPositive
Scenario: Registration check
	Given I have navigated to bank's login page
	And I click register link
	When I enter the following information
	| field    | input          |
	| fname    | paul           |
	| lname    | mikj           |
	| address  | somestreet     |
	| city     | somecity       |
	| state    | somestate      |
	| zip      | somezip        |
	| phone    | 651641615      |
	| ssn      | 615651         |
	| username | avlevovuzzzzzz |
	| password | 123123         |
	| confirm  | 123123         |
	And I click register button
	Then I should see a registration confirmation message

@registrationEmptyAddress
Scenario: Negative reg check - empty address

	Given I have navigated to bank's login page
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
	Then I should see an addressErr error message

@registrationEmptyLastName
Scenario: Negative reg check - empty last name

	Given I have navigated to bank's login page
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
	Then I should see an lnameErr error message

 @registrationEmptyCity
Scenario: Negative reg check - empty city

	Given I have navigated to bank's login page
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
	Then I should see an cityErr error message

# It is not safe to rely on empty strings. It has to be a way to specify such cases by "null" or smth.