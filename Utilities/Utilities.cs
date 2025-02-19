using Automation.Drivers;
using Drelanium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AventStack.ExtentReports;
using Reqnroll;
using Automation.Enums;
using Newtonsoft.Json.Linq;
using NUnit.Framework.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using OpenQA.Selenium.Support.UI;

namespace Automation.Utilities
{
    public class Utilities
    {
        public static ServiceFactory serviceFactoryInstance = ServiceFactory.GetInstance();
        protected static ElementHelper? elementFactory;
        
        public static string? deviceName;
        public static string ENumPackage = "Automation.Enums";
        public static bool iframeExists = false;
        public ExtentReports extent { get; set; } = new ExtentReports();
        public static string scenarioName;
        public static ExtentTest? ScenarioDef { get; protected set; }
        public static ExtentTest features;

        static Utilities()
        {
            var extentReports = new ExtentReports();
            features = extentReports.CreateTest("Feature Name");
        }
        public static string CreateVariable(string variableName)
        {
            return variableName = variableName.Replace(" ", "").Trim();
        }
        public static string ReadTestData(string fileName, string Env,string TestData)
        {
            string Data = string.Empty;
            try
            {
                JsonFileReader jsonReader = new JsonFileReader();
                JObject DataReader = jsonReader.ReadJsonFile(fileName);
                Data = DataReader["TestData"][Env][CreateVariable(TestData)].ToString();
            }
            catch (Exception ex) 
            {string customMessage = $"Please check your file {fileName}..json No data found against {TestData}."; throw new Exception(customMessage, ex); }
            return Data;
        }
        public static string ReadElementData(string fileName, string TestData)
        {
            JsonFileReader jsonReader = new JsonFileReader();
            JObject DataReader = jsonReader.ReadJsonFile(fileName);
            string Data = DataReader["Elements"][CreateVariable(TestData)].ToString();
            return Data;
        }
        public static string ReadExpectedData(string fileName, string TestData)
        {
            JsonFileReader jsonReader = new JsonFileReader();
            JObject DataReader = jsonReader.ReadJsonFile(fileName);
            string Data = DataReader["ExpectedData"][CreateVariable(TestData)].ToString();
            return Data;
        }
        public static string ReadExpectedCSS(string fileName, string TestData)
        {
            JsonFileReader jsonReader = new JsonFileReader();
            JObject DataReader = jsonReader.ReadJsonFile(fileName);
            string Data = DataReader["CSS"][CreateVariable(TestData)].ToString();
            return Data;
        }
        public void SwitchToDefault()
        {
            if (iframeExists == true)
            {
                ServiceFactory.GetDriver().SwitchTo().DefaultContent();
                iframeExists = false;
            }
        }
        public static void ScrollToElement(IWebElement element)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)ServiceFactory.GetDriver();
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            System.Threading.Thread.Sleep(500);
        }
        protected void click(string locator)
        {
            try
            {
                if(elementFactory.iframeExistance("iframe"))
                {
                    CheckForIFrame("iframe",locator);
                }
                IWebElement element = elementFactory.GetLoator(locator);
                ScrollToElement(element);
                element.Click();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        protected void checkBox(string locator)
        {
            if (elementFactory.iframeExistance("iframe"))
            {
                CheckForIFrame("iframe", locator);
            }
            try
            {
                IWebElement element = elementFactory.GetLoator(locator);
                ScrollToElement(element);
                if(!element.Selected)
                {
                    element.Click();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        protected void enterString(string locator, string fieldValue)
        {
            if (elementFactory.iframeExistance("iframe"))
            {
                CheckForIFrame("iframe", locator);
            }
            try
            {
                IWebElement element = elementFactory.GetLoator(locator);
                ScrollToElement(element);
                enterString(element, fieldValue);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private void enterString(IWebElement element, string fieldValue)
        {
            ScrollToElement(element);
            element.SendKeys(fieldValue);
        }
        protected void hitEnter(IWebElement element)
        {
            ScrollToElement(element);
            element.SendKeys(Keys.Tab);
        }
        protected void pressKey(string locator)
        {
            IWebElement element = elementFactory.GetLoator(locator);
            ScrollToElement(element);
            hitEnter(element);
        }
        protected void selectString(string fieldValue, string locator)
        {
            if (elementFactory.iframeExistance("iframe"))
            {
                CheckForIFrame("iframe", locator);
            }
            try
            {
                IWebElement element = elementFactory.GetLoator(locator);
                ScrollToElement(element);
                selectString(element, fieldValue);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private void selectString(IWebElement element, string fieldValue)
        {
            ScrollToElement(element);
            SelectElement dropdown = new SelectElement(element);
            dropdown.SelectByValue(fieldValue);
        }
        protected void hover(IWebElement element)
        {
            ScrollToElement(element);
            Actions action = new Actions(ServiceFactory.GetDriver());
            action.MoveToElement(element).Perform();
        }
        public static bool isVisible(string locator)
        {
            if (elementFactory.iframeExistance("iframe"))
            {
                CheckForIFrame("iframe", locator);
            }
            int size = elementFactory.GetElementList(locator);
            if (size > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected string GetText(string locator)
        {
            if (elementFactory.iframeExistance("iframe"))
            {
                CheckForIFrame("iframe", locator);
            }
            IWebElement element = elementFactory.GetLoator(locator);
            string actulValue = element.Text;
            return actulValue;
        }
        protected string GetAttribute(string locator, string attribute)
        {
            if (elementFactory.iframeExistance("iframe"))
            {
                CheckForIFrame("iframe", locator);
            }
            IWebElement element = elementFactory.GetLoator(locator);
            string actualattributeValue = element.GetAttribute(attribute);
            return actualattributeValue;
        }
        protected string GetCssValue(string locator, string attribute)
        {
            if (elementFactory.iframeExistance("iframe"))
            {
                CheckForIFrame("iframe", locator);
            }
            IWebElement element = elementFactory.GetLoator(locator);
            string actualattributeValue = element.GetCssValue(attribute);
            return actualattributeValue;
        }
        protected void waitForPageLoad()
        {
            if (deviceName.Equals("WEB"))
            {
                elementFactory.WaitForPageToFinishLoading(ServiceFactory.GetDriver(), 10000, 500);
            }
        }
        private static string CapitalizeFully(string input)
        {
            var words = input.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                {
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                }
            }
            return string.Join(" ", words);
        }
        public static string getLocatorNameforLog(string Locator)
        {
            Locator = Locator.Replace("XPATH_", "").Replace("_", " ");
            Locator = CapitalizeFully(Locator);
            return Locator;
        }
        public int GetRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public static string LocatorXpath(string enumClassName, string locator)
        {
            string methodName = "GetValue";
            string extension = "Automation.Enums." + enumClassName.Replace(" ", "") + "Extensions";
            Type extensionsType = Type.GetType(extension);
            string xpath = string.Empty;

            if (extensionsType == null)
            {
                throw new ArgumentException($"Extension type {extension} not found.");
            }

            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            string fullyQualifiedName = $"{ENumPackage}.{enumClassName}";
            Type enumType = currentAssembly.GetType(fullyQualifiedName);

            if (enumType == null)
            {
                throw new ArgumentException($"Enum type {enumClassName} not found.");
            }

            foreach (var enumValue in Enum.GetValues(enumType))
            {
                try
                {
                    MethodInfo method = extensionsType.GetMethod(methodName, BindingFlags.Static | BindingFlags.Public);
                    if (method == null)
                    {
                        throw new Exception($"Method '{methodName}' not found in the enum extensions.");
                    }

                    string currentLocator = enumValue.ToString();
                    string currentXPath = method.Invoke(null, new object[] { enumValue })?.ToString();
                    if (currentLocator.Equals(locator, StringComparison.OrdinalIgnoreCase))
                    {
                        xpath = currentXPath;
                        break;
                    }
                }
                catch (TargetInvocationException ex)
                {
                    Console.WriteLine($"Could not invoke method: {ex.InnerException?.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            return xpath;
        }
        public static void CheckForIFrame(string frame, string locator)
        {
            try
            {
                iframeExists = elementFactory.iframeExistance(frame);
                if (iframeExists)
                {
                    List<IWebElement> list = (List<IWebElement>)elementFactory.GetElements(elementFactory.iframexpath);
                    for (int i = 0; i < list.Count; i++)
                    {
                        DriverFactory.GetDriver(deviceName).SwitchTo().Frame(i);
                        if (elementFactory.GetLoator(locator).Displayed)
                        {
                            elementFactory.WaitForElementToBeVisible(locator);
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw; // Re-throw the exception
            }
        }
        public static string GetBase64Screenshot()
        {
            string base64StringOfScreenshot = string.Empty;
            string screenshotFolder = $"{AppDomain.CurrentDomain.BaseDirectory}Reports\\Screenshots\\";
            string datePart = DateTime.Now.ToString("MMMM_dd", CultureInfo.InvariantCulture);
            string timePart = DateTime.Now.ToString("__HH_mm_ss", CultureInfo.InvariantCulture);
            ITakesScreenshot ts = null;
            if (deviceName.Equals("ANDROID", StringComparison.OrdinalIgnoreCase) ||
                deviceName.Equals("WINDOWS", StringComparison.OrdinalIgnoreCase) ||
                deviceName.Equals("WEB", StringComparison.OrdinalIgnoreCase))
            {
                ts = (ITakesScreenshot)ServiceFactory.GetDriver();
            }
            if (ts != null)
            {
                if (!Directory.Exists(screenshotFolder+datePart))
                {
                    Directory.CreateDirectory(screenshotFolder + datePart);
                }
                Screenshot screenshot = ts.GetScreenshot();
                string dest = Path.Combine(screenshotFolder, datePart, timePart + ".png");
                screenshot.SaveAsFile(dest, ScreenshotImageFormat.Png);
                byte[] fileContent = File.ReadAllBytes(dest);
                base64StringOfScreenshot = Convert.ToBase64String(fileContent);
            }
            return base64StringOfScreenshot;
        }
        public string LogAPIResponse(RestResponse response)
        {
            if (response == null || string.IsNullOrEmpty(response.Content))
            {
                return "Response is empty or null.";
            }
            string formattedJson;
            try
            {
                var parsedJson = JToken.Parse(response.Content);
                formattedJson = parsedJson.ToString(Formatting.Indented);
            }
            catch (JsonReaderException)
            {
                formattedJson = response.Content;
            }
            return $"<pre>{WebUtility.HtmlEncode(formattedJson)}</pre>";
        }
    }
}
