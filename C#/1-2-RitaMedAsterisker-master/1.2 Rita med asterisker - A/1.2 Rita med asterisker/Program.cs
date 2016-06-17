using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2_Rita_med_asterisker
{
    class Program
    {
        static void Main(string[] args)
        {
            //Nästlad loop som körs 25 ggr
            for (int row = 0; row < 25; row++)
            {
                //Värdet bli true varannan gång
                if(row % 2 == 1)
                {
                    Console.Write(" ");
                }
                //switch sats som betyder färg efter variabeln row's värde, Alltså var tredje
                switch(row % 3)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                }
                //Loop skriver ut "* " 39 ggr
                for (int col = 0; col < 39; col++)
                {
                    Console.Write("* ");
                }
                // Radbrytning
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
