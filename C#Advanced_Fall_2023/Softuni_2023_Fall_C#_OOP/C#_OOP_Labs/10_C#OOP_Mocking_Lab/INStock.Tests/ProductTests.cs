using INStock.Contracts;
using INStock.Models;
using NUnit.Framework;
using System;

namespace INStock.Tests
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            IProduct product = new Product("banana", 2.87m, 5);
            Assert.IsNotNull(product);
            Assert.That(product.Label, Is.EqualTo("banana"));
            Assert.That(product.Price, Is.EqualTo(2.87m));
            Assert.That(product.Quantity, Is.EqualTo(5));
        }
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Constructor_ShouldThrowException_WhenLabelIsNullOrWhiteSpace(string label)
        {

            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                IProduct product = new Product(label, 2.87m, 5);
            });
            Assert.That(ex.Message, Is.EqualTo("Invalid name"));
        }
        [Test]
        [TestCase(-1)]
        [TestCase(-3)]
        [TestCase(-42.5)]
        public void Constructor_ShouldThrowException_WhenPriceIsNegative(decimal price)
        {

            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                IProduct product = new Product("Ivan", price, 5);
            });
            Assert.That(ex.Message, Is.EqualTo("Price cannot be negative"));
        }
        [Test]
        [TestCase(-1)]
        [TestCase(-3)]
        [TestCase(-42)]
        public void Constructor_ShouldThrowException_WhenQuantityIsNegative(int q)
        {

            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                IProduct product = new Product("Ivan", 5m, q);
            });
            Assert.That(ex.Message, Is.EqualTo("Quantity cannot be negative"));
        }
        [Test]
        public void CompareToShouldReturn0IfLabelsAreEqual()
        {
            Product product1 = new Product("glen", 65, 1);
            Product product2 = new Product("glen", 100, 2);
            Assert.That(product1.CompareTo(product2), Is.EqualTo(0));
        }

    }
}
