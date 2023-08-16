namespace P02_Gaus_sTrick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            //List<int> sums = new List<int>();
            //for (int i = 0; i < nums.Count / 2; i++)
            //{
            //    sums.Add(nums[i] + nums[nums.Count - 1 - i]);
            //} 
            //if (nums.Count % 2 != 0)
            //{
            //    sums.Add(nums[nums.Count / 2]);
            //}
            //Console.WriteLine(string.Join(" ", sums));


            int iterations = nums.Count / 2;
            for (int i = 0; i < iterations; i++)
            {
                nums[i] += nums[nums.Count - 1];
                nums.RemoveAt(nums.Count - 1);
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}