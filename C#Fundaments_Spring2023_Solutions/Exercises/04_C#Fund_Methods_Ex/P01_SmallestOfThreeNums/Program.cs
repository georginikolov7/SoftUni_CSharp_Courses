using System;

namespace P01_SmallestOfThreeNums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1=int.Parse(Console.ReadLine());
            int num2=int.Parse(Console.ReadLine());
            int num3=int.Parse(Console.ReadLine());
            Console.WriteLine(GetSmallest(num1,num2,num3));
        }

        private static int GetSmallest(int num1, int num2, int num3)
        {
            if (num2 < num1)
            {
                (num1, num2) = (num2,num1);
            }
            if (num3 < num1)
            {
                return (num3);
            }
            else return (num1);
        }
    }
}