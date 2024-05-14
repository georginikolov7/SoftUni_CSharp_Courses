using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public abstract class Vehicle
    {
        private const double defaultFuelConsumption = 1.25;
        private double fuel;
        private int horsePower;
        public Vehicle(int hp, double fuel)
        {
            HorsePower = hp;
            Fuel = fuel;
        }
        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }

        public double Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }

        public virtual double FuelConsumption
        {
            get { return defaultFuelConsumption; }
        }
        public void Drive(double kilometers)
        {
            Fuel -= kilometers * FuelConsumption;
        }

    }
}
