using System.Runtime.InteropServices;
using VoxenSharp.Common;

namespace VoxenSharp.Events;

public class Events
{
    [DllImport(ConfigurationData.VoxenDllFilePath)]
    private static extern int events_initialize();

    [DllImport(ConfigurationData.VoxenDllFilePath)]
    private static extern void events_poll();

    [DllImport(ConfigurationData.VoxenDllFilePath)]
    private static extern bool events_pressed(int key);

    [DllImport(ConfigurationData.VoxenDllFilePath)]
    private static extern bool events_just_pressed(int key);

    [DllImport(ConfigurationData.VoxenDllFilePath)]
    private static extern bool events_mouse_clicked(int button);

    [DllImport(ConfigurationData.VoxenDllFilePath)]
    private static extern bool events_mouse_just_clicked(int button);

    public static int Initialize() => events_initialize();
    public static void Poll() => events_poll();
    public static bool Pressed(int key) => events_pressed(key);
    public static bool JustPressed(int key) => events_just_pressed(key);
    public static bool MouseClicked(int button) => events_mouse_clicked(button);
    public static bool MouseJustClicked(int button) => events_mouse_just_clicked(button);
}

