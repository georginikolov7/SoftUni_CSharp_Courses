using System;
namespace P05_TriplesOfLatinLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 97; i < n+'a'; i++)
            {
                for (int j = 97; j < n+'a'; j++)
                {
                    for (int k = 97; k < n+'a'; k++)
                    {
                        Console.WriteLine($"{(char)i}{(char)j}{(char)k}");
                    }
                }
            }
        }
    }
}