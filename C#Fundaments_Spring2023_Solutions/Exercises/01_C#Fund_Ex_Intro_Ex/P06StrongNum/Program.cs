using System;

namespace P06StrongNum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input=Console.ReadLine();
            //strong - A number is strong, if the sum of the factorials of each digit is equal to the number itself.
            int sumOfFact = 0;
            for (int i = 0; i < input.Length; i++)
            {
                //sum of factorials:
                int currFactorial = 1;
                for (int j = int.Parse(input[i].ToString()); j >=1 ; j--)
                {

                    currFactorial *= j;  
                }

                sumOfFact += currFactorial;
            }
            if (sumOfFact == int.Parse(input))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
