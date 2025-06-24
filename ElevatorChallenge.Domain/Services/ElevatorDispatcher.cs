using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Linq;
using ElevatorChallenge.Domain.Interfaces;

namespace ElevatorChallenge.Application.Services
{
    /// <summary>
    /// Handles dispatching elevators to requested floors.
    /// </summary>
    public class ElevatorDispatcher
    {
        /// <summary>
        /// Finds the nearest available elevator to a requested floor.
        /// </summary>
        /// <param name="requestedFloor">The floor requesting an elevator.</param>
        /// <returns>The nearest elevator or null if none available.</returns>
        public IElevator FindNearestElevator(int requestedFloor, IEnumerable<IElevator> elevators)
        {
            return elevators
                .Where(e => e.CanAddPassengers(1))
                .OrderBy(e => Math.Abs(e.CurrentFloor - requestedFloor))
                .ThenBy(e => e.PassengerCount)
                .FirstOrDefault();
        }
    }
}
