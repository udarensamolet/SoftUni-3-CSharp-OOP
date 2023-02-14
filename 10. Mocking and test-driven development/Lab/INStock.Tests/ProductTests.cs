namespace INStock.Tests
{
    using INStock.Models;
    using NUnit.Framework;
    using System;

    public class ProductTests
    {
        [Test]
        public void Ctor_InitializeCorrectly()
        {
            string label = "Milk";
            decimal price = 10.5m;
            int quantity = 3;

            Product product = new Product(label, price, quantity);

            Assert.AreEqual(label, product.Label);
            Assert.AreEqual(price, product.Price);
            Assert.AreEqual(quantity, product.Quantity);
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Ctor_ThrowsExceptionLabelIsInvalid(string label)
        {
            decimal price = 10.5m;
            int quantity = 3;

            Assert.Throws<ArgumentNullException>(() => new Product(label, price, quantity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void Ctor_ThrowsExceptionPriceIsInvalid(decimal price)
        {
            string label = "Milk";
            int quantity = 5;

            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(label, price, quantity));
        }

        [Test]
        [TestCase(-5)]
        public void Ctor_ThrowsExceptionQuantityIsInvalid(int quantity)
        {
            string label = "Milk";
            decimal price = 10.5m;

            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(label, price, quantity));
        }

          
    }
}