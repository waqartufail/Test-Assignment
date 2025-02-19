using Automation.Drivers;
using OpenQA.Selenium;
using Reqnroll;
using AventStack.ExtentReports;
using Automation.Utilities;

namespace Automation.Hooks
{
    [Binding]
    public class Hooks : Utilities.Utilities
    {
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ReportManager.InitializeReport();
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext, ConfigReader configReader)
        {
            var scenarioName = scenarioContext.ScenarioInfo.Title;
            ScenarioDef =  ReportManager.CreateTest(scenarioName);

            string baseUrl = configReader.GetEnvironmentSetting("BaseURL");
            var apiHelper = new ApiHelper(baseUrl);

            scenarioContext["ApiHelper"] = apiHelper;
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            var scenarioTitle = scenarioContext.ScenarioInfo.Title;
            var test = ReportManager.GetTest();
            ServiceFactory.QuitWebDriver();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ReportManager.FlushReport();
        }
    }
}
