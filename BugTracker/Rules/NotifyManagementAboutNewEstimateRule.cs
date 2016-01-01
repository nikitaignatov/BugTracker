using System.Linq;
using BugTracker.Commands;
using BugTracker.Events;
using BugTracker.Model;
using NRules.Fluent.Dsl;

namespace BugTracker.Rules
{
    [Name("Notify management about new estimate")]
    public class NotifyManagementAboutNewEstimateRule : Rule
    {
        public override void Define()
        {
            Bug bug = null;
            IHandle<NotifyManagementAboutChangedEstimateCommand> handler = null;

            Dependency()
                .Resolve(() => handler);

            When().Match(() => bug,
                s => s.Estimate.HasValue,
                s => s.Resources.Any(x => x.Type == ResourceType.Manager),
                s => s.Events.OfType<ChangedEstimateEvent>().Count() > s.Events.OfType<NotifiedManagerAboutChangedEstimateEvent>().Count());

            Then()
                .Do(ctx => handler.Handle(new NotifyManagementAboutChangedEstimateCommand(bug)))
                .Do(ctx => ctx.Update(bug));
        }
    }
}