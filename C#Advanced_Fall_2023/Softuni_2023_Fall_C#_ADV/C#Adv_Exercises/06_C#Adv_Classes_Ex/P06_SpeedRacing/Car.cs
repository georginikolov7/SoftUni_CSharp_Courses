using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }
        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }
        public void Drive(double distance)
        {
            double neededFuel = distance * FuelConsumptionPerKilometer;
            if (neededFuel > FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                FuelAmount -= neededFuel;
                TravelledDistance += distance;
            }
        }
        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.TravelledDistance}";
        }
    }
}
