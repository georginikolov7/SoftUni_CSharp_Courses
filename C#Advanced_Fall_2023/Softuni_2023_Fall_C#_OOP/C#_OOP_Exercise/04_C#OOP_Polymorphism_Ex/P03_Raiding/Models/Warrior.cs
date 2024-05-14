using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_Raiding.Models
{
    public class Warrior : Damage
    {
        private const int Power = 100;
        public Warrior(string name) : base(name, Power)
        {

        }
    }
}
