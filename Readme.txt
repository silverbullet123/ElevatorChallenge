# Elevator Challenge

This is a C# solution for the DVT Elevator Challenge, implementing a console-based elevator control system using Clean Architecture and SOLID principles.

## Solution Structure
- **ElevatorChallenge.Domain**: Core entities, interfaces, enums, and exceptions.
- **ElevatorChallenge.Application**: Business logic and services.
- **ElevatorChallenge.Infrastructure**: Data access and external system implementations.
- **ElevatorChallenge.Presentation**: Console UI for user interaction.
- **ElevatorChallenge.Tests**: Unit tests using xUnit.

## Prerequisites
- .NET 6.0 SDK
- Visual Studio 2022 or compatible IDE

## Setup
1. Clone the repository or unzip the solution.
2. Open `ElevatorChallenge.sln` in Visual Studio.
3. Restore NuGet packages (xUnit for tests).
4. Build the solution.
5. Set `ElevatorChallenge.Presentation` as the startup project.
6. Run the application.

## Usage
Run the application and use the following commands:
- `CALL <floor> <passenger count> <destination floor>`: Call an elevator to a floor with passengers.
- `STATUS`: Display the current status of elevators and floors.
- `EXIT`: Exit the application.

## Running Tests
- In Visual Studio: Test > Run All Tests.
- Via CLI: `dotnet test`

## Notes
- The solution uses Clean Architecture to ensure modularity and maintainability.
- Unit tests cover key functionality in the Domain and Application layers.
- The console UI simulates elevator movement with delays for realism.