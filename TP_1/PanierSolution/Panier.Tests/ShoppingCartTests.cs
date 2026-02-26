using Panier.Core;

namespace Panier.Tests;

[TestClass]
public class ShoppingCartTests
{
    // Étape 1 — Tests du panier vide

    [TestMethod]
    public void WhenNewCart_Then0Item()
    {
        var cart = new ShoppingCart();
        Assert.AreEqual(0, cart.GetItemCount());
    }

    [TestMethod]
    public void WhenEmptyCart_ThenTotalIs0()
    {
        var cart = new ShoppingCart();
        Assert.AreEqual(0m, cart.GetTotal());
    }

    [TestMethod]
    public void WhenEmptyCart_ApplyDiscount_ThenException()
    {
        var cart = new ShoppingCart();
        Assert.Throws<InvalidOperationException>(() => cart.ApplyDiscount(10m));
    }


    // Étape 2 — Tests d’ajout (validation)
    // Étape 3 — Tests de calcul
    // Étape 4 — Tests de remise
    
}


