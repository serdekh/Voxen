using VoxenSharp.Debuging;

namespace VoxenSharp.Configuration;

public struct ConfigurationData
{
    public const string VoxenDllFilePath = "..\\..\\..\\..\\..\\x64\\Debug\\Voxen.dll";
}

public static class InitializedSystemsInfo
{
    private static int _initializedSystemsCount = 0;

    public static int Count => _initializedSystemsCount;

    private static void ModifyInitializedSystemCount(int value)
    {
        _initializedSystemsCount += value;

        if (_initializedSystemsCount < 0)
        {
            _initializedSystemsCount = 0;
        }

        if (_initializedSystemsCount == 0)
        {
            Debug.Log("Log: All the systems are finalized!", ConsoleColor.DarkGreen);
        }
    }

    public static void Increase() => ModifyInitializedSystemCount(1);
    public static void Decrease() => ModifyInitializedSystemCount(-1);
}