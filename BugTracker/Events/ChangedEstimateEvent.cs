using System;
using BugTracker.Model;

namespace BugTracker.Events
{
    public class ChangedEstimateEvent : IEvent
    {
        public ChangedEstimateEvent(Bug bug, User changedBy, DateTime occuredAt)
        {
            OccuredAt = occuredAt;
            Bug = bug;
            ChangedBy = changedBy;
        }

        public Bug Bug { get; }
        public User ChangedBy { get; }
        public DateTime OccuredAt { get; }
    }
}