using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorChallenge.Application.Services;
using ElevatorChallenge.Domain.Entities;
using ElevatorChallenge.Domain.Enums;
using ElevatorChallenge.Domain.Exceptions;
using ElevatorChallenge.Infrastructure.Data;
using Xunit;

namespace ElevatorChallenge.Tests
{
    public class ElevatorControllerTests
    {
        [Fact]
        public async Task CallElevatorAsync_ValidInput_CallsElevator()
        {
            var buildingRepository = new BuildingRepository(numberOfFloors: 10, numberOfElevators: 1);
            var dispatcher = new ElevatorDispatcher();
            var controller = new ElevatorController(buildingRepository, dispatcher);

            await controller.CallElevatorAsync(2, 1, 5);

            var elevator = controller.GetElevators().First();
            Assert.Equal(2, elevator.CurrentFloor);
            Assert.Equal(1, elevator.PassengerCount);
        }

        [Fact]
        public async Task CallElevatorAsync_InvalidFloor_ThrowsException()
        {
            var buildingRepository = new BuildingRepository(numberOfFloors: 10, numberOfElevators: 1);
            var dispatcher = new ElevatorDispatcher();
            var controller = new ElevatorController(buildingRepository, dispatcher);

            await Assert.ThrowsAsync<InvalidFloorException>(() => controller.CallElevatorAsync(11, 1, 5));
        }

        [Fact]
        public async Task UpdateElevatorStatusAsync_RemovesPassengersAtDestination()
        {
            var buildingRepository = new BuildingRepository(numberOfFloors: 10, numberOfElevators: 1);
            var dispatcher = new ElevatorDispatcher();
            var controller = new ElevatorController(buildingRepository, dispatcher);
            var elevator = controller.GetElevators().First();
            elevator.AddPassengers(new List<Passenger> { new Passenger(1, 3) });
            elevator.MoveToFloor(3);

            await controller.UpdateElevatorStatusAsync();

            Assert.Equal(0, elevator.PassengerCount);
        }
    }
}
