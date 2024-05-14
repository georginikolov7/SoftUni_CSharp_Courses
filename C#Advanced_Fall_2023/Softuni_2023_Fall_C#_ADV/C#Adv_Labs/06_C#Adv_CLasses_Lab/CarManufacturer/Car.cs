using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CarManufacturer
{
    public class Car
    {
        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            fuelConsumption = 10;
        }
        public Car(string make, string model, int year)
            :this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
        : this(make, model, year)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption,Engine engine, Tire[] tires)
            :this(make,model,year,fuelQuantity,fuelConsumption)
        {
            this.engine = engine;
            this.tires = tires;
        }
        private string make;

        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        private int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        private double fuelQuantity;

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }
        private double fuelConsumption;

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }
        private Engine engine;

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }
        private Tire[] tires;

        public Tire[] Tires
        {
            get { return tires; }
            set { tires = value; }
        }

        public void Drive(double distance)
        {
            if (fuelQuantity - distance * fuelConsumption/100 >= 0)
            {
                fuelQuantity -= distance * fuelConsumption/100;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }
        public string WhoAmI()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Make: {this.Make}");
            result.AppendLine($"Model: {this.Model}");
            result.AppendLine($"Year: {this.Year}");
            result.AppendLine($"Fuel: {this.FuelQuantity:F2}");
            return result.ToString();

        }
    }
}
