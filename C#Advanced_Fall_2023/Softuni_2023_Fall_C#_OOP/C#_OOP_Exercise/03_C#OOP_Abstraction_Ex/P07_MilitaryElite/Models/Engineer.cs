using P07_MilitaryElite.Enums;
using P07_MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07_MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps, IReadOnlyCollection<IRepair> repairs) : base(id, firstName, lastName, salary, corps)
        {
            Repairs = repairs;
        }

        public IReadOnlyCollection<IRepair> Repairs { get; private set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");
            foreach (var repair in Repairs)
            {
                sb.AppendLine($"  {repair.ToString()}");
            }
            return sb.ToString().Trim();
        }
    }
}
