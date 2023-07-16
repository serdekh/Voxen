using VoxenSharp.Enums;
using VoxenSharp.Debuging;
using VoxenSharp.Configuration;
using System.Runtime.InteropServices;

namespace VoxenSharp.Events;

public class Events : IEvents
{
    [DllImport(ConfigurationData.VoxenDllFilePath)]
    private static extern int events_initialize();

    [DllImport(ConfigurationData.VoxenDllFilePath)]
    private static extern int events_finalize();

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

    private int _state = 0;

    public SystemState State => (SystemState)_state;

    public bool FailedToInitialize => _state == 1;

    public Events()
    {
        _state = events_initialize();

        if (_state == 1)
        {
            Debug.LogError("System:Events: unsuccessful initialization");
            return;
        }

        Debug.LogSuccess("System:Events: successful initialization");
        InitializedSystemsInfo.Increase();
    }

    public int Initialize() => events_initialize();
    public void Poll() => events_poll();
    public bool Pressed(int key) => events_pressed(key);
    public bool JustPressed(int key) => events_just_pressed(key);
    public bool MouseClicked(int button) => events_mouse_clicked(button);
    public bool MouseJustClicked(int button) => events_mouse_just_clicked(button);

    public void Dispose()
    {
        events_finalize();
        Debug.LogSuccess("System:Events: successful finalization");
        InitializedSystemsInfo.Decrease();
    }
}

