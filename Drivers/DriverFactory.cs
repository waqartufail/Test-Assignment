using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Safari;
using System;
using System.Diagnostics;

namespace Automation.Drivers
{
    public class DriverFactory
    {
        public static IWebDriver Driver { get; private set; }

        public static IWebDriver GetDriver(string browserName)
        {
            Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");
            foreach (var process in chromeDriverProcesses)
            {
                try
                {
                    process.Kill();
                    process.WaitForExit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error killing ChromeDriver instance: {ex.Message}");
                }
            }

            if (Driver == null)
            {
                switch (browserName.ToLower())
                {
                    case "chrome":
                        Driver = new ChromeDriver();
                        break;
                    case "firefox":
                        Driver = new FirefoxDriver();
                        break;
                    case "edge":
                        Driver = new EdgeDriver();
                        break;
                    case "safari":
                        Driver = new SafariDriver();
                        break;
                    default:
                        throw new ArgumentException($"Browser not supported: {browserName}");
                }

                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(5);
                Driver.Manage().Window.Maximize();
            }

            return Driver;
        }

        // Method to quit WebDriver
        public static void QuitWebDriver()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver = null;  // Ensuring the WebDriver instance is set to null after quitting
            }
        }
    }
}
