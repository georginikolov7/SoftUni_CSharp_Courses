using System.Collections.Concurrent;
using System.Collections.Generic;

namespace P08_AnonymousThreat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> data = Console.ReadLine()
                .Split()
                .ToList();
            string input;
            while ((input = Console.ReadLine()) != "3:1")
            {
                string[] command = input.Split().ToArray();
                if (command[0] == "merge")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);
                    MergeData(data, startIndex, endIndex);
                }
                else if (command[0] == "divide")
                {
                    int index = int.Parse(command[1]);
                    int numOfPartions = int.Parse(command[2]);
                    DivideData(data, index, numOfPartions);
                }
            }
            Console.WriteLine(string.Join(" ", data));
        }

        static void DivideData(List<string> data, int index, int numOfPartitions)
        {
            string text = data[index];
            if (numOfPartitions <= 0)
            {
                return;
            }
            data.RemoveRange(index, 1);
            int sublength = text.Length / numOfPartitions;
            int remainingChars = text.Length % numOfPartitions;
            List<string> newElements=new List<string>();
            int elementIndex = 0;
            for (int i = 0; i < numOfPartitions; i++)
            {
                string newString = string.Empty;
                for (int j = 0; j < sublength; j++)
                {
                    newString += text[elementIndex];
                    elementIndex++;
                }
                newElements.Add(newString);
            }
            if(remainingChars > 0)
            {
                for (int i = elementIndex; i < text.Length; i++)
                {
                    newElements[newElements.Count - 1] += text[i];
                }
            }
        }

        static void MergeData(List<string> data, int startIndex, int endIndex)
        {
            startIndex = Clamp(startIndex, 0, data.Count-1);
            endIndex =Clamp(endIndex, 0, data.Count-1);
            string temp = string.Empty;
            for (int i = startIndex; i <= endIndex; i++)
            {
                temp += data[startIndex];
                data.RemoveAt(startIndex);
            }
            data.Insert(startIndex, temp);
        }

        static int Clamp(int value, int minValue, int maxValue)
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > maxValue)
            {
                value = maxValue;
            }
            return value;
        }
    }
}