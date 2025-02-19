using AventStack.ExtentReports;
using NUnit.Framework;
using Automation.Utilities;
using NUnit.Framework.Interfaces;

namespace Automation.Tests
{
    public class BaseTest
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            ReportManager.InitializeReport();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ReportManager.FlushReport();
        }

        [SetUp]
        public void Setup()
        {
            ReportManager.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var test = ReportManager.GetTest();

            switch (status)
            {
                case TestStatus.Failed:
                    test.Fail(TestContext.CurrentContext.Result.Message);
                    break;
                case TestStatus.Skipped:
                    test.Skip(TestContext.CurrentContext.Result.Message);
                    break;
                default:
                    test.Pass("Test passed");
                    break;
            }
        }
    }
}
