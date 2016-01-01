using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTracker.Contracts;
using BugTracker.Events;

namespace BugTracker.Model
{
    public class Bug
    {
        public Bug()
        {
            Events = new List<IEvent>();
            Resources = new List<Resource>();
        }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public Project Project { get; set; }
        public TimeSpan? Estimate { get; set; }
        public virtual ICollection<IEvent> Events { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
    }

    public class Project
    {
        public string Name { get; set; }
        public virtual ICollection<Sprint> Sprints { get; set; }
        public IEnumerable<Bug> Bugs => Sprints.SelectMany(x => x.Bugs);
    }

    public class Tag
    {
        public string Name { get; set; }
    }

    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class Resource
    {
        public Bug Bug { get; set; }
        public User User { get; set; }
        public ResourceType Type { get; set; }
    }

    public enum ResourceType
    {
        Manager, Developer, Customer, StakeHolder, Creator, Tester,
    }

    public class State
    {
        public string Name { get; set; }
    }

    public class Sprint : IComparable<Sprint>
    {
        public Sprint()
        {
            Bugs = new List<Bug>();
        }

        public string Name { get; set; }
        public DateTime? DueDate { get; set; }
        public virtual ICollection<Bug> Bugs { get; set; }

        public int CompareTo(Sprint other)
        {
            return Comparer<DateTime?>.Default.Compare(DueDate, other.DueDate);
        }
    }
}
