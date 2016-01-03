using System;
using System.Linq;
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
    public class FlagsSteps
    {
        private static Container container;
        private static ISessionFactory factory;

        [BeforeTestRun]
        public static void BeforeTest()
        {
            var repository = new RuleRepository();
            repository.Load(x => x.From(typeof(NotifyDevelopersAboutMissingEstimateRule).Assembly));
            factory = repository.Compile();

            container = new Container();
            container.Register(typeof(IHandle<>), typeof(CommandHandler));
            container.Register(() => factory);
            container.Verify();

            factory.DependencyResolver = new SimpleInjectorDependencyResolver(container);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ScenarioContext.Current.Set(container, "container");
            ScenarioContext.Current.Set(factory.CreateSession(), "session");
        }

        [Given(@"A project")]
        public void GivenAProject()
        {
            var project = new Project();
            ScenarioContext.Current.Set(project, "project");
        }

        [Given(@"A sprint")]
        public void GivenASprint()
        {
            var sprint = new Sprint();
            ScenarioContext.Current.Set(sprint, "sprint");
        }

        [Given(@"A bug")]
        public void GivenABug()
        {
            var bug = new Bug();
            ScenarioContext.Current.Set(bug, "bug");
        }

        [When(@"Number of sprints in the project is (.*)")]
        public void WhenNumberOfSprintsInTheProjectIs(int p0)
        {
            var project = ScenarioContext.Current.Get<Project>("project");
            var session = ScenarioContext.Current.Get<ISession>("session");

            session.Insert(project);
            session.Fire();
        }

        [When(@"Number of bugs in sprint is (.*)")]
        public void WhenNumberOfBugsInSprintIs(int p0)
        {
            var sprint = ScenarioContext.Current.Get<Sprint>("sprint");
            var session = ScenarioContext.Current.Get<ISession>("session");

            session.Insert(sprint);
            session.Fire();
        }

        [When(@"Bug is not in sprint")]
        public void WhenBugIsNotInSprint()
        {
            var bug = ScenarioContext.Current.Get<Bug>("bug");
            var session = ScenarioContext.Current.Get<ISession>("session");
            bug.Sprint = null;

            session.Insert(bug);
            session.Fire();
        }

        [When(@"Estimate is missing")]
        public void WhenEstimateIsMissing()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Rources are not assigned")]
        public void WhenRourcesAreNotAssigned()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Due date is not defined")]
        public void WhenDueDateIsNotDefined()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Project is flagged with '(.*)'")]
        public void ThenProjectIsFlaggedWith(string name)
        {
            var bug = ScenarioContext.Current.Get<Project>("project");
            bug.Flags.Any(x => x.Name == name).Should().BeTrue();
        }

        [Then(@"Sprint is flagged wit '(.*)'")]
        public void ThenSprintIsFlaggedWit(string name)
        {
            var bug = ScenarioContext.Current.Get<Sprint>("sprint");
            bug.Flags.Any(x => x.Name == name).Should().BeTrue();
        }

        [Then(@"Bug is flagged with '(.*)'")]
        public void ThenBugIsFlaggedWith(string name)
        {
            var bug = ScenarioContext.Current.Get<Bug>("bug");
            bug.Flags.Any(x => x.Name == name).Should().BeTrue();
        }
    }
}
