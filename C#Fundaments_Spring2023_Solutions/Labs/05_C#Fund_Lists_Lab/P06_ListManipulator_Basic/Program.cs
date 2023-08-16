using System;
using System.Linq;
using System.Collections.Generic;

namespace P06_ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                int number;
                int index;
                string[] operation = command.Split().ToArray();
                switch (operation[0])
                {
                    case "Add":
                        number = int.Parse(operation[1]);
                        nums.Add(number);
                        break;
                    case "Remove":
                        number = int.Parse(operation[1]);
                        nums.Remove(number);
                        break;
                    case "RemoveAt":
                        index = int.Parse(operation[1]);
                        nums.RemoveAt(index);
                        break;
                    case "Insert":
                        number = int.Parse(operation[1]);
                        index = int.Parse(operation[2]);
                        nums.Insert(index, number);
                        break;
                }

            }
            Console.WriteLine(String.Join(" ", nums));
        }
    }
}
