Feature: Sora Union Test Assignment for Health Service

A short summary of the feature
Background: 
Given User Setup Web Browser Session

@Test @Login
Scenario: User should be able to see Login error
	Given User Navigate to "Health Service" Application
	And User Validate "App Title" Title
	And User Click on "Menu" Button on "Main" Page 
	And User Click on "Login" Button on "Main" Page
	Then User Verified "Login Heading" on "Login" Page
	And User Click on "Login" Button on "Login" Page
	Then User Verified "Error" on "Login" Page

@Test @Login
Scenario: User should be able to Login successfully
	Given User Navigate to "Health Service" Application
	And User Validate "App Title" Title
	And User Click on "Menu" Button on "Main" Page 
	And User Click on "Login" Button on "Main" Page
	Then User Verified "Login Heading" on "Login" Page
	And User Enter "User Name" in "User Name Textbox" Field on "Login" Page
	And User Enter "Password" in "Password Textbox" Field on "Login" Page
	And User Click on "Login" Button on "Login" Page
	Then User Verified "Appointment Heading" on "Appointment" Page

@Test @BookAppointment
Scenario: User should be able to Book Appointment
	Given User Navigate to "Health Service" Application
	And User Validate "App Title" Title
	And User Click on "Menu" Button on "Main" Page 
	And User Click on "Login" Button on "Main" Page
	Then User Verified "Login Heading" on "Login" Page
	And User Enter "User Name" in "User Name Textbox" Field on "Login" Page
	And User Enter "Password" in "Password Textbox" Field on "Login" Page
	And User Click on "Login" Button on "Login" Page
	Then User Verified "Appointment Heading" on "Appointment" Page
	And User Select "Tokyo" from "Facility" on "Appointment" Page
	And User Click on "Medicare" Button on "Appointment" Page
	And User Enter "Appointment Date" in "Visit Date" Field on "Appointment" Page
	And User Enter "Comments" in "Comments" Field on "Appointment" Page
	And User Click on "Book Appointment" Button on "Appointment" Page
	Then User Verified "Appointment Confirmation" on "Appointment" Page

@Test @AppointmentHistory
Scenario: User should be able to Check an appointment history
	Given User Navigate to "Health Service" Application
	And User Validate "App Title" Title
	And User Click on "Menu" Button on "Main" Page 
	And User Click on "Login" Button on "Main" Page
	Then User Verified "Login Heading" on "Login" Page
	And User Enter "User Name" in "User Name Textbox" Field on "Login" Page
	And User Enter "Password" in "Password Textbox" Field on "Login" Page
	And User Click on "Login" Button on "Login" Page
	Then User Verified "Appointment Heading" on "Appointment" Page
	And User Select "Hongkong" from "Facility" on "Appointment" Page
	And User Click on "Medicare" Button on "Appointment" Page
	And User Enter "Appointment Date" in "Visit Date" Field on "Appointment" Page
	And User Enter "Comments" in "Comments" Field on "Appointment" Page
	And User Click on "Book Appointment" Button on "Appointment" Page
	Then User Verified "Appointment Confirmation" on "Appointment" Page
	And User Click on "Left Menu" Button on "Appointment" Page
	And User Click on "History" Button on "Appointment" Page
	Then User Verified "Submitted Hongkong Facility" on "Appointment" Page