using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            int index = new Random().Next(0, this.Count - 1);
            string str = this[index];
            this.RemoveAt(index);
            return str;
        }
    }
}
