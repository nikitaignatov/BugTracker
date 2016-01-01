using System;
using System.Linq;
using BugTracker.Commands;
using BugTracker.Events;
using BugTracker.Model;
using NRules.Fluent.Dsl;

namespace BugTracker.Rules
{
    [Name("Notify management about missing developer")]
    public class NotifyManagementAboutMissingDeveloperRule : Rule
    {
        public override void Define()
        {
            Bug bug = null;
            IHandle<NotifyManagementAboutMissingDeveloperCommand> handler = null;

            Dependency()
                .Resolve(() => handler);

            When().Match(() => bug,
                s => s.Estimate.HasValue,
                s => s.Resources.Any(x => x.Type == ResourceType.Manager),
                s => s.Resources.All(x => x.Type != ResourceType.Developer),
                s => !s.Events.OfType<NotifiedManagerAboutMissingDeveloperEvent>().Any(x => x.OccuredAt < DateTime.Now.AddDays(-2)));

            Then()
                .Do(ctx => handler.Handle(new NotifyManagementAboutMissingDeveloperCommand(bug)))
                .Do(ctx => ctx.Update(bug));
        }
    }
}