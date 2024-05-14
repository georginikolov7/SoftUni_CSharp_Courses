using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Person
    {
        private int age;
        private string name;
        public Person()
        {
            name = "No name";
            age = 1;
        }
        public Person(int age) : this()
        {
            this.age = age;
        }
        public Person(string name,int age):this(age)
        {
            this.name = name;
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
        public override string ToString()
        {
            return $"{name} - {age}";
        }
    }
}
