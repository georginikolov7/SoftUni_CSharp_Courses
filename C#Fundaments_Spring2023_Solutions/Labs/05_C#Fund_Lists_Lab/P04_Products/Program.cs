namespace P04_Products
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> products = new List<string>();
            for (int i = 0; i <n; i++)
            {
                products.Add(Console.ReadLine());
            }
            products.Sort();
            int number = 1;
            foreach (string product in products)
            {
                Console.WriteLine($"{number}.{product}");
                number++;
            }

        }
    }
}