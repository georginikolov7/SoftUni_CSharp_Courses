using System;
namespace P09_SpiceMustFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            uint currentYield=uint.Parse(Console.ReadLine());
            uint totalMinedSpice = 0;
            uint daysCount = 0;
            while (currentYield >= 100)
            {
                daysCount++;
                totalMinedSpice += currentYield;
                currentYield -= 10;
            }
            uint spiceForWorkers = daysCount * 26 + 26;
            if (spiceForWorkers > totalMinedSpice)
            {
                totalMinedSpice = 0;
            }
            else totalMinedSpice -= spiceForWorkers;
            Console.WriteLine(daysCount);
            Console.WriteLine(totalMinedSpice);
        }
    }
}