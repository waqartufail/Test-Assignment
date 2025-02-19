using Automation.Drivers;
using Automation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using AventStack.ExtentReports;
using Automation.Pages;
using System.Security.Policy;
using NUnit.Framework.Interfaces;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace Automation.StepDefinitions
{
    [Binding]
    public class CommonSteps : Utilities.Utilities
    {
        #region Variables || Constructors
        private readonly ScenarioContext _scenarioContext;
        private CommonStepPage _commonStepPage;
        private readonly ConfigReader appSettingsReader;
        public string LogMessage;
        public string AppSetting = "appsettings.json";
        public static string Environment = string.Empty;
        public JsonFileReader jsonReader = new JsonFileReader();
        public JObject? appSetting;
        #endregion

        #region Page Load
        public CommonSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            appSettingsReader = new ConfigReader();
            _commonStepPage = new CommonStepPage();
            Environment = appSettingsReader.GetSetting("ApplicationSettings:" + "Environment");
        }
        #endregion

        #region Step Definations
        [Given(@"User Setup Web Browser Session")]
        public void GivenUserSetupWebBrowserSession()
        {
            string browser = appSettingsReader.GetSetting("ApplicationSettings:" + "Browser");
            serviceFactoryInstance.SetDriver(browser);
            deviceName = "WEB";
            elementFactory = new ElementHelper(ServiceFactory.GetDriver());
        }

        [Given(@"User Navigate to ""(.*)"" Application")]
        public void GivenUserNavigateToApplication(string applicationURL)
        {
            string AppName = applicationURL;
            try
            {
                applicationURL = appSettingsReader.GetSetting("ApplicationSettings:" + Environment + ":" + applicationURL);
                ServiceFactory.GetDriver().Navigate().GoToUrl(applicationURL);
                LogMessage = "User successfully navigated to <strong>" + AppName + "</strong>.<br>Environment: <strong>" + Environment + "</strong><br>URL: <strong>" + applicationURL + "</strong>.";
                ScenarioDef.Log(Status.Pass, LogMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetBase64Screenshot()).Build());
            }
            catch (Exception ex)
            {
                LogMessage = "User unable to navigated to <strong>" + AppName + "</strong><br> Error:" + ex.Message + ".";
                ScenarioDef.Log(Status.Fail, LogMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetBase64Screenshot()).Build());
                throw;
            }
        }

        [Given(@"User Validate ""(.*)"" Title")]
        public void GivenUserValidateTitle(string title)
        {
            string Title = title;
            try
            {
                string actualTitle = ServiceFactory.GetDriver().Title;
                title = appSettingsReader.GetSetting("ExpectedValues:" + title);
                if (actualTitle.Equals(title))
                {
                    Assert.True(actualTitle.Equals(title));
                    LogMessage = "User successfully validated title.<br>Expected Title: <strong>" + title + "</strong>.<br>Actual Title: <strong>" + actualTitle + "</strong>.";
                    ScenarioDef.Log(Status.Pass, LogMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetBase64Screenshot()).Build());
                }
                else
                {
                    Assert.True(actualTitle.Equals(title));
                    LogMessage = "User validated title which not matched.<br>Expected Title: <strong>" + title + "</strong>.<br>Actual Title: <strong>" + actualTitle + "</strong>.";
                    ScenarioDef.Log(Status.Fail, LogMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetBase64Screenshot()).Build());
                }
            }
            catch (Exception ex)
            {
                LogMessage = "User unable to validate title <strong>" + Title + "</strong><br> Error:" + ex.Message + ".";
                ScenarioDef.Log(Status.Fail, LogMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetBase64Screenshot()).Build());
                throw;
            }
        }

        [Given(@"User Enter ""(.*)"" in ""(.*)"" Field on ""(.*)"" Page")]
        [When(@"User Enter ""(.*)"" in ""(.*)"" Field on ""(.*)"" Page")]
        [Then(@"User Enter ""(.*)"" in ""(.*)"" Field on ""(.*)"" Page")]
        public void UserEnterInFieldOnPage(string TestData, string Element, string Page)
        {
            try
            {
                LogMessage = _commonStepPage.EnterData(TestData, Element, Page, Environment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Given(@"User Click on ""(.*)"" Button on ""(.*)"" Page")]
        [When(@"User Click on ""(.*)"" Button on ""(.*)"" Page")]
        [Then(@"User Click on ""(.*)"" Button on ""(.*)"" Page")]
        public void ClickOnButton(string Element, string Page)
        {
            try
            {
                LogMessage = _commonStepPage.ClickButton(Element, Page);
            }
            catch (Exception ex)
            {
                LogMessage = "User unable to click on <strong>" + Element + "</strong> on " + Page + ".< br> Error:" + ex.Message + ".";
                ScenarioDef.Log(Status.Fail, LogMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetBase64Screenshot()).Build());
                throw;
            }
        }

        [Given("User Select {string} from {string} on {string} Page")]
        [When("User Select {string} from {string} on {string} Page")]
        [Then("User Select {string} from {string} on {string} Page")]
        public void UserSelectFromOnPage(string TestData, string Element, string Page)
        {
            try
            {
                LogMessage = _commonStepPage.SelectDropDownValue(TestData, Element, Page, Environment);
            }
            catch (Exception ex)
            {
                LogMessage = "User unable to click on <strong>" + Element + "</strong> on " + Page + ".< br> Error:" + ex.Message + ".";
                ScenarioDef.Log(Status.Fail, LogMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetBase64Screenshot()).Build());
                throw;
            }
        }


        [Given(@"User Verified ""(.*)"" on ""(.*)"" Page")]
        [When(@"User Verified ""(.*)"" on ""(.*)"" Page")]
        [Then(@"User Verified ""(.*)"" on ""(.*)"" Page")]
        public void UserVerifiedOnPage(string ExpectedElement, string Page)
        {
            try
            {
                LogMessage = _commonStepPage.VerifyDataOnPage(ExpectedElement, Page);
            }
            catch (Exception ex)
            {
                LogMessage = "User unable to Verify on <strong>" + ExpectedElement + "</strong> on " + Page + ".< br> Error:" + ex.Message + ".";
                ScenarioDef.Log(Status.Fail, LogMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetBase64Screenshot()).Build());
                throw;
            }
        }

        [Then(@"User Verified CSS Style ""(.*)"" of ""(.*)"" on ""(.*)"" Page")]
        public void ThenUserVerifiedCSSStyleOfOnPage(string CSSValue, string Element, string Page)
        {
            try
            {
                LogMessage = _commonStepPage.VerifyCSSValueofElement(CSSValue, Element, Page);
            }
            catch (Exception ex)
            {
                LogMessage = "User unable to Verify CSS Vlaue of <strong>" + CSSValue + "</strong> against " + Element + " on " + Page + ".< br> Error:" + ex.Message + ".";
                ScenarioDef.Log(Status.Fail, LogMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetBase64Screenshot()).Build());
                throw;
            }
        }

        [Then(@"User Verified Attribute ""(.*)"" Value of ""(.*)"" on ""(.*)"" Page")]
        public void ThenUserVerifiedAttributeValueOfOnPage(string AttributeValue, string Element, string Page)
        {
            try
            {
                LogMessage = _commonStepPage.VerifyAttributeValueofElement(AttributeValue, Element, Page);
            }
            catch (Exception ex)
            {
                LogMessage = "User unable to Verify Attribute Vlaue of <strong>" + AttributeValue + "</strong> against " + Element + " on " + Page + ".< br> Error:" + ex.Message + ".";
                ScenarioDef.Log(Status.Fail, LogMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetBase64Screenshot()).Build());
                throw;
            }
        }
        #endregion
    }
}
