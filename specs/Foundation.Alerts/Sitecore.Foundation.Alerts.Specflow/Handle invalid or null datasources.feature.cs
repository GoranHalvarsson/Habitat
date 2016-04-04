﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.0.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Sitecore.Foundation.Alerts.Specflow
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class HandleInvalidOrNullDatasourcesFeature : Xunit.IClassFixture<HandleInvalidOrNullDatasourcesFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Handle invalid or null datasources.feature"
#line hidden
        
        public HandleInvalidOrNullDatasourcesFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Handle invalid or null datasources", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void SetFixture(HandleInvalidOrNullDatasourcesFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Handle invalid or null datasources")]
        [Xunit.TraitAttribute("Description", "Handle invalid or null datasources_UC1_Experince editor view_Invalid datasource")]
        [Xunit.TraitAttribute("Category", "NeedImplementation")]
        public virtual void HandleInvalidOrNullDatasources_UC1_ExperinceEditorView_InvalidDatasource()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Handle invalid or null datasources_UC1_Experince editor view_Invalid datasource", new string[] {
                        "NeedImplementation"});
#line 5
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "ItemPath",
                        "ControlName",
                        "Data Source"});
            table1.AddRow(new string[] {
                        "/sitecore/content/Habitat/Home",
                        "Carousel",
                        "Leeds United"});
#line 6
 testRunner.Given("Datasource is defined for the Control", ((string)(null)), table1, "Given ");
#line 9
 testRunner.When("Habitat website is opened on Main Page in Edit mode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Alert message"});
            table2.AddRow(new string[] {
                        "Data source isn\'t set or have wrong template. Template {AE4635AF-CFBF-4BF6-9B50-0" +
                            "0BE23A910C0} is required"});
#line 10
 testRunner.Then("Alert message is shown for item", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Handle invalid or null datasources")]
        [Xunit.TraitAttribute("Description", "Handle invalid or null datasources_UC2_Normal mode_Invalid datasource")]
        [Xunit.TraitAttribute("Category", "NeedImplementation")]
        public virtual void HandleInvalidOrNullDatasources_UC2_NormalMode_InvalidDatasource()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Handle invalid or null datasources_UC2_Normal mode_Invalid datasource", new string[] {
                        "NeedImplementation"});
#line 17
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "ItemPath",
                        "ControlName",
                        "Data Source"});
            table3.AddRow(new string[] {
                        "/sitecore/content/Habitat/Home",
                        "Carousel",
                        "Leeds United"});
#line 18
 testRunner.Given("Datasource is defined for the Control", ((string)(null)), table3, "Given ");
#line 21
 testRunner.When("Habitat website is opened on Main Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
 testRunner.Then("Item element absents on page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Handle invalid or null datasources")]
        [Xunit.TraitAttribute("Description", "Handle invalid or null datasources_UC3_Experince editor view_null datasource")]
        [Xunit.TraitAttribute("Category", "NeedImplementation")]
        public virtual void HandleInvalidOrNullDatasources_UC3_ExperinceEditorView_NullDatasource()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Handle invalid or null datasources_UC3_Experince editor view_null datasource", new string[] {
                        "NeedImplementation"});
#line 26
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "ItemPath",
                        "ControlName",
                        "Data Source"});
            table4.AddRow(new string[] {
                        "/sitecore/content/Habitat/Home",
                        "Carousel",
                        ""});
#line 27
 testRunner.Given("Datasource is defined for the Control", ((string)(null)), table4, "Given ");
#line 30
 testRunner.When("Habitat website is opened on Main Page in Edit mode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Alert message"});
            table5.AddRow(new string[] {
                        "Data source isn\'t set or have wrong template. Template {AE4635AF-CFBF-4BF6-9B50-0" +
                            "0BE23A910C0} is required"});
#line 31
 testRunner.Then("Alert message is shown for item", ((string)(null)), table5, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Handle invalid or null datasources")]
        [Xunit.TraitAttribute("Description", "Handle invalid or null datasources_UC4_Normal mode_null datasource")]
        [Xunit.TraitAttribute("Category", "NeedImplementation")]
        public virtual void HandleInvalidOrNullDatasources_UC4_NormalMode_NullDatasource()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Handle invalid or null datasources_UC4_Normal mode_null datasource", new string[] {
                        "NeedImplementation"});
#line 38
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "ItemPath",
                        "ControlName",
                        "Data Source"});
            table6.AddRow(new string[] {
                        "/sitecore/content/Habitat/Home",
                        "Carousel",
                        ""});
#line 39
 testRunner.Given("Datasource is defined for the Control", ((string)(null)), table6, "Given ");
#line 42
 testRunner.When("Habitat website is opened on Main Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
 testRunner.Then("Item element absents on page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                HandleInvalidOrNullDatasourcesFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                HandleInvalidOrNullDatasourcesFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
