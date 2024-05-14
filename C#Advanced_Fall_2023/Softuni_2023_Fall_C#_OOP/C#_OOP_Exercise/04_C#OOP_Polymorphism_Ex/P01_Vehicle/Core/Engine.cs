using P01_Vehicle.Factories;
using P01_Vehicle.Factories.Interfaces;
using P01_Vehicle.Models;
using P01_Vehicle.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_Vehicle.Core
{
    public class Engine
    {
        private Dictionary<string, IVehicle> vehicles = new();
        private readonly IVehicleFactory vehicleFactory;
        private const int CountOfVehicles = 3;
        public Engine(IVehicleFactory vehicleFactory)
        {
            this.vehicleFactory = vehicleFactory;
        }
        public void Run()
        {
            for (int i = 0; i < CountOfVehicles; i++)
            {
                try
                {
                    IVehicle vehicle = CreateVehicle();
                    vehicles.Add(vehicle.GetType().Name, vehicle);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            int countOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfCommands; i++)
            {
                try
                {
                    ProccessCommand();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            foreach (var v in vehicles.Values)
            {
                Console.WriteLine(v);
            }

        }
        private IVehicle CreateVehicle()
        {
            string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            return vehicleFactory.Create(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2]), double.Parse(tokens[3]));
        }
        private void ProccessCommand()
        {
            string[] commandTokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string command = commandTokens[0];
            string vehicleType = commandTokens[1];

            IVehicle vehicle = vehicles[vehicleType];
            //if (vehicle == null)
            //{
            //    throw new Exception("Invalid vehicle type!");
            //}
            double value = double.Parse(commandTokens[2]);
            if (command == "Drive")
            {
                Console.WriteLine(vehicles[vehicleType].Drive(value, true));
            }
            else if (command == "DriveEmpty" && (vehicle as Bus) != null)
            {
                Console.WriteLine( vehicle.Drive(value, false));
            }
            else if (command == "Refuel")
            {
                vehicles[vehicleType].Refuel(value);

            }
            //else
            //{
            //    throw new Exception("Invalid command");
            //}
        }
    }
}
