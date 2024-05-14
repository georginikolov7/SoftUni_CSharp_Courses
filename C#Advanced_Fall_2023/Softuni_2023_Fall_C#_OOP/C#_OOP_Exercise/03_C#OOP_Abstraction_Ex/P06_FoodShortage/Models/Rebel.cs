using P04_BorderControl.Models.Interfaces;
using P05_Birthday.Models.Interfaces;
using P06_FoodShortage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06_FoodShortage.Models
{
    internal class Rebel : IBuyer
    {
        private const int FoodIncrement = 5;
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Group { get; private set; }
        public int Food { get; private set; }


        public int BuyFood()
        {
            Food += FoodIncrement;
            return FoodIncrement;
        }
    }
}
