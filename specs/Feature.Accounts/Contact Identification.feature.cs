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
namespace Sitecore.Feature.Accounts.Specflow
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class ContactIdentificationFeature : Xunit.IClassFixture<ContactIdentificationFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Contact Identification.feature"
#line hidden
        
        public ContactIdentificationFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Contact Identification", "As a sales person \r\nI want to show that Sitecore tracks the indentifiction of a v" +
                    "isitor \r\nso that I can show the we know a person across visits", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        public virtual void SetFixture(ContactIdentificationFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Contact Identification")]
        [Xunit.TraitAttribute("Description", "Accounts_Contact Identification_UC1_Anonymus user")]
        [Xunit.TraitAttribute("Category", "Ready")]
        public virtual void Accounts_ContactIdentification_UC1_AnonymusUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Accounts_Contact Identification_UC1_Anonymus user", new string[] {
                        "Ready"});
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given("Habitat website is opened on Main Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.When("Actor selects Open visit details panel slidebar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
 testRunner.And("Actor expands Personal Information header on xDB panel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.Then("User icon presents on Personal Information header section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
 testRunner.And("Personal Information header contains You are anonymous label", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And("Identification secret icon presents", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Contact Identification")]
        [Xunit.TraitAttribute("Description", "Accounts_Contact Identification_UC2_Identification is shown in the demo contact p" +
            "anel for just registered user")]
        [Xunit.TraitAttribute("Category", "Ready")]
        public virtual void Accounts_ContactIdentification_UC2_IdentificationIsShownInTheDemoContactPanelForJustRegisteredUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Accounts_Contact Identification_UC2_Identification is shown in the demo contact p" +
                    "anel for just registered user", new string[] {
                        "Ready"});
#line 17
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "ConfirmPassword"});
            table1.AddRow(new string[] {
                        "kovContact@sitecore.net",
                        "k",
                        "k"});
#line 18
 testRunner.Given("User is registered in Habitat and logged out", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password"});
            table2.AddRow(new string[] {
                        "kovContact@sitecore.net",
                        "k"});
#line 21
 testRunner.And("User was Login to Habitat", ((string)(null)), table2, "And ");
#line 24
 testRunner.When("Actor selects Open visit details panel slidebar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
 testRunner.And("Actor expands Personal Information header on xDB panel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.Then("User icon presents on Personal Information header section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
 testRunner.And("Personal Information header contains You are known label", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Text"});
            table3.AddRow(new string[] {
                        "Email (Primary)"});
            table3.AddRow(new string[] {
                        "kovContact@sitecore.net"});
            table3.AddRow(new string[] {
                        "Identification"});
            table3.AddRow(new string[] {
                        "extranet\\kovContact@sitecore.net"});
#line 28
 testRunner.And("xDB Panel Body text contains", ((string)(null)), table3, "And ");
#line 34
 testRunner.And("Identification known icon presents", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Contact Identification")]
        [Xunit.TraitAttribute("Description", "Accounts_Contact Identification_UC3_Start a new session")]
        [Xunit.TraitAttribute("Category", "Ready")]
        public virtual void Accounts_ContactIdentification_UC3_StartANewSession()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Accounts_Contact Identification_UC3_Start a new session", new string[] {
                        "Ready"});
#line 39
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "ConfirmPassword"});
            table4.AddRow(new string[] {
                        "kovContact@sitecore.net",
                        "k",
                        "k"});
#line 40
 testRunner.Given("User is registered in Habitat and logged out", ((string)(null)), table4, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password"});
            table5.AddRow(new string[] {
                        "kovContact@sitecore.net",
                        "k"});
#line 43
 testRunner.And("User was Login to Habitat", ((string)(null)), table5, "And ");
#line 46
 testRunner.When("Actor selects Open visit details panel slidebar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 47
 testRunner.And("Actor clicks End Visit button on xDB panel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
 testRunner.And("Actor selects Open visit details panel slidebar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.And("Actor expands Personal Information header on xDB panel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.Then("User icon presents on Personal Information header section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 51
 testRunner.And("Personal Information header contains You are known label", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Text"});
            table6.AddRow(new string[] {
                        "Email (Primary)"});
            table6.AddRow(new string[] {
                        "kovContact@sitecore.net"});
            table6.AddRow(new string[] {
                        "Identification"});
            table6.AddRow(new string[] {
                        "extranet\\kovContact@sitecore.net"});
#line 52
 testRunner.And("xDB Panel Body text contains", ((string)(null)), table6, "And ");
#line 58
 testRunner.And("Identification known icon presents", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Contact Identification")]
        [Xunit.TraitAttribute("Description", "Accounts_Contact Identification_UC4_Clear browser cookies")]
        [Xunit.TraitAttribute("Category", "Ready")]
        public virtual void Accounts_ContactIdentification_UC4_ClearBrowserCookies()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Accounts_Contact Identification_UC4_Clear browser cookies", new string[] {
                        "Ready"});
#line 63
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "ConfirmPassword"});
            table7.AddRow(new string[] {
                        "kovContact@sitecore.net",
                        "k",
                        "k"});
#line 64
 testRunner.Given("User is registered in Habitat and logged out", ((string)(null)), table7, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password"});
            table8.AddRow(new string[] {
                        "kovContact@sitecore.net",
                        "k"});
#line 67
 testRunner.And("User was Login to Habitat", ((string)(null)), table8, "And ");
#line 70
 testRunner.When("Actor deletes all browser cookies", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 71
 testRunner.And("Actor selects Open visit details panel slidebar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
 testRunner.And("Actor expands Personal Information header on xDB panel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
 testRunner.Then("User icon presents on Personal Information header section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 74
 testRunner.And("Personal Information header contains You are known label", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Text"});
            table9.AddRow(new string[] {
                        "Email (Primary)"});
            table9.AddRow(new string[] {
                        "kovContact@sitecore.net"});
            table9.AddRow(new string[] {
                        "Identification"});
            table9.AddRow(new string[] {
                        "extranet\\kovContact@sitecore.net"});
#line 75
 testRunner.And("xDB Panel Body text contains", ((string)(null)), table9, "And ");
#line 81
 testRunner.And("Identification known icon presents", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Contact Identification")]
        [Xunit.TraitAttribute("Description", "Accounts_Contact Identification_UC5_Inspect info for known user")]
        [Xunit.TraitAttribute("Category", "InProgress")]
        public virtual void Accounts_ContactIdentification_UC5_InspectInfoForKnownUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Accounts_Contact Identification_UC5_Inspect info for known user", new string[] {
                        "InProgress"});
#line 86
this.ScenarioSetup(scenarioInfo);
#line 87
 testRunner.Given("Habitat website is opened on Main Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password"});
            table10.AddRow(new string[] {
                        "johnsmith@gmail.com",
                        "j"});
#line 88
 testRunner.And("User was Login to Habitat", ((string)(null)), table10, "And ");
#line 91
 testRunner.When("Actor selects Open visit details panel slidebar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 92
 testRunner.And("Actor expands Personal Information header on xDB panel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
 testRunner.Then("User icon presents on Personal Information header section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 94
 testRunner.And("Personal Information header contains You are known label", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "Text"});
            table11.AddRow(new string[] {
                        "Gender"});
            table11.AddRow(new string[] {
                        "Male"});
            table11.AddRow(new string[] {
                        "Job Title"});
            table11.AddRow(new string[] {
                        "Intern"});
            table11.AddRow(new string[] {
                        "Address (main)"});
            table11.AddRow(new string[] {
                        "153 SE 15th Rd Miami, , 33129 USA"});
            table11.AddRow(new string[] {
                        "Email (Primary)"});
            table11.AddRow(new string[] {
                        "JohnSmith@gmail.com"});
            table11.AddRow(new string[] {
                        "Phone (cell)"});
            table11.AddRow(new string[] {
                        "+775 45454456"});
            table11.AddRow(new string[] {
                        "Phone (work)"});
            table11.AddRow(new string[] {
                        "+775 3434567653 ext 15"});
            table11.AddRow(new string[] {
                        "Preferred Language"});
            table11.AddRow(new string[] {
                        "en"});
            table11.AddRow(new string[] {
                        "Identification"});
            table11.AddRow(new string[] {
                        "extranet\\JohnSmith@gmail.com"});
#line 95
 testRunner.And("xDB Panel Body text contains", ((string)(null)), table11, "And ");
#line 113
 testRunner.And("Identification known icon presents", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                ContactIdentificationFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                ContactIdentificationFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
