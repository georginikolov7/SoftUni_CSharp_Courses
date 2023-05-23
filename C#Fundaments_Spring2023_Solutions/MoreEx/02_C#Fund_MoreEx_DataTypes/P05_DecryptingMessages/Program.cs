using System;
using System.Net.Http.Headers;

namespace P05_DecryptingMessages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key=int.Parse(Console.ReadLine());
            int numberOfLines=int.Parse(Console.ReadLine());
            string message = string.Empty;
            for (int i = 0; i < numberOfLines; i++)
            {
                char input=char.Parse(Console.ReadLine());
                //decryter:
                input += (char)key;
                message += input;
            }
            Console.WriteLine(message);
        }
    }
}