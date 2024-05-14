using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_Vehicle.Models.Interfaces
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }
        public double FuelConsumption { get; }
        public double TankCapacity { get; }
        string Drive(double km, bool isACOn);
        void Refuel(double fuel);
    }
}
