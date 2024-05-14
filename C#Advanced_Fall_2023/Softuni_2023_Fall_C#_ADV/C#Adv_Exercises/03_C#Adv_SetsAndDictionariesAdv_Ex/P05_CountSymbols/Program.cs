namespace P05_CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input=Console.ReadLine();
            SortedDictionary<char, int> charsCounts = new();
            foreach(char ch in input)
            {
                if (!charsCounts.ContainsKey(ch))
                {
                    charsCounts.Add(ch, 0);
                }
                charsCounts[ch]++;
            }
            foreach(var kvp in  charsCounts)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}