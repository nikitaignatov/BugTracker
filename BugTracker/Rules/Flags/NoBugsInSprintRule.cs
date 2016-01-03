using System.Linq;
using BugTracker.Flags;
using BugTracker.Model;
using NRules.Fluent.Dsl;

namespace BugTracker.Rules.Flags
{
    public class NoBugsInSprintRule : Rule
    {
        public override void Define()
        {
            Sprint sprint = null;

            When().Match(() => sprint,
                s => s.Bugs.Count == 0,
                s => !s.Flags.OfType<NoBugsInSprintFlag>().Any());

            Then()
                .Do(ctx => sprint.Flags.Add(new NoBugsInSprintFlag()))
                .Do(ctx => ctx.Update(sprint));
        }
    }
}