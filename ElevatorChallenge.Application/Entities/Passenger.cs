using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Domain.Entities
{
    public class Passenger
    {
        public int Id { get; }
        public int DestinationFloor { get; }

        public Passenger(int id, int destinationFloor)
        {
            Id = id;
            DestinationFloor = destinationFloor;
        }
    }
}
