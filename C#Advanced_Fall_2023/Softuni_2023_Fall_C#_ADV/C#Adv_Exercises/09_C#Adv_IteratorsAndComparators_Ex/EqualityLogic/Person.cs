using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public int CompareTo(Person? other)
        {
            if (Name.CompareTo(other.Name) != 0)
            {
                return Name.CompareTo(other.Name);
            }
            return Age.CompareTo(other.Age);
        }
    }
}
