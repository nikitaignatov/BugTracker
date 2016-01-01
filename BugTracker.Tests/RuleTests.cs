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
using NUnit.Framework;
using SimpleInjector;

namespace BugTracker.Tests
{
    [TestFixture]
    public class RuleTests
    {
        private ISessionFactory factory;
        private ISession session;
        private IMailService mail;
        private IHandle<CreateBugCommand> createBug;
        private IHandle<ChangeEstimateCommand> changeEstimate;
        private Container container;
        private User dev;
        private Bug bug;
        private User manager;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            mail = Substitute.For<IMailService>();

            var repository = new RuleRepository();
            repository.Load(x => x.From(typeof(NotifyDeveloperAboutMissingEstimateRule).Assembly));
            factory = repository.Compile();

            container = new Container();
            container.Register(typeof(IHandle<>), typeof(CommandHandler));
            container.Register(() => factory);
            container.Register(() => mail);
            container.Verify();

            factory.DependencyResolver = new SimpleInjectorDependencyResolver(container);
        }

        [SetUp]
        public void Setup()
        {
            mail = Substitute.For<IMailService>();
            session = factory.CreateSession();
            createBug = container.GetInstance<IHandle<CreateBugCommand>>();
            changeEstimate = container.GetInstance<IHandle<ChangeEstimateCommand>>();

            dev = new User { Email = "dev@company" };
            manager = new User { Email = "manager@company" };
            bug = new Bug
            {
                Resources =
                {
                    new Resource { User = dev, Type = ResourceType.Developer },
                    new Resource { User = manager, Type = ResourceType.Manager },
                    new Resource { User = manager, Type = ResourceType.Creator },
                }
            };
        }

        [Test]
        public void test()
        {
            // arrange

            // act
            session.Insert(bug);
            session.Fire();

            // assert
            bug.Events.Count.Should().Be(1);
            mail.Received(1).Send(Arg.Any<MailMessage>());
        }

        [TestCase(ResourceType.Developer, 1)]
        [TestCase(ResourceType.Manager, 0)]
        public void should_send_email_notification(ResourceType type, int numberOfCalls)
        {
            // arrange
            bug = new Bug { Resources = { new Resource { User = dev, Type = type } }, };
            var command = new CreateBugCommand(bug, new User { Email = "nikita@company" });

            // act
            createBug.Handle(command);

            // assert
            mail.Received(numberOfCalls).Send(Arg.Is<MailMessage>(x => x.To.Any(m => m.Address == dev.Email)));
        }

        public void should_send_email_notification_when_estimate_changed()
        {
            // arrange
            bug.Estimate = TimeSpan.FromHours(10);
            var command = new ChangeEstimateCommand(bug, dev);

            // act
            changeEstimate.Handle(command);

            // assert
            mail.Received(1).Send(Arg.Any<MailMessage>());
        }

        [Test]
        public void should_trigger_multiple_events_when_creating_and_changing_estimates()
        {
            // arrange
            bug = new Bug
            {
                Resources =
                {
                    new Resource { User = dev, Type = ResourceType.Developer },
                    new Resource { User = manager, Type = ResourceType.Manager }
                },
            };

            // act
            createBug.Handle(new CreateBugCommand(bug, manager));
            bug.Estimate = TimeSpan.FromHours(10);
            changeEstimate.Handle(new ChangeEstimateCommand(bug, dev));

            // assert
            mail.Received(1).Send(Arg.Is<MailMessage>(x => x.To.Any(m => m.Address == dev.Email)));
            mail.Received(1).Send(Arg.Is<MailMessage>(x => x.To.Any(m => m.Address == manager.Email)));
            bug.Events.Count.Should().Be(4);
            Console.WriteLine("Events:\n\t" + string.Join("\n\t", bug.Events.Select(x => x.GetType().Name)));
        }
    }
}
