using System;
using System.Linq;
using System.Collections.Generic;
namespace P07_ListManipAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            bool isChanged = false;
            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string type;
                int number;
                int index;
                string[] operation = command.Split().ToArray();
                if (operation[0] == "Contains")
                {
                    number = int.Parse(operation[1]);
                    PrintContains(nums, number);
                }
                else if (operation[0] == "PrintEven")
                {
                    type = "even";
                    PrintEvenOdd(nums, type);
                }
                else if (operation[0] == "PrintOdd")
                {
                    type = "odd";
                    PrintEvenOdd(nums, type);
                }
                else if (operation[0] == "GetSum")
                {
                    Console.WriteLine(nums.Sum());
                }
                else if (operation[0] == "Filter")
                {
                    string condition = operation[1];
                    number = int.Parse(operation[2]);
                    Filter(nums, condition, number);
                }
                else
                {
                    isChanged = true;
                    if (operation[0] == "Add")
                    {
                        number = int.Parse(operation[1]);
                        nums.Add(number);
                    }
                    else if (operation[0] == "Remove")
                    {
                        number = int.Parse(operation[1]);
                        nums.Remove(number);
                    }
                    else if (operation[0] == "RemoveAt")
                    {
                        index = int.Parse(operation[1]);
                        nums.RemoveAt(index);
                    }
                    else if (operation[0] == "Insert")
                    {
                        number = int.Parse(operation[1]);
                        index = int.Parse(operation[2]);
                        nums.Insert(index, number);
                    }
                }
            }
            if (isChanged == true)
            {
                Console.WriteLine(string.Join(" ", nums));
            }

        }

        static void Filter(List<int> nums, string condition, int number)
        {

            for (int i = 0; i < nums.Count; i++)
            {
                if (condition == ">" && nums[i] > number)
                {
                    Console.Write(nums[i] + " ");
                }
                else if (condition == "<" && nums[i] < number)
                {
                    Console.Write(nums[i] + " ");
                }
                else if (condition == ">=" && nums[i] >= number)
                {
                    Console.Write(nums[i] + " ");
                }
                else if (condition == "<=" && nums[i] <= number)
                {
                    Console.Write(nums[i] + " ");
                }
            }
            Console.WriteLine();
        }

        static void PrintEvenOdd(List<int> nums, string type)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                if (CheckEvenOrOdd(nums[i], type))
                {
                    Console.Write($"{nums[i]} ");
                }
            }
            Console.WriteLine();
        }

        static bool CheckEvenOrOdd(int number, string type)
        {
            return (number % 2 == 0 && type == "even") || (number % 2 != 0 && type == "odd");
        }

        static void PrintContains(List<int> nums, int number)
        {
            if (nums.Contains(number))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
        }
    }
}
