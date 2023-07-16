using VoxenSharp.Enums;

namespace VoxenSharp.Interfaces;

public interface ISystem : IDisposable
{
    SystemState State { get; }
    bool FailedToInitialize { get; }
}