using System;
using System.Security.Cryptography;

namespace P11_MultiTable2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int integer=int.Parse(Console.ReadLine());
            int multiplier=int.Parse(Console.ReadLine());
            if (multiplier > 10)
            {
                Console.WriteLine($"{integer} X {multiplier} = {integer*multiplier}");
            }
            else
            {
                for (int i = multiplier; i <= 10; i++)
                {
                    Console.WriteLine($"{integer} X {i} = {integer * i}");
                }
            }
        }
    }
}
