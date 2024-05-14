using P07_MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07_MilitaryElite.Models
{
    internal class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNumber) : base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }
        public override string ToString()
        {
            return base.ToString() + $"\nCode Number: {CodeNumber}";
        }
    }
}
