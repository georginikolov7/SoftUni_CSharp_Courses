namespace P01_CountCharsInAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<char, int> charCounts = new Dictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    continue;
                }

                if (!charCounts.ContainsKey(input[i]))
                {
                    charCounts.Add(input[i], 0);
                }

                charCounts[input[i]]++;
            }

            foreach (var kvp in charCounts)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}