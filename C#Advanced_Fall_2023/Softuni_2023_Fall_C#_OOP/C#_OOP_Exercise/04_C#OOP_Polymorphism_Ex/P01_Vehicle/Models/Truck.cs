using P01_Vehicle.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_Vehicle.Models
{
    public class Truck : Vehicle
    {
        private const double ACFuelConsIncrease = 1.6;
        private const double FuelToKeep = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCap)
            : base(fuelQuantity, fuelConsumption,tankCap,ACFuelConsIncrease)
        {
        }

        public override void Refuel(double fuel)
        {
            if (fuel + FuelQuantity > TankCapacity)
            {
                throw new Exception($"Cannot fit {fuel} fuel in the tank");
            }
            base.Refuel(FuelToKeep * fuel);
        }
    }
}
