using System.Linq;
using BugTracker.Commands;
using BugTracker.Events;
using BugTracker.Model;
using NRules.Fluent.Dsl;

namespace BugTracker.Rules
{
    [Name("Notified developer about missing estimate")]
    public class NotifyDeveloperAboutMissingEstimateRule : Rule
    {
        public override void Define()
        {
            Bug bug = null;
            IHandle<NotifyDeveloperAboutMissingEstimateCommand> handler = null;

            Dependency()
                .Resolve(() => handler);

            When().Match(() => bug,
                s => !s.Estimate.HasValue,
                s => s.Resources.Any(x => x.Type == ResourceType.Developer),
                s => !s.Events.OfType<NotifiedDevelopersAboutMissingEstimateEvent>().Any());

            Then()
                .Do(ctx => handler.Handle(new NotifyDeveloperAboutMissingEstimateCommand(bug)))
                .Do(ctx => ctx.Update(bug));
        }
    }
}