using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private const int initialCapacity = 4;
        private T[] items;
        public CustomStack()
        {
            items = new T[initialCapacity];
        }
        public int Count
        {
            get; private set;

        }

        public void Push(params T[] inputItems)
        {
            foreach (T item in inputItems)
            {
                items[Count] = item;
                Count++;
                if (Count >= items.Length)
                {
                    Resize();
                }
            }
        }
        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }
            T item = items[Count - 1];
            items[Count - 1] = default;
            Count--;
            return item;
        }
        private void Resize()
        {
            T[] newArray = new T[items.Length * 2];
            for (int i = 0; i < items.Length; i++)
            {
                newArray[i] = items[i];
            }
            items = newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
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
