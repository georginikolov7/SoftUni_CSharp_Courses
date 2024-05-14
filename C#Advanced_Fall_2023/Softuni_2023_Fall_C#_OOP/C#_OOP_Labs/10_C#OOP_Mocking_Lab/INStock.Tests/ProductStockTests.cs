using INStock.Contracts;
using INStock.Models;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;

namespace INStock.Tests
{
    [TestFixture]
    public class ProductStockTests
    {
        private IProductStock productStock;

        private IProduct product;
        [SetUp]
        public void Setup()
        {

            productStock = new ProductStock();
            product = new Product("banana", 5, 10);
        }
        [Test]
        public void AddShouldWorkCorrectly()
        {
            productStock.Add(product);
            Assert.That(productStock.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddShouldThrowException_When2ProductsWithTheSameLabelAreAdded()
        {
            productStock.Add(product);
            Assert.Throws<InvalidOperationException>(() => productStock.Add(product));
        }
        [Test]
        public void ContainsShouldWorkCorrectly()
        {
            productStock.Add(product);
            Assert.That(productStock.Contains(product), Is.True);
        }
        [Test]
        public void FindByIndex_ShouldWorkCorrectly()
        {
            productStock.Add(null);
            productStock.Add(product);
            IProduct testProduct = productStock.Find(1);
            Assert.That(testProduct, Is.EqualTo(product));
        }

        [Test]
        [TestCase(42)]
        [TestCase(-11)]
        [TestCase(0)]
        public void Find_ShouldThrowEx_WhenIndexIsNotInRange(int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() => productStock.Find(index));
        }
        [Test]
        public void FindByLabelShouldWorkCorrectly()
        {
            product = new Product("a", 2, 3);
            productStock.Add(product);
            productStock.Add(new Product("b", 5, 3));
            productStock.Add(new Product("c", 7, 8));
            Assert.That(productStock.FindByLabel("a"), Is.EqualTo(product));
        }
    }
}
