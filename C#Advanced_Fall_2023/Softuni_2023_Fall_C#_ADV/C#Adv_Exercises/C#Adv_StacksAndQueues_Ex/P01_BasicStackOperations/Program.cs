namespace P01_BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .ToArray();
            int numsToPush = int.Parse(input[0]);
            int numsToPop = int.Parse(input[1]);
            int[] values = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> nums = new Stack<int>(values.Take(numsToPush));

            int popCount = Math.Min(nums.Count, numsToPop);   //stack can have less elements than numsToPop
            for (int i = 0; i < popCount; i++)
            {
                nums.Pop();
            }

            int numToLookFor = int.Parse(input[2]);
            if (nums.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (nums.Contains(numToLookFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(nums.Min());
            }
        }
    }
}