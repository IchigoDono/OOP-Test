using ConsoleApp5.Interface;

namespace ConsoleApp5.Stategy;

public class CalcOneStrategy : ICalculationStrategy
{
    public string Calculate(int num)
    {
        Console.WriteLine("CalcOne executing!");
        var result = num + 1;
        return $"Result is: {result}";
    }
}
