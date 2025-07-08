using ConsoleApp5.Interface;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ConsoleApp5.Configurations;

public class Configuration
{
    public static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(ICalculationStrategy).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
            .ToList()
            .ForEach(t => services.AddTransient(t));

        services.AddSingleton<SuperCalculator>(serviceProvider =>
        {
            var strategies = new Dictionary<string, ICalculationStrategy>();

            var strategyTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(ICalculationStrategy).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            foreach (var type in strategyTypes)
            {
                var attr = type.GetCustomAttribute<StrategyKeyAttribute>();
                var key = attr?.Key ?? type.Name.ToLower();

                var instance = (ICalculationStrategy)serviceProvider.GetService(type)!;
                strategies.Add(key, instance);
            }

            return new SuperCalculator(strategies);
        });

        return services.BuildServiceProvider();
    }
}
