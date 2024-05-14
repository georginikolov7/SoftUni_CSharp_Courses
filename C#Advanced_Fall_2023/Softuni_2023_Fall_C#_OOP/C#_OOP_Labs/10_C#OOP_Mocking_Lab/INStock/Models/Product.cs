using INStock.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INStock.Models
{
    public class Product : IProduct
    {
        private decimal price;
        private string label;
        private int quantity;
        public Product(string label, decimal price, int quantity)
        {
            Label = label;
            Price = price;
            Quantity = quantity;
        }

        public string Label
        {
            get => label; private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid name");
                }
                label = value;
            }
        }

        public decimal Price
        {
            get => price; private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative");
                }
                price = value;
            }
        }

        public int Quantity
        {
            get => quantity; private set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Quantity cannot be negative");
                }
                quantity = value;
            }
        }

        public int CompareTo(IProduct other)
        {
            return Label.CompareTo(other.Label);
        }
    }
}
