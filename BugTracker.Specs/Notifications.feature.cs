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
    [NUnit.Framework.DescriptionAttribute("Notifications")]
    public partial class NotificationsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Notifications.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Notifications", "\tIn order for everyone to be up to date with the changes to the bugs\r\n\tAs a User\r" +
                    "\n\tI will recieve notitifications regarding changes that are relevant to me\r\n\tAs " +
                    "a System\r\n\tI will send notifications and keep track of what has been sent", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Assign developer")]
        public virtual void AssignDeveloper()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assign developer", ((string[])(null)));
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given("I report a new bug \'cannot click on button\' without an estimate", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
  testRunner.When("I assign a Developer with mail address \'dev@company\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
  testRunner.Then("1 mail is sent to \'dev@company\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 12
   testRunner.And("Bug should have 1 event of type \'NotifiedDevelopersAboutMissingEstimateEvent\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Fail when sending mail notification")]
        public virtual void FailWhenSendingMailNotification()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Fail when sending mail notification", ((string[])(null)));
#line 14
this.ScenarioSetup(scenarioInfo);
#line 15
 testRunner.Given("I report a new bug \'cannot click on button\' without an estimate", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
  testRunner.When("I assign a Developer with mail address \'_\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
  testRunner.Then("Bug should have 1 event of type \'FailedToNotifyResourceEvent\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Change estimate")]
        [NUnit.Framework.CategoryAttribute("notification")]
        public virtual void ChangeEstimate()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Change estimate", new string[] {
                        "notification"});
#line 20
this.ScenarioSetup(scenarioInfo);
#line 21
 testRunner.Given("I report a new bug \'cannot click on button\' without an estimate", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 22
   testRunner.And("I assign a Developer with mail address \'dev@company\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
   testRunner.And("I assign myself as a Manager and my mail address is \'manager@company\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
  testRunner.When("Developer changes estimate to 2 hours", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
  testRunner.Then("1 mail is sent to \'manager@company\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 26
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
#line 29
this.ScenarioSetup(scenarioInfo);
#line 30
 testRunner.Given("I report a new bug \'cannot click on button\' without an estimate", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
   testRunner.And("I assign a Developer with mail address \'dev@company\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
   testRunner.And("I assign myself as a Manager and my mail address is \'manager@company\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
  testRunner.When("Developer changes estimate to 2 hours", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
  testRunner.When("Developer changes estimate to 4 hours", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
  testRunner.When("Developer changes estimate to 6 hours", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
  testRunner.Then("3 mails is sent to \'manager@company\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 37
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
#line 40
this.ScenarioSetup(scenarioInfo);
#line 41
 testRunner.Given("I report a new bug \'cannot click on button\' without an estimate", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 42
   testRunner.And("I assign a Developer with mail address \'dev@company\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
   testRunner.And("I assign myself as a Manager and my mail address is \'&\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
  testRunner.When("Developer changes estimate to 2 hours", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
  testRunner.Then("Bug should have 1 event of type \'FailedToNotifyResourceEvent\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("View event history")]
        [NUnit.Framework.CategoryAttribute("mytag")]
        public virtual void ViewEventHistory()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View event history", new string[] {
                        "mytag"});
#line 49
this.ScenarioSetup(scenarioInfo);
#line 50
 testRunner.Given("I report a new bug \'cannot click on button\' without an estimate", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 51
   testRunner.And("I assign myself as a Manager and my mail address is \'manager@company\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
   testRunner.And("I assign a Developer with mail address \'dev@company\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
  testRunner.When("Developer changes estimate to 8 hours", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
  testRunner.When("Developer changes estimate to 4 hours", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
  testRunner.When("Developer changes estimate to 6 hours", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Occurances",
                        "Event type"});
            table1.AddRow(new string[] {
                        "1",
                        "BugCreatedEvent"});
            table1.AddRow(new string[] {
                        "2",
                        "AssignedResourceEvent"});
            table1.AddRow(new string[] {
                        "3",
                        "ChangedEstimateEvent"});
            table1.AddRow(new string[] {
                        "1",
                        "NotifiedDevelopersAboutMissingEstimateEvent"});
            table1.AddRow(new string[] {
                        "3",
                        "NotifiedManagerAboutChangedEstimateEvent"});
#line 56
  testRunner.Then("Bug should have event of type", ((string)(null)), table1, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion