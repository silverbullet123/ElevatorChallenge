using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ElevatorChallenge.Domain.Entities;
using ElevatorChallenge.Domain.Enums;
using ElevatorChallenge.Domain.Interfaces;

namespace ElevatorChallenge.Presentation
{
    /// <summary>
    /// Handles console-based user interaction and status display.
    /// </summary>
    public class ConsoleUI
    {
        private readonly IElevatorController _elevatorController;

        public ConsoleUI(IElevatorController elevatorController)
        {
            _elevatorController = elevatorController;
        }

        public async Task RunAsync()
        {
            Console.WriteLine("Elevator Control System");
            Console.WriteLine("Commands: CALL <floor> <passenger count> <destination floor>, STATUS, EXIT");

            while (true)
            {
                Console.Write("> ");
                var input = Console.ReadLine()?.Trim().ToUpper();
                if (string.IsNullOrEmpty(input))
                    continue;

                if (input == "EXIT")
                    break;

                if (input == "STATUS")
                {
                    await DisplayStatusAsync();
                    continue;
                }

                if (input.StartsWith("CALL"))
                {
                    await HandleCallCommandAsync(input);
                    continue;
                }

                Console.WriteLine("Invalid command. Use CALL, STATUS, or EXIT.");
            }
        }

        private async Task HandleCallCommandAsync(string input)
        {
            try
            {
                var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 4 || !int.TryParse(parts[1], out var floorNumber) ||
                    !int.TryParse(parts[2], out var passengerCount) ||
                    !int.TryParse(parts[3], out var destinationFloor))
                {
                    Console.WriteLine("Invalid CALL command. Format: CALL <floor> <passenger count> <destination floor>");
                    return;
                }

                await _elevatorController.CallElevatorAsync(floorNumber, passengerCount, destinationFloor);
                Console.WriteLine($"Elevator called to floor {floorNumber} for {passengerCount} passengers to floor {destinationFloor}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private async Task DisplayStatusAsync()
        {
            try
            {
                await _elevatorController.UpdateElevatorStatusAsync();
                var elevators = _elevatorController.GetElevators();
                var floors = _elevatorController.GetFloors();

                foreach (var elevator in elevators)
                {
                    Console.WriteLine($"Elevator {elevator.Id}: Floor {elevator.CurrentFloor}, Status: {elevator.Status}, Passengers: {elevator.PassengerCount}/{elevator.MaxPassengers}");
                }

                foreach (var floor in floors)
                {
                    if (floor.WaitingPassengers.Any())
                    {
                        Console.WriteLine($"Floor {floor.FloorNumber}: {floor.WaitingPassengers.Count} passengers waiting");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}