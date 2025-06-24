using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorChallenge.Domain.Entities;
using ElevatorChallenge.Domain.Enums;
using ElevatorChallenge.Domain.Interfaces;

namespace ElevatorChallenge.Infrastructure.Data
{
    /// <summary>
    /// Simulates data storage for building floors and elevators.
    /// </summary>
    public class BuildingRepository
    {
        private readonly List<IElevator> _elevators;
        private readonly List<Floor> _floors;

        public BuildingRepository(int numberOfFloors = 10, int numberOfElevators = 3)
        {
            _elevators = Enumerable.Range(1, numberOfElevators)
                .Select(i => new Elevator(i, ElevatorType.Passenger, maxPassengers: 10) as IElevator)
                .ToList();
            _floors = Enumerable.Range(1, numberOfFloors)
                .Select(i => new Floor(i))
                .ToList();
        }

        public IReadOnlyList<IElevator> GetElevators() => _elevators.AsReadOnly();
        public IReadOnlyList<Floor> GetFloors() => _floors.AsReadOnly();
    }
}