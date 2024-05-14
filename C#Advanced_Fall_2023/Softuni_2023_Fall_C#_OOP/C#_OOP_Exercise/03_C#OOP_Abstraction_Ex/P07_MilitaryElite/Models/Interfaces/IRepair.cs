using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07_MilitaryElite.Models.Interfaces
{
    public interface IRepair
    {
        public string PartName { get; }
        public int HoursWorked { get; }
    }
}
