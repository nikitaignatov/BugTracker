using BugTracker.Model;

namespace BugTracker.Commands
{
    public class NotifyDevelopersAboutMissingEstimateCommand : ICommand
    {
        public NotifyDevelopersAboutMissingEstimateCommand(Bug bug)
        {
            Bug = bug;
        }

        public Bug Bug { get; }
    }
}