using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Domain.Exceptions
{
    /// <summary>
    /// Exception thrown when an elevator's passenger capacity is exceeded.
    /// </summary>
    public class CapacityExceededException : Exception
    {
        public CapacityExceededException(string message) : base(message) { }
    }
}
