using System;
using System.Linq;
namespace P06_EvenAndOddSubstraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sumEven = 0
                , sumOdd = 0;
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            foreach (int i in array)
            {
                if (i % 2 == 0)
                {
                    sumEven += i;
                }
                else sumOdd += i;
            }
            Console.WriteLine(sumEven-sumOdd);

        }
    }
}