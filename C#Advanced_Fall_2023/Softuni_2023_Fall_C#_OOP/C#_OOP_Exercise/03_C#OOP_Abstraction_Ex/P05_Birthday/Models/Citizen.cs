using P04_BorderControl.Models.Interfaces;
using P05_Birthday.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04_BorderControl.Models
{
    public class Citizen : IIdentifiable, INameable, IBirthable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }

        public string Birthdate { get; private set; }
    }
}
