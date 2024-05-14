using P08_CollectionHierarchy.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P08_CollectionHierarchy.Models
{
    public class MyList : IRemovable
    {
        private const int IndexToAdd = 0,IndexToRemove = 0;
        private readonly List<string> list = new();
        public int Used { get => list.Count; }
        public int Add(string element)
        {

            list.Insert(IndexToAdd, element);
            return IndexToAdd;
        }

        public string Remove()
        {
            string element = list[0];
            list.RemoveAt(0);
            return element;
        }
    }
}
