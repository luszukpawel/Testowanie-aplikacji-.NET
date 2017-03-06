using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Tile
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    class Program
    {
      

        static void Main(string[] args)
        {
            for (int k = 5; k >= 0; k--)
            {
              Console.WriteLine("xd " + k);

            }
           
            Console.ReadKey();
        }
    }
}
