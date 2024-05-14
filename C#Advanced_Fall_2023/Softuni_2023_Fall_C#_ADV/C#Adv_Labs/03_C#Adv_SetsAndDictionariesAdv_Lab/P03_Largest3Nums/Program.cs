namespace P03_Largest3Nums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int[] sorted = nums.OrderByDescending(x => x).ToArray();
            int countOfNums = 3;
            if (sorted.Length < countOfNums)
            {
                countOfNums = sorted.Length;
            }
            for (int i = 0; i < countOfNums; i++)
            {
                Console.Write(sorted[i] + " ");
            }
        }
    }
}