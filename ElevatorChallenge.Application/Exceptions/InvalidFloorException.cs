using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Domain.Exceptions
{
    /// <summary>
    /// Exception thrown when an invalid floor is requested.
    /// </summary>
    public class InvalidFloorException : Exception
    {
        public InvalidFloorException(string message) : base(message) { }
    }
}
