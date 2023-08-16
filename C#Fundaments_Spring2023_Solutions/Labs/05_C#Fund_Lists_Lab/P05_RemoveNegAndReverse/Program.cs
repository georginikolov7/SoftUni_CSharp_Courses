namespace P05_RemoveNegAndReverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] < 0)
                {
                    nums.RemoveAt(i--);
                }
            }

            if (nums.Count>0)
            {
                nums.Reverse();
                Console.WriteLine(string.Join(" ", nums));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}