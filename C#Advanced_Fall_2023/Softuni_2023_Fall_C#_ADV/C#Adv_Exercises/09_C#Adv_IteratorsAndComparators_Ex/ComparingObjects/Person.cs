using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public string Town
        {
            get { return town; }
            set { town = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int CompareTo(Person other)
        {
            int result = this.name.CompareTo(other.name);
            if (result == 0)
            {
                result = this.age.CompareTo(other.age);
                if (result == 0)
                {
                    result = this.town.CompareTo(other.town);
                }
            }
            return result;
        }
    }
}
