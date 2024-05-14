namespace P02_StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            Stack<int> nums = new Stack<int>(input);
            string command;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] splitted = command.Split(' ');
                if (command.Contains("add"))
                {
                    int first = int.Parse(splitted[1]);
                    int second = int.Parse(splitted[2]);
                    nums.Push(first);
                    nums.Push(second);

                }
                else if (command.Contains("remove"))
                {
                    int n = int.Parse(splitted[1]);
                    if (n <= nums.Count)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            nums.Pop();
                        }
                    }
                }
            }
            Console.WriteLine($"Sum: {nums.Sum()}");
        }
    }
}