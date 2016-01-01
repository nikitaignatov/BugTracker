using BugTracker.Model;

namespace BugTracker.Commands
{
    public class NotifyManagementAboutChangedEstimateCommand : ICommand
    {
        public NotifyManagementAboutChangedEstimateCommand(Bug bug)
        {
            Bug = bug;
        }

        public Bug Bug { get; }
    }
}