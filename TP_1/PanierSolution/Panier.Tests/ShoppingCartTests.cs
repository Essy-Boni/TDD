using Panier.Core;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Panier.Tests;

[TestClass]
public class ShoppingCartTests
{


    // Étape 1 — Tests du panier vide
    #region

    [TestMethod] //Un panier neuf contient 0 article.
    public void WhenNewCart_Then0Item()
    {
        var cart = new ShoppingCart();
        Assert.AreEqual(0, cart.GetItemCount());
    }

    [TestMethod] //Un panier vide a un total égal à 0.
    public void WhenEmptyCart_ThenTotalIs0()
    {
        var cart = new ShoppingCart();
        Assert.AreEqual(0m, cart.GetTotal());
    }

    [TestMethod] //Appliquer une remise sur un panier vide déclenche une exception.
    public void WhenEmptyCart_ApplyDiscount_ThenException()
    {
        var cart = new ShoppingCart();
        Assert.Throws<InvalidOperationException>(() => cart.ApplyDiscount(10m));
    }
    #endregion

    // Étape 2 — Tests d’ajout (validation)
    #region

    [TestMethod] //Ajouter un article valide augmente le nombre d’articles.
    public void WhenAddItem_ValidItem_ThenIncreaseItemCount()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Lemon", 2.50m, 2);
        Assert.AreEqual(1, cart.GetItemCount());
    }

    [TestMethod] //Ajouter un article avec nom invalide déclenche une exception.
    public void WhenAddItem_InvalidName_ThenException()
    {
        var cart = new ShoppingCart();
        Assert.Throws<ArgumentException>(() => cart.AddItem("   ", 1m, 1));
    }

    [TestMethod] //Ajouter un article avec prix ≤ 0 déclenche une exception.
    public void WhenAddItem_PriceLessOrEqual0_ThenException()
    {
        var cart = new ShoppingCart();

        Assert.Throws<ArgumentOutOfRangeException>(() => cart.AddItem("Pineapple", 0m, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => cart.AddItem("Pineapple", -1m, 1));
    }

    [TestMethod] //Ajouter un article avec quantité ≤ 0 déclenche une exception.
    public void WhenAddItem_QtyLessOrEqual0_Throws()
    {
        var cart = new ShoppingCart();

        Assert.Throws<ArgumentOutOfRangeException>(() => cart.AddItem("Apple", 1m, 0));
        Assert.Throws<ArgumentOutOfRangeException>(() => cart.AddItem("Apple", 1m, -2));
    }
    #endregion


    // Étape 3 — Tests de calcul
    #region 
    [TestMethod] //Un article → total = price × quantity.
    public void WhenAddItem_1Item_ThenTotalIsPriceTimesQty()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Kiwi", 2.00m, 3);

        Assert.AreEqual(6.00m, cart.GetTotal());
    }

    [TestMethod] //Plusieurs articles → total = somme correcte.
    public void WhenAddItem_MultipleItems_ThenTotalIsSumOfAllItems()
    {
        var cart = new ShoppingCart();

        cart.AddItem("Kaki", 2.00m, 3);   
        cart.AddItem("Banana", 1.50m, 2);    

        Assert.AreEqual(9.00m, cart.GetTotal());
    }

    #endregion

    // Étape 4 — Tests de remise
    #region 
        
    [TestMethod] // Appliquer 10% réduit correctement le total.
    public void WhenApplyDiscount_10Percent_ThenReducesTotal()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Apple", 10m, 1); 

        cart.ApplyDiscount(10m);

        Assert.AreEqual(9m, cart.GetTotal());
    }

    [TestMethod] // Appliquer 0% ne change rien.
    public void WhenApplyDiscount_0Percent_ThenTotalIntact()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Apple", 10m, 1);

        cart.ApplyDiscount(0m);

        Assert.AreEqual(10m, cart.GetTotal());
    }

    
    [TestMethod] // Appliquer 100% donne 0.
    public void WhenApplyDiscount_100Percent_ThenTotalEqualZero()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Apple", 10m, 1);

        cart.ApplyDiscount(100m);

        Assert.AreEqual(0m, cart.GetTotal());
    }

    [TestMethod] // Remise négative → exception.
    public void WhenApplyDiscount_NegativePercent_ThenException()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Apple", 10m, 1);

        Assert.Throws<ArgumentOutOfRangeException>(() => cart.ApplyDiscount(-1m));
    }

    [TestMethod]
    public void WhenApplyDiscount_MoreThan100_ThenException() // Remise > 100 → exception.
    {
        var cart = new ShoppingCart();
        cart.AddItem("Apple", 10m, 1);

        Assert.Throws<ArgumentOutOfRangeException>(() => cart.ApplyDiscount(101m));
    }

    [TestMethod] // Appliquer une remise deux fois → exception.
    public void WhenApplyDiscount_Twice_ThenException() 
    {
        var cart = new ShoppingCart();
        cart.AddItem("Apple", 10m, 1);

        cart.ApplyDiscount(10m);

        Assert.Throws<InvalidOperationException>(() => cart.ApplyDiscount(5m));
    }

    #endregion

    //Bonus 1
    [TestMethod]
    public void WhenAddItem_SameNameDifferentPrice_ThenExceptionAndCartIntact()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Apple", 1.0m, 1);

        Assert.Throws<InvalidOperationException>(() => cart.AddItem("Apple", 2.0m, 1));

        Assert.AreEqual(1, cart.GetItemCount());
        Assert.AreEqual(1.0m, cart.GetTotal());
    }

}


