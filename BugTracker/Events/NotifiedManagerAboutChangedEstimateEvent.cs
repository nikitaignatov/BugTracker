using System;
using BugTracker.Model;

namespace BugTracker.Events
{
    public class NotifiedManagerAboutChangedEstimateEvent : IEvent
    {
        public NotifiedManagerAboutChangedEstimateEvent(Bug bug, DateTime occuredAt)
        {
            OccuredAt = occuredAt;
            Bug = bug;
        }

        public Bug Bug { get; }
        public DateTime OccuredAt { get; }
    }
}