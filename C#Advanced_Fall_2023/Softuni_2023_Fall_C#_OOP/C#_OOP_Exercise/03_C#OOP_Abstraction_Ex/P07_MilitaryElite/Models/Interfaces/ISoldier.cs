using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07_MilitaryElite.Models.Interfaces
{
    public interface ISoldier
    {
        int Id { get; }
        string FirstName { get; }
        string LastName { get; }
    }
}
