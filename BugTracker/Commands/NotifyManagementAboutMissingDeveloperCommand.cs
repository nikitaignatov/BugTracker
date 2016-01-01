using BugTracker.Model;

namespace BugTracker.Commands
{
    public class NotifyManagementAboutMissingDeveloperCommand : ICommand
    {
        public NotifyManagementAboutMissingDeveloperCommand(Bug bug)
        {
            Bug = bug;
        }

        public Bug Bug { get; }
    }
}