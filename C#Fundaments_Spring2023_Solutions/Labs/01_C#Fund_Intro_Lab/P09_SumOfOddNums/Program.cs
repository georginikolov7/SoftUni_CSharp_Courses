using System;

namespace P09_SumOfOddNums
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int n=int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i <= n+n-1; i+=2)  //1 3 5 7 9 
            {
                sum += i;
                Console.WriteLine(i);
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
