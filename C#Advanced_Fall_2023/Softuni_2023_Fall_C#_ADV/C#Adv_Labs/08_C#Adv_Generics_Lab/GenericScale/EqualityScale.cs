using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericScale
{
    public class EqualityScale<T> where T: IEquatable<T>
    {
        public EqualityScale(T left,T right)
        {
            this.left = left;
            this.right = right;
        }
        private T left;
        private T right;

        


        public  bool AreEqual()
        {
            return left.Equals(right);
        }
    }
}
