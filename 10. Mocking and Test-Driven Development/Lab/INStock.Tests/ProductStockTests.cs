namespace INStock.Tests
{
    using INStock.Contracts;
    using INStock.Models;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductStockTests
    {
        private ProductStock productStock;

        [SetUp]
        public void SetUp()
        {
            productStock = new ProductStock();
        }


        [Test]
        public void Ctor_InitializeInstanceCorrecly()
        {
            Assert.AreEqual(0, productStock.Count);
        }

        [Test]
        public void Ctor_InitializeProductCorrectly()
        {
            Product product = new Product("Milk", 9, 3);
            productStock.Add(product);
            var resultProduct = productStock[0];

            string expectedLabel = "Milk";
            decimal expectedPrice = 9;
            int expectedQuantity = 3;

            Assert.AreEqual(expectedPrice, resultProduct.Price);
            Assert.AreEqual(expectedLabel, resultProduct.Label);
            Assert.AreEqual(expectedQuantity, resultProduct.Quantity);
        }


        [Test]
        public void Add_CountIncreases()
        {
            Product product = new Product("Milk", 10, 3);
            productStock.Add(product);
            Assert.AreEqual(1, productStock.Count);
        }

        [Test]
        public void Add_ThrowsExceptionWhenAddedSameProduct()
        {
            Product product = new Product("Milk", 10, 3);
            productStock.Add(product);
            Assert.Throws<Exception>(() => productStock.Add(product));
        }

        [Test]
        public void Contains_ReturnsTrueWhenSearchingForAddedProduct()
        {
            Product product = new Product("Milk", 10, 3);
            productStock.Add(product);
            bool result = productStock.Contains(product);
            Assert.IsTrue(result);
        }

        [Test]
        public void Contains_ReturnsFalseWhenSearchingForAddedProduct()
        {
            Product product = new Product("Milk", 10, 3);
            bool result = productStock.Contains(product);
            Assert.IsFalse(result);
        }

        [Test]
        public void Find_ReturnsTargetProduct()
        {
            Product product = new Product("Milk", 10, 3);
            productStock.Add(product);
            int index = 0;
            var resultProduct = productStock.Find(index);
            string expectedLabel = "Milk";
            decimal expectedPrice = 10;
            int expectedQuantity = 3;

            Assert.AreEqual(expectedPrice, resultProduct.Price);
            Assert.AreEqual(expectedLabel, resultProduct.Label);
            Assert.AreEqual(expectedQuantity, resultProduct.Quantity);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(2)]
        public void Find_ThrowsExceptionInvalidIndex(int index)
        {
            Product product = new Product("Milk", 10, 3);
            productStock.Add(product);
            Assert.Throws<IndexOutOfRangeException>(() => productStock.Find(index));
        }

        [Test]
        public void FindAllByPrice_ReturnsAllProductsWithGivenPrice()
        {
            Product product1 = new Product("Milk", 1, 1);
            Product product2 = new Product("Bread", 10, 2);
            Product product3 = new Product("Alcohol", 10, 3);
            Product product4 = new Product("Chocolate", 1, 1);
            Product product5 = new Product("Carrot", 10, 2);
            Product product6 = new Product("Cheese", 10, 3);

            productStock.Add(product1);
            productStock.Add(product2);
            productStock.Add(product3);
            productStock.Add(product4);
            productStock.Add(product5);
            productStock.Add(product6);

            List<IProduct> expectedResult = new List<IProduct>
            {
                product1,
                product4
            };

            List<IProduct> actualResult = productStock.FindAllByPrice(1).ToList();

            Assert.AreEqual(expectedResult.Count, actualResult.Count);
        }

        [Test]
        public void FindAllByQuantity_ReturnAllProductsWithGivenQuantity()
        {
            Product product1 = new Product("Milk", 1, 1);
            Product product2 = new Product("Bread", 10, 2);
            Product product3 = new Product("Alcohol", 10, 3);
            Product product4 = new Product("Chocolate", 1, 1);
            Product product5 = new Product("Carrot", 10, 2);
            Product product6 = new Product("Cheese", 10, 3);

            productStock.Add(product1);
            productStock.Add(product2);
            productStock.Add(product3);
            productStock.Add(product4);
            productStock.Add(product5);
            productStock.Add(product6);

            List<IProduct> expectedResult = new List<IProduct>
            {
                product1,
                product4
            };

            List<IProduct> actualResult = productStock.FindAllByQuantity(1).ToList();

            Assert.AreEqual(expectedResult.Count, actualResult.Count);
        }

        [Test]
        public void FindAllInRange_ReturnsProductsInGivenRange()
        {
            Product product1 = new Product("Milk", 10, 1);
            Product product2 = new Product("Bread", 20, 2);
            Product product3 = new Product("Alcohol", 30, 3);
            Product product4 = new Product("Chocolate", 10, 1);
            Product product5 = new Product("Carrot", 20, 2);
            Product product6 = new Product("Cheese", 30, 3);

            productStock.Add(product1);
            productStock.Add(product2);
            productStock.Add(product3);
            productStock.Add(product4);
            productStock.Add(product5);
            productStock.Add(product6);

            List<IProduct> expectedResult = new List<IProduct>
            {
                product2,
                product5
            };

            List<IProduct> actualResult = productStock.FindAllInRange(15, 25).ToList();

            Assert.AreEqual(expectedResult.Count, actualResult.Count);
        }

        [Test]
        public void FindByLabel_ReturnsTargetProduct()
        {
            Product product1 = new Product("Milk", 10, 3);
            Product product2 = new Product("Cheese", 10, 3);
            Product product3 = new Product("Bread", 10, 3);
            productStock.Add(product1);
            productStock.Add(product2);
            productStock.Add(product3);
            string targetLabel = "Milk";

            var resultProduct = productStock.FindByLabel(targetLabel);

            string expectedLabel = "Milk";
            decimal expectedPrice = 10;
            int expectedQuantity = 3;

            Assert.AreEqual(expectedPrice, resultProduct.Price);
            Assert.AreEqual(expectedLabel, resultProduct.Label);
            Assert.AreEqual(expectedQuantity, resultProduct.Quantity);
        }

        [Test]
        public void FindMostExpensiveProduct_ReturnsTargetProduct()
        {
            Product product1 = new Product("Milk", 10, 1);
            Product product2 = new Product("Cheese", 20, 3);
            Product product3 = new Product("Bread", 110, 3);
            productStock.Add(product1);
            productStock.Add(product2);
            productStock.Add(product3);

            var resultProduct = productStock.FindMostExpensiveProduct();

            string expectedLabel = "Bread";
            decimal expectedPrice = 110;
            int expectedQuantity = 3;

            Assert.AreEqual(expectedPrice, resultProduct.Price);
            Assert.AreEqual(expectedLabel, resultProduct.Label);
            Assert.AreEqual(expectedQuantity, resultProduct.Quantity);
        }

        [Test]
        public void Remove_ReturnsTrue()
        {
            Product product1 = new Product("Milk", 10, 1);
            Product product2 = new Product("Cheese", 20, 3);
            Product product3 = new Product("Bread", 110, 3);
            productStock.Add(product1);
            productStock.Add(product2);
            productStock.Add(product3);

            var result = productStock.Remove(product1);
            Assert.IsTrue(result);
            Assert.AreEqual(2, productStock.Count);
        }

        [Test]
        public void Remove_ReturnsFalse()
        {
            Product product1 = new Product("Milk", 10, 1);
            Product product2 = new Product("Cheese", 20, 3);
            Product product3 = new Product("Bread", 110, 3);
            productStock.Add(product1);
            productStock.Add(product2);

            var result = productStock.Remove(product3);
            Assert.IsFalse(result);
            Assert.AreEqual(2, productStock.Count);
        }

        [Test]
        public void GetEnumerator_ReturnsAllProducts()
        {
            Product product1 = new Product("Milk", 10, 1);
            Product product2 = new Product("Cheese", 20, 3);
            Product product3 = new Product("Bread", 110, 3);
            productStock.Add(product1);
            productStock.Add(product2);
            productStock.Add(product3);
        }






    }
}
