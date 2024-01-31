using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var display = new GraphicsDisplay();
            display.Run();
        }
    }
}
