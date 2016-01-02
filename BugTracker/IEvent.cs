using System;

namespace BugTracker
{
    public interface IEvent { DateTime OccuredAt { get; } }
}