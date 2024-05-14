using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P08_CarSalesman
{
    public class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        public int Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }
        public string Efficiency
        {
            get { return efficiency; }
            set
            {
                efficiency = value;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"  {Model}:");
            sb.AppendLine($"    Power: {Power}");
            sb.AppendLine($"    Displacement: {(Displacement == 0 ? "n/a" : Displacement)}");
            sb.AppendLine($"    Efficiency: {(Efficiency == default ? "n/a" : Efficiency)}");
            return sb.ToString().Trim();
        }
    }
}
