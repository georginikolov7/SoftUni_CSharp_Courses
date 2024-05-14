using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_Raiding.Models
{
    public class Paladin : Healer
    {
        private const int Power = 100;
        public Paladin(string name) : base(name, Power)
        {
        }
    }
}
