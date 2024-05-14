using P08_CollectionHierarchy.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P08_CollectionHierarchy.Models
{
    public class AddRemoveCollection : IRemovable
    {
        private readonly List<string> list = new();

        public int Add(string element)
        {
            list.Insert(0, element);
            return 0;
        }

        public string Remove()
        {
            string element = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return element;
        }
    }
}
