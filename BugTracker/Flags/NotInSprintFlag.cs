using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Flags
{
    public class NotInSprintFlag : IFlag
    {
        public string Name { get; } = "not in sprint";
        public string Description { get; } = "Assign the item to a sprint.";
    }
}
