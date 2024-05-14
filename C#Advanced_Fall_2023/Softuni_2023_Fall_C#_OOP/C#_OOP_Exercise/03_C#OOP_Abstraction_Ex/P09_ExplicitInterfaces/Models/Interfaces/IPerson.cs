using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P09_ExplicitInterfaces.Models.Interfaces
{
    public interface IPerson
    {
        string Name { get; }
        public int Age { get; }
        public string GetName();
    }
}
