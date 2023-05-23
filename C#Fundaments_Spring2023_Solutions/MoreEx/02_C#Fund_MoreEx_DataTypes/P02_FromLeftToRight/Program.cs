using System;
namespace P02_FromLeftToRight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            string input=string.Empty;
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                int startIndex=input.IndexOf(" ");
                long firstNum = long.Parse(input.Substring(0,startIndex));
                long secondNum =long.Parse(input.Substring(startIndex));
                if (firstNum>secondNum)
                {
                    PrintSumDigits(firstNum);
                }
                else
                {
                    PrintSumDigits(secondNum);
                }
            }
        }

        private static void PrintSumDigits(long num)
        {
            long sum = 0;
            while(num != 0)
            {
                sum += num % 10;
                num /= 10;
            }
            Console.WriteLine(Math.Abs(sum));
        }
    }
}