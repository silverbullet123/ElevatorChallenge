using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using ElevatorChallenge.Domain.Entities;
using ElevatorChallenge.Domain.Enums;


namespace ElevatorChallenge.Domain.Enums
{
    /// <summary>
    /// Defines the types of elevators supported.
    /// </summary>
    public enum ElevatorType
    {
        Passenger,
        HighSpeed,
        Freight,
        Glass
    }
}