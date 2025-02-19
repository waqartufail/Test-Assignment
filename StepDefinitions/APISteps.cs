using Automation.Utilities;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;

namespace Automation.StepDefinitions
{
    [Binding]
    public class APISteps : Utilities.Utilities
    {
        private readonly ConfigReader _configuration;
        private readonly ApiHelper _apiHelper;
        private RestResponse _response;
        public string LogMessage = string.Empty;
        private GET _getHTTPMethod;
        private readonly Reqnroll.ScenarioContext _scenarioContext;

        public APISteps(Reqnroll.ScenarioContext scenarioContext, ConfigReader configuration)
        {
            _scenarioContext = scenarioContext;
            _getHTTPMethod = new GET(scenarioContext,configuration);
        }

        [Given(@"Hit Get Request on ""(.*)""")]
        public void GivenHitGetRequestOn(string endPoint)
        {
            _response = _getHTTPMethod.sendGETRequest(endPoint);
        }

        [Then(@"Verify Response Status Code Should be ""(.*)""")]
        public void ThenVerifyResponseStatusCodeShouldBe(int statusCode)
        {
            Assert.AreEqual(statusCode, (int)_response.StatusCode);
        }

        [Then(@"Verify Response Should Contain ""(.*)""")]
        public void ThenVerifyResponseShouldContain(string expectedMessage)
        {
            if(_response.Content != null)
            {
                _getHTTPMethod.verifyResponseValue(expectedMessage,_response);
            }
        }

    }
}
