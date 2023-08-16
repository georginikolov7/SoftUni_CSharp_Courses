using System;
using System.Linq;
using System.Collections.Generic;

namespace P07_AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> finalList = new List<string>();
            List<string> inputList = input.Split('|').ToList();
            for (int i = 0; i < inputList.Count; i++)
            {
                List<string> currentList = inputList[inputList.Count - 1 - i].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                finalList.AddRange(currentList);
            }
            Console.WriteLine(string.Join(" ", finalList));
        }
    }
}
