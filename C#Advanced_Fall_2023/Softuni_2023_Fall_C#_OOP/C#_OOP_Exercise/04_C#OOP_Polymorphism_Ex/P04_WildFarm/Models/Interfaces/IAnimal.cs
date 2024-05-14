using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace P04_WildFarm.Models.Interfaces
{
    public interface IAnimal
    {
        public string Name { get;  }
        public double Weight { get; }
        public int FoodEaten { get; }
        public string AskForFood();
        public void Feed(IFood food);
        
    }
}
