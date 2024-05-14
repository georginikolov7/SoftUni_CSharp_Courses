using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double defaultFuelConsumption = 3;
        public Car(int hp, double fuel)
            : base(hp, fuel)
        {

        }
        public override double FuelConsumption => defaultFuelConsumption;
    }
}
