namespace Exercices.Tests;

[TestClass]
public class GradingCalculatorTests
{

    [TestMethod]
    public void GetGrade_Score95_Attendance90_Returns_A()
    {
        // Arrange
        var calculator = new GradingCalculator
        {
            Score = 95,
            AttendancePercentage = 90
        };

        // Act
        var result = calculator.GetGrade();

        // Assert
        Assert.AreEqual('A', result);
    }

    [TestMethod]
    public void GetGrade_Score85_Attendance90_Returns_B()
    {
        var calculator = new GradingCalculator { Score = 85, AttendancePercentage = 90 };
        var result = calculator.GetGrade();
        Assert.AreEqual('B', result);
    }

    [TestMethod]
    public void GetGrade_Score65_Attendance90_Returns_C()
    {
        var calculator = new GradingCalculator { Score = 65, AttendancePercentage = 90 };
        var result = calculator.GetGrade();
        Assert.AreEqual('C', result);
    }

    [TestMethod]
    public void GetGrade_Score95_Attendance65_Returns_B()
    {
        var calculator = new GradingCalculator { Score = 95, AttendancePercentage = 65 };
        var result = calculator.GetGrade();
        Assert.AreEqual('B', result);
    }

    [TestMethod]
    public void GetGrade_Score95_Attendance55_Returns_F()
    {
        var calculator = new GradingCalculator { Score = 95, AttendancePercentage = 55 };
        var result = calculator.GetGrade();
        Assert.AreEqual('F', result);
    }

    [TestMethod]
    public void GetGrade_Score65_Attendance55_Returns_F()
    {
        var calculator = new GradingCalculator { Score = 65, AttendancePercentage = 55 };
        var result = calculator.GetGrade();
        Assert.AreEqual('F', result);
    }

    [TestMethod]
    public void GetGrade_Score50_Attendance90_Returns_F()
    {
        var calculator = new GradingCalculator { Score = 50, AttendancePercentage = 90 };
        var result = calculator.GetGrade();
        Assert.AreEqual('F', result);
    }
}