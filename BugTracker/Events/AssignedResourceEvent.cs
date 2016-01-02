using System;
using BugTracker.Model;

namespace BugTracker.Events
{
    public class AssignedResourceEvent : IEvent
    {
        public AssignedResourceEvent(Bug bug, Resource resource, User assignedBy, DateTime occuredAt)
        {
            AssignedBy = assignedBy;
            OccuredAt = occuredAt;
            Bug = bug;
            Resource = resource;
        }

        public Bug Bug { get; }
        public Resource Resource { get; }
        public User AssignedBy { get; }
        public DateTime OccuredAt { get; }
    }
}