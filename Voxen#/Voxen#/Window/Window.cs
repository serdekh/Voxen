using VoxenSharp.Enums;
using VoxenSharp.Debuging;
using VoxenSharp.Configuration;
using System.Runtime.InteropServices;

namespace VoxenSharp.Window;

public class Window : IWindow
{
    [DllImport(ConfigurationData.VoxenDllFilePath)]
    private static extern int window_initialize(int width, int height, string title);

    [DllImport(ConfigurationData.VoxenDllFilePath)]
    private static extern bool window_should_close();

    [DllImport(ConfigurationData.VoxenDllFilePath)]
    private static extern void window_swap_buffers();

    [DllImport(ConfigurationData.VoxenDllFilePath)]
    private static extern void window_terminate();

    [DllImport(ConfigurationData.VoxenDllFilePath)]
    private static extern void window_set_should_be_closed(bool value);

    private int _state = 0;

    public int Width { get; private set; }
    public int Height { get; private set; }
    public string? Title { get; private set; }

    public SystemState State => (SystemState)_state;

    public bool FailedToInitialize => _state == 1;

    public Window(int width, int height, string title)
    {
        Title = title;
        Width = width; 
        Height = height;

        _state = Initialize(width, height, title);

        if (_state == 1)
        {
            Debug.LogError($"System:Window: unsuccessful \"{Title}\" window initialization");
            Debug.Log("Hint: try to change size to be positive or name of your window", ConsoleColor.Yellow);
            return;
        }

        Debug.LogSuccess($"System:Window: successful \"{Title}\" window initialization");
        InitializedSystemsInfo.Increase();
    }

    public void Terminate() => window_terminate();
    public void SwapBuffers() => window_swap_buffers();
    public bool ShouldBeClosed() => window_should_close();
    public bool ShouldNotBeClosed() => !window_should_close();
    public void SetShouldBeClosed(bool value) => window_set_should_be_closed(value);
    public int Initialize(int width, int height, string title) => window_initialize(width, height, title);

    public void Dispose()
    {
        window_terminate();
        Debug.LogSuccess($"System:Window: successful \"{Title}\" finalization");
        InitializedSystemsInfo.Decrease();
    }
}