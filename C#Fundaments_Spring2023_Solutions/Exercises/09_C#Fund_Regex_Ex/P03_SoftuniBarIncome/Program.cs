using System.Text.RegularExpressions;

namespace P03_SoftuniBarIncome
{
    class Customer 
    {
        public Customer(string name, string product, int count, decimal price)
        {
            Name = name;
            Product = product;
            Count = count;
            Price = price;
        }

        public string Name { get; set; }    
        public string Product { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal GetTotalPrice()
        {
            return Price*Count;
        }
        public void Print()
        {
            Console.WriteLine($"{Name}: {Product} - {GetTotalPrice():f2}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers= new List<Customer>();

            string pattern = @"%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|[^|$%.]*?(?<count>\d+)\|[^|$%.]*?(?<price>\d+|\d+\.\d+)\$";
            string input;
            while((input=Console.ReadLine())!="end of shift")
            {
                if(Regex.IsMatch(input, pattern))
                {
                    Match match = Regex.Match(input, pattern);
                    string currentName = match.Groups["name"].Value;
                    string currentProduct = match.Groups["product"].Value;
                    int currentCount =int.Parse( match.Groups["count"].Value);
                    decimal currentPrice = decimal.Parse(match.Groups["price"].Value);
                    Customer currentCustomer = new Customer(currentName, currentProduct, currentCount, currentPrice);
                    customers.Add(currentCustomer);
                    currentCustomer.Print();

                }
            }
            Console.WriteLine($"Total income: {customers.Select(x=>x.GetTotalPrice()).ToList().Sum():f2}");
        }
    }
}