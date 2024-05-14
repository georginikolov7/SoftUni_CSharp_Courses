namespace P06_Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> colorsClothes = new();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ");
                string currentColor = input[0];
                string[] currentItems = input[1].Split(",");
                if (!colorsClothes.ContainsKey(currentColor))
                {
                    colorsClothes.Add(currentColor, new Dictionary<string, int>());
                }
                foreach(string item in currentItems)
                {
                    if (!colorsClothes[currentColor].ContainsKey(item))
                    {
                        colorsClothes[currentColor].Add(item, 0);
                    }
                    colorsClothes[currentColor][item]++;
                }
            }

            string[] sought = Console.ReadLine()
                .Split();
            string soughtColor = sought[0];
            string soughtItem = sought[1];
            foreach(var kvp1 in colorsClothes)
            {
                Console.WriteLine($"{kvp1.Key} clothes:");
                foreach(var kvp2 in kvp1.Value)
                {
                    Console.Write($"* {kvp2.Key} - {kvp2.Value}");
                    if(kvp1.Key==soughtColor&& kvp2.Key == soughtItem)
                    {
                        Console.Write(" (found!)");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}