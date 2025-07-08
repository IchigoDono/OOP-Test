using ConsoleApp5.Interface;

namespace ConsoleApp5.Stategy;

[StrategyKey("two")]
public class CalcTwoStrategy : ICalculationStrategy
{
    public string Calculate(int num)
    {
        Console.WriteLine("CalcTwo executing!");
        var result = num + 2;
        return $"Result is: {result}";
    }
}
