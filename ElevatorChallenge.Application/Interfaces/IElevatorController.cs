using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElevatorChallenge.Domain.Entities;

namespace ElevatorChallenge.Domain.Interfaces
{
    public interface IElevatorController
    {
        Task CallElevatorAsync(int floorNumber, int passengerCount, int destinationFloor);
        Task UpdateElevatorStatusAsync();
        IReadOnlyList<IElevator> GetElevators();
        IReadOnlyList<Floor> GetFloors();
    }
}
