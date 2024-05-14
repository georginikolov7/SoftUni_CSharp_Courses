using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04_Pizza
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            toppings = new List<Topping>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public Dough Dough
        {
            get;
            set;
        }
        public void AddTopping(Topping topping)
        {
            if (NumberOfToppings == 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }
        public int NumberOfToppings
        {
            get => toppings.Count;
        }
        public double Calories
        {
            get
            {
                return Dough.Calories + toppings.Sum(t => t.Calories);
            }
        }
        public override string ToString()
        {
            return $"{Name} - {Calories:f2} Calories.";
        }
    }
}
