using P08_CollectionHierarchy.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace P08_CollectionHierarchy.Models
{
    public class AddCollection : IAdeable
    {
        private readonly List<string> list=new();

        public int Add(string element)
        {
            list.Add(element);
            return list.Count - 1;
        }
    }
}
