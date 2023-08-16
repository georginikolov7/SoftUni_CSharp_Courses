using System;
using System.Linq;
using System.Reflection;

namespace P11_arrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split(" ").ToArray();
                string oddOrEven;
                int count;
                switch (command[0])
                {
                    case "exchange":
                        int index = int.Parse(command[1]);
                        Exchange(index,  inputArray);
                        break;

                    case "max":
                        oddOrEven = command[1];        //even or odd
                        PrintMax(inputArray, oddOrEven);
                        break;

                    case "min":
                        oddOrEven = command[1];        //even or odd
                        PrintMin(inputArray, oddOrEven);
                        break;
                    case "first":
                        count = int.Parse(command[1]);
                        oddOrEven = command[2];
                        PrintFirst(inputArray, count, oddOrEven);
                        break;
                    case "last":
                        count = int.Parse(command[1]);
                        oddOrEven = command[2];
                        PrintLast(inputArray, count, oddOrEven);
                        break;
                }

            }
            Console.WriteLine($"[{string.Join(", ", inputArray)}]");
        }

        static void Exchange(int startIndex,  int[] inputArray)
        {
            if (startIndex < 0 || startIndex >= inputArray.Length)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            int[] tempArray = new int[inputArray.Length];
            int tempArrayIndex = 0;
            for (int i = startIndex + 1; i < inputArray.Length; i++)
            {
                tempArray[tempArrayIndex++] = inputArray[i];
            }
            for (int i = 0; i <= startIndex; i++)
            {
                tempArray[tempArrayIndex++] = inputArray[i];
            }
            inputArray = tempArray;
        }
        static void PrintMax(int[] inputArray, string numType)
        {
            int maxValue = int.MinValue;
            int index = -1;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (DoesNumTypeMatchElement(inputArray[i], numType))
                {
                    if (inputArray[i] >= maxValue)
                    {
                        maxValue = inputArray[i];
                        index = i;
                    }
                }
            }
            if (index == -1)
            {
                Console.WriteLine("No matches");
            }
            else Console.WriteLine(index);
        }
        static void PrintMin(int[] inputArray, string numType)
        {
            int minValue = int.MaxValue;
            int index = -1;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (DoesNumTypeMatchElement(inputArray[i], numType))
                {
                    if (inputArray[i] <= minValue)
                    {
                        minValue = inputArray[i];
                        index = i;
                    }
                }
            }
            if (index == -1)
            {
                Console.WriteLine("No matches");
            }
            else Console.WriteLine(index);
        }
        static void PrintFirst(int[] inputArray, int count, string numType)
        {
            int valuesCount = 0;
            List<int> values = new List<int>();
            if (!CheckInputCount(count, inputArray)) return;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (DoesNumTypeMatchElement(inputArray[i], numType))
                {
                    values.Add(inputArray[i]);
                    valuesCount++;
                    if (valuesCount == count)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine($"[{string.Join(", ", values)}]");
        }
        static void PrintLast(int[] inputArray, int count, string oddOrEven)
        {
            if (!CheckInputCount(count, inputArray))
            {
                return;
            }
            int valuesCount = 0;
            List<int> values = new List<int>();
            for (int i = inputArray.Length - 1; i >= 0; i--)
            {
                if (DoesNumTypeMatchElement(inputArray[i], oddOrEven))
                {
                    values.Add(inputArray[i]);
                    valuesCount++;
                    if (valuesCount == count)
                    {
                        break;
                    }
                }
            }
            values.Reverse();
            Console.WriteLine($"[{string.Join(", ", values)}]");
        }


        static bool CheckInputCount(int count, int[] inputArray)
        {
            if (count > inputArray.Length)
            {
                Console.WriteLine("Invalid count");
                return false;

            }
            return true;
        }
        static bool DoesNumTypeMatchElement(int number, string numType)
        {
            return (number % 2 == 0 && numType == "even") || (number % 2 != 0 && numType == "odd");
        }

    }
}