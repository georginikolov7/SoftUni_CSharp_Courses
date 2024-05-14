namespace P04_ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, float>> shops = new SortedDictionary<string, Dictionary<string, float>>
               ();
            string input;
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] tokens = input
                    .Split(", ")
                    .ToArray();
                string currentShop = tokens[0];
                string currentProduct = tokens[1];
                float currentPrice = float.Parse(tokens[2]);
                if (!shops.ContainsKey(currentShop))
                {
                    shops[currentShop] = new Dictionary<string, float>();
                }
                shops[currentShop].Add(currentProduct, currentPrice);
            }
            foreach(var kvp in shops)
            {
                Console.WriteLine(kvp.Key+"->");
                foreach(var kvp2 in kvp.Value)
                {
                    Console.WriteLine($"Product: {kvp2.Key}, Price: {kvp2.Value}");
                }
            }
        }
    }
}