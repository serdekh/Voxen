using System.Runtime.InteropServices;

namespace VoxenSharp
{
    public class VoxenSharpIncluderTest
    {
        [DllImport("..\\..\\..\\..\\..\\x64\\Debug\\Voxen.dll")]
        private static extern void print_hello();

        public static void PrintHello() => print_hello();
    }
}
