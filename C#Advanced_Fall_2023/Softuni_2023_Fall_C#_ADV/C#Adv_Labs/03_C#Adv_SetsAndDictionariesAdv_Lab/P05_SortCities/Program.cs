namespace P05_CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfInputs=int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < countOfInputs; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currentContinent = input[0];
                string currentCountry = input[1];
                string currentCity = input[2];
                if (!continents.ContainsKey(currentContinent))
                {
                    continents[currentContinent] = new Dictionary<string, List<string>>();
                }
                if (!continents[currentContinent].ContainsKey(currentCountry))
                {
                    continents[currentContinent].Add(currentCountry, new List<string>());
                }
                continents[currentContinent][currentCountry].Add(currentCity);
            }
            foreach(var kvp in continents)
            {
                Console.WriteLine($"{kvp.Key}:");
                foreach(var kvp2 in kvp.Value)
                {
                    Console.WriteLine($"{kvp2.Key} -> {string.Join(", ",kvp2.Value)}");
                }
            }
        }
    }
}