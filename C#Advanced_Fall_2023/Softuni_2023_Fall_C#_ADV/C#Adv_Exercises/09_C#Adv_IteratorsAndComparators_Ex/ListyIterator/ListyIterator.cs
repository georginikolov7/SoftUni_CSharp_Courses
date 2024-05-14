using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListyIteratorType
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> items;
        private int index = 0;
        public ListyIterator(List<T> collection)
        {
            this.items = collection;
        }
        public bool Move()
        {
            if (index < this.items.Count - 1)
            {
                index++;
                return true;
            }
            return false;
        }
        public bool HasNext()
        {
            return index < this.items.Count - 1;
        }
        public void Print()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(items[index]);
        }
        public void PrintAll()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            foreach (T item in items)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < items.Count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
