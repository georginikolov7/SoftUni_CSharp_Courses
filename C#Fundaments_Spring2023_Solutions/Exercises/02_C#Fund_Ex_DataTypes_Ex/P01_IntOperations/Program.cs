using System;
namespace P01_IntOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2=int.Parse(Console.ReadLine());
            int number3=int.Parse(Console.ReadLine());
            int number4=int.Parse(Console.ReadLine());
            int result;
            result = number2 + number1;
            result /= number3;
            result *= number4;
            Console.WriteLine(result);
        }
    }
}