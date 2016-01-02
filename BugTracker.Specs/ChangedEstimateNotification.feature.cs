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
                    "\r\n\tI want to know if an email could not be sent", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Change estimate")]
        [NUnit.Framework.CategoryAttribute("notification")]
        public virtual void ChangeEstimate()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Change estimate", new string[] {
                        "notification"});
#line 10
this.ScenarioSetup(scenarioInfo);
#line 11
 testRunner.Given("I report a new bug \'cannot click on button\' without an estimate", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 12
   testRunner.And("I assign a Developer with mail address \'dev@company\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
   testRunner.And("I assign myself as a Manager and my mail address is \'manager@company\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
  testRunner.When("Developer changes estimate to 2 hours", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
  testRunner.Then("1 mail is sent to \'manager@company\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
   testRunner.And("Bug should have 1 event of type \'NotifiedManagerAboutChangedEstimateEvent\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Change estimate multiple times")]
        [NUnit.Framework.CategoryAttribute("notification")]
        public virtual void ChangeEstimateMultipleTimes()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Change estimate multiple times", new string[] {
                        "notification"});
#line 19
this.ScenarioSetup(scenarioInfo);
#line 20
 testRunner.Given("I report a new bug \'cannot click on button\' without an estimate", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 21
   testRunner.And("I assign a Developer with mail address \'dev@company\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
   testRunner.And("I assign myself as a Manager and my mail address is \'manager@company\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
  testRunner.When("Developer changes estimate to 2 hours", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
  testRunner.When("Developer changes estimate to 4 hours", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
  testRunner.When("Developer changes estimate to 6 hours", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
  testRunner.Then("2 mails is sent to \'manager@company\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
   testRunner.And("Bug should have 3 event of type \'NotifiedManagerAboutChangedEstimateEvent\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Failure when sending mail")]
        [NUnit.Framework.CategoryAttribute("notification")]
        [NUnit.Framework.CategoryAttribute("event")]
        [NUnit.Framework.CategoryAttribute("failure")]
        public virtual void FailureWhenSendingMail()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Failure when sending mail", new string[] {
                        "notification",
                        "event",
                        "failure"});
#line 30
this.ScenarioSetup(scenarioInfo);
#line 31
 testRunner.Given("I report a new bug \'cannot click on button\' without an estimate", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 32
   testRunner.And("I assign a Developer with mail address \'dev@company\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
   testRunner.And("I assign myself as a Manager and my mail address is \'&\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
  testRunner.When("Developer changes estimate to 2 hours", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
  testRunner.Then("Bug should have 1 event of type \'FailedToNotifyResourceEvent\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
