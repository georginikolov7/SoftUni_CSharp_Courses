﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace P07_RawData
{
    public class Car
    {
        public Car(string model,
            int engineSpeed,
            int enginePower,
            int cargoWeight,
            string cargoType,
            double tire1Pressure,
            int tire1Age,
            double tire2Pressure,
            int tire2Age,
            double tire3Pressure,
            int tire3Age,
            double tire4Pressure,
            int tire4Age
            ) 
        {
            this.Model = model;
            this.Engine = new Engine(engineSpeed,enginePower);
            this.Cargo = new Cargo(cargoType, cargoWeight);

            //initialize tires:
            this.Tires = new Tire[4];
            Tires[0] = new Tire(tire1Age, tire1Pressure);
            Tires[1] = new Tire(tire2Age, tire2Pressure);
            Tires[2] = new Tire(tire3Age, tire3Pressure);
            Tires[3] = new Tire(tire4Age, tire4Pressure);
        }
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }
        public Cargo Cargo
        {
            get
            {
                return cargo;
            }
            set
            {
                cargo = value;
            }
        }
        public Tire[] Tires
        {
            get { return tires; }
            set { tires = value; }
        }
    }
}
