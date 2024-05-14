using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public abstract class Beverage : Product
    {
        public Beverage(string name, decimal price, double mililiters) : base(name, price)
        {
            this.Milliliters = mililiters;
        }
        public double Milliliters { get; set; }
    }
}
