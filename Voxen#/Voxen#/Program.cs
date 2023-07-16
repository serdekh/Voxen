using VoxenSharp.Events;
using VoxenSharp.Window;

class Program
{
    static void Main(string[] args)
    {
        using var events = new Events();
        using var window = new Window(1600, 900, "title");

        if (window.FailedToInitialize || events.FailedToInitialize)
        {
            return;
        }

        while (window.ShouldNotBeClosed())
        {
            events.Poll();

            if (events.JustPressed(256))
            {
                window.SetShouldBeClosed(true);
            }

            if (events.MouseJustClicked(0))
            {
                Console.WriteLine("Click!");
            }

            window.SwapBuffers();
        }
    }
}