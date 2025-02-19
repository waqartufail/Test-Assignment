using Automation.Utilities;
using AventStack.ExtentReports;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace Automation.Pages
{
    public class CommonStepPage : Utilities.Utilities
    {
        public string LogMessage = string.Empty;
        public CommonStepPage()
        { }

        #region Enter Test Data into Field
        public string EnterData(string TestData, string Element, string Page, string Environment)
        {
            bool isPassword = false;
            bool isDateField = false;
            if (TestData.Contains("Passw"))
            {
                isPassword = true;
            }
            if (TestData.Contains("Date"))
            {
                isDateField = true;
            }
            try
            {
                if(TestData.Contains("Date"))
                {
                    TestData = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy");
                }
                else
                {
                    TestData = ReadTestData(Page, Environment, TestData);

                }
                Element = ReadElementData(Page, Element);
                string locator = LocatorXpath(Page, Element);
                waitForPageLoad();
                elementFactory.WaitForElementToBeVisible(locator);
                elementFactory.WaitForElementToBeClickable(locator);
                enterString(locator, TestData);
                if (isPassword) { TestData = "*****"; }
                if(isDateField) { pressKey(locator); }
                LogMessage = "User have entered <strong>" + TestData + "</strong> in " + getLocatorNameforLog(Element) + " field on " + Page + " page.";
                ScenarioDef.Log(Status.Pass, LogMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetBase64Screenshot()).Build());
                SwitchToDefault();
            }
            catch (Exception ex)
            {
                LogMessage = "User unable to enter <strong>" + TestData + "</strong> in " + getLocatorNameforLog(Element) + " field on " + Page + " page." + "<br><strong> Error:</strong> " + ex.Message + ".";
                ScenarioDef.Log(Status.Fail, LogMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetBase64Screenshot()).Build());
                throw;
            }
            return LogMessage;
        }
        #endregion

        #region Click on Button or Element
        public string ClickButton(string Element, string Page)
        {
            try
            {
                Element = ReadElementData(Page, Element);
                string locator = LocatorXpath(Page, Element);
                waitForPageLoad();
                elementFactory.WaitForElementToBeVisible(locator);
                elementFactory.WaitForElementToBeClickable(locator);
                click(locator);
                LogMessage = "User clicked on <strong>" + getLocatorNameforLog(Element) + "</strong> button on " + Page + " page.";
                ScenarioDef.Log(Status.Pass, LogMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetBase64Screenshot()).Build());
                SwitchToDefault();
            }
            catch
            {
                LogMessage = "User unable to click on <strong>" + getLocatorNameforLog(Element) + "</strong> field on " + Page + " page.";
                ScenarioDef.Log(Status.Fail, LogMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetBase64Screenshot()).Build());
            }
            return LogMessage;
        }
        #endregion

        #region Select Value from Dropdown
        public string SelectDropDownValue(string TestData, string Element, string Page, string Environment)
        {
            try
            {
                TestData = ReadTestData(Page, Environment, TestData);
                Element = ReadElementData(Page, Element);
                string locator = LocatorXpath(Page, Element);
                waitForPageLoad();
                elementFactory.WaitForElementToBeVisible(locator);
                elementFactory.WaitForElementToBeClickable(locator);
                selectString(TestData,locator);
                LogMessage = "User have selected <strong>" + TestData + "</strong> from " + getLocatorNameforLog(Element) + " field on " + Page + " page.";
                ScenarioDef.Log(Status.Pass, LogMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetBase64Screenshot()).Build());
                SwitchToDefault();
            }
            catch (Exception ex)
            {
                LogMessage = "User unable to select <strong>" + TestData + "</strong> from " + getLocatorNameforLog(Element) + " field on " + Page + " page." + "<br><strong> Error:</strong> " + ex.Message + ".";
                ScenarioDef.Log(Status.Fail, LogMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetBase64Screenshot()).Build());
                throw;
            }
            return LogMessage;
        }
        #endregion

        #region Verify Filed's Visibility and Text on Page
        public string VerifyDataOnPage(string Element, string Page)
        {
            string actualData = string.Empty;
            string ExpectedData = string.Empty;
            string ElementName = Element;
            try
            {
                ExpectedData = ReadExpectedData(Page, Element);
                Element = ReadElementData(Page, Element);
                string locator = LocatorXpath(Page, Element);
                waitForPageLoad();
                elementFactory.WaitForElementToBeVisible(locator);
                elementFactory.WaitForElementToBeClickable(locator);
                actualData = GetText(locator);
                if (ExpectedData.Equals(actualData))
                {
                    LogMessage = "User have verified the visibility and value of <strong>"+ElementName+"</strong><br> Expectd Data: <strong>" + ExpectedData + "</strong><br> Actual Data <strong>" + actualData + "</strong><br> on "+Page+" page.";
                    ScenarioDef.Log(Status.Pass, LogMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetBase64Screenshot()).Build());
                }
                Assert.AreEqual(ExpectedData, actualData);
                SwitchToDefault();
            }
            catch (Exception ex)
            {
                LogMessage = "User have verified the data missmatched.<br> Expectd Data: <strong>" + ExpectedData + "</strong><br> Actual Data <strong>" + actualData + "</strong><br> on " + Page + " page.";
                ScenarioDef.Log(Status.Fail, LogMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetBase64Screenshot()).Build());
            }
            return LogMessage;
        }
        #endregion

        #region Verify CSS Value of an Element
        public string VerifyCSSValueofElement(string CSSValue, string Element, string Page)
        {
            string actualCSSValue = string.Empty;
            string ExpectedCSSValue = string.Empty;
            string ElementName = Element;
            try
            {
                ExpectedCSSValue = ReadExpectedCSS(Page, CSSValue);
                Element = ReadElementData(Page, Element);
                string locator = LocatorXpath(Page, Element);
                waitForPageLoad();
                elementFactory.WaitForElementToBeVisible(locator);
                elementFactory.WaitForElementToBeClickable(locator);
                actualCSSValue = GetCssValue(locator, CSSValue);
                if (ExpectedCSSValue.Equals(actualCSSValue))
                {
                    LogMessage = "User have verified the CSS Value matched, <strong>"+CSSValue+ "</strong> of <strong>"+ ElementName + "</strong><br> Expectd Value: <strong>" +CSSValue+":"+ ExpectedCSSValue + "</strong><br> Actual Value <strong>" + CSSValue + ":" + actualCSSValue + "</strong><br> on " + Page + " page.";
                    ScenarioDef.Log(Status.Pass, LogMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetBase64Screenshot()).Build());
                }
                Assert.AreEqual(ExpectedCSSValue, actualCSSValue);
                SwitchToDefault();
            }
            catch (Exception ex) 
            {
                LogMessage = "User have verified the CSS Value missmatched, <strong>" + CSSValue + "</strong> of " + ElementName + "<br> Expectd Value: <strong>" + ExpectedCSSValue + "</strong><br> Actual Value <strong>" + actualCSSValue + "</strong><br> on " + Page + " page.";
                ScenarioDef.Log(Status.Fail, LogMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetBase64Screenshot()).Build());
            }
            return LogMessage;
        }
        #endregion

        #region Verify HTML Attribute Value of an Element
        public string VerifyAttributeValueofElement(string Attribute, string Element, string Page)
        {
            string actualAttributeValue = string.Empty;
            string ExpectedAttributeValue = string.Empty;
            string ElementName = Element;
            try
            {
                ExpectedAttributeValue = ReadExpectedCSS(Page, Attribute);
                Element = ReadElementData(Page, Element);
                string locator = LocatorXpath(Page, Element);
                waitForPageLoad();
                elementFactory.WaitForElementToBeVisible(locator);
                elementFactory.WaitForElementToBeClickable(locator);
                actualAttributeValue = GetAttribute(locator, Attribute);
                if (ExpectedAttributeValue.Equals(actualAttributeValue))
                {
                    LogMessage = "User have verified the CSS Value matched, <strong>" + Attribute + "</strong> of <strong>" + ElementName + "</strong><br> Expectd Value: <strong>" + Attribute + ":" 
                        + ExpectedAttributeValue + "</strong><br> Actual Value <strong>" + Attribute + ":" + actualAttributeValue + "</strong><br> on " + Page + " page.";
                    ScenarioDef.Log(Status.Pass, LogMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetBase64Screenshot()).Build());
                }
                Assert.AreEqual(ExpectedAttributeValue, actualAttributeValue);
                SwitchToDefault();
            }
            catch (Exception ex)
            {
                LogMessage = "User have verified the CSS Value missmatched, <strong>" + Attribute + "</strong> of " + ElementName + "<br> Expectd Value: <strong>" + ExpectedAttributeValue +
                    "</strong><br> Actual Value <strong>" + actualAttributeValue + "</strong><br> on " + Page + " page.";
                ScenarioDef.Log(Status.Fail, LogMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetBase64Screenshot()).Build());
            }
            return LogMessage;
        }
        #endregion
    }
}
