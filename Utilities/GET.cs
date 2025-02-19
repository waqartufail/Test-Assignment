using AventStack.ExtentReports;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Reqnroll;

namespace Automation.Utilities
{
    public class GET : Utilities
    {
        private readonly ConfigReader _configuration;
        private readonly ApiHelper _apiHelper;
        private RestResponse _response;
        private string _baseURL = "BaseURL";
        public string LogMessage = string.Empty;
        public GET(ScenarioContext scenarioContext, ConfigReader configuration) {
            _configuration = configuration;
            if (scenarioContext.ContainsKey("ApiHelper"))
            {
                _apiHelper = (ApiHelper)scenarioContext["ApiHelper"];
                _baseURL = _configuration.GetEnvironmentSetting(_baseURL);
                _response = ApiResponseManager.Response;
            }
            else
            {
                throw new KeyNotFoundException("The ApiHelper was not found in the ScenarioContext. Ensure the BeforeScenario hook is executed properly.");
            }
        }
        

        public RestResponse sendGETRequest(string endPoint)
        {
            try
            {
                endPoint = endPoint.Replace(" ", "");
                endPoint = _baseURL + _configuration.GetSetting("APISettings:" + endPoint);
                _response = _apiHelper.SendRequest(endPoint, Method.Get);
                LogMessage = "User Sent Request on URL: <strong>" + endPoint + "</strong> </br>Method : <strong>GET </strong></br><strong>Response</strong> :</br>" + LogAPIResponse(_response);
                ScenarioDef.Log(Status.Pass, LogMessage);
                int statusCode = (int)_response.StatusCode;
                string statusCodeColor = (statusCode == 200 || statusCode == 201) ? "green" : "red";
                LogMessage = $"Status Code is <strong style='color:{statusCodeColor}'> {statusCode} : {_response.StatusCode} </strong>";
                ScenarioDef.Log(Status.Pass, LogMessage);
            }
            catch (Exception ex) 
            {
                LogMessage = "User Sent Request on URL: <strong>" + endPoint + "</strong> </br>Method : <strong>GET </strong></br><strong>Response</strong> :</br>" + LogAPIResponse(_response);
                ScenarioDef.Log(Status.Fail, LogMessage);
                int statusCode = (int)_response.StatusCode;
                string statusCodeColor = (statusCode == 200 || statusCode == 201) ? "green" : "red";
                LogMessage = $"Status Code is <strong style='color:{statusCodeColor}'> {statusCode} : {_response.StatusCode} </strong>";
                ScenarioDef.Log(Status.Fail, LogMessage);
            }

            
            return _response;
        }

        public bool verifyResponseValue(string expectedValue, RestResponse _response)
        {
            if (expectedValue == null)
            {
                Assert.Fail("Expected value cannot be null.");
            }

            Assert.IsNotNull(_response, "Response is null. Ensure API request was made successfully.");
            Assert.IsNotNull(_response.Content, "Response content is empty.");

            JObject jsonResponse = JObject.Parse(_response.Content.ToString());
            var matchingProperty = jsonResponse
                .Descendants()
                .OfType<JProperty>()
                .FirstOrDefault(p => string.Equals(p.Value.ToString(), expectedValue, StringComparison.OrdinalIgnoreCase));

            if (matchingProperty != null)
            {
                string key = matchingProperty.Name;
                LogMessage = $"Verified <strong>{{\"{key}\":\"{expectedValue}\"}}</strong> from the response";
                ScenarioDef.Log(Status.Pass, LogMessage);
                return true;
            }
            else
            {
                LogMessage = $"Value '{expectedValue}' not found in the response.";
                ScenarioDef.Log(Status.Fail, LogMessage);
                Assert.Fail(LogMessage);
                return false;
            }
        }

    }
}
