using RestSharp;
using System;
using System.Net;

namespace Automation.Utilities
{
    public class ApiHelper
    {
        private readonly RestClient _client;

        public ApiHelper(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public RestResponse SendRequest(string resource, Method method, object body = null)
        {
            var request = new RestRequest(resource, method);

            request.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Accept-Language", "en-US,en;q=0.9,ur;q=0.8,ar;q=0.7");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("Host", "dummy.restapiexample.com");
            request.AddHeader("Upgrade-Insecure-Requests", "1");
            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/133.0.0.0 Safari/537.36");
            request.AddHeader("Cookie", "humans_21909=1");

            if (body != null)
            {
                request.AddJsonBody(body);
            }

            int maxRetries = 10;
            int retryCount = 0;
            RestResponse response;

            do
            {
                response = _client.Execute(request);
                int statusCode = (int)response.StatusCode;

                Console.WriteLine($"Attempt {retryCount + 1}: Status Code {statusCode}");

                if (statusCode == 200 || statusCode == 201)
                {
                    return response;
                }

                if (statusCode == 409 || statusCode == 429)
                {
                    retryCount++;
                    Thread.Sleep(2000);
                }
                else
                {
                    break;
                }

            } while (retryCount < maxRetries);

            throw new Exception($"Request to {resource} failed with status code {response.StatusCode} after {maxRetries} retries.");
        }

    }
}
