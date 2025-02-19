using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Service.Options;
//using OpenQA.Selenium.Appium.Service.Driver;
using Newtonsoft.Json.Linq;
using Automation.Utilities;

public class ServiceFactory
{
    private static ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
    private static ServiceFactory? instance = null;
    private static ConfigReader _configuration = new ConfigReader();
    private static string? BROWSER = _configuration.GetSetting("ApplicationSettings:" + "Browser");

    public ServiceFactory() {
        //SetDriver(BROWSER);
    }

    public static ServiceFactory GetInstance()
    {
        if (instance == null)
        {
            instance = new ServiceFactory();
        }
        return instance;
    }

    public void setBrowser(string browser)
    {
        BROWSER = browser;
    }
    public static string GetBrowser()
    {
        if(BROWSER == null)
        {
            throw new InvalidOperationException("Browser is not Set. Please set the Browser before accessing it.");
        }
        return BROWSER;
    }
    public void SetDriver(string browser)
    {
        switch (browser.ToUpper())
        {
            case "FIREFOX":
                FirefoxOptions firefoxOptions = new FirefoxOptions();
                driver.Value = new FirefoxDriver(firefoxOptions);
                break;

            case "CHROME":
                ChromeOptions chromeOptions = ChromeOptionsDesktop();
                driver.Value = new ChromeDriver(chromeOptions);
                break;

            case "EDGE":
                EdgeOptions edgeOptions = new EdgeOptions();
                driver.Value = new EdgeDriver(edgeOptions);
                break;

            default:
                ChromeOptions defaultOptions = ChromeOptionsDesktop();
                driver.Value = new ChromeDriver(defaultOptions);
                break;
        }
    }

    public static IWebDriver GetDriver()
    {
        if (driver.Value == null)
        {
            throw new InvalidOperationException("WebDriver is not initialized. Please set the driver before accessing it.");
        }
        return driver.Value;
    }
    public ChromeOptions ChromeOptionsAndroidMobile()
    {
        ChromeOptions chromeOptions = new ChromeOptions();
        Dictionary<string, object> mobileEmulation = new Dictionary<string, object>();
        mobileEmulation.Add("deviceName", _configuration.GetSetting("DeviceSetting:" + "DeviceName"));

        chromeOptions.AddArguments("--disable-extensions", "--disable-popup-blocking", "--window-size=240,720");
        chromeOptions.AcceptInsecureCertificates = true;

        return chromeOptions;
    }

    public ChromeOptions ChromeOptionsDesktop()
    {
        ChromeOptions chromeOptions = new ChromeOptions();
        chromeOptions.AddArguments("start-maximized");
        chromeOptions.AcceptInsecureCertificates = true;

        return chromeOptions;
    }
    public static void QuitWebDriver()
    {
        if (driver.Value != null)
        {
            driver.Value.Quit();
            driver.Value.Dispose();
            driver.Value = null;
        }
    }
}
