namespace BugTracker.Flags
{
    public class NoBugsInSprintFlag : IFlag
    {
        public string Name { get; } = "no bugs in sprint";
        public string Description { get; } = "Assign bugs to this sprint.";
    }
}