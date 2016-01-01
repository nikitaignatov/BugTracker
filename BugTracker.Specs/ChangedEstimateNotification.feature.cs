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
namespace BugTracker.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Changed estimate notification")]
    public partial class ChangedEstimateNotificationFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ChangedEstimateNotification.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Changed estimate notification", "\tIn order to know when estimates of a Bug are changed\r\n\tAs a Manager\r\n\tI want to " +
                    "recieve notification by email\r\n\tAs a System\r\n\tI want to know that email was sent" +
                    "", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
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
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Send mail notification to Manager")]
        [NUnit.Framework.CategoryAttribute("notification")]
        [NUnit.Framework.CategoryAttribute("mail")]
        public virtual void SendMailNotificationToManager()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Send mail notification to Manager", new string[] {
                        "notification",
                        "mail"});
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
 testRunner.Given("I report a new bug \'cannot click on button\' without an estimate", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
   testRunner.And("I assign a Developer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
   testRunner.And("I assign myself as a Manager and my mail address is \'manager@company\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
  testRunner.When("Developer changes estimate", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
  testRunner.Then("Email is sent to \'manager@company\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add event when notification is sent")]
        [NUnit.Framework.CategoryAttribute("notification")]
        [NUnit.Framework.CategoryAttribute("event")]
        public virtual void AddEventWhenNotificationIsSent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add event when notification is sent", new string[] {
                        "notification",
                        "event"});
#line 17
this.ScenarioSetup(scenarioInfo);
#line 18
 testRunner.Given("I report a new bug \'cannot click on button\' without an estimate", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
   testRunner.And("I assign a Developer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
   testRunner.And("I assign myself as a Manager and my mail address is \'manager@company\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
     testRunner.When("Developer changes estimate", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
     testRunner.Then("Bug should have 1 event of type \'NotifiedManagerAboutChangedEstimateEvent\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
