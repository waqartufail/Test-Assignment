using Automation.Drivers;
using Drelanium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Automation.Utilities
{
    public class ElementHelper
    {
        IWebDriver _driver;
        public static ConfigReader _configuration = new ConfigReader();
        public static int timeOut = Convert.ToInt32(_configuration.GetSetting("ApplicationSettings:" + "Timeout"));
        public string iframexpath;

        public ElementHelper(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebElement WaitForElementToBeVisible(By locator)
        {
            WebDriverWait _wait = new WebDriverWait(_driver, TimeUnit.Seconds(timeOut));
            return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
        public IWebElement WaitForElementToBeClickable(By locator)
        {
            WebDriverWait _wait = new WebDriverWait(_driver, TimeUnit.Seconds(timeOut));
            return _wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }
        public IWebElement WaitForElementToBeVisible(string locator)
        {
            return WaitForElementToBeVisible(GetLocator(locator));
        }
        public IWebElement WaitForElementToBeClickable(string locator)
        {
            return WaitForElementToBeClickable(GetLocator(locator));
        }
        public void WaitForPageToFinishLoading(IWebDriver driver, int timeOutInMilliSeconds, int pollingTimeInMilliSeconds)
        {
            Func<IWebDriver, bool> pageLoadCondition = webDriver =>
                ((IJavaScriptExecutor)webDriver).ExecuteScript("return document.readyState").ToString().Equals("complete");
            var wait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromMilliseconds(timeOutInMilliSeconds),
                PollingInterval = TimeSpan.FromMilliseconds(pollingTimeInMilliSeconds)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until(pageLoadCondition);
        }
        private By GetLocator(string locator)
        {
            if (locator.StartsWith("//") || locator.StartsWith("(//"))
            {
                return By.XPath(locator);
            }
            else if (locator.StartsWith("#"))
            {
                return By.CssSelector(locator);
            }
            else if (locator.Contains("="))
            {
                var parts = locator.Split('=');
                var type = parts[0].Trim().ToLower();
                var value = parts[1].Trim();

                return type switch
                {
                    "id" => By.Id(value),
                    "name" => By.Name(value),
                    "css" => By.CssSelector(value),
                    "xpath" => By.XPath(value),
                    _ => throw new ArgumentException($"Invalid locator type: {type}")
                };
            }
            else
            {
                return By.Id(locator);
            }
        }
        public IWebElement GetLoator(string locator)
        {
            IWebElement element = _driver.FindElement(GetLocator(locator));
            return element;
        }
        public IList<IWebElement> GetElements(string locator)
        {
            IList<IWebElement> elements = null;
            try
            {
                elements = _driver.FindElements(GetLocator(locator));
                return elements;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool iframeExistance(string locator)
        {
            try
            {
                iframexpath = "//iframe";
                List<IWebElement> iframes = _driver.FindElements(By.XPath(iframexpath)).ToList();
                return iframes.Count > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int GetElementList(string locator)
        {
            IList<IWebElement> elements = _driver.FindElements(GetLocator(locator));
            return elements.Count();
        }
    }
}
