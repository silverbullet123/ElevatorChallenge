using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using ElevatorChallenge.Domain.Enums;
using ElevatorChallenge.Domain.Interfaces;
using ElevatorChallenge.Domain.Exceptions;


namespace ElevatorChallenge.Domain.Entities
{
    public class Elevator : IElevator
    {
        private readonly List<Passenger> _passengers = new List<Passenger>();

        public int Id { get; }
        public int CurrentFloor { get; private set; }
        public ElevatorStatus Status { get; private set; }
        public ElevatorType Type { get; }
        public int MaxPassengers { get; }
        public int PassengerCount => _passengers.Count;
        public IReadOnlyList<Passenger> Passengers => _passengers.AsReadOnly();

        public Elevator(int id, ElevatorType type, int maxPassengers)
        {
            Id = id;
            Type = type;
            MaxPassengers = maxPassengers;
            CurrentFloor = 1;
            Status = ElevatorStatus.Stationary;
        }

        public void MoveToFloor(int floor)
        {
            Status = floor > CurrentFloor ? ElevatorStatus.MovingUp : ElevatorStatus.MovingDown;
            CurrentFloor = floor;
            Status = ElevatorStatus.Stationary;
        }

        public bool CanAddPassengers(int count) => PassengerCount + count <= MaxPassengers;

        public void AddPassengers(List<Passenger> passengers)
        {
            if (!CanAddPassengers(passengers.Count))
                throw new CapacityExceededException($"Elevator {Id} cannot add {passengers.Count} passengers. Capacity: {MaxPassengers}, Current: {PassengerCount}.");
            _passengers.AddRange(passengers);
        }

        public void RemovePassengers(List<Passenger> passengers)
        {
            foreach (var passenger in passengers)
                _passengers.Remove(passenger);
        }
    }
}