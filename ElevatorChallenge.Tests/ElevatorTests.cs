using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using ElevatorChallenge.Domain.Entities;
using ElevatorChallenge.Domain.Enums;
using ElevatorChallenge.Domain.Exceptions;
using Xunit;

namespace ElevatorChallenge.Tests
{
    public class ElevatorTests
    {
        [Fact]
        public void AddPassengers_WithinCapacity_Succeeds()
        {
            var elevator = new Elevator(1, ElevatorType.Passenger, maxPassengers: 5);
            var passengers = new List<Passenger> { new Passenger(1, 3) };

            elevator.AddPassengers(passengers);

            Assert.Equal(1, elevator.PassengerCount);
        }

        [Fact]
        public void AddPassengers_ExceedsCapacity_ThrowsException()
        {
            var elevator = new Elevator(1, ElevatorType.Passenger, maxPassengers: 2);
            var passengers = new List<Passenger>
            {
                new Passenger(1, 3),
                new Passenger(2, 4),
                new Passenger(3, 5)
            };

            Assert.Throws<CapacityExceededException>(() => elevator.AddPassengers(passengers));
        }

        [Fact]
        public void MoveToFloor_UpdatesFloorAndStatus()
        {
            var elevator = new Elevator(1, ElevatorType.Passenger, maxPassengers: 5);
            elevator.MoveToFloor(3);

            Assert.Equal(3, elevator.CurrentFloor);
            Assert.Equal(ElevatorStatus.Stationary, elevator.Status);
        }
    }
}
