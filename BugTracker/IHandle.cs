using BugTracker.Commands;

namespace BugTracker
{
    public interface IHandle<in T> where T : ICommand
    {
        void Handle(T cmd);
    }
}