using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EqualityLogic
{
    public class PersonComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person? x, Person? y)
        {
            return x.Name.CompareTo(y.Name) == 0
                && x.Age.CompareTo(y.Age) == 0;
        }

        public int GetHashCode([DisallowNull] Person obj)
        {
            return obj.Age+obj.Name.GetHashCode()*17;
        }
    }
}
