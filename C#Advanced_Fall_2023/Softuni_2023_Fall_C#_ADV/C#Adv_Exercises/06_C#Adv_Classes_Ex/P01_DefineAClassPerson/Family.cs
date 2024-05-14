using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> members;
        public Family()
        {
            Members = new List<Person>();
        }

        public List<Person> Members
        {
            get { return members; }
            set { members = value; }
        }

       
        public void AddMember(Person member)
        {
            Members.Add(member);
        }
        public Person GetOldestMember()
        {
            return Members.MaxBy(x => x.Age);
        }
    }
}
