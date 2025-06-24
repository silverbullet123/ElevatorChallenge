using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Domain.Entities
{
    /// <summary>
    /// Represents a floor in the building with waiting passengers.
    /// </summary>
    public class Floor
    {
        public int FloorNumber { get; }
        public List<Passenger> WaitingPassengers { get; } = new List<Passenger>();

        public Floor(int floorNumber)
        {
            FloorNumber = floorNumber;
        }
    }
}