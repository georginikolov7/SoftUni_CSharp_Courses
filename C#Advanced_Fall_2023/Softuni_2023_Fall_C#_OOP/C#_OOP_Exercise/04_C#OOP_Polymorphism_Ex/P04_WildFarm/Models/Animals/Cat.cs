using P04_WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04_WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const double WEIGHT_INCREMENT = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        protected override IReadOnlyCollection<string> EatenFoodTypes => new List<string>() { typeof(Vegetable).ToString(),  typeof(Meat).ToString() };

        protected override double WeightIncrement => WEIGHT_INCREMENT;

        public override string AskForFood()
        {
            return "Meow";
        }
    }
}
