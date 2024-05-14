using P09_ExplicitInterfaces.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P09_ExplicitInterfaces.Models
{
    internal class Citizen : IPerson, IResident
    {
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }

        public string Name { get; private set; }

        public string Country { get; private set; }

        public int Age { get; private set; }

        string IPerson.GetName()
        {
            return Name;
        }
        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {Name}";
        }
    }
}
