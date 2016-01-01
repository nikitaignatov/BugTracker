using BugTracker.Model;

namespace BugTracker.Commands
{
    public class NotifyDeveloperAboutMissingEstimateCommand : ICommand
    {
        public NotifyDeveloperAboutMissingEstimateCommand(Bug bug)
        {
            Bug = bug;
        }

        public Bug Bug { get; }
    }
}