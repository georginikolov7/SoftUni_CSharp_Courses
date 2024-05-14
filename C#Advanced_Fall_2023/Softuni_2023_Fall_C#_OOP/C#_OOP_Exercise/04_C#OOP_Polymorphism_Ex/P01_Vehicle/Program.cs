

using P01_Vehicle.Core;
using P01_Vehicle.Factories;
using P01_Vehicle.Factories.Interfaces;

IVehicleFactory vehicleFactory = new VehicleFactory();
Engine engine = new Engine(vehicleFactory);
engine.Run();