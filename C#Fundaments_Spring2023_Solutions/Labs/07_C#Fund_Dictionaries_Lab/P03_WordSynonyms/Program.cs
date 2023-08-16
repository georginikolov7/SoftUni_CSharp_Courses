using System.Collections.Generic;

namespace P03_WordSynonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var synonyms = new Dictionary<string, List<string>>();
            int n = int.Parse(Console.ReadLine());
            for ( int i = 0; i < n; i++)
            {
                string key = Console.ReadLine();
                string value = Console.ReadLine();
                if (!synonyms.ContainsKey(key))
                {
                    synonyms.Add(key, new List<string>());
                }

                synonyms[key].Add(value);
            }

            foreach (var kvp in synonyms)
            {
                string words = string.Join(", ", kvp.Value);
                Console.WriteLine($"{kvp.Key} - {words}");
            }
        }
    }
}