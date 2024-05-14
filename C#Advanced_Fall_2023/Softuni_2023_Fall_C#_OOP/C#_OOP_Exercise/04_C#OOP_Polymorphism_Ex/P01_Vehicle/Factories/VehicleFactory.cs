using P01_Vehicle.Factories.Interfaces;
using P01_Vehicle.Models;
using P01_Vehicle.Models.Interfaces;


namespace P01_Vehicle.Factories
{
    internal class VehicleFactory : IVehicleFactory
    {
        public IVehicle Create(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            switch (type)
            {
                case "Car":
                    return new Car(fuelQuantity, fuelConsumption, tankCapacity);
                case "Truck":
                    return new Truck(fuelQuantity, fuelConsumption, tankCapacity);
                case "Bus":
                    return new Bus(fuelQuantity, fuelConsumption, tankCapacity);
                default:
                    throw new ArgumentException("Invalid vehicle type");
            }

        }
    }
}
