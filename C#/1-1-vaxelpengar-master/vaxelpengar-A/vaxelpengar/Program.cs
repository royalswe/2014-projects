using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaxelpengar
{
    class Program
    {
        static void Main(string[] args)
        {   
            //Deklarera olika variabler
            uint amount;
            uint total;
            uint change;
            double roundingOffAmount;
            double subtotal;

            //While sats för upprepande felförsök genom try/catch
            while(true)
            {
                try
                {
                    Console.Write("Ange totalsumma         :");
                    subtotal = double.Parse(Console.ReadLine());
                    //Om summan är mindre än 1 körs if satsen
                    if(subtotal < 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Totalsumman är för liten. Köpet kunde inte genomföras.");
                        Console.ResetColor();
                    }
                    else
                    {   //Avsluta while
                        break;
                    }
                }
                catch
                {   
                    //Felmeddelande för fel inmatning av summan
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nu gick något fel, försök igen.");
                    Console.ResetColor();
                }
            }
           //Öresavrundning utav totalen
           total = (uint)Math.Round(subtotal);
           roundingOffAmount = total - subtotal;

           //While sats för upprepande felförsök genom try/catch
           while(true)
           {
               try
               {
                   Console.Write("Ange erhållet belopp:   :");
                   amount = uint.Parse(Console.ReadLine());
                   //Om erhållen belopp är mindre än totalen körs if satsen
                   if (amount < total)
                   {
                       Console.BackgroundColor = ConsoleColor.Red;
                       Console.WriteLine("Det saknas {0:c}", (total - amount));
                       Console.ResetColor();
               
                   }
                   else
                   {    
                       break;
                   }
                }
                catch 
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nu gick något fel, försök igen.");
                    Console.ResetColor();
                }
               
           }
           //Belopp att få tillbaka
           change = amount - total;

            //Kvitto som skrivs ut
            Console.WriteLine("\nKVITTO\n------------------------------------------");
            Console.WriteLine("Totalt             :\t{0,10:c}", subtotal);
            Console.WriteLine("Öresavrundning     :\t{0,10:c}", roundingOffAmount);
            Console.WriteLine("Att betala         :\t{0,10:c}", total);
            Console.WriteLine("Kontant            :\t{0,10:c}", amount);
            Console.WriteLine("Tillbaka           :\t{0,10:c}", change);
            Console.WriteLine("------------------------------------------\n");

            //Beräkna vilka valörer kunden ska få tillbaks
            if (change >= 500)
            {
                Console.WriteLine(" 500-lappar\t: {0}st", (change / 500));
               change = change % 500;
            }

            if (change >= 100)
            {
                Console.WriteLine(" 100-lappar\t: {0}st", (change / 100));
                change = change % 100;
            }

            if (change >= 50)
            {
                Console.WriteLine("  50-lappar\t: {0}st", (change / 50));
                change = change % 50;
            }

            if (change >= 20)
            {
                Console.WriteLine("  20-lappar\t: {0}st", (change / 20));
                change = change % 20;
            }

            if (change >= 10)
            {
                Console.WriteLine("  10-kronor\t: {0}st", (change / 10));
                change = change % 10;
            }

            if (change >= 5)
            {
                Console.WriteLine("   5-kronor\t: {0}st", (change / 5));
                change = change % 5;
            }

            if (change >= 1)
            {
                Console.WriteLine("   1-kronor\t: {0}st", (change / 1));
                change = change % 1;
            }


        }
    }
}
