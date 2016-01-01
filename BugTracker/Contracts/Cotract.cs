using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTracker.Model;

namespace BugTracker.Contracts
{
    public interface IHaveId<T> { T Id { get; set; } }
    public interface IHaveSubject { string Subject { get; set; } }
    public interface IHaveName { string Name { get; set; } }
    public interface IHaveEmail { string Email { get; set; } }
    public interface IHaveDescription { string Description { get; set; } }
    public interface IHaveDueDate { DateTime? DueDate { get; set; } }
    public interface IHaveCreationDate { DateTime CreationDate { get; set; } }
    public interface IHaveProject { Project Project { get; set; } }
}
