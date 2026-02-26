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
}
