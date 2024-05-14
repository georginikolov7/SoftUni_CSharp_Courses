using P04_WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04_WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double WEIGHT_INCREMENT = 0.25;

        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        protected override IReadOnlyCollection<string> EatenFoodTypes => new List<string>() { typeof(Meat).ToString() };

        protected override double WeightIncrement => WEIGHT_INCREMENT;

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }
    }
}
