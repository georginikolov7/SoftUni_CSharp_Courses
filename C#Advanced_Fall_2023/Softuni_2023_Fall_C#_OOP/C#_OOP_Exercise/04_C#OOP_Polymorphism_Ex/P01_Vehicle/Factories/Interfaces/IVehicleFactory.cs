using P01_Vehicle.Models.Interfaces;

namespace P01_Vehicle.Factories.Interfaces
{
    public interface IVehicleFactory
    {
        IVehicle Create(string type, double fuelQuantity, double fuelConsumption, double tankCapacity);

    }
}
