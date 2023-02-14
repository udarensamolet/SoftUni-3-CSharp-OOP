using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

using INStock.Contracts;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;

namespace INStock.Models
{
    public class ProductStock : IProductStock
    {
        private List<IProduct> products;

        public ProductStock()
        {
            products = new List<IProduct>();
        }

        public IReadOnlyCollection<IProduct> Products => products.AsReadOnly();

        public IProduct this[int index]
        {
            get => products[index];
            set => products[index] = value; 
        }

        public int Count => Products.Count;

        public void Add(IProduct product)
        {
            var targetProduct = Products.FirstOrDefault(p => p.Label == product.Label);
            if (!(targetProduct == null))
            {
                throw new Exception($"Product with label {product.Label} already exists in the collection!");
            }
            products.Add(product);
        }

        public bool Contains(IProduct product)
        {
            var targetProduct = Products.FirstOrDefault(p => p.Label == product.Label);
            if (targetProduct == null)
            {
                return false;
            }
            return true;
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index > this.Count)
            {
                throw new IndexOutOfRangeException("Index is outside the bounds of the collection!");
            }
            var targetProduct = products[index];
            return targetProduct;
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {

            List<IProduct> result = products
                .Where(p => p.Price == (decimal)price)
                .ToList();
            return result;
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            List<IProduct> result = products
                .Where(p => p.Quantity == quantity)
                .ToList();
            return result;
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            List<IProduct> result = products
                .Where(p => p.Price >= (decimal)lo && p.Price <= (decimal)hi)
                .ToList();
            return result.OrderByDescending(x => x.Price);
        }

        public IProduct FindByLabel(string label)
        {
            var target = Products.FirstOrDefault(p => p.Label == label);
            return target;
        }

        public IProduct FindMostExpensiveProduct()
        {
            decimal mostExpensivePrice = decimal.MinValue;
            IProduct mostExpensiveProduct = null;
            foreach (var product in Products)
            {
                if (product.Price > mostExpensivePrice)
                {
                    mostExpensivePrice = product.Price;
                    mostExpensiveProduct = product;
                }
            }
            return mostExpensiveProduct;
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            /*foreach (var product in Products)
            {
                yield return product;
            }*/

            for (int i = 0; i < products.Count; i++)
            {
                yield return products[i];
            }
        }

        public bool Remove(IProduct product)
        {
            var targetProduct = Products.FirstOrDefault(x => x.Label == product.Label);
            if (targetProduct == null)
            {
                return false;
            }
            products.Remove(targetProduct);
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
