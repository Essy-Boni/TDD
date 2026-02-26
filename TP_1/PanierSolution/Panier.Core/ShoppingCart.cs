using System;
using System.Collections.Generic;
using System.Text;

namespace Panier.Core
{
    public sealed class ShoppingCart
    {
        public int GetItemCount() => throw new NotImplementedException();
        public void AddItem(string name, decimal price, int quantity) => throw new NotImplementedException();
        public decimal GetTotal() => throw new NotImplementedException();
        public void ApplyDiscount(decimal percentage) => throw new NotImplementedException();
    }
}
