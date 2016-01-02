using System;
using System.Linq;
using System.Net.Mail;
using BugTracker.Commands;
using BugTracker.Model;
using BugTracker.Rules;
using FluentAssertions;
using NRules;
using NRules.Fluent;
using NSubstitute;
using SimpleInjector;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BugTracker.Specs
{
    [Binding]
    public class NotificationSteps
    {
        private Bug bug;
        private User dev;
        private User manager;
        private static Container container;
        private static IMailService mail;

        [BeforeTestRun]
        public static void BeforeTest()
        {
            mail = Substitute.For<IMailService>();
            var repository = new RuleRepository();
            repository.Load(x => x.From(typeof(NotifyDevelopersAboutMissingEstimateRule).Assembly));
            var factory = repository.Compile();

            container = new Container();
            container.Register(typeof(IHandle<>), typeof(CommandHandler));
            container.Register(() => factory);
            container.Register(() => mail);
            container.Verify();

            factory.DependencyResolver = new SimpleInjectorDependencyResolver(container);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            mail = Substitute.For<IMailService>();
            ScenarioContext.Current.Set(mail, "mail");
            ScenarioContext.Current.Set(container, "container");

            dev = new User { Email = "dev@company" };
            manager = new User { Email = "manager@company" };
        }

        [Given(@"I report a new bug '(.*)' without an estimate")]
        public void GivenIReportANewBugWithoutAnEstimate(string name)
        {
            bug = new Bug { Name = name };
            var handler = container.GetInstance<IHandle<CreateBugCommand>>();
            handler.Handle(new CreateBugCommand(bug, manager));
        }

        [Given(@"I assign myself as a (\w+) and my mail address is '(.*)'")]
        [Given(@"I assign a (\w+) with mail address '(.*)'")]
        [When(@"I assign a (\w+) with mail address '(.*)'")]
        public void GivenIAssignMyselfAsAManagerAndMyMailAddressIs(ResourceType type, string email)
        {
            var resource = new Resource { Bug = bug, User = new User { Email = email }, Type = type };
            var handler = container.GetInstance<IHandle<AssignResourceCommand>>();
            handler.Handle(new AssignResourceCommand(bug, resource, manager));
        }

        [When(@"Developer changes estimate to (\d+) hours")]
        public void WhenDeveloperChangesEstimate(int hours)
        {
            bug.Estimate = TimeSpan.FromHours(hours);
            var handler = container.GetInstance<IHandle<ChangeEstimateCommand>>();
            handler.Handle(new ChangeEstimateCommand(bug, dev));
        }

        [Then(@"(\d+) mail is sent to '(.*)'")]
        [Then(@"(\d+) mails is sent to '(.*)'")]
        public void ThenEmailIsSentTo(int numberOfMails, string emailAddress)
        {
            var mail = ScenarioContext.Current.Get<IMailService>("mail");
            mail.Received(numberOfMails).Send(Arg.Is<MailMessage>(x => x.To.Any(m => m.Address == emailAddress)));
        }

        [Then(@"Bug should have (.*) event of type '(.*)'")]
        public void ThenBugShouldHaveEventOfType(int numberOfEvents, string typeName)
        {
            bug.Events
                .Count(x => x.GetType().Name == typeName)
                .Should().Be(numberOfEvents);
        }

        [Then(@"Bug should have event of type")]
        public void ThenBugShouldHaveEventOfType(Table table)
        {
            var list = bug.Events
                .GroupBy(x => x.GetType().Name)
                .Select(x => new EventHistory { Occurances = x.Count(), EventType = x.Key })
                .ToList();

            table.CompareToSet(list);
        }

        class EventHistory
        {
            public int Occurances { get; set; }
            public string EventType { get; set; }
        }
    }
}

