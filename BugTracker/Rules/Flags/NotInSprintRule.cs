using System.Linq;
using BugTracker.Flags;
using BugTracker.Model;
using NRules.Fluent.Dsl;

namespace BugTracker.Rules.Flags
{
    public class NotInSprintRule : Rule
    {
        public override void Define()
        {
            Bug bug = null;

            When().Match(() => bug,
                s => s.Sprint == null,
                s => !s.Flags.OfType<NotInSprintFlag>().Any());

            Then()
                .Do(ctx => bug.Flags.Add(new NotInSprintFlag()))
                .Do(ctx => ctx.Update(bug));
        }
    }
}