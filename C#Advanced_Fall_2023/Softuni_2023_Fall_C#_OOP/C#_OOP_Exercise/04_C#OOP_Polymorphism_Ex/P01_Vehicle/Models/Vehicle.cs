using P01_Vehicle.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_Vehicle.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double increasedConsumption;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCap, double increasedConsumption)
        {
            TankCapacity = tankCap;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            this.increasedConsumption = increasedConsumption;
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            private set
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption { get; private set; }


        public double TankCapacity { get; private set; }

        public string Drive(double km, bool isACOn)
        {
            double consumption = isACOn ? FuelConsumption + increasedConsumption : FuelConsumption;
            double neededFuel = km * consumption;
            if (neededFuel <= FuelQuantity)
            {
                FuelQuantity -= neededFuel;
                return $"{this.GetType().Name} travelled {km} km";
            }
            return $"{this.GetType().Name} needs refueling";
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else if (fuel + fuelQuantity > TankCapacity)
            {
                throw new Exception($"Cannot fit {fuel} fuel in the tank");
            }
            FuelQuantity += fuel;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
