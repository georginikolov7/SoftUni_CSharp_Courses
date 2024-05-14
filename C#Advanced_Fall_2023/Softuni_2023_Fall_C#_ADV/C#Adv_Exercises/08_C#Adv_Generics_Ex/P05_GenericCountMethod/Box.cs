using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05_GenericCountMethod
{
    public class Box<T> where T : IComparable<T>,IComparable
    {
        public Box(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public override string ToString()
        {
            return $"{typeof(T)}: {Value}";
        }
    }
}
