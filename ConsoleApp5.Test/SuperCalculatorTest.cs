using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConsoleApp5.Test;

public class SuperCalculatorTests
{
    [Fact]
    public void Calculate_ShouldReturnCorrectResult_ForKnownStrategy()
    {
        // Arrange
        var mockStrategy = new Mock<ICalculationStrategy>();
        // Устанавливаем поведение мока: когда Calculate(10) вызывается, вернуть "Mocked Result: 11"
        mockStrategy.Setup(s => s.Calculate(10)).Returns("Mocked Result: 11");

        // Создаем словарь с нашей мокированной стратегией
        var strategies = new Dictionary<string, ICalculationStrategy>
        {
            { "testkey", mockStrategy.Object }
        };

        // Создаем SuperCalculator, передавая ему мокированный словарь
        var calculator = new SuperCalculator(strategies);

        // Act
        var result = calculator.Calculate("testkey", 10);

        // Assert
        Assert.Equal("Mocked Result: 11", result);
        // Проверяем, что метод Calculate на моке был вызван ровно один раз с аргументом 10
        mockStrategy.Verify(s => s.Calculate(10), Times.Once);
    }

    [Fact]
    public void Calculate_ShouldReturnEmptyString_ForUnknownStrategy()
    {
        // Arrange
        // Создаем пустой словарь стратегий
        var strategies = new Dictionary<string, ICalculationStrategy>();
        var calculator = new SuperCalculator(strategies);

        // Act
        var result = calculator.Calculate("unknown", 5);

        // Assert
        Assert.Equal("", result);
    }

    [Fact]
    public void Calculate_ShouldUseCorrectStrategy_WhenMultipleStrategiesExist()
    {
        // Arrange
        var mockStrategyOne = new Mock<ICalculationStrategy>();
        mockStrategyOne.Setup(s => s.Calculate(10)).Returns("Strategy One Result");

        var mockStrategyTwo = new Mock<ICalculationStrategy>();
        mockStrategyTwo.Setup(s => s.Calculate(20)).Returns("Strategy Two Result");

        // Создаем словарь с несколькими мокированными стратегиями
        var strategies = new Dictionary<ICalculationStrategy>
        {
            { "one", mockStrategyOne.Object },
            { "two", mockStrategyTwo.Object }
        };

        var calculator = new SuperCalculator(strategies);

        // Act
        var resultOne = calculator.Calculate("one", 10);
        var resultTwo = calculator.Calculate("two", 20);

        // Assert
        Assert.Equal("Strategy One Result", resultOne);
        Assert.Equal("Strategy Two Result", resultTwo);

        // Проверяем, что каждый мок был вызван соответствующим образом
        mockStrategyOne.Verify(s => s.Calculate(10), Times.Once);
        mockStrategyTwo.Verify(s => s.Calculate(20), Times.Once);
    }

    [Fact]
    public void Constructor_ShouldThrowArgumentNullException_WhenStrategiesIsNull()
    {
        // Arrange, Act & Assert
        // Проверяем, что конструктор выбрасывает ArgumentNullException, если передан null
        Assert.Throws<ArgumentNullException>(() => new SuperCalculator(null));
    }
}