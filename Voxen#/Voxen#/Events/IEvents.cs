using System;
using System.Collections.Generic;
using VoxenSharp.Interfaces;

namespace VoxenSharp.Events;

public interface IEvents : ISystem
{
    int Initialize();
    void Poll();
    bool Pressed(int key);
    bool JustPressed(int key);
    bool MouseClicked(int button);
    bool MouseJustClicked(int button);
}