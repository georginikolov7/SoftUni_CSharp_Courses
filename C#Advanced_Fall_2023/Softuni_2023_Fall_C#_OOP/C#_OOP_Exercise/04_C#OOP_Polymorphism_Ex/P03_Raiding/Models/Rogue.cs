using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_Raiding.Models
{
    public class Rogue : Damage
    {
        private const int Power = 80;
        public Rogue(string name) : base(name, Power)
        {
        }
    }
}
