using P05_Birthday.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05_Birthday.Models
{
    public class Pet : IBirthable, INameable
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; private set; }
        public string Birthdate { get; private set; }

    }
}
