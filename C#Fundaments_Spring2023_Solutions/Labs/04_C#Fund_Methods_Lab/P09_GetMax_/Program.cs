using System;
using System.Linq;

namespace P09_GetMax_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();

            if (dataType == "int")
            {
                int input1 = int.Parse(Console.ReadLine());
                int input2 = int.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(input1, input2));
            }
            else if (dataType == "char")
            {
                char input1 = char.Parse(Console.ReadLine());
                char input2 = char.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(input1, input2));
            }
            else if (dataType == "string")
            {
                string input1 = Console.ReadLine();
                string input2 = Console.ReadLine();
                Console.WriteLine(GetMax(input1, input2));
            }
        }
        static int GetMax(int n1, int n2)
        {
            if (n1 > n2) return n1;
            else return n2;
            
        }
        static char GetMax(char ch1, char ch2)
        {
            if (ch1 > ch2) return ch1;
            else return ch2;
            
        }
        static string GetMax(string string1, string string2)
        {
            if (string1.CompareTo(string2)>0)
            {
                return string1;
            }
            else return string2;
        }
    }
}