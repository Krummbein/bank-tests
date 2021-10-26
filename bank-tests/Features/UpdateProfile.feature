Feature: UpdateProfile

@updatePositive
Scenario: Positive update check
	Given I have a registered user upd_pos_3 with password 123
	When I click Update Contact Info link
	And I fill in new information
	| field   | input      |
	| fname   | paul       |
	| lname   | mikj       |
	| address | somestreet |
	| city    | somecity   |
	| state   | somestate  |
	| zip     | somezip    |
	| phone   | 651641615  |
	And I click Update Profile button
	Then I should see an update confirmation message

@updateEmptyFirstName
Scenario: Negative update check - empty fname
	Given I have a registered user upd_neg_fname_3 with password 123
	When I click Update Contact Info link
	And I fill in new information
	| field   | input      |
	| fname   |            |
	| lname   | mikj       |
	| address | somestreet |
	| city    | somecity   |
	| state   | somestate  |
	| zip     | somezip    |
	| phone   | 651641615  |
	Then I should see a fnameErr error message

@updateEmptyZip
Scenario: Negative update check - empty zip
	Given I have a registered user upd_neg_zip_3 with password 123
	When I click Update Contact Info link
	And I fill in new information
	| field   | input      |
	| fname   | paul       |
	| lname   | mikj       |
	| address | somestreet |
	| city    | somecity   |
	| state   | somestate  |
	| zip     |            |
	| phone   | 651641615  |
	Then I should see a zipErr error message