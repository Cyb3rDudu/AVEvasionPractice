using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _07_FlSAlloc
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern UInt32 FlsAlloc(IntPtr lpCallback);
        static void Main(string[] args)
        {
            UInt32 result = FlsAlloc(IntPtr.Zero);
            if (result != 0xFFFFFFFF)
            {
                runner();
            }
            return;
        }
        static void runner()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
