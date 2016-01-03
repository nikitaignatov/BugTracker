namespace BugTracker.Flags
{
    public class NoSprintsAddedToProjectFlag : IFlag
    {
        public string Name { get; } = "no sprints added to project";
        public string Description { get; } = "Consider adding a sprint to this project.";
    }
}