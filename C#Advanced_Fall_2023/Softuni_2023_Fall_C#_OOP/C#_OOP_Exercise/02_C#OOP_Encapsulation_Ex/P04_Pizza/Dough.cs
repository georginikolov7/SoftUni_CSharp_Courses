using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04_Pizza
{
    public class Dough
    {
        private const double BaseDoughCaloriesPerGram = 2;
        private Dictionary<string, double> flourTypesCalories;
        private Dictionary<string, double> bakingTechniquesCalories;
        private const double MinWeight = 1;
        private const double MaxWeight = 200;
        private string flourType;
        private string bakingTechnique;
        private double weight;
        public Dough(string flourType, string bakingTechnique, double weight)
        {
            flourTypesCalories = new() { { "white",1.5},
                {"wholegrain",1.0 }};
            bakingTechniquesCalories = new() { { "crispy", 0.9 }, { "chewy", 1.1 }, { "homemade", 1.0 } };
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string FlourType
        {
            get => flourType;

            private set
            {
                if (!flourTypesCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
        }
        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                if (!bakingTechniquesCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }
        public double Weight
        {
            get => weight;
            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }

        }
        public double Calories
        {
            get
            {
                return weight * BaseDoughCaloriesPerGram * flourTypesCalories[FlourType.ToLower()] * bakingTechniquesCalories[bakingTechnique.ToLower()];
            }
        }

    }
}
