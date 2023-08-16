using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int[] input = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();
            int bombNumber = input[0];
            int power = input[1];
            while (numbers.Contains(bombNumber))
            {
                int bombIndex = numbers.IndexOf(bombNumber);
                int leftIndex = bombIndex - power;
                if (leftIndex < 0) leftIndex = 0;
                int rightIndex = bombIndex + power;
                if (rightIndex >= numbers.Count) rightIndex = numbers.Count - 1;
                int rangeCount = rightIndex - leftIndex + 1;
                numbers.RemoveRange(leftIndex, rangeCount);
                //1 2 2 4 2 2 2 9
                //4 2

            }

            Console.WriteLine(numbers.Sum());

        }


    }
}