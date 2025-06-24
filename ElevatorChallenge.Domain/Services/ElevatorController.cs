using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorChallenge.Domain.Exceptions;
using ElevatorChallenge.Domain.Entities;
using ElevatorChallenge.Domain.Enums;
using ElevatorChallenge.Domain.Interfaces;
using ElevatorChallenge.Infrastructure.Data;

namespace ElevatorChallenge.Application.Services
{
    /// <summary>
    /// Manages elevator operations and passenger assignments.
    /// </summary>
    public class ElevatorController : IElevatorController
    {
        private readonly BuildingRepository _buildingRepository;
        private readonly ElevatorDispatcher _dispatcher;
        private readonly int _maxFloors;

        public ElevatorController(BuildingRepository buildingRepository, ElevatorDispatcher dispatcher)
        {
            _buildingRepository = buildingRepository;
            _dispatcher = dispatcher;
            _maxFloors = buildingRepository.GetFloors().Max(f => f.FloorNumber);
        }

        public async Task CallElevatorAsync(int floorNumber, int passengerCount, int destinationFloor)
        {
            ValidateFloor(floorNumber, "Requested floor");
            ValidateFloor(destinationFloor, "Destination floor");
            if (passengerCount <= 0)
                throw new ArgumentException("Passenger count must be positive.");

            var floor = _buildingRepository.GetFloors().First(f => f.FloorNumber == floorNumber);
            var passengers = Enumerable.Range(1, passengerCount)
                .Select(i => new Passenger(i, destinationFloor))
                .ToList();
            floor.WaitingPassengers.AddRange(passengers);

            var elevator = _dispatcher.FindNearestElevator(floorNumber, _buildingRepository.GetElevators());
            if (elevator == null)
                throw new InvalidOperationException("No available elevators.");

            await SimulateElevatorMovementAsync(elevator, floorNumber, passengers);
        }

        public async Task UpdateElevatorStatusAsync()
        {
            foreach (var elevator in _buildingRepository.GetElevators())
            {
                var passengersToRemove = elevator.Passengers
                    .Where(p => p.DestinationFloor == elevator.CurrentFloor)
                    .ToList();
                elevator.RemovePassengers(passengersToRemove);
                await Task.Delay(1000);
            }
        }

        public IReadOnlyList<IElevator> GetElevators() => _buildingRepository.GetElevators();
        public IReadOnlyList<Floor> GetFloors() => _buildingRepository.GetFloors();

        private void ValidateFloor(int floorNumber, string context)
        {
            if (floorNumber < 1 || floorNumber > _maxFloors)
                throw new InvalidFloorException($"{context} {floorNumber} is invalid. Must be between 1 and {_maxFloors}.");
        }

        private async Task SimulateElevatorMovementAsync(IElevator elevator, int targetFloor, List<Passenger> passengers)
        {
            elevator.MoveToFloor(targetFloor);
            await Task.Delay(Math.Abs(elevator.CurrentFloor - targetFloor) * 1000);
            elevator.AddPassengers(passengers);
            var floor = _buildingRepository.GetFloors().First(f => f.FloorNumber == targetFloor);
            floor.WaitingPassengers.RemoveAll(p => passengers.Contains(p));
        }
    }
}
