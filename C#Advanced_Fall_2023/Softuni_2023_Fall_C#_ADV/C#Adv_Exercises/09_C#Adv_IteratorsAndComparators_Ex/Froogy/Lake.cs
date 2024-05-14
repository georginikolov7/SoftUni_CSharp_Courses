using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private int[] stoneNumbers;
        public Lake(int[] stoneNumbers)
        {
            this.stoneNumbers = stoneNumbers;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stoneNumbers.Length; i += 2)
            {
                yield return stoneNumbers[i];
            }
            int startIndex= stoneNumbers.Length - 1;
            if (stoneNumbers.Length % 2 != 0)
            {
                startIndex -= 1;
            }
         
            for (int i = startIndex; i >= 0; i-=2)
            {
                yield return stoneNumbers[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()=>GetEnumerator();
        
       
        
    }
}
