using ConsoleApp5;
using ConsoleApp5.Interface;
using Moq;

namespace TestProject1;

public class SuperCalculatorTests
{
    [Fact]
    public void Calculate_ShouldReturnCorrectResult_ForKnownStrategy()
    {
        var mockStrategy = new Mock<ICalculationStrategy>();
        mockStrategy.Setup(s => s.Calculate(10)).Returns("Mocked Result: 11");

        var strategies = new Dictionary<string, ICalculationStrategy>
        {
            { "testkey", mockStrategy.Object }
        };

        var calculator = new SuperCalculator(strategies);

        var result = calculator.Calculate("testkey", 10);

        Assert.Equal("Mocked Result: 11", result);
        mockStrategy.Verify(s => s.Calculate(10), Times.Once);
    }

    [Fact]
    public void Calculate_ShouldReturnEmptyString_ForUnknownStrategy()
    {
        var strategies = new Dictionary<string, ICalculationStrategy>();
        var calculator = new SuperCalculator(strategies);

        var result = calculator.Calculate("unknown", 5);

        Assert.Equal("", result);
    }

    [Fact]
    public void Calculate_ShouldUseCorrectStrategy_WhenMultipleStrategiesExist()
    {
        var mockStrategyOne = new Mock<ICalculationStrategy>();
        mockStrategyOne.Setup(s => s.Calculate(10)).Returns("Strategy One Result");

        var mockStrategyTwo = new Mock<ICalculationStrategy>();
        mockStrategyTwo.Setup(s => s.Calculate(20)).Returns("Strategy Two Result");

        var strategies = new Dictionary<string, ICalculationStrategy>
        {
            { "one", mockStrategyOne.Object },
            { "two", mockStrategyTwo.Object }
        };

        var calculator = new SuperCalculator(strategies);

        var resultOne = calculator.Calculate("one", 10);
        var resultTwo = calculator.Calculate("two", 20);

        Assert.Equal("Strategy One Result", resultOne);
        Assert.Equal("Strategy Two Result", resultTwo);

        mockStrategyOne.Verify(s => s.Calculate(10), Times.Once);
        mockStrategyTwo.Verify(s => s.Calculate(20), Times.Once);
    }
}