using static Exercices.RechercherVille;

namespace Exercices.Tests;

[TestClass]
public class RechercherVilleTests
{
    [TestMethod]
    public void WhenRechercherVille_lessthan2char_ThenNotFoundException()
    {
        var service = new RechercherVille();
        service.Rechercher("P");
    }

    [TestMethod]
    public void WhenRechercherVille_Va_ThenValenceAndVancouver()
    {
        var service = new RechercherVille();
        var result = service.Rechercher("Va");

        CollectionAssert.AreEqual(new List<string> { "Valence", "Vancouver" }, result);
    }

}
