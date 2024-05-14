using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Engine
    {
        public Engine(int hp,double cubicCapacity)
        {
			horsePower = hp;
			CubicCapacity = cubicCapacity;
        }
        private int horsePower;

		public int HorsePower
		{
			get { return horsePower; }
			set { horsePower = value; }
		}
		private double cubicCapacity;

		public double CubicCapacity
		{
			get { return cubicCapacity; }
			set { cubicCapacity = value; }
		}


	}
}
