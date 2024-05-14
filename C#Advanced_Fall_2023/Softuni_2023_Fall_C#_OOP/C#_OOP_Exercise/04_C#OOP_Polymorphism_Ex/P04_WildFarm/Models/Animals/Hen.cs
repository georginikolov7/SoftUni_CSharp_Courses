using P04_WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04_WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double WEIGHT_INCREMENT = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }
        protected override IReadOnlyCollection<string> EatenFoodTypes => new List<string>()
        {
             typeof(Vegetable).ToString(),
              typeof(Fruit).ToString(),
               typeof(Seeds).ToString(),
                typeof(Meat).ToString()
        };

        protected override double WeightIncrement => WEIGHT_INCREMENT;

        public override string AskForFood()
        {
            return "Cluck";
        }
    }
}
