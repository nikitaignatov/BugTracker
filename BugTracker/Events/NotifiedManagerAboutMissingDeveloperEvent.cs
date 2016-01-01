using System;
using BugTracker.Commands;
using BugTracker.Model;

namespace BugTracker.Events
{
    public class NotifiedManagerAboutMissingDeveloperEvent : IEvent
    {
        public NotifiedManagerAboutMissingDeveloperEvent(Bug bug, DateTime occuredAt)
        {
            OccuredAt = occuredAt;
            Bug = bug;
        }

        public Bug Bug { get; }
        public DateTime OccuredAt { get; }
    }
}