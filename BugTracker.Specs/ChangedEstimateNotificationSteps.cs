using System;
using System.Linq;
using System.Net.Mail;
using BugTracker.Commands;
using BugTracker.Events;
using BugTracker.Model;
using BugTracker.Rules;
using FluentAssertions;
using NRules;
using NRules.Fluent;
using NSubstitute;
using SimpleInjector;
using TechTalk.SpecFlow;

namespace BugTracker.Specs
{
    [Binding]
    public class ChangedEstimateNotificationSteps
    {
        private Bug bug;
        private User dev;
        private User manager;
        private IHandle<ChangeEstimateCommand> changeEstimate;

        public ChangedEstimateNotificationSteps()
        {
            var mail = Substitute.For<IMailService>();
            ScenarioContext.Current.Set(mail, "mail");

            var repository = new RuleRepository();
            repository.Load(x => x.From(typeof(NotifyDeveloperAboutMissingEstimateRule).Assembly));
            var factory = repository.Compile();

            var container = new Container();
            container.Register(typeof(IHandle<>), typeof(CommandHandler));
            container.Register(() => factory);
            container.Register(() => mail);
            container.Verify();

            factory.DependencyResolver = new SimpleInjectorDependencyResolver(container);
            ScenarioContext.Current.Set(container, "container");
        }

        [Given(@"I report a new bug '(.*)' without an estimate")]
        public void GivenIReportANewBugWithoutAnEstimate(string name)
        {
            dev = new User { Email = "dev@company" };
            manager = new User { Email = "manager@company" };
            bug = new Bug { Name = name };
        }

        [Given(@"I assign a Developer")]
        public void GivenIAssignADeveloper()
        {
            bug.Resources.Add(new Resource { User = dev, Type = ResourceType.Developer });
        }

        [Given(@"I assign myself as a Manager and my mail address is '(.*)'")]
        public void GivenIAssignMyselfAsAManagerAndMyMailAddressIs(string email)
        {
            manager.Email = email;
            bug.Resources.Add(new Resource { User = manager, Type = ResourceType.Manager });
        }

        [When(@"Developer changes estimate")]
        public void WhenDeveloperChangesEstimate()
        {
            bug.Estimate = TimeSpan.FromDays(2);
            changeEstimate = ScenarioContext.Current.Get<Container>("container").GetInstance<IHandle<ChangeEstimateCommand>>();
            changeEstimate.Handle(new ChangeEstimateCommand(bug, dev));
        }

        [Then(@"Email is sent to '(.*)'")]
        public void ThenEmailIsSentTo(string emailAddress)
        {
            var mail = ScenarioContext.Current.Get<IMailService>("mail");
            mail.Received(1).Send(Arg.Is<MailMessage>(x => x.To.Any(m => m.Address == emailAddress)));
        }

        [Then(@"Bug should have (.*) event of type '(.*)'")]
        public void ThenBugShouldHaveEventOfType(int numberOfEvents, string typeName)
        {
            bug.Events.OfType<NotifiedManagerAboutChangedEstimateEvent>()
                .Count(x => x.GetType().Name == typeName)
                .Should().Be(numberOfEvents);
        }
    }
}

