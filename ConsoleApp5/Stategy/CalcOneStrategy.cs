using ConsoleApp5.Interface;

namespace ConsoleApp5.Stategy;

[StrategyKey("one")]
public class CalcOneStrategy : ICalculationStrategy
{
    public string Calculate(int num)
    {
        Console.WriteLine("CalcOne executing!");
        var result = num + 1;
        return $"Result is: {result}";
    }
}
