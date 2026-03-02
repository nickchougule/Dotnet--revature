using Xunit;
using MyApp;

namespace MyApp.Tests;

public class CalculatorTests
{
    [Theory]
    [InlineData(2, 3, 5)]
    [InlineData(0, 0, 0)]
    [InlineData(-1, 1, 0)]
    public void Add_TwoNumbers_GivesCorrectResult(int x, int y, int expectedResult)
    {
        var calculator = new Calculator();
        var actualResult = calculator.Add(x, y);
        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [InlineData(5, 3, 2)]
    [InlineData(0, 0, 0)]
    [InlineData(-1, 1, -2)]
    public void Subtract_TwoNumbers_GivesCorrectResult(int x, int y, int expectedResult)
    {
        var calculator = new Calculator();
        var actualResult = calculator.Subtract(x, y);
        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [InlineData(2, 3, 6)]
    [InlineData(0, 5, 0)]
    [InlineData(-2, 3, -6)]
    public void Multiply_TwoNumbers_GivesCorrectResult(int x, int y, int expectedResult)
    {
        var calculator = new Calculator();
        var actualResult = calculator.Multiply(x, y);
        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [InlineData(10, 2, 5)]
    [InlineData(9, 3, 3)]
    [InlineData(-10, 2, -5)]
    public void Divide_TwoNumbers_GivesCorrectResult(int x, int y, double expectedResult)
    {
        var calculator = new Calculator();
        var actualResult = calculator.Divide(x, y);
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void Divide_ByZero_ThrowsException()
    {
        var calculator = new Calculator();
        Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
    }
}