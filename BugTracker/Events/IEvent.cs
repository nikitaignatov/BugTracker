using System;

namespace BugTracker.Events
{
    public interface IEvent { DateTime OccuredAt { get; } }
}