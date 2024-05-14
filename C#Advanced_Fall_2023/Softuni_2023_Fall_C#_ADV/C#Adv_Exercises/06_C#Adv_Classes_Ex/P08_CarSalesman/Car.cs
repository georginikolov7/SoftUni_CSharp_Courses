using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P08_CarSalesman
{
    internal class Car
    {
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }

        private string model;
        private Engine engine;
        private int weight;
        private string color;

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

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"{Model}:");
            sb.AppendLine(Engine.ToString());
            sb.AppendLine($"  Weight: {(Weight==0?"n/a":Weight)}");
            sb.AppendLine($"  Color: {(Color == default ? "n/a" : Color)}");
            return sb.ToString();

        }
    }
}
