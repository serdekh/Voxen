using VoxenSharp.Common;
using System.Runtime.InteropServices;

namespace VoxenSharp.Window;

public enum WindowState
{
    Success,
    Error
}

public class Window
{
    [DllImport(ConfigurationData.VoxenDllFilePath)]
    private static extern int window_api_initialize(int width, int height, string title);

    [DllImport(ConfigurationData.VoxenDllFilePath)]
    private static extern bool window_api_should_close();

    [DllImport(ConfigurationData.VoxenDllFilePath)]
    private static extern void window_api_swap_buffers();

    [DllImport(ConfigurationData.VoxenDllFilePath)]
    private static extern void window_api_terminate();

    [DllImport(ConfigurationData.VoxenDllFilePath)]
    private static extern void window_api_set_should_be_closed(bool value);

    private int _state = 0;

    public WindowState State => (WindowState)_state;

    public Window(int width, int height, string title)
    {
        _state = window_api_initialize(width, height, title);
    }

    ~Window()
    {
        Terminate();
    }

    public bool ShouldBeClosed() => window_api_should_close();

    public void SwapBuffers() => window_api_swap_buffers();

    public void SetShouldBeClosed(bool value) => window_api_set_should_be_closed(value);

    public void Terminate() => window_api_terminate();
}

