using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geometriska_figurer
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            //Shape shapeChoice;
            
            do
            {
                    Console.Clear();  // Rensa konsoll fönstret
                    ViewMenu();
                    Console.Write("Ange menyval (0-2): ");
                    // Skriv in ett värde och kollar om det är en int samt värdet är lika med 0
                    if (int.TryParse(Console.ReadLine(), out choice) && choice == 0)
                    {
                        return;
                    }
                    else if (choice == 1 || choice == 2)
                    {
                        //Hämta metoden CreateShape och ge parametern värdet som choice har
                        //shapeChoice = CreateShape((ShapeType)(choice));
                        //ViewShapeDetail(shapeChoice);
                        ViewShapeDetail(CreateShape((ShapeType)(choice)));
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Fel! ge ett nummer mellam 0 - 2.");
                        Console.ResetColor();
                    }

            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Tryck på tangent för att fortsätta (Escape avslutar)");
            Console.ResetColor();

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);


            
        }
        private static Shape CreateShape(ShapeType shapeType)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("========================================");
            Console.WriteLine("={0,25}             =", shapeType);
            Console.WriteLine("========================================\n");
            Console.ResetColor();
            
            // Deklarera samt skriver in de olikas värden
            double length = ReadDoubleGreaterThanZero("Ange längden: ");
            double width = ReadDoubleGreaterThanZero("Ange Bredden: ");

            Console.WriteLine();

            // Val av form 
            switch (shapeType)
            {
                case ShapeType.Ellipse:
                    return new Ellipse(length, width);
                case ShapeType.Rectangle:
                    return new Rectangle(length, width);
                default:
                    throw new ApplicationException();
            }
            
        }
        private static double ReadDoubleGreaterThanZero(string prompt)
        {
            double value;

            Console.Write(prompt);

            while (true)
	        {
                     // Skriv in ett värde och kollar om det är en double samt värdet är högre än 0
                    if (double.TryParse(Console.ReadLine(), out value) && value > 0)
                    {
                        return value;
                    }

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("FEL! Ange ett flyttal större än 0");
                    Console.ResetColor();
	        }

        }
        private static void ViewMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("========================================");
            Console.WriteLine("=                                      =");
            Console.WriteLine("=          Geometriska figurer         =");
            Console.WriteLine("=                                      =");
            Console.WriteLine("========================================");
            Console.ResetColor();

            Console.WriteLine("\n0. Avsluta.\n\n1. Ellips\n\n2. Rektangel.\n");


        }
        private static void ViewShapeDetail(Shape shape)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("========================================");
            Console.WriteLine("=                Detaljer              =");
            Console.WriteLine("========================================");
            Console.ResetColor();

            Console.Write(shape.ToString());
            Console.WriteLine();
        }
    }
}
