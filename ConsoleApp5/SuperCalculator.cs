using ConsoleApp5.Interface;
using System.Reflection;

namespace ConsoleApp5;

public class SuperCalculator
{
    private readonly Dictionary<string, ICalculationStrategy> _strategies;

    public SuperCalculator()
    {
        _strategies = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(ICalculationStrategy).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
            .Select(t =>
            {
                var attr = t.GetCustomAttribute<StrategyKeyAttribute>();
                var key = attr?.Key ?? t.Name.ToLower(); 
                var instance = (ICalculationStrategy)Activator.CreateInstance(t)!;
                return (key, instance);
            })
            .ToDictionary(x => x.key, x => x.instance);
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
