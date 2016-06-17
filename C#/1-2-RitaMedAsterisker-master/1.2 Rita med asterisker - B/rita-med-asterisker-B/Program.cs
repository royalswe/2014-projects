using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rita_med_asterisker_B
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                // Hämtar metoden RenderTriangel som skriver ut triangeln samt hämtar parametern ReadOddByte som ger antal asterisker i triangeln
                RenderTriangle(ReadOddByte());


                //vid esc avbryts loopen
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write("\nTryck tangent för att fortsätta - Esc avslutar");
                Console.WriteLine("\n");
                Console.ResetColor();
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }
        private static byte ReadOddByte()
        {
            while (true)
            {
                try
                {
                    Console.Write("Ange det udda antalet asterisker <max 79> i triangelns bas : ");

                    byte userInput = byte.Parse(Console.ReadLine());
                    if (userInput > 0 && userInput < 80 && userInput % 2 != 0)
                    {
                        return userInput;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("\nFEL! Det inmatade värdet är inte ett udda heltal mellan 1 och 79\n\n");
                        Console.ResetColor();
                    }
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("\nFEL! Det inmatade värdet är inte ett udda heltal\n\n");
                    Console.ResetColor();
                }
            }
        }
        private static void RenderTriangle(byte cols)
        {
            //for (int row = 1; row <= cols; row += 2)
            //{
            //    for (int spaces = 1; spaces < cols - row; spaces += 2)
            //    {
            //        Console.Write(" ");
            //    }
            //    for (int numberOfAsterisks = 1; numberOfAsterisks <= row; numberOfAsterisks++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();
            //}
            
            for (int rows = 0; rows <= (cols / 2); rows++)
            {
                for (int i = 0; i < ((cols / 2) - rows); i++)
                {
                    Console.Write(" ");
                }
                for (int numOfAsterisk = 1; numOfAsterisk < (2 * rows + 2); numOfAsterisk++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
