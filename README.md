# README #

### What is this repository for? ###
**Reqnroll** Project is an automated testing framework designed to streamline **API** and **UI** test execution using **SpecFlow**, **Selenium**, and **RestSharp**. It enables **BDD (Behavior-Driven Development)** by integrating with Gherkin syntax, allowing testers and developers to write human-readable test scenarios.

Key features:\
✅ **BDD** Support with SpecFlow\
✅ **API** Testing using RestSharp\
✅ **UI** Automation with Selenium\
✅ Custom **Reporting** and Logging

### How to write a UI Test? ###
* Create a new **.feature** file under `*\Sora Union\Features\WebApplication*` folder.
* This framework have Pre-defined steps for
> **Navigation**:\
>  User Navigate to "My Application" Application
- configure URL in `appsettings.json` file against each environment i.e: `QA/UAT/Production`.\
> [!NOTE]
> MyApplication should be available in `appsettings.json`

> **Enter Text in Text box**:\
>  User Enter "User Name" in "User Name Textbox" Field on "Login" Page 

create new `.json` file under `TestData` folder with the name of `Home.json`, with three main **attributes**:\
*TestData*,\
*Elements*\
*ExpectedData*\
create new `.cs` file under `Enums` folder with the name of `Home.cs`
> [!NOTE]
> **atrribute** : *TestData* to store test data\
Example:\
`"TestData": {"QA": {"UserName": "John Doe"},"UAT": {"UserName": "John Doe"},"Production": {"UserName": "John Doe"}`\
> **atrribute** : *Elements* to store locator's variable or name to utilize in *reporting*\
Example:\
`"Elements": { "UserNameTextbox": "XPATH_USER_NAME" }`\
> `XPATH_USER_NAME` should be declared under `Home.cs` against it's **XPATH**,\
i.e: **XPATH_USER_NAME = `//input[@id='username]`**
> **atrribute** : *ExpectedData* to store expected result for *assertions*\
Example:\
 `"ExpectedData": { "Error": "Login failed! Invalid user name or password." }`
  
> **Click on an Element**:\
>  User Click on "Login" Button on "Home" Page

> [!CAUTION]
> No need to create new `Home.json` file, just add `Login` button's variable, `i,e: XPATH_LOGIN` under *Elements* attribute.
- Add it's XPATH in `Home.cs`.

> **Assertion**:\
>  User Verified "Login Error" on "Home" Page

> [!CAUTION]
> No need to create new `Home.json` file, just
> add `LoginError` button's variable, `i,e: XPATH_LOGIN_ERROR` under *Elements* attribute.
> add `LoginError` expected message under *ExpectedData* attribute.
> add `XPATH_LOGIN_ERROR` in Enums `Home.cs` file with it's `XPATH` value.

### How to write API Test? ###
* Create a new **.feature** file under *\Sora Union\Features\API* folder.
> **GET**:\
> Hit Get Request on "Employee List"
- configure BaseURL in `appsettings.json` file against each environment i.e: `QA/UAT/Production`.\
- configure endpoint `EmployeeList` in `appsetiings.json` under **APISettings** attribute.\
  `"APISettings": {"EmployeeList": "api/v1/employees"}`
> Verify Response Should Contain "198500" 
- it will automatically verify the value `198500` in the response and print in report with it's attribute.\
  `i.e: {"employee_salary":"198500"}`

It simplifies automated testing, improves test maintainability, increases reusability on `.feature` level and enhances collaboration between teams. 🚀

## How to Execute ##
To execute the project, open Test Explorer
Right Click on desire test case and click on Run

## 📌 Prepared By ##
**👤 Name: Muhammad Waqar Tufail**\
**📧 Email: samar4250@gmail.com**\
**📞 Phone: (+92) 334-360 9679**\
**🔗 LinkedIn: waqar-tufail-a4bb90a8**

