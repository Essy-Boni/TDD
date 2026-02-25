namespace DemoBasesTDD.Tests;


[TestClass]
public class CalculTest
{
    [TestMethod]
    public void WhenAddition_42_7_Then_49()
    {
        // Arrange
        var calcul = new Calcul();

        // Act
        var result = calcul.Addition(42, 7);

        // Assert
        Assert.AreEqual(49, result);
    }

    [TestMethod]
    public void WhenDivision_30_10_Then_3()
    {
        // Arrange
        var calcul = new Calcul();

        // Act
        var result = calcul.Division(30, 10);

        // Assert
        Assert.AreEqual(3, result);
    }

    [TestMethod]
    public void WhenDivision_1_0_Then_DivideByZeroException()
    {
        // Arrange
        var calcul = new Calcul();

        // Act & Assert
        //Assert.ThrowsExactly<DivideByZeroException>(() => calcul.Division(1, 0));

        try
        {
           calcul.Division(1,0);
        }
        catch (Exception ex)
        {
            Assert.AreEqual(typeof(DivideByZeroException), ex.GetType());
        }
    }
}
