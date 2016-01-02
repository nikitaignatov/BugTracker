using System.Linq;
using BugTracker.Commands;
using BugTracker.Events;
using BugTracker.Model;
using NRules.Fluent.Dsl;

namespace BugTracker.Rules
{
    [Name("Notifty developers about missing estimate")]
    public class NotifyDevelopersAboutMissingEstimateRule : Rule
    {
        public override void Define()
        {
            Bug bug = null;
            IHandle<NotifyDevelopersAboutMissingEstimateCommand> handler = null;

            Dependency()
                .Resolve(() => handler);

            When().Match(() => bug,
                s => !s.Estimate.HasValue,
                s => s.Resources.Any(x => x.Type == ResourceType.Developer),
                s => !s.Events.OfType<FailedToNotifyResourceEvent>().Any(x => x.Command is NotifyDevelopersAboutMissingEstimateCommand),
                s => !s.Events.OfType<NotifiedDevelopersAboutMissingEstimateEvent>().Any());

            Then()
                .Do(ctx => handler.Handle(new NotifyDevelopersAboutMissingEstimateCommand(bug)))
                .Do(ctx => ctx.Update(bug));
        }
    }
}