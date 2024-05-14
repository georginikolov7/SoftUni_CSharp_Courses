using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_Vehicle.Models
{
    public class Bus : Vehicle
    {
        private const double ACFuelConsIncrease = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCap) : base(fuelQuantity, fuelConsumption, tankCap,ACFuelConsIncrease)
        {

        }

    }
}
