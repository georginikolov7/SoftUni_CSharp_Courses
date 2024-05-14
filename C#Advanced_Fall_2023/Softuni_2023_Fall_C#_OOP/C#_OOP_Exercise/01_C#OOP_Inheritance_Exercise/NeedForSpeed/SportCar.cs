using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const double defaultFuelConsumption = 10;
        public SportCar(int hp, double fuel)
            : base(hp, fuel)
        {
        }
        public override double FuelConsumption => defaultFuelConsumption;
    }
}
