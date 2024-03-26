
namespace Common.Core.Logger;

public class Logger : ILogger
{
    public void Error(Type type, string message)
    {
        Console.WriteLine($"Inside-{type.Name}: {message}");
    }

    public void Info(Type type, string message)
    {
        Console.WriteLine($"Inside-{type.Name}: {message}");
    }

    public void Warn(Type type, string message)
    {
        Console.WriteLine($"Inside-{type.Name}: {message}");
    }
}
