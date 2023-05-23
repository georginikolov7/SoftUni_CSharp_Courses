using System;
namespace P04_Refactoring_PrimeChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lastNum = int.Parse(Console.ReadLine());
            for (int currentNum = 2; currentNum <= lastNum; currentNum++)
            {
                bool isPrime = true;
                for (int devisor = 2; devisor < currentNum; devisor++)
                {
                    if (currentNum % devisor == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine("{0} -> {1}", currentNum, isPrime.ToString().ToLower());
            }
        }
    }
}