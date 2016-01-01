using System;
using BugTracker.Commands;
using BugTracker.Model;

namespace BugTracker.Events
{
    public class FailedToNotifyResourceEvent : IEvent
    {
        public FailedToNotifyResourceEvent(Resource resource, ICommand command, Exception exception, DateTime occuredAt)
        {
            Resource = resource;
            OccuredAt = occuredAt;
            Command = command;
            Exception = exception;
        }

        public ICommand Command { get; }
        public Exception Exception { get; }
        public Resource Resource { get; }
        public DateTime OccuredAt { get; }
    }
}