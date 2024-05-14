using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double defaultFuelConsumption = 8;
        public RaceMotorcycle(int hp, double fuel)
            : base(hp, fuel)
        {

        }
        public override double FuelConsumption => defaultFuelConsumption;
    }
}
