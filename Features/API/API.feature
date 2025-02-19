Feature: API using Rest Sharp

A short summary of the feature

@API
Scenario: Verify that the employee “Michael Silva” has a salary of 198500
	Given Hit Get Request on "Employee List"
	Then Verify Response Status Code Should be "200"
	Then Verify Response Should Contain "198500" 

@API @TC1254
Scenario: Verify that the response and it's values are valid
	Given Hit Get Request on "Get Employee"
	Then Verify Response Status Code Should be "200"
	Then Verify Response Should Contain "5"
	Then Verify Response Should Contain "Airi Satou"
	Then Verify Response Should Contain "162700"
	Then Verify Response Should Contain "33"