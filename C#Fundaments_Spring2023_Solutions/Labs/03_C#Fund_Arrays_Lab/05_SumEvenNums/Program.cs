using System.Net.Http.Headers;

namespace _05_SumEvenNums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int sumEvens = 0;


            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 0) sumEvens += nums[i];
            }
            Console.WriteLine(sumEvens);

        }
    }
}