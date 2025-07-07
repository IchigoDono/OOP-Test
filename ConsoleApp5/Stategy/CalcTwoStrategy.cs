using ConsoleApp5.Interface;

namespace ConsoleApp5.Stategy;

public class CalcTwoStrategy : ICalculationStrategy
{
    public string Calculate(int num)
    {
        Console.WriteLine("CalcTwo executing!");
        var result = num + 2;
        return $"Result is: {result}";
    }
}
