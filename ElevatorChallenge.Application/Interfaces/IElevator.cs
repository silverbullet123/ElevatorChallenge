using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorChallenge.Domain.Entities;
using ElevatorChallenge.Domain.Enums;

namespace ElevatorChallenge.Domain.Interfaces
{
    public interface IElevator
    {
        int Id { get; }
        int CurrentFloor { get; }
        ElevatorStatus Status { get; }
        ElevatorType Type { get; }
        int MaxPassengers { get; }
        int PassengerCount { get; }
        IReadOnlyList<Passenger> Passengers { get; }
        void MoveToFloor(int floor);
        bool CanAddPassengers(int count);
        void AddPassengers(List<Passenger> passengers);
        void RemovePassengers(List<Passenger> passengers);
    }
}
