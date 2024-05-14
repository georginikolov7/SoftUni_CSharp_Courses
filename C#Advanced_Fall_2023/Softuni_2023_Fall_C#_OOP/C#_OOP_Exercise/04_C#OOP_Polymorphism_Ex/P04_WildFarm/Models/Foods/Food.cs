using P04_WildFarm.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04_WildFarm.Models.Foods
{
    public abstract class Food : IFood
    {

        protected Food(int quantity)
        {
            Quantity = quantity;
        }
        public int Quantity { get; private set; }
    }
}
