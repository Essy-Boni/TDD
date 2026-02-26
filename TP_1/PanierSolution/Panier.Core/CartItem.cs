using System;
using System.Collections.Generic;
using System.Text;

namespace Panier.Core
{
    public sealed class CartItem
    {
        public CartItem(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public string Name { get; }
        public decimal Price { get; }
        public int Quantity { get; }
    }
}
