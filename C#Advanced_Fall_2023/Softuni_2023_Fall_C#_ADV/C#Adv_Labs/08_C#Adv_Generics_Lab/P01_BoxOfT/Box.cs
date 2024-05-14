using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    public class Box<T>
    {
        public List<T> internalList { get; set; }
        private int count;
        public Box()
        {
            internalList = new List<T>();
        }
        public int Count
        {
            get { return count; }
        }
        public void Add(T element)
        {
            this.internalList.Add(element);
            count++;
        }
        public T Remove()
        {
            T element = internalList[count - 1];
            internalList.RemoveAt(count - 1);
            count--;
            return element;
        }
    }
}
