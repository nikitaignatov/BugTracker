using BugTracker.Model;

namespace BugTracker.Commands
{
    public class CreateBugCommand : ICommand
    {
        public CreateBugCommand(Bug bug, User createdBy)
        {
            Bug = bug;
            CreatedBy = createdBy;
        }

        public Bug Bug { get; }
        public User CreatedBy { get; }
    }
}