namespace BowlingApp.Test;

[TestClass]
public class FrameTest
{



    [TestMethod] // Série standard : Le premier lancer d’une série doit augmenter le score de la série
    public void Roll_SimpleFrame_FirstRoll_CheckScore()
    {
        var gen = new GenerateurMock(4);
        var frame = new Frame(gen, false);

        var result = frame.MakeRoll(); 

        Assert.IsTrue(result); // 1er tour => result 4
        Assert.AreEqual(4, frame.Score); // Score = +4
    }

    [TestMethod] // Série standard : Le second lancer d’une série doit augmenter le score de cette série
    public void Roll_SimpleFrame_SecondRoll_CheckScore()
    {
        var gen = new GenerateurMock(4, 3);
        var frame = new Frame(gen, false);

        frame.MakeRoll(); // 1er tour => result 4
        frame.MakeRoll(); // 2eme tour => result 3

        Assert.AreEqual(7, frame.Score); // Score = 4 + 3 
    }

    [TestMethod] // Série standard : En cas de strike, il ne doit pas être possible de lancer de nouveau au cours de cette même série
    public void Roll_SimpleFrame_SecondRoll_FirstRollStrick_ReturnFalse()
    {
        var gen = new GenerateurMock(10);
        var frame = new Frame(gen, false);

        Assert.IsTrue(frame.MakeRoll()); //1er tour : result = 10 (strike) 
        Assert.IsFalse(frame.MakeRoll()); // Lancer impossible
    }

    [TestMethod]
    public void Roll_SimpleFrame_MoreRolls_ReturnFalse() // Série standard : il ne doit pas être possible de lancer plus de 2 fois
    {
        var gen = new GenerateurMock(3, 4);
        var frame = new Frame(gen, false);

        Assert.IsTrue(frame.MakeRoll()); // 1er tour => result 3 
        Assert.IsTrue(frame.MakeRoll()); // 2eme tour => result 4 (score = 7, il reste 3 quilles)
        Assert.IsFalse(frame.MakeRoll()); // Lancer impossible

    }

    [TestMethod] // Série Finale : En cas de strike, il doit être possible de lancer une nouvelle fois au cours d’une série
    public void Roll_LastFrame_SecondRoll_FirstRollStrick_ReturnTrue()
    {
        var gen = new GenerateurMock(10, 3);
        var frame = new Frame(gen, true);

        Assert.IsTrue(frame.MakeRoll()); // 1ère série = strike
        Assert.IsTrue(frame.MakeRoll()); // 2ème lancé possible
    }

    [TestMethod] // Série Finale : En cas de strike puis de lancer, le score est censé augmenter en accord avec le résultat du lancer
    public void Roll_LastFrame_SecondRoll_FirstRollStrick_CheckScore()
    {
        var gen = new GenerateurMock(10, 3);
        var frame = new Frame(gen, lastFrame: true);

        frame.MakeRoll(); // 1ère serie = strike
        frame.MakeRoll(); // 2ème serie, score = 3

        Assert.AreEqual(13, frame.Score); // Résultat final = 10 + 3 
    }

    [TestMethod] // Série finale : En cas de strike puis d’un lancer, il doit être possible de lancer une nouvelle fois
    public void Roll_LastFrame_ThirdRoll_FirstRollStrick_ReturnTrue()
    {
        var gen = new GenerateurMock(10, 3, 5);
        var frame = new Frame(gen, true);

        frame.MakeRoll(); // 1er lancé = strike 
        frame.MakeRoll(); // 2eme lancé 

        Assert.IsTrue(frame.MakeRoll()); // 3ème lancé autorisé
    }

    [TestMethod] // Série finale : En cas de spare puis de lancer, le score est censé augmenter en accord avec le résultat du lancer
    public void Roll_LastFrame_ThirdRoll_Spare_CheckScore()
    {
        var gen = new GenerateurMock(4, 6, 5); 
        var frame = new Frame(gen, lastFrame: true);

        frame.MakeRoll(); // 4
        frame.MakeRoll(); // 6 => score = spare (10)
        frame.MakeRoll(); // 3è lancé => score 5

        Assert.AreEqual(15, frame.Score); // resultat = 4 + 6 + 5
    }

    [TestMethod] // Série finale : En cas de strike puis de lancer, le score est censé augmenter en accord avec le résultat
    public void Roll_LastFrame_ThirdRoll_FirstRollStrick_CheckScore()
    {
        var gen = new GenerateurMock(10, 3, 5);
        var frame = new Frame(gen, lastFrame: true);

        frame.MakeRoll(); // Strike
        frame.MakeRoll(); // 3
        frame.MakeRoll(); // 5

        Assert.AreEqual(18, frame.Score); // resultat = 10 + 3 + 5
    }

    [TestMethod] // Série finale :  En cas de spare, il doit être possible de lancer une nouvelle fois au cours d’une série
    public void Roll_LastFrame_ThirdRoll_Spare_ReturnTrue()
    {
        var gen = new GenerateurMock(4, 6, 5); 
        var frame = new Frame(gen, lastFrame: true);

        Assert.IsTrue(frame.MakeRoll()); // 4
        Assert.IsTrue(frame.MakeRoll()); // 6 => spare
        Assert.IsTrue(frame.MakeRoll()); // 3ème lancé autorisé
    }

    [TestMethod] // Série finale :  En cas de lancers standards, il ne doit pas être possible de lancer plus de 4 fois
    public void Roll_LastFrame_FourthRoll_ReturnFalse()
    {
        var gen = new GenerateurMock(10, 3, 5);
        var frame = new Frame(gen, true);

        frame.MakeRoll(); // 1er lancé
        frame.MakeRoll(); // 2e lancé
        frame.MakeRoll();// 3e lancé

        Assert.IsFalse(frame.MakeRoll()); // 4e non autorisé
    }

}
