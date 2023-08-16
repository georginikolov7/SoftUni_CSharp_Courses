
namespace P02_OddOccurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            input = ConvertAllToLower(input);
            Dictionary<string, int> countOfReps = new Dictionary<string, int>();
            foreach (string s in input)
            {
                if (countOfReps.ContainsKey(s))
                {
                    countOfReps[s]++;
                }
                else
                {
                    countOfReps.Add(s, 1);
                }
            }
            foreach (var kvp in countOfReps)
            {
                if (kvp.Value % 2 != 0)
                {
                    Console.Write($"{kvp.Key} ");
                }
            }
        }


        static string[] ConvertAllToLower(string[] input)
        {
            return input
                .Select(x => x.ToLower())
                .ToArray();
        }
    }
}