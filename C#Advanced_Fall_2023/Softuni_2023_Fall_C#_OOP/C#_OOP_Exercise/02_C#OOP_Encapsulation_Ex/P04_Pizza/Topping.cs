using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04_Pizza
{
    public class Topping
    {
        private const double MinWeight = 1;
        private const double MaxWeight = 50;
        private const double BaseCaloriesPerGram = 2;
        private Dictionary<string, double> typesCalories;
        private double weight;
        private string type;
        public Topping(string type, double weight)
        {
            typesCalories = new()
            {
                {"meat",1.2 },{"veggies",0.8 },{"cheese",1.1 },{ "sauce",0.9}
            };
            Type = type;
            Weight = weight;
        }
        public string Type
        {
            get => type;
            private set
            {
                if (!typesCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }
        public double Weight
        {
            get => weight;
            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }
        public double Calories
        {
            get
            {
                return BaseCaloriesPerGram * weight * typesCalories[type.ToLower()];
            }
        }

    }
}

