using System.Collections.Generic;
using System;

namespace P04_ListOperations
{
    /* 5 12 42 95 32 1
 Insert 3 0
 Remove 10
 Insert 8 6
 Shift right 1
 Shift left 2
 End*/
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input;
            //1 23 29 18 43 21 20
            while ((input = Console.ReadLine()) != "End")
            {
                int index, number, count;
                //                Add { number} – add the given number to the end of the list
                //• Insert { number}
                //                { index} – insert the number at the given index
                //• Remove { index} – remove the number at the given index
                //• Shift left { count} – first number becomes last. This has to be repeated the specified number of times
                //• Shift right { count} – last number becomes first. To be repeated the specified number of times
                string[] arguments = input.Split();
                string direction;
                if (arguments[0] == "Add")
                {

                    nums.Add(int.Parse(arguments[1]));
                }
                else if (arguments[0] == "Insert")
                {
                    number = int.Parse(arguments[1]);
                    index = int.Parse(arguments[2]);
                    if (!CheckIndex(nums, index))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    nums.Insert(index, number);
                }
                else if (arguments[0] == "Remove")
                {
                    index = int.Parse(arguments[1]);
                    if (!CheckIndex(nums, index))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    nums.RemoveAt(index);
                }
                else if (arguments[0] == "Shift")
                {
                    if (arguments[1] == "left")
                    {
                        ShiftLeft(nums, int.Parse(arguments[2]));
                    }
                    else if (arguments[1] == "right")
                    {
                        ShiftRight(nums, int.Parse(arguments[2]));
                    }

                }


            }
            Console.WriteLine(string.Join(" ", nums));

        }

        static bool CheckIndex(List<int> nums, int index)
        {
            return index >= 0 && index < nums.Count;
        }

        static void ShiftLeft(List<int> nums, int count)
        {

            count %= nums.Count;
            List<int> shiftedList = nums.GetRange(0, count);
            nums.RemoveRange(0,count);
            nums.InsertRange(nums.Count, shiftedList);

        }
        static void ShiftRight(List<int> nums, int count)
        {
            count %= nums.Count;
            //List<int> shiftedList = nums.GetRange(nums.Count - count, count);
            //nums.RemoveRange(nums.Count - count, count);
            //nums.InsertRange(0, shiftedList);

            List<int> shiftedList = nums.GetRange(0,nums.Count-count);
            nums.RemoveRange(0,nums.Count-count);
            nums.AddRange(shiftedList);
        }
    }
}