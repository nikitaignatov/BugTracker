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

        [Given(@"I have a bug '(.*)'")]
        public void GivenIHaveABug(string name)
        {
            dev = new User { Email = "dev@company" };
            manager = new User { Email = "manager@company" };
            bug = new Bug { Name = name };
        }

        [Given(@"It is missing an estimate")]
        public void GivenItIsMissingAnEstimate()
        {
            bug.Estimate = null;
        }

        [Given(@"It has Developer in resources")]
        public void GivenItHasDeveloperInResources()
        {
            bug.Resources.Add(new Resource { User = dev, Type = ResourceType.Developer });
        }

        [Given(@"It has Me as Manager in resources")]
        public void GivenItHasMeAsManagerInResources()
        {
            bug.Resources.Add(new Resource { User = manager, Type = ResourceType.Manager });
        }

        [When(@"Developer changes estimate")]
        public void WhenDeveloperChangesEstimate()
        {
            bug.Estimate = TimeSpan.FromDays(2);
            changeEstimate = ScenarioContext.Current.Get<Container>("container").GetInstance<IHandle<ChangeEstimateCommand>>();
            changeEstimate.Handle(new ChangeEstimateCommand(bug, dev));
        }

        [Then(@"I should recieve (\d+) email")]
        public void ThenIShouldRecieveAnEmail(int numberOfMails)
        {
            var mail = ScenarioContext.Current.Get<IMailService>("mail");
            mail.Received(numberOfMails).Send(Arg.Any<MailMessage>());
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

