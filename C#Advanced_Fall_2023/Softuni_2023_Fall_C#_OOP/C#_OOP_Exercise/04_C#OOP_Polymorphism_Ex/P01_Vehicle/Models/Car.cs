using P01_Vehicle.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_Vehicle.Models
{
    public class Car : Vehicle
    {
        private const double ACFuelConsIncrease = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCap)
            : base(fuelQuantity, fuelConsumption, tankCap,ACFuelConsIncrease)
        {

        }

    }
}
