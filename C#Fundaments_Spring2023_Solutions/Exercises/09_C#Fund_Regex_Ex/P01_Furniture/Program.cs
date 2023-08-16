using System;
using System.Text.RegularExpressions;

namespace P01_Furniture
{
    class Furniture
    {
        public Furniture(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }


        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total()
        {
            return Price * Quantity;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Furniture> furniture = new List<Furniture>();
            string pattern = @">>(?<name>[a-zA-Z ]+)<<(?<price>\d+|\d+\.\d+)!(?<quantity>\d+)";
            string inputLine;
            Regex regex = new Regex(pattern);
            while ((inputLine = Console.ReadLine()) != "Purchase")
            {
                if (regex.IsMatch(inputLine))
                {
                    Match match = regex.Match(inputLine);
                    string currentName = match.Groups["name"].Value;
                    decimal currentPrice = decimal.Parse(match.Groups["price"].Value);
                    int currentQuantity = int.Parse(match.Groups["quantity"].Value);
                    furniture.Add(new Furniture(currentName, currentPrice, currentQuantity));
                }
            }
            PrintFurniture(furniture);
        }

        static void PrintFurniture(List<Furniture> furniture)
        {
            decimal total = 0;
            Console.WriteLine("Bought furniture:");
            foreach (Furniture furnitureItem in furniture)
            {
                total += furnitureItem.Total();
                Console.WriteLine(furnitureItem.Name);
            }
            Console.WriteLine($"Total money spend: {total:f2}");
        }
    }
}
