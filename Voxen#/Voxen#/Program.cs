using VoxenSharp.Events;
using VoxenSharp.Window;

class Program
{
    static void Main(string[] args)
    {
        if (Window.Initialize(1600, 900, "title") == 1)
        {
            Console.WriteLine("Failed to open the window");
            return;
        }  

        if (Events.Initialize() == 1)
        {
            Console.WriteLine("Failed to initialize libs");
            return;
        }

        while (!Window.ShouldBeClosed())
        {
            Events.Poll();

            if (Events.JustPressed(256))
            {
                Window.SetShouldBeClosed(true);
            }

            if (Events.MouseJustClicked(0))
            {
                Console.WriteLine("Click!");
            }

            Window.SwapBuffers();
        }

        Window.Terminate();
    }
}