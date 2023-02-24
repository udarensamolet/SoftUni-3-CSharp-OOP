using INStock.Contracts;
using System.Diagnostics.CodeAnalysis;
using System;

namespace INStock.Models
{
    public class Product : IProduct
    {
        private string label;
        private decimal price;
        private int quantity;

        public Product(string label, decimal price, int quantity)
        {
            Label = label;
            Price = price;
            Quantity = quantity;
        }

        public string Label
        {
            get => label;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Label cannot be empty!");
                }
                label = value;
            }
        }
        public decimal Price
        {
            get => price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Label cannot be below 0 or equal to 0!");
                }
                price = value;
            }
        }

        public int Quantity
        {
            get => quantity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Quantity cannot be below 0!");
                }
                quantity = value;
            }
        }

        public int CompareTo([AllowNull] IProduct other)
        {
            throw new System.NotImplementedException();
        }
    }
}
