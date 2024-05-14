using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            products = new();
        }

        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
      
        public void BuyProduct(Product product)
        {
            if (product.Cost <= this.Money)
            {
                products.Add(product);
                Money -= product.Cost;
                Console.WriteLine($"{name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }
        public void PrintProducts()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Name} - ");
            if (products.Count == 0)
            {
                sb.Append("Nothing bought");
            }
            else
            {
                sb.AppendLine(string.Join(", ", products.Select(x => x.Name)));
            }
            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
