using System.Linq;
using BugTracker.Flags;
using BugTracker.Model;
using NRules.Fluent.Dsl;

namespace BugTracker.Rules.Flags
{
    public class NoSprintsAddedToProjectRule : Rule
    {
        public override void Define()
        {
            Project project = null;

            When().Match(() => project,
                s => s.Sprints.Count == 0,
                s => !s.Flags.OfType<NoSprintsAddedToProjectFlag>().Any());

            Then()
                .Do(ctx => project.Flags.Add(new NoSprintsAddedToProjectFlag()))
                .Do(ctx => ctx.Update(project));
        }
    }
}