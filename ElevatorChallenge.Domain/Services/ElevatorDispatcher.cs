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
    public class ElevatorDispatcher
    {
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
