using BugTracker.Model;

namespace BugTracker.Commands
{
    public class AssignResourceCommand : ICommand
    {
        public AssignResourceCommand(Bug bug, Resource resource, User assignedBy)
        {
            Bug = bug;
            Resource = resource;
            AssignedBy = assignedBy;
        }

        public Bug Bug { get; }
        public Resource Resource { get; }
        public User AssignedBy { get; }
    }
}