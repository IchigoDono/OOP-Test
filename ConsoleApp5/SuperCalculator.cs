using ConsoleApp5.Interface;

namespace ConsoleApp5;

public class SuperCalculator
{
    private readonly Dictionary<string, ICalculationStrategy> _strategies;

    public SuperCalculator(Dictionary<string, ICalculationStrategy> strategies)
    {
        _strategies = strategies;
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
