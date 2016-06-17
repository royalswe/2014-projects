using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godtycklig_lonerevision
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            //Deklarera variabeln som bestämmer hur många löner som ska utföras
            int salaries = 0;

            do
            {
                while (salaries < 2)
                {
                    //metoden ReadInt returnera värdet samt ser till att heltal skrivs in
                    salaries = ReadInt("Ange antal löner Att mata in: ");
                    if (salaries < 2)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Du måste mata in minst två löner för att göra en beräkning!");
                        Console.ResetColor();
                    }
                    else
                    {
                        break;
                    }
                }
                ProcessSalary(salaries);

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Tryck tangent för ny beräkning - Esc avslutar");
                Console.ResetColor();

                //Vid val av tangenten esc stängs programmet annars fortsätter programmet i loopen. // Lösningen googlades fram
                //ConsoleKeyInfo cki;
                //cki = Console.ReadKey(true);
                //if (cki.Key == ConsoleKey.Escape)
                //{
                //    return;
                //}
                ////Nollställer för att kunna skriva in antal löner igen.
                salaries = 0;
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }
        static void ProcessSalary(int count)
        {
            //Deklarera värderna
            int medianSalary;
            int totalSalary = 0;

            int[] salaries = new int[count];
            int[] sortedSalaries = new int[count];

            for (int i = 0; i < count; i++)
            {
                //Loopa igenom antal löner som hämtas från ReadInt
                salaries[i] = ReadInt(string.Format("Ange Löneräkning nummer {0}: ", i + 1));
                totalSalary += salaries[i];
                sortedSalaries[i] += salaries[i];
            }
            //Sortera SortedSalaries
            Array.Sort(sortedSalaries);

            //Beräkna medianen //Tack till http://www.dreamincode.net/forums/topic/150030-median-value/ för median beräkningen
            int m = sortedSalaries.Count() / 2;
            if (sortedSalaries.Count() % 2 == 0)
            {
                medianSalary = (sortedSalaries[m - 1] + sortedSalaries[m]) / 2;
            }
            else
            {
                medianSalary = sortedSalaries[m];
            }
            // Skriver ut värderna
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Medianlön:     {0:c0}", medianSalary);
            Console.WriteLine("Medellön:      {0:c0}", salaries.Average());
            Console.WriteLine("Lönespridning: {0:c0}", salaries.Max() - salaries.Min());
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine();

            //Skriver ut alla löner
            for (int i = 1; i <= count; i++)
            {
                Console.Write("{0, 10:c0}", salaries[i - 1]);
                //Var tredje värde gör en radbrytning
                if (i % 3 == 0)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }

        static int ReadInt(string prompt)
        {
            int number;
            string input = null;

            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    input = Console.ReadLine();
                    number = int.Parse(input);

                    if (number < 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Du måste ge ett högre tal än 1!");
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("FEL! {0} kan inte tolkas som ett heltal!", input);
                }
                Console.ResetColor();
            }

            return number;
        }
    }
}
