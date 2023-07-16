namespace VoxenSharp.Debuging;

public class Debug
{
    public static void Log(string message, ConsoleColor color)
    {
        var previousColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ForegroundColor = previousColor;
    }

    public static void LogError(string message)
    {
        Log(message, ConsoleColor.Red);
    }

    public static void LogSuccess(string message)
    {
        Log(message, ConsoleColor.Green);
    }
}