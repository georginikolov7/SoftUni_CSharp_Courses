using P04_WildFarm.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04_WildFarm.Factories.Interfaces
{
    public interface IFoodFactory
    {
        IFood CreateFood(string[] tokens);
    }
}
