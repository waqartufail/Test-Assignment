﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:2.0.0.0
//      Reqnroll Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SoraUnion.Features.WebApplication
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Sora Union Test Assignment for Health Service")]
    [NUnit.Framework.FixtureLifeCycleAttribute(NUnit.Framework.LifeCycle.InstancePerTestCase)]
    public partial class SoraUnionTestAssignmentForHealthServiceFeature
    {
        
        private global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private static global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/WebApplication", "Sora Union Test Assignment for Health Service", "A short summary of the feature", global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
        
#line 1 "SoraUnionHealthService.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public static async System.Threading.Tasks.Task FeatureSetupAsync()
        {
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public static async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(featureHint: featureInfo);
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Equals(featureInfo) == false)))
            {
                await testRunner.OnFeatureEndAsync();
            }
            if ((testRunner.FeatureContext == null))
            {
                await testRunner.OnFeatureStartAsync(featureInfo);
            }
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
            global::Reqnroll.TestRunnerManager.ReleaseTestRunner(testRunner);
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        public virtual async System.Threading.Tasks.Task FeatureBackgroundAsync()
        {
#line 4
#line hidden
#line 5
await testRunner.GivenAsync("User Setup Web Browser Session", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User should be able to see Login error")]
        [NUnit.Framework.CategoryAttribute("Test")]
        [NUnit.Framework.CategoryAttribute("Login")]
        public async System.Threading.Tasks.Task UserShouldBeAbleToSeeLoginError()
        {
            string[] tagsOfScenario = new string[] {
                    "Test",
                    "Login"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("User should be able to see Login error", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 8
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 4
await this.FeatureBackgroundAsync();
#line hidden
#line 9
 await testRunner.GivenAsync("User Navigate to \"Health Service\" Application", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 10
 await testRunner.AndAsync("User Validate \"App Title\" Title", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 11
 await testRunner.AndAsync("User Click on \"Menu\" Button on \"Main\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 12
 await testRunner.AndAsync("User Click on \"Login\" Button on \"Main\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 13
 await testRunner.ThenAsync("User Verified \"Login Heading\" on \"Login\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 14
 await testRunner.AndAsync("User Click on \"Login\" Button on \"Login\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 15
 await testRunner.ThenAsync("User Verified \"Error\" on \"Login\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User should be able to Login successfully")]
        [NUnit.Framework.CategoryAttribute("Test")]
        [NUnit.Framework.CategoryAttribute("Login")]
        public async System.Threading.Tasks.Task UserShouldBeAbleToLoginSuccessfully()
        {
            string[] tagsOfScenario = new string[] {
                    "Test",
                    "Login"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("User should be able to Login successfully", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 18
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 4
await this.FeatureBackgroundAsync();
#line hidden
#line 19
 await testRunner.GivenAsync("User Navigate to \"Health Service\" Application", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 20
 await testRunner.AndAsync("User Validate \"App Title\" Title", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 21
 await testRunner.AndAsync("User Click on \"Menu\" Button on \"Main\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 22
 await testRunner.AndAsync("User Click on \"Login\" Button on \"Main\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 23
 await testRunner.ThenAsync("User Verified \"Login Heading\" on \"Login\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 24
 await testRunner.AndAsync("User Enter \"User Name\" in \"User Name Textbox\" Field on \"Login\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 25
 await testRunner.AndAsync("User Enter \"Password\" in \"Password Textbox\" Field on \"Login\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 26
 await testRunner.AndAsync("User Click on \"Login\" Button on \"Login\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 27
 await testRunner.ThenAsync("User Verified \"Appointment Heading\" on \"Appointment\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User should be able to Book Appointment")]
        [NUnit.Framework.CategoryAttribute("Test")]
        [NUnit.Framework.CategoryAttribute("BookAppointment")]
        public async System.Threading.Tasks.Task UserShouldBeAbleToBookAppointment()
        {
            string[] tagsOfScenario = new string[] {
                    "Test",
                    "BookAppointment"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("User should be able to Book Appointment", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 30
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 4
await this.FeatureBackgroundAsync();
#line hidden
#line 31
 await testRunner.GivenAsync("User Navigate to \"Health Service\" Application", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 32
 await testRunner.AndAsync("User Validate \"App Title\" Title", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 33
 await testRunner.AndAsync("User Click on \"Menu\" Button on \"Main\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 34
 await testRunner.AndAsync("User Click on \"Login\" Button on \"Main\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 35
 await testRunner.ThenAsync("User Verified \"Login Heading\" on \"Login\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 36
 await testRunner.AndAsync("User Enter \"User Name\" in \"User Name Textbox\" Field on \"Login\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 37
 await testRunner.AndAsync("User Enter \"Password\" in \"Password Textbox\" Field on \"Login\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 38
 await testRunner.AndAsync("User Click on \"Login\" Button on \"Login\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 39
 await testRunner.ThenAsync("User Verified \"Appointment Heading\" on \"Appointment\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 40
 await testRunner.AndAsync("User Select \"Tokyo\" from \"Facility\" on \"Appointment\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 41
 await testRunner.AndAsync("User Click on \"Medicare\" Button on \"Appointment\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 42
 await testRunner.AndAsync("User Enter \"Appointment Date\" in \"Visit Date\" Field on \"Appointment\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 43
 await testRunner.AndAsync("User Enter \"Comments\" in \"Comments\" Field on \"Appointment\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 44
 await testRunner.AndAsync("User Click on \"Book Appointment\" Button on \"Appointment\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 45
 await testRunner.ThenAsync("User Verified \"Appointment Confirmation\" on \"Appointment\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User should be able to Check an appointment history")]
        [NUnit.Framework.CategoryAttribute("Test")]
        [NUnit.Framework.CategoryAttribute("AppointmentHistory")]
        public async System.Threading.Tasks.Task UserShouldBeAbleToCheckAnAppointmentHistory()
        {
            string[] tagsOfScenario = new string[] {
                    "Test",
                    "AppointmentHistory"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("User should be able to Check an appointment history", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 48
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 4
await this.FeatureBackgroundAsync();
#line hidden
#line 49
 await testRunner.GivenAsync("User Navigate to \"Health Service\" Application", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 50
 await testRunner.AndAsync("User Validate \"App Title\" Title", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 51
 await testRunner.AndAsync("User Click on \"Menu\" Button on \"Main\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 52
 await testRunner.AndAsync("User Click on \"Login\" Button on \"Main\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 53
 await testRunner.ThenAsync("User Verified \"Login Heading\" on \"Login\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 54
 await testRunner.AndAsync("User Enter \"User Name\" in \"User Name Textbox\" Field on \"Login\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 55
 await testRunner.AndAsync("User Enter \"Password\" in \"Password Textbox\" Field on \"Login\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 56
 await testRunner.AndAsync("User Click on \"Login\" Button on \"Login\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 57
 await testRunner.ThenAsync("User Verified \"Appointment Heading\" on \"Appointment\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 58
 await testRunner.AndAsync("User Select \"Hongkong\" from \"Facility\" on \"Appointment\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 59
 await testRunner.AndAsync("User Click on \"Medicare\" Button on \"Appointment\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 60
 await testRunner.AndAsync("User Enter \"Appointment Date\" in \"Visit Date\" Field on \"Appointment\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 61
 await testRunner.AndAsync("User Enter \"Comments\" in \"Comments\" Field on \"Appointment\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 62
 await testRunner.AndAsync("User Click on \"Book Appointment\" Button on \"Appointment\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 63
 await testRunner.ThenAsync("User Verified \"Appointment Confirmation\" on \"Appointment\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 64
 await testRunner.AndAsync("User Click on \"Left Menu\" Button on \"Appointment\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 65
 await testRunner.AndAsync("User Click on \"History\" Button on \"Appointment\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 66
 await testRunner.ThenAsync("User Verified \"Submitted Hongkong Facility\" on \"Appointment\" Page", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
    }
}
#pragma warning restore
#endregion
