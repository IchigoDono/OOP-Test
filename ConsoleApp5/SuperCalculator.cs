using ConsoleApp5.Interface;
using ConsoleApp5.Stategy;

namespace ConsoleApp5;

public class SuperCalculator
{
    private readonly Dictionary<string, ICalculationStrategy> _strategies;

    public SuperCalculator()
    {
        _strategies = new Dictionary<string, ICalculationStrategy>
        {
            { "one", new CalcOneStrategy() },
            { "two", new CalcTwoStrategy() }
        };
    }

    public string Calculate(string type, int num)
    {
        if (_strategies.TryGetValue(type, out var strategy))
        {
            return strategy.Calculate(num);
        }

        return ""; 
    }
}
