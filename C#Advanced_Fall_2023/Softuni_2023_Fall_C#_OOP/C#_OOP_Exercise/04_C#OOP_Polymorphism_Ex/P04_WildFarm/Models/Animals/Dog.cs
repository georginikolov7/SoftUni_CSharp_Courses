using P04_WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04_WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private const double WEIGHT_INCREMENT = 0.40;
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        protected override IReadOnlyCollection<string> EatenFoodTypes => new List<string>()
        {
             typeof(Meat).ToString()
        };

        protected override double WeightIncrement => WEIGHT_INCREMENT;

        public override string AskForFood()
        {
            return "Woof!";
        }
        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
