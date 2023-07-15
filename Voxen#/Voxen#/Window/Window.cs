using VoxenSharp.Common;
using System.Runtime.InteropServices;

namespace VoxenSharp.Window;

public class Window
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

    public static bool ShouldBeClosed() => window_should_close();

    public static void SwapBuffers() => window_swap_buffers();

    public static void SetShouldBeClosed(bool value) => window_set_should_be_closed(value);

    public static void Terminate() => window_terminate();

    public static int Initialize(int width, int height, string title) => window_initialize(width, height, title);
}