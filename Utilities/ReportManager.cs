using Automation.StepDefinitions;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace Automation.Utilities
{
    public static class ReportManager
    {
        private static ExtentReports _extentReports;
        private static ExtentTest _test;
        private static ExtentHtmlReporter _htmlReporter;
        private static readonly string _reportDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}Reports";
        private static readonly string _reportPath = Path.Combine(_reportDirectory, "index.html");
        private static readonly string _logoPath = Path.Combine(_reportDirectory, "SoraUnion.png");
        private static ConfigReader appSettingsReader;

        public static void InitializeReport()
        {
            try
            {
                appSettingsReader = new ConfigReader();

                // Ensure Reports folder exists
                if (!Directory.Exists(_reportDirectory))
                {
                    Directory.CreateDirectory(_reportDirectory);
                }

                _htmlReporter = new ExtentHtmlReporter(_reportPath);
                _htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
                _htmlReporter.Config.DocumentTitle = "Sora Union - Automation Assignment";
                _htmlReporter.Config.ReportName = "Automation Assignment Test Report";

                _htmlReporter.Config.CSS = $@"
                    /* Hide default ExtentReports logo */
                    .logo-dark {{
                        display: none !important;
                    }}

                    /* Add custom Simah logo */
                    .nav-logo {{
                        background: url('{_logoPath.Replace("\\", "/")}') no-repeat center center !important;
                        background-size: contain !important;
                        height: 60px !important;
                    }}

                    /* Style the report header */
                    .report-name {{
                        background-color: #003366 !important; /* Dark Blue */
                        color: #FFFFFF !important; /* White */
                        font-family: Arial, sans-serif !important; 
                        font-size: 22px !important;
                        font-weight: bold;
                        text-align: left;
                        padding: 15px;
                    }}
                ";

                _htmlReporter.Config.JS = $@"
                    document.addEventListener('DOMContentLoaded', function() {{
                        // Remove default ExtentReports logo
                        let logoDiv = document.querySelector('.logo-dark');
                        if (logoDiv) {{
                            logoDiv.style.display = 'none';
                        }}

                        // Remove existing favicon(s)
                        let existingFavicons = document.querySelectorAll('link[rel~=""icon""]');
                        existingFavicons.forEach(fav => fav.parentNode.removeChild(fav));

                        // Add new favicon
                        let newFavicon = document.createElement('link');
                        newFavicon.rel = 'icon';
                        newFavicon.type = 'image/png';
                        newFavicon.href = '{_logoPath.Replace("\\", "/")}?v=' + new Date().getTime(); // Cache-busting
                        document.head.appendChild(newFavicon);
                    }});
                ";

                _extentReports = new ExtentReports();
                _extentReports.AttachReporter(_htmlReporter);
                _extentReports.AddSystemInfo("User Name", Environment.UserName);
                _extentReports.AddSystemInfo("Time Zone", TimeZoneInfo.Local.DisplayName);
                _extentReports.AddSystemInfo(".NET Version", Environment.Version.ToString());
                _extentReports.AddSystemInfo("Environment", appSettingsReader.GetSetting("ApplicationSettings:Environment"));
                _extentReports.AddSystemInfo("Browser", appSettingsReader.GetSetting("ApplicationSettings:Browser"));
                _extentReports.AddSystemInfo("Operating System", Environment.OSVersion.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing ExtentReports: {ex.Message}");
                throw;
            }
        }

        public static ExtentTest CreateTest(string testName)
        {
            _test = _extentReports.CreateTest(testName);
            return _test;
        }

        public static ExtentTest GetTest()
        {
            if (_test == null)
            {
                throw new InvalidOperationException("No test instance found. Ensure 'CreateTest()' is called before logging steps.");
            }
            return _test;
        }

        public static void FlushReport()
        {
            try
            {
                _extentReports.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error flushing ExtentReports: {ex.Message}");
            }
        }
    }
}
