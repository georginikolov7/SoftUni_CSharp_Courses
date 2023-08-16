namespace P03_Orders
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public void UpdatePrice(double newPrice)
        {
            Price = newPrice;
        }
        public override string ToString()
        {
            return $"{Name} -> {Price * Quantity:f2}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            string input;
            while ((input = Console.ReadLine()) != "buy")
            {
                string[] tokens = input.Split();
                string product = tokens[0];
                double currentPrice = double.Parse(tokens[1]);
                int currentQuantity = int.Parse(tokens[2]);
                if (!products.ContainsKey(product))
                {
                    products.Add(product, new Product { Name = product, Price = currentPrice, Quantity = currentQuantity });
                }

                else
                {
                    products[product].Quantity += currentQuantity;
                    products[product].UpdatePrice(currentPrice);
                }
            }
            foreach(Product product in products.Values)
            {
                Console.WriteLine(product);
            }

        }
    }
}