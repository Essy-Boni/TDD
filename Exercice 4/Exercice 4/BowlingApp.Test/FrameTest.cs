using Moq;

namespace BowlingApp.Test;

[TestClass]
public class FrameTest
{

    [TestMethod] // Série standard : Le premier lancer d’une série doit augmenter le score de la série
    public void Roll_SimpleFrame_FirstRoll_CheckScore()
    {
        IGenerateur fakeGen = Mock.Of<IGenerateur>();
        Mock.Get(fakeGen)
            .Setup(g => g.RandomPin(It.IsAny<int>()))
            .Returns(4);

        var frame = new Frame(fakeGen, lastFrame: false);

        Assert.IsTrue(frame.MakeRoll()); // 1er tour => result 4
        Assert.AreEqual(4, frame.Score); // Score = +4
    }

    [TestMethod] // Série standard : Le second lancer d’une série doit augmenter le score de cette série
    public void Roll_SimpleFrame_SecondRoll_CheckScore()
    {
        IGenerateur fakeGen = Mock.Of<IGenerateur>();
        Mock.Get(fakeGen)
            .SetupSequence(g => g.RandomPin(It.IsAny<int>()))
            .Returns(4) // 1er tour => result 4
            .Returns(3); // 2eme tour => result 3

        var frame = new Frame(fakeGen, lastFrame: false);

        frame.MakeRoll();
        frame.MakeRoll();

        Assert.AreEqual(7, frame.Score);
    }

    [TestMethod] // Série standard : En cas de strike, il ne doit pas être possible de lancer de nouveau au cours de cette même série
    public void Roll_SimpleFrame_SecondRoll_FirstRollStrick_ReturnFalse()
    {
       
        IGenerateur fakeGen = Mock.Of<IGenerateur>();
        Mock.Get(fakeGen).Setup(g => g.RandomPin(It.IsAny<int>())).Returns(10);

        var frame = new Frame(fakeGen, lastFrame: false);

        Assert.IsTrue(frame.MakeRoll()); //1er tour : result = 10 (strike) 
        Assert.IsFalse(frame.MakeRoll()); // Lancer impossible
        Assert.AreEqual(10, frame.Score);
    }

    [TestMethod]
    public void Roll_SimpleFrame_MoreRolls_ReturnFalse() // Série standard : il ne doit pas être possible de lancer plus de 2 fois
    {
        IGenerateur fakeGen = Mock.Of<IGenerateur>();
        Mock.Get(fakeGen).SetupSequence(g => g.RandomPin(It.IsAny<int>()))
            .Returns(3) // 1er tour => result 3 
            .Returns(4); // 2eme tour => result 4 (score = 7, il reste 3 quilles)

        var frame = new Frame(fakeGen, lastFrame: false);

        Assert.IsTrue(frame.MakeRoll());
        Assert.IsTrue(frame.MakeRoll());
        Assert.IsFalse(frame.MakeRoll()); // Lancer impossible
    }

    [TestMethod] // Série Finale : En cas de strike, il doit être possible de lancer une nouvelle fois au cours d’une série
    public void Roll_LastFrame_SecondRoll_FirstRollStrick_ReturnTrue()
    {
        IGenerateur fakeGen = Mock.Of<IGenerateur>();
        Mock.Get(fakeGen).SetupSequence(g => g.RandomPin(It.IsAny<int>()))
            .Returns(10) // 1ère série = strike
            .Returns(3);

        var frame = new Frame(fakeGen, lastFrame: true);

        Assert.IsTrue(frame.MakeRoll());
        Assert.IsTrue(frame.MakeRoll()); // 2ème lancé possible
    }

    [TestMethod] // Série Finale : En cas de strike puis de lancer, le score est censé augmenter en accord avec le résultat du lancer
    public void Roll_LastFrame_SecondRoll_FirstRollStrick_CheckScore()
    {
        IGenerateur fakeGen = Mock.Of<IGenerateur>();
        Mock.Get(fakeGen).SetupSequence(g => g.RandomPin(It.IsAny<int>()))
            .Returns(10)  // 1ère serie = strike
            .Returns(3); // 2ème serie, score = 3

        var frame = new Frame(fakeGen, lastFrame: true);

        frame.MakeRoll();
        frame.MakeRoll();

        Assert.AreEqual(13, frame.Score); // Résultat final = 10 + 3 
    }

    [TestMethod] // Série finale : En cas de strike puis d’un lancer, il doit être possible de lancer une nouvelle fois
    public void Roll_LastFrame_ThirdRoll_FirstRollStrick_ReturnTrue()
    {
        IGenerateur fakeGen = Mock.Of<IGenerateur>();
        Mock.Get(fakeGen).SetupSequence(g => g.RandomPin(It.IsAny<int>()))
            .Returns(10) // 1er lancé = strike 
            .Returns(3) // 2eme lancé 
            .Returns(5);

        var frame = new Frame(fakeGen, lastFrame: true);

        Assert.IsTrue(frame.MakeRoll());
        Assert.IsTrue(frame.MakeRoll());
        Assert.IsTrue(frame.MakeRoll()); // 3ème lancé autorisé
    }

    [TestMethod] // Série finale : En cas de spare puis de lancer, le score est censé augmenter en accord avec le résultat du lancer
    public void Roll_LastFrame_ThirdRoll_Spare_CheckScore()
    {
        IGenerateur fakeGen = Mock.Of<IGenerateur>();
        Mock.Get(fakeGen).SetupSequence(g => g.RandomPin(It.IsAny<int>()))
            .Returns(4)
            .Returns(6) 
            .Returns(5); 
        
        var frame = new Frame(fakeGen, lastFrame: true);

        frame.MakeRoll(); // 4
        frame.MakeRoll(); // 6 => score = spare (10)
        frame.MakeRoll(); // 3è lancé => score 5

        Assert.AreEqual(15, frame.Score); // resultat = 4 + 6 + 5
    }

    [TestMethod] // Série finale : En cas de strike puis de lancer, le score est censé augmenter en accord avec le résultat
    public void Roll_LastFrame_ThirdRoll_FirstRollStrick_CheckScore()
    {
        IGenerateur fakeGen = Mock.Of<IGenerateur>();
        Mock.Get(fakeGen).SetupSequence(g => g.RandomPin(It.IsAny<int>()))
            .Returns(10)
            .Returns(3)
            .Returns(5);

        var frame = new Frame(fakeGen, lastFrame: true);

        frame.MakeRoll();
        frame.MakeRoll();
        frame.MakeRoll();

        Assert.AreEqual(18, frame.Score); // resultat = 10 + 3 + 5
    }

    [TestMethod] // Série finale :  En cas de spare, il doit être possible de lancer une nouvelle fois au cours d’une série
    public void Roll_LastFrame_ThirdRoll_Spare_ReturnTrue()
    {
        IGenerateur fakeGen = Mock.Of<IGenerateur>();
        Mock.Get(fakeGen).SetupSequence(g => g.RandomPin(It.IsAny<int>()))
            .Returns(4) // 4
            .Returns(6) // 6 => spare
            .Returns(5);

        var frame = new Frame(fakeGen, lastFrame: true);

        Assert.IsTrue(frame.MakeRoll());
        Assert.IsTrue(frame.MakeRoll());
        Assert.IsTrue(frame.MakeRoll()); // 3ème lancé autorisé
    }

    [TestMethod] // Série finale :  En cas de lancers standards, il ne doit pas être possible de lancer plus de 4 fois
    public void Roll_LastFrame_FourthRoll_ReturnFalse()
    {
        IGenerateur fakeGen = Mock.Of<IGenerateur>();
        Mock.Get(fakeGen)
            .SetupSequence(g => g.RandomPin(It.IsAny<int>()))
            .Returns(10)
            .Returns(3)
            .Returns(5);

        var frame = new Frame(fakeGen, lastFrame: true);

        frame.MakeRoll(); // 1er lancé
        frame.MakeRoll(); // 2e lancé
        frame.MakeRoll();// 3e lancé

        Assert.IsFalse(frame.MakeRoll()); // 4e non autorisé
    }

}


