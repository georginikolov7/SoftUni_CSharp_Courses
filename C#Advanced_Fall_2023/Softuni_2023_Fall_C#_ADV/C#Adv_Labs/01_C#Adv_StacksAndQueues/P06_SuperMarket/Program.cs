namespace P06_SuperMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customers = new Queue<string>();
            string input;
            while ((input=Console.ReadLine())!="End")
            {
                if (input == "Paid")
                {
                    while (customers.Count > 0)
                    {
                        Console.WriteLine(customers.Dequeue());
                    }
                    continue;
                }
                customers.Enqueue(input);
            }
            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}