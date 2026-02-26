using static Exercices.RechercherVille;

namespace Exercices.Tests;

[TestClass]
public class RechercherVilleTests
{
    private static readonly List<string> DefaultVilles = new()
    {
        "Paris", "Budapest", "Skopje", "Rotterdam", "Valence", "Vancouver",
        "Amsterdam", "Vienne", "Sydney", "New York", "Londres", "Bangkok",
        "Hong Kong", "Dubaï", "Rome", "Istanbul"
    };

    private readonly List<string> _villes;

    public RechercherVilleTests()
    {
        _villes = DefaultVilles;
    }

    [TestMethod]
    public void WhenRechercherVille_lessthan2char_ThenNotFoundException()
    {
        var service = new RechercherVille();
        Assert.Throws<NotFoundException>(() => service.Rechercher("P"));
    }

    [TestMethod]
    public void WhenRechercherVille_Va_ThenValenceAndVancouver()
    {
        var service = new RechercherVille();
        var result = service.Rechercher("Va");

        CollectionAssert.AreEqual(new List<string> { "Valence", "Vancouver" }, result);
    }

    [TestMethod]
    public void WhenRechercherVille_Ape_ThenBudapest()
    {
        var service = new RechercherVille();
        var result = service.Rechercher("ape");

        CollectionAssert.AreEqual(new List<string> { "Budapest" }, result);
    }

    [TestMethod]
    public void WhenRechercherVille_Asterisk_ThenReturnsAll()
    {
        var service = new RechercherVille();
        var result = service.Rechercher("*");

        CollectionAssert.AreEqual(new List<string>
    {
        "Paris", "Budapest", "Skopje", "Rotterdam", "Valence", "Vancouver",
        "Amsterdam", "Vienne", "Sydney", "New York", "Londres", "Bangkok",
        "Hong Kong", "Dubaï", "Rome", "Istanbul"
    }, result);
    }

}
