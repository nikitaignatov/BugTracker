using BugTracker.Model;

namespace BugTracker.Commands
{
    public class ChangeEstimateCommand : ICommand
    {
        public ChangeEstimateCommand(Bug bug, User changedBy)
        {
            Bug = bug;
            ChangedBy = changedBy;
        }

        public Bug Bug { get; }
        public User ChangedBy { get; }
    }
}