using VoxenSharp.Interfaces;

namespace VoxenSharp.Window;

public interface IWindow : ISystem
{
    void Terminate();
    void SwapBuffers();
    bool ShouldBeClosed();
    bool ShouldNotBeClosed();
    void SetShouldBeClosed(bool value);
    int Initialize(int width, int height, string title);
}