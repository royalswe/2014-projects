using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_1_vaxelpengar_B
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalSum;
            double roundingOffAmount;
            uint sumToPay;
            uint recievedAmount;
            uint change;

            do
            {
                totalSum = ReadPositiveDouble("Ange totalsumma : ");

                //avrunda till heltal
                sumToPay = (uint)Math.Round(totalSum);
                roundingOffAmount = sumToPay - totalSum;

                recievedAmount = ReadUint("Ange erhållet belopp: ", sumToPay);

                change = recievedAmount - sumToPay;

                //Kvitto som skrivs ut
                Console.WriteLine("\nKVITTO\n------------------------------------");
                Console.WriteLine("Totalt             :\t{0,10:c}", totalSum);
                Console.WriteLine("Öresavrundning     :\t{0,10:c}", roundingOffAmount);
                Console.WriteLine("Att betala         :\t{0,10:c}", sumToPay);
                Console.WriteLine("Kontant            :\t{0,10:c}", recievedAmount);
                Console.WriteLine("Tillbaka           :\t{0,10:c}", change);
                Console.WriteLine("------------------------------------\n");

                //skriver ut valörer att få tillbaka
                SplitIntoDenominations(change);

                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nTryck tangent för ny beräkning - ESC avslutar");
                Console.ResetColor();
            // Vid esc avbryts loopen
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        public static double ReadPositiveDouble(string prompt)
        {         
            while (true)
            {
                try
                {
                    Console.Write(prompt);

                    string userInput = Console.ReadLine();
                    double input = double.Parse(userInput);
                    if(input >= 1)
                    {
                        return input;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nFEL! {0} kan inte tolkas som en giltlig summa pengar\n", userInput);
                        Console.ResetColor(); 
                    }
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nFEL! ogiltligt värde' kan inte tolkas som en giltlig summa pengar\n");
                    Console.ResetColor();
                }
            }

        }
        public static uint ReadUint(string prompt, uint minValue)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);

                    string userInput = Console.ReadLine();
                    uint input = uint.Parse(userInput);
                    if (input >= minValue)
                    {
                        return input;
                    }
                    else
                    {                    
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nFEL! {0} är för litet belopp\n", userInput);
                    Console.ResetColor();
                    }
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nFEL! ogiltligt värde' kan inte tolkas som en giltlig summa pengar\n");
                    Console.ResetColor();
                }
            }
        }
        public static void SplitIntoDenominations(uint change)
        {
            uint[] value = new uint[7] { 500, 100, 50, 20, 10, 5, 1 };

            foreach (uint values in value)
            {
                if (change >=  value)
                {
                    Console.WriteLine("{0,3}{1,-13}:{2}", value, value > 10 ? "-lappar" : "-kronor", change / value);

                    //switch (value)
                    //{
                    //    case 500:
                    //    case 100:
                    //    case 50:
                    //    case 20:
                    //        Console.WriteLine("{0,3}{1,-13}{2}{3}", value, "-lappar", ": ", (change / value));
                    //        break;
                    //    case 10:
                    //    case 5:
                    //    case 1:
                    //        Console.WriteLine("{0,3}{1,-13}{2}{3}", value, "-kronor", ": ", (change / value));
                    //        break;
                    //}
                }
                }
                //change = change % values;
                change %= values;
                
            }

        }

    }
}
