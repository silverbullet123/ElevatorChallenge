using System.Threading.Tasks;
using ElevatorChallenge.Application.Services;
using ElevatorChallenge.Infrastructure.Data;
using ElevatorChallenge.Presentation;

namespace ElevatorChallenge
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var buildingRepository = new BuildingRepository(numberOfFloors: 10, numberOfElevators: 3);
            var dispatcher = new ElevatorDispatcher();
            var controller = new ElevatorController(buildingRepository, dispatcher);
            var ui = new ConsoleUI(controller);

            await ui.RunAsync();
        }
    }
}