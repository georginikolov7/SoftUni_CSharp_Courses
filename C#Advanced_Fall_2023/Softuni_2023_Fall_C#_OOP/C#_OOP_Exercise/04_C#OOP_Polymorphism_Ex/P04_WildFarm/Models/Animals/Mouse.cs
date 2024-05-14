using P04_WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04_WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        private const double WEIGHT_INCREMENT = 0.10;
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        protected override IReadOnlyCollection<string> EatenFoodTypes => new List<string>()
        {
             typeof(Vegetable).ToString(),
             typeof(Fruit).ToString()
        };

        protected override double WeightIncrement => WEIGHT_INCREMENT;

        public override string AskForFood()
        {
            return "Squeak";
        }
        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
