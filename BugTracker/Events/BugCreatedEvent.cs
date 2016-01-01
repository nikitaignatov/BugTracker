using System;
using BugTracker.Model;

namespace BugTracker.Events
{
    public class BugCreatedEvent : IEvent
    {
        public BugCreatedEvent(Bug bug, User createdBy, DateTime occuredAt)
        {
            CreatedBy = createdBy;
            OccuredAt = occuredAt;
            Bug = bug;
        }

        public Bug Bug { get; }
        public User CreatedBy { get; }
        public DateTime OccuredAt { get; }
    }
}