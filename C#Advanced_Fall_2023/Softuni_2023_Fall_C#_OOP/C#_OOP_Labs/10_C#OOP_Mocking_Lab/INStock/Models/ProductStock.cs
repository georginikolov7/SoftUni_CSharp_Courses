using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace INStock.Models
{

    public class ProductStock : IProductStock
    {
        private List<IProduct> products;
        public ProductStock()
        {
            products = new();
        }
        public IProduct this[int index] { get => products[index]; set { products[index] = value; } }

        public int Count => products.Count;

        public void Add(IProduct product)
        {
            if (products.Contains(product))
            {
                throw new InvalidOperationException("Product is already in stock!");
            }
            products.Add(product);
        }

        public bool Contains(IProduct product)
        {
            return products.Contains(product);
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index >= products.Count) { throw new IndexOutOfRangeException("index"); }
            return products[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {
            return products.Where(p => p.Price == price);
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            return products.Where(p => p.Quantity == quantity);
        }

        public IEnumerable<IProduct> FindAllInPriceRange(decimal lo, decimal hi)
        {
            return products.Where(p => p.Price >= lo && p.Price <= hi);
        }

        public IProduct FindByLabel(string label)
        {
            if (!products.Any(p => p.Label == label))
            {
                throw new ArgumentException("Product not found!");

            }
            return products.Single(p => p.Label == label);
        }

        public IProduct FindMostExpensiveProduct()
        {
            return products.OrderByDescending(p => p.Price).FirstOrDefault();
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            foreach (var product in products)
            {
                yield return product;
            }
        }

        public bool Remove(IProduct product)
        {
            if (products.Remove(product))
            {
                return true;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
