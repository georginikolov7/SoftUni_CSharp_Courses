using System;
using System.Runtime.Versioning;

namespace P09_PalindromeInts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                Console.WriteLine(IsPalindrome(input));
            }
        }

        private static bool IsPalindrome(string input)
        {
            //string firstHalf = input.Substring(0, input.Length / 2);
            //string secondHalf = input.Substring((input.Length + 1) / 2, input.Length / 2);
            //char[] arr = secondHalf.ToCharArray();
            //Array.Reverse(arr);
            //secondHalf = new string(arr);
            //return firstHalf == secondHalf;

            //second variant:
            //char[] arr=input.ToCharArray();
            //for (int i = 0; i < (input.Length+1)/2; i++)
            //{
            //    if (arr[i] != arr[arr.Length - i-1])
            //    {
            //        return false;
            //    }
            //}
            //return true;

            //third variant:
            char[] arr=input.ToCharArray();
            Array.Reverse(arr);
            string inversed=new string(arr);
            return input == inversed;
        }
    }
}