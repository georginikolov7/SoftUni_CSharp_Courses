using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_Raiding.Models
{
    public class Druid : Healer
    {
        private const int Power = 80;
        public Druid(string name) : base(name, Power)
        {

        }
        
    }
}
