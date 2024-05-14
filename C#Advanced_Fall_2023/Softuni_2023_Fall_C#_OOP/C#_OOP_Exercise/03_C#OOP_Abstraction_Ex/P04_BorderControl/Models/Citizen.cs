using P04_BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04_BorderControl.Models
{
    public class Citizen : IIdentifiable
    {
        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
    }
}
