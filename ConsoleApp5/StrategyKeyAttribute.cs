namespace ConsoleApp5;

public class StrategyKeyAttribute : Attribute
{
    public string Key { get; }

    public StrategyKeyAttribute(string key)
    {
        Key = key;
    }
}
