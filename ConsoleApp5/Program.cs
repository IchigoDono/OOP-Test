using ConsoleApp5.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp5;

public class Program
{
    public static void Main(string[] args)
    {
        var serviceProvider = Configuration.ConfigureServices();

        var calculator = serviceProvider.GetService<SuperCalculator>();

        Console.WriteLine(calculator.Calculate("one", 5));
        Console.WriteLine(calculator.Calculate("two", 10));
        Console.WriteLine(calculator.Calculate("unknown", 15));

        Console.ReadLine();
    }
}
